using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using Newtonsoft.Json.Schema.Generation;
using RevolutionInsure.EnrollmentPlatform.AutomationREST.Utilites;
using RevolutionInsure.EnrollmentPlatform.AutomationREST.Utilites.TestData;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text.RegularExpressions;
using System.Web.Mvc;
using RevolutionInsure.EmrollmentPlatform.Common.ViewModels.Account;

namespace RevolutionInsure.EnrollmentPlatform.AutomationREST.ControllersActions
{
    public class GenericActions
    {
        protected string Route { get; set; }
        protected Client Client = new Client();
        protected IList<string> ErrorMessages = new List<string>();
        public List<Exception> Exceptions = new List<Exception>();

        private Dictionary<string, string> URLData = new Dictionary<string, string>();

        private IList<object> HeadersData = new List<object>();

        public string Response { get; set; }

        public string Errors { get; set; }

        public HttpStatusCode GetResponceStatusCode()
        {
            return Client.HttpRequestStatusCode;
        }

        protected string GetConfigErrorMessage(string typeOfMessage)
        {
            ApplicationConfiguration appconf = new ApplicationConfiguration(@"GeneralConfiguration/API", "ErrorMessages");
            return appconf.GetConfig()[typeOfMessage];
        }

        protected void AddAutorizationHeader(LoginResultModel loginModel)
        {
            if (loginModel.IdToken == null) return;
            Client = new Client();
            Client.AutorizationHeader = loginModel.IdToken;
        }

        public void AddURLData(string key, string obj)
        {
            URLData.Add(key, obj);
        }

        public void ClearURLData()
        {
            URLData.Clear();
        }

        public void CollectRoute(String subRoute)
        {
            Match prefixMatch = null;
            if (Regex.IsMatch(Route,@"^\w+\/\{\w+\:int\}\/\w+$"))
            {
                prefixMatch = Regex.Match(Route, @"^(?<URLPart1>\w+)\/\{(?<URLPrefixParam>\w+\:int)\}\/(?<URLPart2>\w+)$");
            }
            if (subRoute != null)
                Route = Route + "/" + subRoute;
            if (URLData != null && URLData.Count > 0)
            {
                //Processing some URL Data
                foreach (KeyValuePair<string, string> entry in URLData)
                {
                    if (Regex.IsMatch(entry.Key, @"^PrefixParam\{\w+\:int\}$"))
                    {
                        //Case when need to define PrefixParam
                        Route = prefixMatch.Groups["URLPart1"]?.Value + "/" + entry.Value + "/" + prefixMatch.Groups["URLPart2"]?.Value;
                    } else if (Regex.IsMatch(entry.Key, @"^\{\w+\:int\}$"))
                    {
                        //Case when the input URL Params like URL ID: {id:int}
                        Route = Route + "/" + entry.Value;
                    }else if(Regex.IsMatch(entry.Key, @"^List<int>\s*\w+$"))  
                    {
                        //Case when the input URL Params are List like: Lisy<int> ids
                        var m = Regex.Match(entry.Key, @"^List<int>\s*(?<URLParam>\w+)$");
                        string str = m.Groups["URLParam"]?.Value;
                        Route = Route + "?" + str + "=" + entry.Value;
                    }else if (Regex.IsMatch(entry.Key,@"^\{\w+\:int\}\/\w+$"))
                    {
                        //Case when the input URL Params are List like: /{productid:int}/KnockoutQuestion
                        //var m = Regex.Match(entry.Key, @"^\{\w+\:int\}\/(?<URLPart2>\w+)$");
                        //string str = m.Groups["URLPart2"]?.Value;
                        // Route = Route + "/" + entry.Value + str;
                    }else
                    {
                        //Case when the input URL Params are List like: ?Status=1
                        Route = Route + "?" + entry.Key + "=" + entry.Value;
                    }
                }
            }
        }

        public void AddHeadersData(object obj)
        {
            HeadersData.Add(obj); 
        }

        public void CleanHeadersData()
        {
            HeadersData.Clear();
        }

        public void CreateHeaders(AutorizationType autorizationType, object obj)
        {
            if (autorizationType == AutorizationType.AllowAnonymous)
            {

            }else if (autorizationType == AutorizationType.Authorize)
            {
                CleanHeadersData();
                AddHeadersData(obj);
            }
        }

