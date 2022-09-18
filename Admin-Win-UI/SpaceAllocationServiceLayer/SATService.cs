using log4net;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;
using System.Reflection;
using Utility.ExceptionHelper;

namespace SpaceAllocationServiceLayer
{
    public class SATService
    {
        private readonly ILog _logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        private HttpWebRequest HttpWebRequest(String url)
        {
            try
            {
                HttpWebRequest _httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
                //_httpWebRequest.Method = "POST";
                _httpWebRequest.ContentType = "application/json";

                return _httpWebRequest;
            }
            catch (Exception ex)
            {
                _logger.Error($"Exception while getting HttpWebRequest. Exception: {ex.GetExceptionDetail()}");
                throw;
            }
        }

        public String SendPostRequest(String url)
        {
            try
            {
                HttpWebRequest httpRequest = this.HttpWebRequest(url);
                httpRequest.Method = "POST";
                //httpRequest.Headers[StringConstant.Authorization] = StringConstant.ZohoDashoauthtoken + StringConstant.Space + ZohoConfiguration.AccessToken;

                //localHttpRequest.ContentLength = requestData.Length;
                StreamWriter streamWriter = new StreamWriter(httpRequest.GetRequestStream());
                //streamWriter.Write(requestData);
                streamWriter.Close();
                string result;
                HttpWebResponse objResponse = (HttpWebResponse)httpRequest.GetResponse();
                using (StreamReader sr = new StreamReader(objResponse.GetResponseStream()))
                {
                    result = sr.ReadToEnd();
                    sr.Close();
                }
                return result;
            }
            catch (Exception ex)
            {
                _logger.Error($"Exception while sending post request. Exception: {ex.GetExceptionDetail()}");
                throw;
            }
        }

        public String SendPostRequest(String url, Object obj)
        {
            try
            {
                HttpWebRequest httpRequest = this.HttpWebRequest(url);
                httpRequest.Method = "POST";
                
                //httpRequest.Headers[StringConstant.ContentDashType] = "application /json;charset=UTF-8";
                httpRequest.ContentType = "application /json;charset=UTF-8";

                using (var streamWriter = new StreamWriter(httpRequest.GetRequestStream()))
                {
                    string json = JsonConvert.SerializeObject(obj);
                    _logger.Info($"Request: {json}");
                    streamWriter.Write(json);
                }

                string result;
                HttpWebResponse objResponse = (HttpWebResponse)httpRequest.GetResponse();

                if (objResponse.StatusCode == HttpStatusCode.OK)
                {
                    using (StreamReader sr = new StreamReader(objResponse.GetResponseStream()))
                    {
                        result = sr.ReadToEnd();
                        sr.Close();
                    }

                    _logger.Info($"Response: {result}");

                    return result;
                }
                else
                {
                    throw new Exception($"Exception from Server: Status Code: {objResponse.StatusCode}, Status Description: {objResponse.StatusDescription}");
                }                
            }
            catch (Exception ex)
            {
                _logger.Error($"Exception while sending post request. Exception: {ex.GetExceptionDetail()}");
                throw;
            }
        }

        public String SendPutRequest(String url, Object obj)
        {
            String jsonRequest = String.Empty;

            try
            {
                HttpWebRequest httpRequest = this.HttpWebRequest(url);
                httpRequest.Method = "PUT";
                //httpRequest.Headers[StringConstant.ContentDashType] = "application /json;charset=UTF-8";
                httpRequest.ContentType = "application /json;charset=UTF-8";

                using (var streamWriter = new StreamWriter(httpRequest.GetRequestStream()))
                {
                    jsonRequest = JsonConvert.SerializeObject(obj);
                    _logger.Info($"Request: {jsonRequest}");
                    streamWriter.Write(jsonRequest);
                }

                string result;
                HttpWebResponse objResponse = (HttpWebResponse)httpRequest.GetResponse();
                using (StreamReader sr = new StreamReader(objResponse.GetResponseStream()))
                {
                    result = sr.ReadToEnd();
                    sr.Close();
                }

                _logger.Info($"Response: {result}");

                return result;
            }
            catch (Exception ex)
            {
                _logger.Error($"Exception while sending post request. Exception: {ex.GetExceptionDetail()}");
                throw;
            }
        }

        public String SendGetRequest(String url)
        {
            try
            {
                HttpWebRequest httpRequest = this.HttpWebRequest(url);
                httpRequest.Method = "GET";

                string result;

                using (HttpWebResponse response = (HttpWebResponse)httpRequest.GetResponse())
                {
                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        using (StreamReader stream = new StreamReader(response.GetResponseStream()))
                        {
                            result = stream.ReadToEnd();
                            stream.Close();
                        }

                        _logger.Info($"Response: {result}");

                        return result;
                    }
                    else
                    {
                        throw new Exception($"Exception from Server: Status Code: {response.StatusCode}, Status Description: {response.StatusDescription}");
                    }                    
                }

                ////localHttpRequest.ContentLength = requestData.Length;
                //StreamWriter streamWriter = new StreamWriter(httpRequest.GetRequestStream());
                ////streamWriter.Write(requestData);
                //streamWriter.Close();
                //string result;
                //HttpWebResponse objResponse = (HttpWebResponse)httpRequest.GetResponse();
                //using (StreamReader sr = new StreamReader(objResponse.GetResponseStream()))
                //{
                //    result = sr.ReadToEnd();
                //    sr.Close();
                //}
                return result;
            }
            catch (WebException wex)
            {
                _logger.Error($"Exception while sending get request. Exception: {wex.GetExceptionDetail()}");
                throw;
            }
            catch (Exception ex)
            {
                _logger.Error($"Exception while sending request. Exception: {ex.GetExceptionDetail()}");
                throw;
            }
        }
    }
}
