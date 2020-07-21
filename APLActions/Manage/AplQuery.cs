using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using BlazorApp1.Data.kafka;
using System.Net.Http;
using System.Net;
using Microsoft.AspNetCore.CookiePolicy;
using System.IO;
using static Raven.Client.Constants;
using APLActions.Manage;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace APLActions
{
    //1.查询堆栈库存
    //2.查询工位板位图
    public class AplQuery
    {
        private ILogger _aplLog;
        private KafkaSetting _kafkaSetting;
        private string baseUrl = "http://172.16.38.15:8090";
        private string fullUrl;
        private string response;
        private string Response;
        private string data;

        public AplQuery(ILogger<AplQuery> logger, IConfiguration configuration)
        {
            this._aplLog = logger;
            _kafkaSetting = new KafkaSetting();
            configuration.GetSection("KafkaSetting").Bind(_kafkaSetting);
        }
        public void Init(KafkaSetting kafkaSetting)
        {
            baseUrl = kafkaSetting.IpPort.Split(":")[0];
        }

        public string BaseQuery(string param=null)
        {
            fullUrl = baseUrl + param;
            Response =  HttpPost(fullUrl);
            return Response;
            //JObject jo = (JObject)JsonConvert.DeserializeObject(Response);
            
            //var conver = JsonConvert.DeserializeXmlNode(Response);
            //var BarCode = conver.GetElementById("BarCode").Value;
            //return BarCode;
            //if (Response != null && Response is AplQueryModel aplQueryModel)
            //{
            //    var response = new AplQueryModel
            //    {
            //        StatusCode = 
            //    };
            //}

            //if (Response.status_code == 200)
            //{
            //    data = Json.loads(Response.content.decode('utf-8'));
            //    return data;
            //}
        }
        public string TableQuery(string device, string pos)
        {
            data = BaseQuery("/test/Dispatcher/QueryBoards");

            if (string.IsNullOrEmpty(data))
            {
                _aplLog?.LogError("get boards null.");
            }

            //foreach (Directory item in data["Content"][device])
            //{
            //    return item["Barcode"];
            //}
            return null;
        }
        public void HotelQuery()
        {

        }
        private string HttpPost(string Url)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Url);
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            //request.ContentLength = Encoding.UTF8.GetByteCount(postDataStr);
            
            //Stream myRequestStream = request.GetRequestStream();
            //StreamWriter myStreamWriter = new StreamWriter(myRequestStream, Encoding.GetEncoding("gb2312"));
            //myStreamWriter.Write(postDataStr);
            //myStreamWriter.Close();
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream myResponseStream = response.GetResponseStream();
            StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.GetEncoding("utf-8"));
            string retString = myStreamReader.ReadToEnd();
            //myStreamReader.Close();
            myResponseStream.Close();

            return retString;
        }
        /// <summary>
        /// GET请求与获取结果
        /// </summary>
        public static string HttpGet(string Url, string postDataStr)
        {
            // HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Url + (postDataStr == "" ? "" : "?") + postDataStr);
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Url);
            request.Method = "GET"; //设置请求方式
            request.ContentType = "application/json-patch+json;charset=UTF-8"; //设置内容类型

            HttpWebResponse response = (HttpWebResponse)request.GetResponse(); //返回响应

            Stream myResponseStream = response.GetResponseStream(); //获得响应流

            StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.UTF8);//以UTF8编码方式读取该流
            string retString = myStreamReader.ReadToEnd();//读取所有

            myStreamReader.Close();//关闭流
            myResponseStream.Close();
            return retString;
        }
    }
}