        public void HeadersDataProcessing()
        {
            if (HeadersData != null && HeadersData.Count > 0)
                foreach (object obj in HeadersData)
                {
                    //AdditionalDataProcessing
                    if (obj.GetType() == typeof(LoginResultModel))
                    {
                        var lrm = (LoginResultModel)obj;
                        AddAutorizationHeader(lrm);
                    }

                }
        }
        /*
        protected bool isValideJSON(Type type, string jsonData) 
        {
            JSchemaGenerator generator = new JSchemaGenerator();
            JSchema schema = generator.Generate(type);
            JSONData.LoadJSONSchemaToFile(type);
            try
            {
                if (type.IsGenericType && (type.GetGenericTypeDefinition() == typeof(List<>)))
                {
                    JArray jarray = JArray.Parse(jsonData);
                    return jarray.IsValid(schema, out ErrorMessages);
                } 
                JObject jobj = JObject.Parse(jsonData);
                return jobj.IsValid(schema, out ErrorMessages);
            }
            catch(JsonReaderException ex)
            {
                ErrorMessages.Add(ex.Message);
                Exceptions.Add(ex);
            }
            return false;
        }
        */
        /*
        protected T RunAPI<T>(string parameters, HttpVerbs method)
        {
            T jsonObjectModel = default(T);
            Client.Method = method;
            var response = Client.Request(parameters);
            Response = response;
//            if (isValideJSON(typeof(T), response))
            try
            {
                jsonObjectModel = JsonConvert.DeserializeObject<T>(response);
                JSONData.LoadJSONDataToFile<T>(jsonObjectModel);
                return jsonObjectModel;
            }catch(Exception e)
            {
                ErrorMessages.Add(e.Message);
                Exceptions.Add(e);
            }
            Errors = (int)Client.HttpRequestStatusCode + " - " + Response + " : " + GetConfigErrorMessage("TypeOfVerification") + typeof(T).Name + ".\n";
            Errors = Errors + String.Join(";\n", ErrorMessages);
            return default(T);
        }
        */

        /*
        protected T RunAPI<T>(string parameters, HttpVerbs method, string body)
        {
            T jsonObjectModel = default(T);
            Client.Body = body;
            Client.Method = method;
            var response = Client.Request(parameters);
            Response = response;
            //if (isValideJSON(typeof(T), response))
            try
            {
                jsonObjectModel = JsonConvert.DeserializeObject<T>(response);
                JSONData.LoadJSONDataToFile<T>(jsonObjectModel);
                return jsonObjectModel;
            }
            catch(Exception e)
            {
                ErrorMessages.Add(e.Message);
                Exceptions.Add(e);
            }
            Errors = (int)Client.HttpRequestStatusCode + " - " + Response + " : " + GetConfigErrorMessage("TypeOfVerification") + typeof(T).Name + ".\n";
            Errors = Errors + String.Join(";\n", ErrorMessages);
            return default(T);
        }
        */
        //general APIRUN
        public T RunAPI<T>(string endPoint, string subRoute, HttpVerbs method, string body)
        {
            T jsonObjectModel = default(T);
            HeadersDataProcessing();
            Client.Method = method;
            if (body != null)
                Client.Body = body;
            CollectRoute(subRoute);
            var response = Client.Request(Route);
            Response = response;
            if (this.isSuccessRequest())
            {
                try
                {
                    jsonObjectModel = JsonConvert.DeserializeObject<T>(response);
                    JSONData.LoadJSONDataToFile<T>(jsonObjectModel);
                    return jsonObjectModel;
                }
                catch (Exception e)
                {
                    ErrorMessages.Add(e.Message);
                    Exceptions.Add(e);
                }
                Errors = (int)Client.HttpRequestStatusCode + " - " + Response + " : " + GetConfigErrorMessage("TypeOfVerification") + typeof(T).Name + ".\n";
                Errors = Errors + String.Join(";\n", ErrorMessages);
            }
            return default(T);
        }

        protected bool isSuccessRequest()
        {
            if       ((int)Client.HttpRequestStatusCode >= 100 && (int)Client.HttpRequestStatusCode < 200)
            {
                //Informational 
                return true;
            }else if ((int)Client.HttpRequestStatusCode >= 200 && (int)Client.HttpRequestStatusCode < 300)
            {
                //Success
                return true;
            }else if ((int)Client.HttpRequestStatusCode >= 300 && (int)Client.HttpRequestStatusCode < 400)
            {
                //Redirection
                return true;
            }else if ((int)Client.HttpRequestStatusCode >= 400 && (int)Client.HttpRequestStatusCode < 500)
            {
                //Client Error
                Exceptions = Client.Exceptions;
                Errors = "Client Error: " + (int)Client.HttpRequestStatusCode + " - " + Response + ".\n";
                Errors = Errors + String.Join(";\n", ErrorMessages);
                Errors = Errors + String.Join(";\n", Exceptions);
                return false;
            }else if ((int)Client.HttpRequestStatusCode >= 500 && (int)Client.HttpRequestStatusCode < 600)
            {
                //Server Error
                Exceptions = Client.Exceptions;
                Errors = "Server Error: " + (int)Client.HttpRequestStatusCode + " - " + Response + ".\n";
                Errors = Errors + String.Join(";\n", ErrorMessages);
                Errors = Errors + String.Join(";\n", Exceptions);
                return false;
            }
            //Unecpected error code
            Exceptions = Client.Exceptions;
            Errors = "Unknown Error: " + (int)Client.HttpRequestStatusCode + " - " + Response + ".\n";
            Errors = Errors + String.Join(";\n", ErrorMessages);
            Errors = Errors + String.Join(";\n", Exceptions);
            return false;
        }

    }
}
