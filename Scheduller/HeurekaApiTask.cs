//using FirebaseAdmin;
//using FirebaseAdmin.Auth;
//using FireSharp;
//using FireSharp.Config;
//using FireSharp.Interfaces;
//using FireSharp.Response;
//using Google.Apis.Auth.OAuth2;
//using Microsoft.AspNetCore.Http;
//using Newtonsoft.Json;
//using Newtonsoft.Json.Linq;
//using app.Classes;
//using app.Scheduller.Scheduling;
//using RestSharp;
//using System;
//using System.Collections.Generic;
//using System.Diagnostics;
//using System.IO;
//using System.Linq;
//using System.Net.Http;
//using System.Threading;
//using System.Threading.Tasks;
//using System.Xml;
//using System.Xml.Serialization;

//namespace app.Scheduller
//{
//    public class HeurekaApiTask : IScheduledTask
//    {
//        public string Schedule => "*/15 * * * *";
//        //public string Schedule => "*/5 * * * *";

//        private const string heurekaReview = "https://www.heureka.cz/direct/dotaznik/export-review.php?key=";
//        private const string heurekaProductReview = "https://www.heureka.cz/direct/dotaznik/export-product-review.php?key=";

//        private const string ApiKeyFile = "./scripts/backend/ntf-faze1.json";
//        private const string TokenId = "wdmpVqHsDlYwY0kTDrDLj2lrkrwZXCvaiWlKUkLG";
//        private const string BasePath = "https://ntf-faze1.firebaseio.com/";
//        private static readonly HttpClient client = new HttpClient();
//        private readonly FirebaseApp a = FirebaseApp.Create(new AppOptions()
//        {
//            Credential = GoogleCredential.FromFile(ApiKeyFile),

//        });

//        public async Task ExecuteAsync(CancellationToken cancellationToken)
//        {
//            try
//            {
//                XmlDocument xmlResponse = new XmlDocument();
//                RestClient client = new RestClient();
//                IRestResponse response = new RestResponse();
//                IRestRequest request = new RestRequest(Method.GET);
//                IFirebaseConfig config = new FireSharp.Config.FirebaseConfig
//                {
//                    AuthSecret = TokenId,
//                    BasePath = BasePath
//                };

//                IFirebaseClient _client = new FirebaseClient(config);
//                FirebaseResponse responseStepHeureka = await _client.GetTaskAsync("StepHeureka");


//                var heurekaAPIs = JsonConvert.DeserializeObject<Dictionary<string, HeurekaStepClass>>(responseStepHeureka.Body).ToList();

//                foreach (var heurekaKey in heurekaAPIs)
//                {
//                    try
//                    {
//                        //load heureka REVIEW from API
//                        if (heurekaKey.Value.apiKey.Length == 32)
//                        {
//                            //check firstload from Heureka
//                            _client = new FirebaseClient(config);
//                            FirebaseResponse checkFirstLoad = await _client.GetTaskAsync("HeurekaReviews/" + heurekaKey.Key);




//                            //load REVIEW from heureka
//                            client = new RestClient(heurekaReview + heurekaKey.Value.apiKey.ToString());
//                            response = client.Execute(request);


//                            // prepare for firebase and save
//                            if ((int)response.StatusCode == StatusCodes.Status200OK)
//                            {
//                                try
//                                {
//                                    xmlResponse.LoadXml(response.Content.ToString());

//                                    if (xmlResponse.FirstChild.NodeType == XmlNodeType.XmlDeclaration)
//                                        xmlResponse.RemoveChild(xmlResponse.FirstChild); //remove xml declaration

//                                    XmlSerializer serializer = new XmlSerializer(typeof(HeurekaReview.review));
//                                    XmlNodeList xnList = xmlResponse.SelectNodes("/reviews/review");

