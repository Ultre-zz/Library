using System;
using System.IO;
using System.Net;
using System.Text;

namespace Utility.uHttp
{
    class HttpUtils
    {
        HttpWebRequest Request { get; set; }
        CookieContainer Cookies { get; set; }
        HttpWebResponse Response { get; set; }
        public HttpUtils()
        {
            Cookies=new CookieContainer();
        }
        #region DoGET方法以及重载
        public void DoGET(string uriString)
        {
            RequestWithGET(new Uri(uriString));
        }
        public void RequestWithGET(Uri uri)
        {
            Request=HttpWebRequest.Create(uri) as HttpWebRequest;
            Request.Method = "GET";
            Request.CookieContainer = Cookies;
            Request.BeginGetResponse(new AsyncCallback(RequestCallBack), Request);
        }
        #endregion
        #region DoPOST方法以及重载
        public void DoPOST(string uriString, byte[] data, string accept, string connection, string contentType, string host, string referer, string userAgent)
        {
            Uri uri = new Uri(uriString);
            DoPOST(uri, data, accept, connection, contentType, host, referer, userAgent);
        }
        public void DoPOST(Uri uri, byte[] data, string accept, string connection, string contentType, string host, string referer, string userAgent)
        {
            //初始化请求
            Request = HttpWebRequest.Create(uri) as HttpWebRequest;
            Request.Method = "POST";
            Request.CookieContainer = Cookies;
            #region 设置Header
            if (accept != string.Empty)
            {
                Request.Accept = accept;
            }
            if (connection != string.Empty)
            {
                Request.Connection = connection;
            }
            if (contentType != string.Empty)
            {
                Request.ContentType = contentType;
            }
            if (host != string.Empty)
            {
                Request.Host = host;
            }
            if (referer != string.Empty)
            {
                Request.Referer = referer;
            }
            if (userAgent != string.Empty)
            {
                Request.UserAgent = userAgent;
            }
            #endregion
            Request.ContentLength = data.Length;
            //写入POST数据
            using (Stream stream = Request.GetRequestStream())
            {
                stream.Write(data, 0, data.Length);
                stream.Close();
            }
            Request.BeginGetResponse(new AsyncCallback(RequestCallBack), Request);
        }
        #endregion
        public void RequestCallBack(IAsyncResult ar)
        {
            HttpWebRequest request = ar.AsyncState as HttpWebRequest;
            Response = request.EndGetResponse(ar) as HttpWebResponse;
            Stream stream = Response.GetResponseStream();
        }
        /// <summary>
        /// 文本转换为字节数组
        /// </summary>
        /// <param name=”str”>待转换文本</param>
        /// <returns>字节数组</returns>
        static public byte[] StringToByteArray(string str)
        {
            return Encoding.Default.GetBytes(str);
        }
        /// <summary>
        /// 从流中读出文本
        /// </summary>
        /// <param name=”stream”>流</param>
        /// <param name=”coding”>编码</param>
        /// <returns>文本</returns>
        static public string StreamToString(Stream stream, string coding = "UTF-8")
        {
            string rtStr = "";
            using (StreamReader streamReader = new StreamReader(stream, Encoding.GetEncoding(coding)))
            {
                rtStr = streamReader.ReadToEnd();
                streamReader.Close();
            }
            return rtStr;
        }

    }
}
