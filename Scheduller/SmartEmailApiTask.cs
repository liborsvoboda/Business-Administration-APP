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
//    public class SmartEmailApiTask : IScheduledTask
//    {
//        public string Schedule => "*/15 * * * *";
//        //public string Schedule => "*/5 * * * *";

//        private static readonly string username = "libor.svoboda@kliknetezde.cz";
//        private static readonly string apiKey = "8kal3xijr06qun32nwwyubpm8n3xgad3k63nb6i6";
//        private static readonly string smartEmailAuth = "Basic " + Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(username + ":" + apiKey));
//        private const string SmartData = "https://appi.smartemailing.cz/api/v2";


//        private const string ApiKeyFile = "./scripts/backend/ntf-faze1.json";
//        private const string TokenId = "wdmpVqHsDlYwY0kTDrDLj2lrkrwZXCvaiWlKUkLG";
//        private const string BasePath = "https://ntf-faze1.firebaseio.com/";
//        private static readonly HttpClient client = new HttpClient();


//        public async Task ExecuteAsync(CancellationToken cancellationToken)
//        {
//            try
//            {
//                bool saveChange = false;
//                XmlDocument xmlResponse = new XmlDocument();
//                RestClient smartClient = new RestClient();
//                IRestResponse smartResponse = new RestResponse();
//                IRestResponse response = new RestResponse();
//                IRestRequest request = new RestRequest(Method.GET);
//                IFirebaseConfig config = new FireSharp.Config.FirebaseConfig
//                {
//                    AuthSecret = TokenId,
//                    BasePath = BasePath
//                };

//                IFirebaseClient _client = new FirebaseClient(config);
//                FirebaseResponse responseProfiles = await _client.GetTaskAsync("StepProfil");


//                var Profiles = JsonConvert.DeserializeObject<Dictionary<string, ProfileStepClass>>(responseProfiles.Body).ToList();

//                foreach (var profile in Profiles)
//                {


//                    //check the smaremailing request
//                    if (!string.IsNullOrWhiteSpace(profile.Value.RegEmail) && !profile.Value.SmartRegComplete && DateTimeOffset.FromUnixTimeMilliseconds((long)profile.Value.SmartStamp).AddDays(1) <  new DateTimeOffset(DateTime.Now))
//                    {
//                        saveChange = false;
//                        if (profile.Value.Level >= 13)
//                        {
//                            _client = new FirebaseClient(config);
//                            FirebaseResponse checkFirstLoad = await _client.GetTaskAsync("Campaigns/" + profile.Key);
//                            if (!string.IsNullOrWhiteSpace(checkFirstLoad.Body) && checkFirstLoad.Body != "null")
//                            {
//                                profile.Value.Level = 16;
//                                profile.Value.SmartRegComplete = true;
//                                profile.Value.SmartStamp = (ulong)((DateTimeOffset)DateTime.UtcNow).ToUnixTimeSeconds();
//                                saveChange = true;
//                            }

//                        }

//                        if (profile.Value.Level == 13 )
//                        {
//                            _client = new FirebaseClient(config);
//                            FirebaseResponse checkFirstLoad = await _client.GetTaskAsync("VisitsCount/" + profile.Key);
//                            if (!string.IsNullOrWhiteSpace(checkFirstLoad.Body) && checkFirstLoad.Body != "null")
//                            {
//                                profile.Value.Level = 14;
//                                profile.Value.SmartRegComplete = true;
//                                profile.Value.SmartStamp = (ulong)((DateTimeOffset)DateTime.UtcNow).ToUnixTimeSeconds();
//                                saveChange = true;
//                            }

//                        }

//                        if (profile.Value.Level == 14)
//                        {
//                            _client = new FirebaseClient(config);
//                            FirebaseResponse checkFirstLoad = await _client.GetTaskAsync("StepHeureka/" + profile.Key);
//                            if (!string.IsNullOrWhiteSpace(checkFirstLoad.Body) && checkFirstLoad.Body != "null")
//                            {
//                                profile.Value.Level = 15;
//                                profile.Value.SmartRegComplete = true;
//                                profile.Value.SmartStamp = (ulong)((DateTimeOffset)DateTime.UtcNow).ToUnixTimeSeconds();
//                                saveChange = true;
//                            }

//                        }