//                                    foreach (XmlNode xn in xnList)
//                                    {
//                                        using (TextReader reader = new StringReader(xn.OuterXml.Replace(Environment.NewLine, "")))
//                                        {
//                                            try
//                                            {
//                                                HeurekaReview.review result = (HeurekaReview.review)serializer.Deserialize(reader);
//                                                if (checkFirstLoad.Body == "null" || result.unix_timestamp >= new DateTimeOffset(DateTime.UtcNow.AddDays(-1)).ToUnixTimeSeconds())
//                                                {
//                                                    if (!String.IsNullOrWhiteSpace(result.order_id)) {
//                                                        await _client.UpdateTaskAsync("HeurekaReviews/" + heurekaKey.Key + "/" + result.order_id, result);
//                                                    }
//                                                    else if (!String.IsNullOrWhiteSpace(result.rating_id.ToString()))
//                                                    {
//                                                        await _client.UpdateTaskAsync("HeurekaReviews/" + heurekaKey.Key + "/" + result.rating_id.ToString(), result);
//                                                    }
//                                                }
//                                            }
//                                            catch (Exception e)
//                                            {
//                                                //Debug.WriteLine("error: " + e.Message);
//                                            }
//                                        }
//                                    }
//                                }
//                                catch (Exception e)
//                                {

//                                }
//                            }







//                            //load heureka PRODUCT REVIEW from API
//                            client = new RestClient(heurekaProductReview + heurekaKey.Value.apiKey.ToString());
//                            response = client.Execute(request);


//                            // prepare for firebase and save
//                            if ((int)response.StatusCode == StatusCodes.Status200OK)
//                            {
//                                try { 
//                                    xmlResponse.LoadXml(response.Content.ToString());

//                                    if (xmlResponse.FirstChild.NodeType == XmlNodeType.XmlDeclaration)
//                                        xmlResponse.RemoveChild(xmlResponse.FirstChild); //remove xml declaration

//                                    XmlSerializer serializer = new XmlSerializer(typeof(HeurekaProductReview.product));
//                                    XmlNodeList xnList = xmlResponse.SelectNodes("/products/product");

//                                    foreach (XmlNode xn in xnList)
//                                    {
//                                        using (TextReader reader = new StringReader(xn.OuterXml))
//                                        {
//                                            try
//                                            {
//                                                HeurekaProductReview.product result = (HeurekaProductReview.product)serializer.Deserialize(reader);
//                                                if (checkFirstLoad.Body == "null" || result.reviews.review.unix_timestamp >= new DateTimeOffset(DateTime.UtcNow.AddDays(-1)).ToUnixTimeSeconds())
//                                                {
//                                                    if (!String.IsNullOrWhiteSpace(result.order_id))
//                                                    {
//                                                        await _client.UpdateTaskAsync("HeurekaProductReviews/" + heurekaKey.Key + "/" + result.order_id, result);
//                                                    }
//                                                    else if (!String.IsNullOrWhiteSpace(result.reviews.review.rating_id.ToString()))
//                                                    {
//                                                        await _client.UpdateTaskAsync("HeurekaProductReviews/" + heurekaKey.Key + "/" + result.reviews.review.rating_id.ToString(), result);
//                                                    }
//                                                }
//                                            }
//                                            catch (Exception e)
//                                            {
//                                                //Debug.WriteLine("error: " + e.Message);
//                                            }
//                                        }
//                                    }
//                                }
//                                catch (Exception e)
//                                {

//                                }
//                            }
//                        }
//                    }
//                    catch (Exception e)
//                    {

//                    }
//                }

//                //await Task.Delay(1000, cancellationToken);
//            } catch(Exception e)
//            {
//                await Task.Delay(1000, cancellationToken);
//            }
//        }
//    }

//}



////funguje push var dino = await _client.PushTaskAsync("heurekaReviews/" + heurekaKey.Key,new Dinosaur());
////funguje put var dino = await _client.SetTaskAsync("heurekaReviews/" + heurekaKey.Key, new Dinosaur());
////funguje put+update var dino = await _client.UpdateTaskAsync("heurekaReviews/" + heurekaKey.Key, new Dinosaur());

