using RevolutionInsure.EnrollmentPlatform.AutomationREST.Utilites.TestData;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web.Mvc;

namespace RevolutionInsure.EnrollmentPlatform.AutomationREST.Utilites
{
    public class Client
    {

        private static string ApplicationJSON = "application/json";
        private static string TextJSON = "text/json";
        //TODO Add xml-context

        public string EndPoint { get; private set;}
        public HttpVerbs Method { get; set; }
        public string ContentType { get; set; }

        public List<Exception> Exceptions = new List<Exception>();
        //public string PostBody { get; set; }

        //public string PutBody { get; set; }

        public string Body { get; set; }
        public string AutorizationHeader { get; set; }

        public HttpStatusCode HttpRequestStatusCode { get; private set;}


    /// <summary>
    /// Create a GET web-api client for Local started End Point
    /// </summary>
    public Client()
        {

            EndPoint = GetEndPoint();
            ContentType = ApplicationJSON;
        }

        /// <summary>
        /// Create a web-api client for parametrized started End Point, method and postData
        /// </summary>
        /// <param name="endpoint">URL of the End Point</param>
        /// <param name="method">HTTP Method</param>
        /// <param name="body">Data string</param>
        public Client(string endpoint, HttpVerbs method, string body)
        {
            EndPoint = GetEndPoint();
            Method = method;
            ContentType = ApplicationJSON;
            Body = body;
        }

        /// <summary>
        /// Create a web-api GET client for set End Point
        /// </summary>
        /// <param name="endpoint"></param>
        //public Client(string endpoint)
        //{
            //EndPoint = GetEndPoint(endpoint);
        //    ContentType = ApplicationJSON;
        //}
        /// <summary>
        /// Create a web-api client for Local started End Point
        /// </summary>
        /// <param name="method"></param>
        /// <param name="body"></param>
        public Client(HttpVerbs method, string body)
        {
            EndPoint = GetEndPoint();
            Method = method;
            ContentType = ApplicationJSON;
            Body = body;

        }

        public string GetEndPoint()
        {
            ApplicationConfiguration appconfig = new ApplicationConfiguration(@"GeneralConfiguration", "RunConfig");
            string runlocation = appconfig.GetConfig()["RunLocation"];
            runlocation = appconfig.GetConfig(@"APIConfiguration", "EndPoint")[runlocation];
            return runlocation;
        }        

        public string Request()
        {
            return Request("");
        }

        public string Request(string parameters)
        {
            var request = (HttpWebRequest)WebRequest.Create(EndPoint + parameters);

            request.Method = Method.ToString();
            request.ContentLength = 0;
            request.ContentType = ContentType;
            if (!string.IsNullOrEmpty(AutorizationHeader))
            {
                request.Headers.Add(@"Authorization:Bearer " + AutorizationHeader);
            }

            if (!string.IsNullOrEmpty(Body) && ((Method == HttpVerbs.Post) || (Method == HttpVerbs.Put)))
            {
                var encoding = new UTF8Encoding();
                var bytes = Encoding.UTF8.GetBytes(Body);
                request.ContentLength = bytes.Length;

                try
                {
                    using (var writeStream = request.GetRequestStream())
                    {
                        writeStream.Write(bytes, 0, bytes.Length);
                    }

                }
                catch (WebException we)
                {
                    Exceptions.Add(we);
                }
            }

            try
            {
                var response = (HttpWebResponse)request.GetResponse();

            }
            catch(WebException we)
            {
                Exceptions.Add(we);
                Console.WriteLine(we);
                if (we.Response == null)
                {
                    Console.WriteLine(we);
                    return we.Message;
                }
                using (var responseStream = we.Response.GetResponseStream())
                {
                    if (responseStream != null)
                    {
                        using (var reader = new StreamReader(responseStream))
                        {
                            var responseExceptionValue = reader.ReadToEnd();
                            Exceptions.Add(new Exception(responseExceptionValue));
                            //var jsonSerializerSettings = new JsonSerializerSettings() { DefaultValueHandling = DefaultValueHandling.Ignore };
                            //Exceptions.Add(JsonConvert.DeserializeObject<AutoMapperMappingException>(responseExceptionValue));
                        }
                    }
                }
                HttpRequestStatusCode = ((HttpWebResponse)we.Response).StatusCode;
                return ((HttpWebResponse)we.Response).StatusDescription;                
            }
            catch(Exception e)
            {
                Exceptions.Add(e);
                Console.WriteLine(e);
                return e.Message;
            }
            using (var response = (HttpWebResponse)request.GetResponse())
            {
                var responseValue = string.Empty;

                HttpRequestStatusCode = response.StatusCode;

                if (response.StatusCode != HttpStatusCode.OK)
                {
                    var message = String.Format("Request failed. Received HTTP {0}", response.StatusCode);
                    Exceptions.Add(new Exception(message));
                    //throw new ApplicationException(message);
                }

                // grab the response
                using (var responseStream = response.GetResponseStream())
                {
                    if (responseStream != null)
                        using (var reader = new StreamReader(responseStream))
                        {
                            responseValue = reader.ReadToEnd();
                        }
                }

                return responseValue;
            }
        }

    }
}
