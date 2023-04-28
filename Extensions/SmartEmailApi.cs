using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Formatters;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app.Extensions
{
    public class SmartEmailApi
    {

        private readonly RequestDelegate _next;
        private static readonly string username = "libor.svoboda@kliknetezde.cz";
        private static readonly string apiKey = "8kal3xijr06qun32nwwyubpm8n3xgad3k63nb6i6";
        private static readonly string smartEmailAuth = "Basic " + Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(username + ":" + apiKey));

        private const string SmartReview = "https://app.smartemailing.cz/api/v3/contactlists";
        private const string SmartData = "https://app.smartemailing.cz/api/v2";

        public SmartEmailApi(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            bool smartemailUsed = false;
            RestResponse response = new RestResponse();
            RestClient client = new RestClient();


            //call full contact list
            if (context.Request.Path.ToString().EndsWith("smartemail/getcontactlist"))
            {
                smartemailUsed = true;

                RestRequest request = new RestRequest(Method.GET);
                request.AddHeader("authorization", smartEmailAuth);
                request.AddHeader("content-type", "application/x-www-form-urlencoded");
                request.AddHeader("accept", "text/html,application/json");
                client = new RestClient(SmartReview);
                response = await client.ExecuteAsync(request);
            }


            // create or update contact
            if (context.Request.Path.ToString().EndsWith("smartemail/createnewcontact"))
            {
                smartemailUsed = true;
                JObject jsonData = JObject.Parse(new StreamReader(context.Request.Body).ReadToEnd());

                RestRequest request = new RestRequest(Method.POST) { RequestFormat = DataFormat.Xml };
                request = CreateNewContact(request, jsonData.Value<string>("email"));
                client = new RestClient(SmartData);
                response = await client.ExecuteAsync(request);
            }


            //ChangeContactList
            if (context.Request.Path.ToString().EndsWith("smartemail/changecontactlist"))
            {
                smartemailUsed = true;
                JObject jsonData = JObject.Parse(new StreamReader(context.Request.Body).ReadToEnd());

                RestRequest request = new RestRequest(Method.POST) { RequestFormat = DataFormat.Xml };
                request = ChangeContactList(request, jsonData.Value<string>("email"), jsonData.Value<int>("requestedContactListId"));
                client = new RestClient(SmartData);
                response = await client.ExecuteAsync(request);
            }




            //response part
            if (smartemailUsed)
            {
                try
                {
                    // context.Request.EnableRewind();
                    string jsonData = new StreamReader(context.Request.Body).ReadToEnd();

                    if (context.Request.Headers.First(p => p.Key.ToString() == "resultstatus").Value.ToString().ToLower() == "disallowed")
                    {
                        await context.Response.WriteAsync(response.Content);//.Wait(); 
                        AddJsonResponseHeader(context);
                    }
                    else
                    {
                        context.Response.ContentType = "text/plain";
                        await context.Response.WriteAsync("StatusOK");//.Wait();
                        context.Response.StatusCode = (int)response.StatusCode;
                    }
                }
                catch
                {
                    context.Response.ContentType = "text/plain";
                    context.Response.StatusCode = StatusCodes.Status200OK;
                }
            }
            //await _next.Invoke(context);
            await _next(context);//.Wait();


        }



        private HttpContext AddJsonResponseHeader(HttpContext context)
        {

            // context.Response.Headers.Add("access-control-allow-origin", "https://localhost:44322");
            context.Response.Headers.Add("access-control-allow-origin", "http://dev.aspifyhost.cz");
            context.Response.Headers.Add("x-content-type-options", "nosniff");
            context.Response.Headers.Add("vary", "Origin");
            context.Response.Headers.Add("pragma", "no-cache");
            context.Response.Headers.Add("content-type", "application/json; charset=UTF-8");
            context.Response.Headers.Add("cache-control", "no-cache, no-store, max-age=0, must-revalidate");
            context.Response.ContentType = "application/json; charset=UTF-8";
            context.Response.Headers.Add("content-encoding", "gzip");
            context.Response.Headers.Add("x-xss-protection", "0");
            //context.Response.Headers.Add("x-xss-protection", "1; mode=block");
            context.Response.Headers.Add("x-frame-options", "SAMEORIGIN");
            return context;
        }

        private string UnitoUtf(string strFrom)
        {
            byte[] bytSrc;
            byte[] bytDestination;
            string strTo = String.Empty;
            bytSrc = Encoding.Unicode.GetBytes(strFrom);
            bytDestination = Encoding.Convert(Encoding.Unicode, Encoding.ASCII, bytSrc);
            strTo = Encoding.ASCII.GetString(bytDestination);
            return strTo;
        }

        private RestRequest CreateNewContact(RestRequest context, string email)
        {
            //documetation https://docs.google.com/document/d/1QnSuvTFbsCbwk7rze0b-uLvyx2Wj9Oj0D4bKuwqm90w/pub#h.t8vgf2zohcn
            // <!-- unconfirmed | confirmed | unsubscribed | banned | removed -->
            Parameter createOrUpdateContact = new Parameter("application/xml", @"<?xml version='1.0' encoding='UTF-8'?><xmlrequest> 
                        <username>" + username + @"</username>
                        <usertoken>" + apiKey + @"</usertoken>
                        <requesttype>Contacts</requesttype>
                        <requestmethod>createupdate</requestmethod>
                        <details>
                            <emailaddress>" + email + @"</emailaddress>
                            <language>cs_CZ</language>
                            <contactliststatuses>
                                 <item>
                                     <id>2</id>
                                     <status>confirmed</status>
                                 </item>
                           </contactliststatuses>
                       </details>
                      </xmlrequest>", "application/xml", ParameterType.RequestBody);

            //<name>Libor</name>
            //          <surname>Svoboda</surname>
            //          <company>Pixel</company>
            //          <street>Long 123</street>
            //          <town>My Town</town>
            //          <postalcode>123456</postalcode>
            //          <phone>+420123456789</phone>
            context.Parameters.Add(createOrUpdateContact);
            return context;
        }


        private RestRequest ChangeContactList(RestRequest context, string email, int requestedContactListId)
        {
            string generateItemString = null;
            List<int> allGroups = new List<int> { 2, 3, 4, 5, 13, 14, 15, 16 };

            foreach (int element in allGroups)
            {
                if (element != requestedContactListId)
                {
                    generateItemString += "<item><id>" + element.ToString() + "</id><status>removed</status></item>";
                }
                else
                {
                    generateItemString += "<item><id>" + element.ToString() + "</id><status>confirmed</status></item>";
                }
            }

            Parameter updateContact = new Parameter("application/xml", @"<?xml version='1.0' encoding='UTF-8'?><xmlrequest> 
                <username>" + username + @"</username>
                <usertoken>" + apiKey + @"</usertoken>
                <requesttype>Contacts</requesttype>
                <requestmethod>createupdate</requestmethod>
                <details>
                    <emailaddress>" + email + @"</emailaddress>
                    <contactliststatuses>" + generateItemString + @"</contactliststatuses>
                </details>
                </xmlrequest>", "application/xml", ParameterType.RequestBody);
            context.Parameters.Add(updateContact);
            return context;
        }




    }


    public static class RestClientExtensions
    {
        public static async Task<RestResponse> ExecuteAsync(this RestClient client, RestRequest request)
        {
            TaskCompletionSource<IRestResponse> taskCompletion = new TaskCompletionSource<IRestResponse>();
            RestRequestAsyncHandle handle = client.ExecuteAsync(request, r => taskCompletion.SetResult(r));
            return (RestResponse)(await taskCompletion.Task);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class SmartEmailCallerExtensions
    {
        public static IApplicationBuilder UseSmartEmailMiddlewareExtensionApi(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<SmartEmailApi>();
        }
    }


}