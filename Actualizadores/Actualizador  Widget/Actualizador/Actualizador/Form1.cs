using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Text.RegularExpressions;
using System.IO;
using System.Net;
using System.Globalization;
using emailFeed;

namespace Actualizador
{
    public partial class Form1 : Form
    {
        public Form1()
        {
           
                InitializeComponent();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        { 
           
            render(writer);
            
        }

  
        public void render(HtmlDocument writer)
        {
            for (int i = 0; i <= 14; i++)
            {
                int idCapital = i;
                //string idCapital = ciclo;
                if (idCapital == 0)
                {
                    string id = "55760";
                   //string id = null;
                    string url = "http://xml.tutiempo.net/rss/" + id + ".xml";
                    XmlDocument doc = GetDocument(url);
                }

                else if (idCapital == 1)
                {
                    string id = "55660";
                    string url = "http://xml.tutiempo.net/rss/" + id + ".xml";
                    XmlDocument doc = GetDocument(url);
                   
                    //writer.Write(doc.OuterXml);
                }

                else if (idCapital == 2)
                {
                    string id = "55697";
                    string url = "http://xml.tutiempo.net/rss/" + id + ".xml";
                    XmlDocument doc = GetDocument(url);
                    //writer.Write(doc.OuterXml);

                }

                else if (idCapital == 3)
                {
                    string id = "55658";
                    string url = "http://xml.tutiempo.net/rss/" + id + ".xml";
                    XmlDocument doc = GetDocument(url);
                    //writer.Write(doc.OuterXml);
                }

                else if (idCapital == 4)
                {
                    string id = "55682";
                    string url = "http://xml.tutiempo.net/rss/" + id + ".xml";
                    XmlDocument doc = GetDocument(url);
                    //writer.Write(doc.OuterXml);
                }

                else if (idCapital == 5)
                {
                    string id = "55702";
                    string url = "http://xml.tutiempo.net/rss/" + id + ".xml";
                    XmlDocument doc = GetDocument(url);
                    //writer.Write(doc.OuterXml);
                }

                else if (idCapital == 6)
                {
                    string  id = "34277";
                    string url = "http://xml.tutiempo.net/rss/" + id + ".xml";
                    XmlDocument doc = GetDocument(url);
                    //writer.Write(doc.OuterXml);
                }

       

                else if (idCapital == 7)
                {
                    string id = "55747";
                    string url = "http://xml.tutiempo.net/rss/" + id + ".xml";
                    XmlDocument doc = GetDocument(url);
                    //writer.Write(doc.OuterXml);
                }

                else if (idCapital == 8)
                {
                    string id = "34278";
                    string url = "http://xml.tutiempo.net/rss/" + id + ".xml";
                    XmlDocument doc = GetDocument(url);
                    //writer.Write(doc.OuterXml);
                }

                else if (idCapital == 9)
                {
                    string id = "55680";
                    string url = "http://xml.tutiempo.net/rss/" + id + ".xml";
                    XmlDocument doc = GetDocument(url);
                    //writer.Write(doc.OuterXml);

                }

                else if (idCapital == 10)
                {
                    string id = "55763";
                    string url = "http://xml.tutiempo.net/rss/" + id + ".xml";
                    XmlDocument doc = GetDocument(url);
                    //writer.Write(doc.OuterXml);

                }

                else if (idCapital == 11)
                {
                    string id = "55768";
                    string url = "http://xml.tutiempo.net/rss/" + id + ".xml";
                    XmlDocument doc = GetDocument(url);
                    //writer.Write(doc.OuterXml);

                }

                else if (idCapital == 12)
                {
                    string id = "55739";
                    string url = "http://xml.tutiempo.net/rss/" + id + ".xml";
                    XmlDocument doc = GetDocument(url);
                    //writer.Write(doc.OuterXml);

                }

                else if (idCapital == 13)
                {
                    string id = "31180";
                    string url = "http://xml.tutiempo.net/rss/" + id + ".xml";
                    XmlDocument doc = GetDocument(url);
                    //writer.Write(doc.OuterXml);

                }

                else if (idCapital == 14)
                {
                    string id = "55743";
                    string url = "http://xml.tutiempo.net/rss/" + id + ".xml";
                    XmlDocument doc = GetDocument(url);
                    //writer.Write(doc.OuterXml);

                }
            }
            this.Close();
            //writer.Write(doc.OuterXml);
        }

        private XmlDocument GetDocument(string feedUrl)
        {
            return CreateDocument(feedUrl);
        }

        private XmlDocument CreateDocument(string feedUrl)
        {
            XmlDocument doc = new XmlDocument();
            XmlNode docNode = doc.CreateXmlDeclaration("1.0", "UTF-16", null);
            doc.AppendChild(docNode);

            XmlNode rssNode = doc.CreateElement("rss");
            doc.AppendChild(rssNode);

            XmlNode channelNode = doc.CreateElement("channel");
            rssNode.AppendChild(channelNode);
            XmlDocument feed = GetFeed(feedUrl);
            if (feed != null)
            {
                rssNode.AppendChild(NormalizeNode(doc, feed.SelectSingleNode("rss/channel/title"), "title", 100));
                XmlNodeList items = feed.SelectNodes("rss/channel/item");
                //for (int i = 0; i < 3; ++i)
                //{

                //if (items[i] != null)
                //{
                try
                {



                    XmlNode itemNode = doc.CreateElement("item");
                    channelNode.AppendChild(itemNode);

                  
                        string regiones = "Arica";

                        XmlNode region = doc.CreateElement("region");
                        region.InnerText = regiones.ToString();
                        itemNode.AppendChild(region);
                  

                    int hoy = 0;
                    int mañana = 1;
                    int proximo = 2;

                    if (hoy == 0)
                    {
                        XmlNode fecha = doc.CreateElement("fechaHoy");
                        fecha.InnerText = "Hoy";
                        itemNode.AppendChild(fecha);

                        //Nodo Temperatura Max
                        XmlNode temperaturaMax = doc.CreateElement("temperaturaMaxHoy");
                        temperaturaMax.InnerText = items[hoy].SelectSingleNode("description").InnerText;

                        string cadenaTempMax = temperaturaMax.InnerText;

                        if (!string.IsNullOrEmpty(cadenaTempMax))
                        {
                            //unicode no aceptado

                            cadenaTempMax = cadenaTempMax.Replace("&deg;", "°");



                            temperaturaMax.InnerText = cadenaTempMax.ToString();

                            if (cadenaTempMax.Contains("<img height="))
                            {

                                //Quitar elementos!!!

                                const string HTML_TAG_PATTERN = "<.*?>";

                                string r = Regex.Replace(cadenaTempMax, HTML_TAG_PATTERN, string.Empty);


                                string init = r.ToString().IndexOf(" y ").ToString();
                                string end = r.ToString().IndexOf("máxima").ToString();
                                temperaturaMax.InnerText = r.ToString().Remove(Convert.ToInt32(init)).ToString().Remove(0, Convert.ToInt32(end));


                                string modificado = temperaturaMax.InnerText;
                                string intmodificado = modificado.ToString().IndexOf(" de ").ToString();

                                temperaturaMax.InnerText = modificado.ToString().Remove(0, (Convert.ToInt32(intmodificado)) + 4).Replace("°C","");

                            }
                        }


                        itemNode.AppendChild(temperaturaMax);

                        //TemperaturaMin

                        XmlNode temperaturaMin = doc.CreateElement("temperaturaMinHoy");
                        temperaturaMin.InnerText = items[hoy].SelectSingleNode("description").InnerText;

                        string cadenaTempMin = temperaturaMin.InnerText;

                        if (!string.IsNullOrEmpty(cadenaTempMin))
                        {
                            //unicode no aceptado

                            cadenaTempMin = cadenaTempMin.Replace("&deg;", "°");



                            temperaturaMin.InnerText = cadenaTempMin.ToString();

                            if (cadenaTempMin.Contains("<img height="))
                            {

                                //Quitar elementos!!!

                                const string HTML_TAG_PATTERN = "<.*?>";

                                string r = Regex.Replace(cadenaTempMax, HTML_TAG_PATTERN, string.Empty);


                                string init = r.ToString().IndexOf(".").ToString();
                                string end = r.ToString().IndexOf("mínima").ToString();
                                temperaturaMin.InnerText = r.ToString().Remove(Convert.ToInt32(init)).ToString().Remove(0, Convert.ToInt32(end));

                                string modificado = temperaturaMin.InnerText;
                                string intmodificado = modificado.ToString().IndexOf(" de ").ToString();

                                temperaturaMin.InnerText = modificado.ToString().Remove(0, (Convert.ToInt32(intmodificado)) + 4).Replace("°C", " ");

                            }
                        }


                        itemNode.AppendChild(temperaturaMin);

                        XmlNode imagen = doc.CreateElement("imagenHoy");
                        string img1 = items[hoy].SelectSingleNode("description").InnerText.IndexOf("src=").ToString();
                        string img2 = items[hoy].SelectSingleNode("description").InnerText.IndexOf(".png").ToString();
                        imagen.InnerText = items[hoy].SelectSingleNode("description").InnerText.Remove(Convert.ToInt32(img2) + 4).ToString().Remove(0, Convert.ToInt32(img1) + 5);

                        if (imagen.InnerText == "http://i5.tutiempo.net/wi/01/20/1.png")
                        {
                            imagen.InnerText = "../Imagenes/Pronosticos/1.png";
                        }

                        else if (imagen.InnerText == "http://i5.tutiempo.net/wi/01/20/2.png")
                        {

                            imagen.InnerText = "../Imagenes/Pronosticos/2.png";

                        }
                        else if (imagen.InnerText == "http://i5.tutiempo.net/wi/01/20/3.png")
                        {

                            imagen.InnerText = "../Imagenes/Pronosticos/3.png";

                        }
                        else if (imagen.InnerText == "http://i5.tutiempo.net/wi/01/20/4.png")
                        {

                            imagen.InnerText = "../Imagenes/Pronosticos/4.png";

                        }
                        else if (imagen.InnerText == "http://i5.tutiempo.net/wi/01/20/5.png")
                        {

                            imagen.InnerText = "../Imagenes/Pronosticos/5.png";

                        }
                        else if (imagen.InnerText == "http://i5.tutiempo.net/wi/01/20/6.png")
                        {

                            imagen.InnerText = "../Imagenes/Pronosticos/6.png";

                        }
                        else if (imagen.InnerText == "http://i5.tutiempo.net/wi/01/20/7.png")
                        {

                            imagen.InnerText = "../Imagenes/Pronosticos/7.png";

                        }
                        else if (imagen.InnerText == "http://i5.tutiempo.net/wi/01/20/8.png")
                        {

                            imagen.InnerText = "../Imagenes/Pronosticos/8.png";

                        }
                        else if (imagen.InnerText == "http://i5.tutiempo.net/wi/01/20/9.png")
                        {

                            imagen.InnerText = "../Imagenes/Pronosticos/9.png";

                        }
                        else if (imagen.InnerText == "http://i5.tutiempo.net/wi/01/20/10.png")
                        {

                            imagen.InnerText = "../Imagenes/Pronosticos/10.png";

                        }
                        else if (imagen.InnerText == "http://i5.tutiempo.net/wi/01/20/11.png")
                        {

                            imagen.InnerText = "../Imagenes/Pronosticos/12.png";

                        }
                        else if (imagen.InnerText == "http://i5.tutiempo.net/wi/01/20/12.png")
                        {

                            imagen.InnerText = "../Imagenes/Pronosticos/12.png";

                        }
                        else if (imagen.InnerText == "http://i5.tutiempo.net/wi/01/20/13.png")
                        {

                            imagen.InnerText = "../Imagenes/Pronosticos/13.png";

                        }
                        else if (imagen.InnerText == "http://i5.tutiempo.net/wi/01/20/14.png")
                        {

                            imagen.InnerText = "../Imagenes/Pronosticos/14.png";

                        }
                        else if (imagen.InnerText == "http://i5.tutiempo.net/wi/01/20/15.png")
                        {

                            imagen.InnerText = "../Imagenes/Pronosticos/15.png";

                        }
                        else if (imagen.InnerText == "http://i5.tutiempo.net/wi/01/20/16.png")
                        {

                            imagen.InnerText = "../Imagenes/Pronosticos/16.png";

                        }
                        else if (imagen.InnerText == "http://i5.tutiempo.net/wi/01/20/17.png")
                        {

                            imagen.InnerText = "../Imagenes/Pronosticos/17.png";

                        }
                        else if (imagen.InnerText == "http://i5.tutiempo.net/wi/01/20/18.png")
                        {

                            imagen.InnerText = "../Imagenes/Pronosticos/18.png";

                        }
                        else if (imagen.InnerText == "http://i5.tutiempo.net/wi/01/20/19.png")
                        {

                            imagen.InnerText = "../Imagenes/Pronosticos/19.png";

                        }
                        else if (imagen.InnerText == "http://i5.tutiempo.net/wi/01/20/20.png")
                        {

                            imagen.InnerText = "../Imagenes/Pronosticos/20.png";

                        }
                        else if (imagen.InnerText == "http://i5.tutiempo.net/wi/01/20/21.png")
                        {

                            imagen.InnerText = "../Imagenes/Pronosticos/21.png";

                        }
                        else if (imagen.InnerText == "http://i5.tutiempo.net/wi/01/20/22.png")
                        {

                            imagen.InnerText = "../Imagenes/Pronosticos/22.png";

                        }
                        else if (imagen.InnerText == "http://i5.tutiempo.net/wi/01/20/23.png")
                        {

                            imagen.InnerText = "../Imagenes/Pronosticos/23.png";

                        }
                        else if (imagen.InnerText == "http://i5.tutiempo.net/wi/01/20/24.png")
                        {

                            imagen.InnerText = "../Imagenes/Pronosticos/24.png";

                        }
                        else if (imagen.InnerText == "http://i5.tutiempo.net/wi/01/20/25.png")
                        {

                            imagen.InnerText = "../Imagenes/Pronosticos/25.png";

                        }
                        else if (imagen.InnerText == "http://i5.tutiempo.net/wi/01/20/26.png")
                        {

                            imagen.InnerText = "../Imagenes/Pronosticos/26.png";

                        }
                        else if (imagen.InnerText == "http://i5.tutiempo.net/wi/01/20/27.png")
                        {

                            imagen.InnerText = "../Imagenes/Pronosticos/27.png";

                        }
                        else if (imagen.InnerText == "http://i5.tutiempo.net/wi/01/20/28.png")
                        {

                            imagen.InnerText = "../Imagenes/Pronosticos/28.png";

                        }
                        else if (imagen.InnerText == "http://i5.tutiempo.net/wi/01/20/29.png")
                        {

                            imagen.InnerText = "../Imagenes/Pronosticos/29.png";

                        }
                        else if (imagen.InnerText == "http://i5.tutiempo.net/wi/01/20/30.png")
                        {

                            imagen.InnerText = "../Imagenes/Pronosticos/30.png";

                        }
                        else if (imagen.InnerText == "http://i5.tutiempo.net/wi/01/20/31.png")
                        {

                            imagen.InnerText = "../Imagenes/Pronosticos/31.png";

                        }
                        else if (imagen.InnerText == "http://i5.tutiempo.net/wi/01/20/32.png")
                        {

                            imagen.InnerText = "../Imagenes/Pronosticos/32.png";

                        }
                        else if (imagen.InnerText == "http://i5.tutiempo.net/wi/01/20/33.png")
                        {

                            imagen.InnerText = "../Imagenes/Pronosticos/33.png";

                        }
                        else if (imagen.InnerText == "http://i5.tutiempo.net/wi/01/20/34.png")
                        {

                            imagen.InnerText = "../Imagenes/Pronosticos/34.png";

                        }
                        itemNode.AppendChild(imagen);

                    }

                    if (mañana == 1)
                    {

                        XmlNode fecha = doc.CreateElement("fechaMañana");
                        fecha.InnerText = "Mañana";
                        itemNode.AppendChild(fecha);
                        //Nodo Temperatura Max
                        XmlNode temperaturaMax = doc.CreateElement("temperaturaMaxMañana");
                        temperaturaMax.InnerText = items[mañana].SelectSingleNode("description").InnerText;

                        string cadenaTempMax = temperaturaMax.InnerText;

                        if (!string.IsNullOrEmpty(cadenaTempMax))
                        {
                            //unicode no aceptado

                            cadenaTempMax = cadenaTempMax.Replace("&deg;", "°");



                            temperaturaMax.InnerText = cadenaTempMax.ToString();

                            if (cadenaTempMax.Contains("<img height="))
                            {

                                //Quitar elementos!!!

                                const string HTML_TAG_PATTERN = "<.*?>";

                                string r = Regex.Replace(cadenaTempMax, HTML_TAG_PATTERN, string.Empty);


                                string init = r.ToString().IndexOf(" y ").ToString();
                                string end = r.ToString().IndexOf("máxima").ToString();
                                temperaturaMax.InnerText = r.ToString().Remove(Convert.ToInt32(init)).ToString().Remove(0, Convert.ToInt32(end));

                                string modificado = temperaturaMax.InnerText;
                                string intmodificado = modificado.ToString().IndexOf(" de ").ToString();

                                temperaturaMax.InnerText = modificado.ToString().Remove(0, (Convert.ToInt32(intmodificado)) + 4).Replace("°C","");
                            }
                        }


                        itemNode.AppendChild(temperaturaMax);

                        //TemperaturaMin

                        XmlNode temperaturaMin = doc.CreateElement("temperaturaMinMañana");
                        temperaturaMin.InnerText = items[mañana].SelectSingleNode("description").InnerText;

                        string cadenaTempMin = temperaturaMin.InnerText;

                        if (!string.IsNullOrEmpty(cadenaTempMin))
                        {
                            //unicode no aceptado

                            cadenaTempMin = cadenaTempMin.Replace("&deg;", "°");



                            temperaturaMin.InnerText = cadenaTempMin.ToString();

                            if (cadenaTempMin.Contains("<img height="))
                            {

                                //Quitar elementos!!!

                                const string HTML_TAG_PATTERN = "<.*?>";

                                string r = Regex.Replace(cadenaTempMax, HTML_TAG_PATTERN, string.Empty);


                                string init = r.ToString().IndexOf(".").ToString();
                                string end = r.ToString().IndexOf("mínima").ToString();
                                temperaturaMin.InnerText = r.ToString().Remove(Convert.ToInt32(init)).ToString().Remove(0, Convert.ToInt32(end));

                                string modificado = temperaturaMin.InnerText;
                                string intmodificado = modificado.ToString().IndexOf(" de ").ToString();

                                temperaturaMin.InnerText = modificado.ToString().Remove(0, (Convert.ToInt32(intmodificado)) + 4).Replace("°C", " ");
                            }
                        }


                        itemNode.AppendChild(temperaturaMin);

                        XmlNode imagen = doc.CreateElement("imagenMañana");
                        string img1 = items[mañana].SelectSingleNode("description").InnerText.IndexOf("src=").ToString();
                        string img2 = items[mañana].SelectSingleNode("description").InnerText.IndexOf(".png").ToString();
                        imagen.InnerText = items[mañana].SelectSingleNode("description").InnerText.Remove(Convert.ToInt32(img2) + 4).ToString().Remove(0, Convert.ToInt32(img1) + 5);

                        if (imagen.InnerText == "http://i5.tutiempo.net/wi/01/20/1.png")
                        {
                            imagen.InnerText = "../Imagenes/Pronosticos/1.png";
                        }

                        else if (imagen.InnerText == "http://i5.tutiempo.net/wi/01/20/2.png")
                        {

                            imagen.InnerText = "../Imagenes/Pronosticos/2.png";

                        }
                        else if (imagen.InnerText == "http://i5.tutiempo.net/wi/01/20/3.png")
                        {

                            imagen.InnerText = "../Imagenes/Pronosticos/3.png";

                        }
                        else if (imagen.InnerText == "http://i5.tutiempo.net/wi/01/20/4.png")
                        {

                            imagen.InnerText = "../Imagenes/Pronosticos/4.png";

                        }
                        else if (imagen.InnerText == "http://i5.tutiempo.net/wi/01/20/5.png")
                        {

                            imagen.InnerText = "../Imagenes/Pronosticos/5.png";

                        }
                        else if (imagen.InnerText == "http://i5.tutiempo.net/wi/01/20/6.png")
                        {

                            imagen.InnerText = "../Imagenes/Pronosticos/6.png";

                        }
                        else if (imagen.InnerText == "http://i5.tutiempo.net/wi/01/20/7.png")
                        {

                            imagen.InnerText = "../Imagenes/Pronosticos/7.png";

                        }
                        else if (imagen.InnerText == "http://i5.tutiempo.net/wi/01/20/8.png")
                        {

                            imagen.InnerText = "../Imagenes/Pronosticos/8.png";

                        }
                        else if (imagen.InnerText == "http://i5.tutiempo.net/wi/01/20/9.png")
                        {

                            imagen.InnerText = "../Imagenes/Pronosticos/9.png";

                        }
                        else if (imagen.InnerText == "http://i5.tutiempo.net/wi/01/20/10.png")
                        {

                            imagen.InnerText = "../Imagenes/Pronosticos/10.png";

                        }
                        else if (imagen.InnerText == "http://i5.tutiempo.net/wi/01/20/11.png")
                        {

                            imagen.InnerText = "../Imagenes/Pronosticos/12.png";

                        }
                        else if (imagen.InnerText == "http://i5.tutiempo.net/wi/01/20/12.png")
                        {

                            imagen.InnerText = "../Imagenes/Pronosticos/12.png";

                        }
                        else if (imagen.InnerText == "http://i5.tutiempo.net/wi/01/20/13.png")
                        {

                            imagen.InnerText = "../Imagenes/Pronosticos/13.png";

                        }
                        else if (imagen.InnerText == "http://i5.tutiempo.net/wi/01/20/14.png")
                        {

                            imagen.InnerText = "../Imagenes/Pronosticos/14.png";

                        }
                        else if (imagen.InnerText == "http://i5.tutiempo.net/wi/01/20/15.png")
                        {

                            imagen.InnerText = "../Imagenes/Pronosticos/15.png";

                        }
                        else if (imagen.InnerText == "http://i5.tutiempo.net/wi/01/20/16.png")
                        {

                            imagen.InnerText = "../Imagenes/Pronosticos/16.png";

                        }
                        else if (imagen.InnerText == "http://i5.tutiempo.net/wi/01/20/17.png")
                        {

                            imagen.InnerText = "../Imagenes/Pronosticos/17.png";

                        }
                        else if (imagen.InnerText == "http://i5.tutiempo.net/wi/01/20/18.png")
                        {

                            imagen.InnerText = "../Imagenes/Pronosticos/18.png";

                        }
                        else if (imagen.InnerText == "http://i5.tutiempo.net/wi/01/20/19.png")
                        {

                            imagen.InnerText = "../Imagenes/Pronosticos/19.png";

                        }
                        else if (imagen.InnerText == "http://i5.tutiempo.net/wi/01/20/20.png")
                        {

                            imagen.InnerText = "../Imagenes/Pronosticos/20.png";

                        }
                        else if (imagen.InnerText == "http://i5.tutiempo.net/wi/01/20/21.png")
                        {

                            imagen.InnerText = "../Imagenes/Pronosticos/21.png";

                        }
                        else if (imagen.InnerText == "http://i5.tutiempo.net/wi/01/20/22.png")
                        {

                            imagen.InnerText = "../Imagenes/Pronosticos/22.png";

                        }
                        else if (imagen.InnerText == "http://i5.tutiempo.net/wi/01/20/23.png")
                        {

                            imagen.InnerText = "../Imagenes/Pronosticos/23.png";

                        }
                        else if (imagen.InnerText == "http://i5.tutiempo.net/wi/01/20/24.png")
                        {

                            imagen.InnerText = "../Imagenes/Pronosticos/24.png";

                        }
                        else if (imagen.InnerText == "http://i5.tutiempo.net/wi/01/20/25.png")
                        {

                            imagen.InnerText = "../Imagenes/Pronosticos/25.png";

                        }
                        else if (imagen.InnerText == "http://i5.tutiempo.net/wi/01/20/26.png")
                        {

                            imagen.InnerText = "../Imagenes/Pronosticos/26.png";

                        }
                        else if (imagen.InnerText == "http://i5.tutiempo.net/wi/01/20/27.png")
                        {

                            imagen.InnerText = "../Imagenes/Pronosticos/27.png";

                        }
                        else if (imagen.InnerText == "http://i5.tutiempo.net/wi/01/20/28.png")
                        {

                            imagen.InnerText = "../Imagenes/Pronosticos/28.png";

                        }
                        else if (imagen.InnerText == "http://i5.tutiempo.net/wi/01/20/29.png")
                        {

                            imagen.InnerText = "../Imagenes/Pronosticos/29.png";

                        }
                        else if (imagen.InnerText == "http://i5.tutiempo.net/wi/01/20/30.png")
                        {

                            imagen.InnerText = "../Imagenes/Pronosticos/30.png";

                        }
                        else if (imagen.InnerText == "http://i5.tutiempo.net/wi/01/20/31.png")
                        {

                            imagen.InnerText = "../Imagenes/Pronosticos/31.png";

                        }
                        else if (imagen.InnerText == "http://i5.tutiempo.net/wi/01/20/32.png")
                        {

                            imagen.InnerText = "../Imagenes/Pronosticos/32.png";

                        }
                        else if (imagen.InnerText == "http://i5.tutiempo.net/wi/01/20/33.png")
                        {

                            imagen.InnerText = "../Imagenes/Pronosticos/33.png";

                        }
                        else if (imagen.InnerText == "http://i5.tutiempo.net/wi/01/20/34.png")
                        {

                            imagen.InnerText = "../Imagenes/Pronosticos/34.png";

                        }
                        itemNode.AppendChild(imagen);

                    }

                    if (proximo == 2)
                    {

                        XmlNode fecha = doc.CreateElement("fechaProximo");
                        string initFecha = items[proximo].SelectSingleNode("title").InnerText.IndexOf("-").ToString();

                        fecha.InnerText = items[proximo].SelectSingleNode("title").InnerText.Remove(0, Convert.ToInt32(initFecha) + 2);
                        string endFecha = fecha.InnerText.IndexOf(" ").ToString();
                        string fechaLimpia = fecha.InnerText.Remove(Convert.ToInt32(endFecha));
                        fecha.InnerText = fechaLimpia.ToString();
                        itemNode.AppendChild(fecha);

                        //Nodo Temperatura Max
                        XmlNode temperaturaMax = doc.CreateElement("temperaturaMaxProximo");
                        temperaturaMax.InnerText = items[proximo].SelectSingleNode("description").InnerText;

                        string cadenaTempMax = temperaturaMax.InnerText;

                        if (!string.IsNullOrEmpty(cadenaTempMax))
                        {
                            //unicode no aceptado

                            cadenaTempMax = cadenaTempMax.Replace("&deg;", "°");



                            temperaturaMax.InnerText = cadenaTempMax.ToString();

                            if (cadenaTempMax.Contains("<img height="))
                            {

                                //Quitar elementos!!!

                                const string HTML_TAG_PATTERN = "<.*?>";

                                string r = Regex.Replace(cadenaTempMax, HTML_TAG_PATTERN, string.Empty);


                                string init = r.ToString().IndexOf(" y ").ToString();
                                string end = r.ToString().IndexOf("máxima").ToString();
                                temperaturaMax.InnerText = r.ToString().Remove(Convert.ToInt32(init)).ToString().Remove(0, Convert.ToInt32(end));

                                string modificado = temperaturaMax.InnerText;
                                string intmodificado = modificado.ToString().IndexOf(" de ").ToString();

                                temperaturaMax.InnerText = modificado.ToString().Remove(0, (Convert.ToInt32(intmodificado)) + 4).Replace("°C","");

                            }
                        }


                        itemNode.AppendChild(temperaturaMax);

                        //TemperaturaMin

                        XmlNode temperaturaMin = doc.CreateElement("temperaturaMinProximo");
                        temperaturaMin.InnerText = items[proximo].SelectSingleNode("description").InnerText;

                        string cadenaTempMin = temperaturaMin.InnerText;

                        if (!string.IsNullOrEmpty(cadenaTempMin))
                        {
                            //unicode no aceptado

                            cadenaTempMin = cadenaTempMin.Replace("&deg;", "°");



                            temperaturaMin.InnerText = cadenaTempMin.ToString();

                            if (cadenaTempMin.Contains("<img height="))
                            {

                                //Quitar elementos!!!

                                const string HTML_TAG_PATTERN = "<.*?>";

                                string r = Regex.Replace(cadenaTempMax, HTML_TAG_PATTERN, string.Empty);


                                string init = r.ToString().IndexOf(".").ToString();
                                string end = r.ToString().IndexOf("mínima").ToString();
                                temperaturaMin.InnerText = r.ToString().Remove(Convert.ToInt32(init)).ToString().Remove(0, Convert.ToInt32(end));

                                string modificado = temperaturaMin.InnerText;
                                string intmodificado = modificado.ToString().IndexOf(" de ").ToString();

                                temperaturaMin.InnerText = modificado.ToString().Remove(0, (Convert.ToInt32(intmodificado)) + 4).Replace("°C", " ");

                            }
                        }


                        itemNode.AppendChild(temperaturaMin);

                        XmlNode imagen = doc.CreateElement("imagenProximo");
                        string img1 = items[proximo].SelectSingleNode("description").InnerText.IndexOf("src=").ToString();
                        string img2 = items[proximo].SelectSingleNode("description").InnerText.IndexOf(".png").ToString();
                        imagen.InnerText = items[proximo].SelectSingleNode("description").InnerText.Remove(Convert.ToInt32(img2) + 4).ToString().Remove(0, Convert.ToInt32(img1) + 5);
                        if (imagen.InnerText == "http://i5.tutiempo.net/wi/01/20/1.png")
                        {
                            imagen.InnerText = "../Imagenes/Pronosticos/1.png";
                        }

                        else if (imagen.InnerText == "http://i5.tutiempo.net/wi/01/20/2.png")
                        {

                            imagen.InnerText = "../Imagenes/Pronosticos/2.png";

                        }
                        else if (imagen.InnerText == "http://i5.tutiempo.net/wi/01/20/3.png")
                        {

                            imagen.InnerText = "../Imagenes/Pronosticos/3.png";

                        }
                        else if (imagen.InnerText == "http://i5.tutiempo.net/wi/01/20/4.png")
                        {

                            imagen.InnerText = "../Imagenes/Pronosticos/4.png";

                        }
                        else if (imagen.InnerText == "http://i5.tutiempo.net/wi/01/20/5.png")
                        {

                            imagen.InnerText = "../Imagenes/Pronosticos/5.png";

                        }
                        else if (imagen.InnerText == "http://i5.tutiempo.net/wi/01/20/6.png")
                        {

                            imagen.InnerText = "../Imagenes/Pronosticos/6.png";

                        }
                        else if (imagen.InnerText == "http://i5.tutiempo.net/wi/01/20/7.png")
                        {

                            imagen.InnerText = "../Imagenes/Pronosticos/7.png";

                        }
                        else if (imagen.InnerText == "http://i5.tutiempo.net/wi/01/20/8.png")
                        {

                            imagen.InnerText = "../Imagenes/Pronosticos/8.png";

                        }
                        else if (imagen.InnerText == "http://i5.tutiempo.net/wi/01/20/9.png")
                        {

                            imagen.InnerText = "../Imagenes/Pronosticos/9.png";

                        }
                        else if (imagen.InnerText == "http://i5.tutiempo.net/wi/01/20/10.png")
                        {

                            imagen.InnerText = "../Imagenes/Pronosticos/10.png";

                        }
                        else if (imagen.InnerText == "http://i5.tutiempo.net/wi/01/20/11.png")
                        {

                            imagen.InnerText = "../Imagenes/Pronosticos/12.png";

                        }
                        else if (imagen.InnerText == "http://i5.tutiempo.net/wi/01/20/12.png")
                        {

                            imagen.InnerText = "../Imagenes/Pronosticos/12.png";

                        }
                        else if (imagen.InnerText == "http://i5.tutiempo.net/wi/01/20/13.png")
                        {

                            imagen.InnerText = "../Imagenes/Pronosticos/13.png";

                        }
                        else if (imagen.InnerText == "http://i5.tutiempo.net/wi/01/20/14.png")
                        {

                            imagen.InnerText = "../Imagenes/Pronosticos/14.png";

                        }
                        else if (imagen.InnerText == "http://i5.tutiempo.net/wi/01/20/15.png")
                        {

                            imagen.InnerText = "../Imagenes/Pronosticos/15.png";

                        }
                        else if (imagen.InnerText == "http://i5.tutiempo.net/wi/01/20/16.png")
                        {

                            imagen.InnerText = "../Imagenes/Pronosticos/16.png";

                        }
                        else if (imagen.InnerText == "http://i5.tutiempo.net/wi/01/20/17.png")
                        {

                            imagen.InnerText = "../Imagenes/Pronosticos/17.png";

                        }
                        else if (imagen.InnerText == "http://i5.tutiempo.net/wi/01/20/18.png")
                        {

                            imagen.InnerText = "../Imagenes/Pronosticos/18.png";

                        }
                        else if (imagen.InnerText == "http://i5.tutiempo.net/wi/01/20/19.png")
                        {

                            imagen.InnerText = "../Imagenes/Pronosticos/19.png";

                        }
                        else if (imagen.InnerText == "http://i5.tutiempo.net/wi/01/20/20.png")
                        {

                            imagen.InnerText = "../Imagenes/Pronosticos/20.png";

                        }
                        else if (imagen.InnerText == "http://i5.tutiempo.net/wi/01/20/21.png")
                        {

                            imagen.InnerText = "../Imagenes/Pronosticos/21.png";

                        }
                        else if (imagen.InnerText == "http://i5.tutiempo.net/wi/01/20/22.png")
                        {

                            imagen.InnerText = "../Imagenes/Pronosticos/22.png";

                        }
                        else if (imagen.InnerText == "http://i5.tutiempo.net/wi/01/20/23.png")
                        {

                            imagen.InnerText = "../Imagenes/Pronosticos/23.png";

                        }
                        else if (imagen.InnerText == "http://i5.tutiempo.net/wi/01/20/24.png")
                        {

                            imagen.InnerText = "../Imagenes/Pronosticos/24.png";

                        }
                        else if (imagen.InnerText == "http://i5.tutiempo.net/wi/01/20/25.png")
                        {

                            imagen.InnerText = "../Imagenes/Pronosticos/25.png";

                        }
                        else if (imagen.InnerText == "http://i5.tutiempo.net/wi/01/20/26.png")
                        {

                            imagen.InnerText = "../Imagenes/Pronosticos/26.png";

                        }
                        else if (imagen.InnerText == "http://i5.tutiempo.net/wi/01/20/27.png")
                        {

                            imagen.InnerText = "../Imagenes/Pronosticos/27.png";

                        }
                        else if (imagen.InnerText == "http://i5.tutiempo.net/wi/01/20/28.png")
                        {

                            imagen.InnerText = "../Imagenes/Pronosticos/28.png";

                        }
                        else if (imagen.InnerText == "http://i5.tutiempo.net/wi/01/20/29.png")
                        {

                            imagen.InnerText = "../Imagenes/Pronosticos/29.png";

                        }
                        else if (imagen.InnerText == "http://i5.tutiempo.net/wi/01/20/30.png")
                        {

                            imagen.InnerText = "../Imagenes/Pronosticos/30.png";

                        }
                        else if (imagen.InnerText == "http://i5.tutiempo.net/wi/01/20/31.png")
                        {

                            imagen.InnerText = "../Imagenes/Pronosticos/31.png";

                        }
                        else if (imagen.InnerText == "http://i5.tutiempo.net/wi/01/20/32.png")
                        {

                            imagen.InnerText = "../Imagenes/Pronosticos/32.png";

                        }
                        else if (imagen.InnerText == "http://i5.tutiempo.net/wi/01/20/33.png")
                        {

                            imagen.InnerText = "../Imagenes/Pronosticos/33.png";

                        }
                        else if (imagen.InnerText == "http://i5.tutiempo.net/wi/01/20/34.png")
                        {

                            imagen.InnerText = "../Imagenes/Pronosticos/34.png";

                        }
                        itemNode.AppendChild(imagen);

                    }




                }

                catch (Exception e)
                {



                }



                //}
                //}
            }
            //items[hoy].SelectSingleNode("description").InnerText;
          
            
            string fechaHoy = doc.SelectSingleNode("rss/channel/item/fechaHoy").InnerText.ToString();
            string temperaturaMaxHoy = doc.SelectSingleNode("rss/channel/item/temperaturaMaxHoy").InnerText.ToString();
            string temperaturaMinHoy = doc.SelectSingleNode("rss/channel/item/temperaturaMinHoy").InnerText.ToString();
            string imagenHoy = doc.SelectSingleNode("rss/channel/item/imagenHoy").InnerText.ToString();
            string fechaMañana = doc.SelectSingleNode("rss/channel/item/fechaMañana").InnerText.ToString();
            string temperaturaMaxMañana = doc.SelectSingleNode("rss/channel/item/temperaturaMaxMañana").InnerText.ToString();
            string temperaturaMinMañana = doc.SelectSingleNode("rss/channel/item/temperaturaMinMañana").InnerText.ToString();
            string imagenMañana = doc.SelectSingleNode("rss/channel/item/imagenMañana").InnerText.ToString();
            string fechaProximo = doc.SelectSingleNode("rss/channel/item/fechaProximo").InnerText.ToString();
            string temperaturaMaxProximo = doc.SelectSingleNode("rss/channel/item/temperaturaMaxProximo").InnerText.ToString();
            string temperaturaMinProximo = doc.SelectSingleNode("rss/channel/item/temperaturaMinProximo").InnerText.ToString();
            string imagenProximo = doc.SelectSingleNode("rss/channel/item/imagenProximo").InnerText.ToString();
            string fechaIngreso = DateTime.Now.Day.ToString() + "-" + DateTime.Now.Month.ToString() + "-" + DateTime.Now.Year.ToString();
            string Region = doc.SelectSingleNode("rss/title").InnerText.ToString().Remove(0, 13);
            Conexion obj = new Conexion();

            obj.Insertar_Tiempo(fechaHoy, temperaturaMaxHoy, temperaturaMinHoy, imagenHoy, fechaMañana, temperaturaMaxMañana, temperaturaMinMañana, imagenMañana, fechaProximo,
                                temperaturaMaxProximo, temperaturaMinProximo, imagenProximo, fechaIngreso,Region);

            return doc;
            
        }

        private XmlDocument GetFeed(string feedUrl)
        {
            // Create a request for the URL. 		
            WebRequest request = WebRequest.Create(feedUrl);
            // If required by the server, set the credentials.
            request.Credentials = CredentialCache.DefaultCredentials;
            // Get the response.

            HttpWebResponse response = null;
            XmlDocument doc = null;
            try
            {
                response = (HttpWebResponse)request.GetResponse();

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    Stream dataStream = response.GetResponseStream();
                    doc = new XmlDocument();
                    doc.Load(dataStream);
                    dataStream.Close();
                }
            }
            catch (Exception e)
            {
                emailFeed.Email.sendEmail("mescalona@smartboxtv.com,afaundez@smartboxtv.com,rcortes@smartboxtv.com", e, "Form1");
              
                this.Close();
            }
            finally
            {
                if (response != null)
                    response.Close();
            }

            return doc;
        }

