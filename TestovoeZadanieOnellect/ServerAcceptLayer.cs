using System;
using System.IO;
using System.Net;
using System.Text;
using System.Xml;

namespace TestovoeZadanieOnellect
{
    class ServerAcceptLayer
    {
        static string LinkAdress(string name)
        {
            try
            {
                XmlDocument a = new XmlDocument();
                a.Load("Config.xml");
                XmlElement xRoot = a.DocumentElement;
                XmlNode childnode = xRoot.SelectSingleNode($"Adress[@name='{name}']/Url");
                if (childnode != null)
                {
                    return childnode.InnerText;
                }
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }
        public static string SendNumbers(Numbers numbers)
        {           
            string url = LinkAdress("Numbers");
            if (url != null)
            {
                try
                {
                    WebRequest request = WebRequest.Create(url);
                    request.Method = "POST";
                    request.ContentType = "application/x-www-form-urlencoded";

                    string postData = numbers.ToString();
                    byte[] byteArray = Encoding.UTF8.GetBytes(postData);
                    request.ContentLength = byteArray.Length;

                    using (Stream dataStream = request.GetRequestStream())
                    {
                        dataStream.Write(byteArray, 0, byteArray.Length);
                    }
                   
                    WebResponse response = request.GetResponse();                  
                    string result = ((HttpWebResponse)response).StatusDescription;
                    response.Close();
                    return result;
                }
                catch (WebException we)
                {
                    return $"Сообщение{we.Message} Статус {we.Status}";
                }
            }
            else
            {
                return $"Ошибка: url не задан";
            }
        }
    }
}
