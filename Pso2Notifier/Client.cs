using Pso2Notifier.Models;
using System;
using System.Diagnostics;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Windows.Data.Json;
using Windows.Data.Xml.Dom;

namespace Pso2Notifier
{
    /// <summary>
    /// Fetch Web Content Class
    /// </summary>
    class Client
    {
        private static HttpClient client;
        private static Client _instance = new Client();

        /// <summary>
        /// Constructor (this class is a singleton!)
        /// </summary>
        private Client()
        {
            client = new HttpClient();
            setTimeout(3000);
            setUa();
            setAcceptMimeType();
        }
        /// <summary>
        /// Instance
        /// </summary>
        /// <returns></returns>
        public static Client instance()
        {
            return _instance;
        }
        /// <summary>
        /// Set UserAgent
        /// </summary>
        /// <param name="ua"></param>
        public static void setUa(string ua = "")
        {
            if (ua == "")
            {
                var assembly = new AppAssembly();
                ua = assembly.Title + "_" + assembly.Version;
            }
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Add("User-Agent", ua);
        }
        /// <summary>
        /// Set Accept Mime Type
        /// </summary>
        /// <param name="mime"></param>
        public static void setAcceptMimeType(string mime = "text/plain")
        {
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue(mime));
        }
        /// <summary>
        /// Set Timeout
        /// </summary>
        /// <param name="timeout"></param>
        public static void setTimeout(int timeout = 3000)
        {
            client.Timeout = TimeSpan.FromMilliseconds(timeout);
        }
        /// <summary>
        /// Download Stream
        /// </summary>
        /// <param name="uri"></param>
        /// <param name="isAwait"></param>
        /// <returns></returns>
        public static async Task<Stream> getStream(string uri, bool isAwait = false)
        {
            Debug.WriteLine("Fetch Stream: " + uri);
            return await client.GetStreamAsync(uri).ConfigureAwait(isAwait);
        }
        /// <summary>
        /// Download String 
        /// </summary>
        /// <param name="uri"></param>
        /// <param name="isAwait"></param>
        /// <returns></returns>
        public static async Task<string> getString(string uri, bool isAwait = false)
        {
            Debug.WriteLine("Fetch String : " + uri);
            return await client.GetStringAsync(uri).ConfigureAwait(isAwait);
        }
        /// <summary>
        /// Download json
        /// </summary>
        /// <param name="uri"></param>
        /// <returns></returns>
        public static JsonArray getJson(string uri)
        {
            setAcceptMimeType("application/json");
            string ret = getString(uri).Result;
            Debug.WriteLine(ret);
            return JsonArray.Parse(ret);
        }
        /// <summary>
        /// Dwonload Xml
        /// </summary>
        /// <param name="uri"></param>
        /// <returns></returns>
        public static XmlDocument getXml(string uri)
        {
            setAcceptMimeType("application/xml");
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(getString(uri).Result);
            return doc;
        }
    }
}