        const string HTML_TAG_PATTERN = "<.*?>";


        string NormalizeText(string t, int maxChars)
        {
            string r = Regex.Replace(t, HTML_TAG_PATTERN, string.Empty);
            if (r.Length > maxChars)
                r = r.Substring(0, maxChars);
            return r;
        }

        XmlNode NormalizeNode(XmlDocument destination, XmlNode node, string title, int maxChars)
        {
            XmlNode newNode = destination.CreateElement(title);
            if (node != null)
                newNode.InnerText = NormalizeText(node.InnerText, maxChars);
            return newNode;
        }

        private string setFecha(string fecha)
        {
            DateTime fechaPub = DateTime.Parse(fecha);

            CultureInfo ci = new CultureInfo("Es-CL");



            string mes = ci.DateTimeFormat.GetMonthName(fechaPub.Month);
            mes = mes.Replace(mes.Substring(0, 1), mes.Substring(0, 1).ToUpper());
            string dia_Semana = ci.DateTimeFormat.GetDayName(fechaPub.DayOfWeek);
            dia_Semana = dia_Semana.Replace(dia_Semana.Substring(0, 1), dia_Semana.Substring(0, 1).ToUpper());
            string dias = fechaPub.Day.ToString();
            string año = fechaPub.Year.ToString();




            return dia_Semana + " , " + dias + " " + "de" + " " + mes + " " + "de" + " " + año;
        }

        public HtmlDocument writer { get; set; }

        public object feedUrl { get; set; }
    }
}