//                        if (profile.Value.Level <= 5)
//                        {
//                            _client = new FirebaseClient(config);
//                            FirebaseResponse checkFirstLoad = await _client.GetTaskAsync("Campaigns/" + profile.Key);
//                            if (!string.IsNullOrWhiteSpace(checkFirstLoad.Body) && checkFirstLoad.Body != "null")
//                            {
//                                profile.Value.Level = 5;
//                                profile.Value.SmartRegComplete = true;
//                                profile.Value.SmartStamp = (ulong)((DateTimeOffset)DateTime.UtcNow).ToUnixTimeSeconds();
//                                saveChange = true;
//                            }

//                        }

//                        if (profile.Value.Level == 3)
//                        {
//                            _client = new FirebaseClient(config);
//                            FirebaseResponse checkFirstLoad = await _client.GetTaskAsync("StepHeureka/" + profile.Key);
//                            if (!string.IsNullOrWhiteSpace(checkFirstLoad.Body) && checkFirstLoad.Body != "null")
//                            {
//                                profile.Value.Level = 4;
//                                profile.Value.SmartRegComplete = true;
//                                profile.Value.SmartStamp = (ulong)((DateTimeOffset)DateTime.UtcNow).ToUnixTimeSeconds();
//                                saveChange = true;
//                            }

//                        }

//                        if (profile.Value.Level == 2)
//                        {
//                            _client = new FirebaseClient(config);
//                            FirebaseResponse checkFirstLoad = await _client.GetTaskAsync("VisitsCount/" + profile.Key);
//                            if (!string.IsNullOrWhiteSpace(checkFirstLoad.Body) && checkFirstLoad.Body != "null") {
//                                profile.Value.Level = 3;
//                                profile.Value.SmartRegComplete = true;
//                                profile.Value.SmartStamp = (ulong)((DateTimeOffset)DateTime.UtcNow).ToUnixTimeSeconds();
//                                saveChange = true;
//                            }
                            
//                        }

//                        //run changing smartemailing
//                        if (saveChange) {

//                            IRestRequest smartRequest = new RestRequest(Method.POST) { RequestFormat = DataFormat.Xml };
//                            ChangeContactList(smartRequest, profile.Value.RegEmail, (int)profile.Value.Level);
//                            smartClient = new RestClient(SmartData);
//                            smartResponse =  smartClient.Execute(smartRequest);

//                            if ((int)smartResponse.StatusCode == StatusCodes.Status200OK)
//                            {
//                                await _client.UpdateTaskAsync("StepProfil/" + profile.Key, profile.Value);
//                            }

                          
//                        }
//                        //Debug.WriteLine(profile.ToString());




//                    }

//                }

//                //await Task.Delay(1000, cancellationToken);
//            } catch(Exception e)
//            {
//                await Task.Delay(1000, cancellationToken);
//            }
//        }




//        private IRestRequest ChangeContactList(IRestRequest context, string email, int requestedContactListId)
//        {
//            string generateItemString = null;
//            List<int> allGroups = new List<int> { 2, 3, 4, 5, 13, 14, 15, 16 };

//            foreach (int element in allGroups)
//            {
//                if (element != requestedContactListId)
//                {
//                    generateItemString += "<item><id>" + element.ToString() + "</id><status>removed</status></item>";
//                }
//                else
//                {
//                    generateItemString += "<item><id>" + element.ToString() + "</id><status>confirmed</status></item>";
//                }
//            }

//            Parameter updateContact = new Parameter("application/xml", @"<?xml version='1.0' encoding='UTF-8'?><xmlrequest> 
//                <username>" + username + @"</username>
//                <usertoken>" + apiKey + @"</usertoken>
//                <requesttype>Contacts</requesttype>
//                <requestmethod>createupdate</requestmethod>
//                <details>
//                    <emailaddress>" + email + @"</emailaddress>
//                    <contactliststatuses>" + generateItemString + @"</contactliststatuses>
//                </details>
//                </xmlrequest>", "application/xml", ParameterType.RequestBody);
//            context.Parameters.Add(updateContact);
//            return context;
//        }

//    }

//}



////funguje push var dino = await _client.PushTaskAsync("heurekaReviews/" + heurekaKey.Key,new Dinosaur());
////funguje put var dino = await _client.SetTaskAsync("heurekaReviews/" + heurekaKey.Key, new Dinosaur());
////funguje put+update var dino = await _client.UpdateTaskAsync("heurekaReviews/" + heurekaKey.Key, new Dinosaur());

