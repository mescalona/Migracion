using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.Text.RegularExpressions;

namespace Jugadores
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(getSourceCode("http://www.mundial2014.com/selecciones/"));
            //Console.WriteLine(getSourceCodeCalendarioFechas("http://www.mundial2014.com/resultados/"));
            Console.WriteLine(getSourceCodeEquipos("http://www.mundial2014.com/resultados/"));
            Console.WriteLine(getSourceCodeTablas("http://www.marcadores.com/futbol/internacional/mundial/clasificacion.html"));
            //Console.ReadLine();
        }

        private static string getSourceCode(string uri)
        {
            string sourceCode = "";
            try
            {
                //Expresión regular
                //string pattern = "<li>(.*)<a>(.*)<\\/a><\\/li>";
                string regularJugadores = "<a class=[^>]*?>(?<TagText>.*?)</span>";
                //string regularDemarcacion = "<span class=[^>]*?>(?<TagText>.*?)</a>";

                ////

                //Equipos Mundial

                string[] arrEquipos = new string[]
                {   "brasil",
                    "croacia",
                    "mexico",
                    "camerun",
                    "espana",
                    "holanda",
                    "chile",
                    "australia",
                    "colombia",
                    "grecia",
                    "costa-de-marfil",
                    "japon",
                    "uruguay",
                    "costa-rica",
                    "inglaterra",
                    "italia",
                    "suiza",
                    "ecuador",
                    "francia",
                    "honduras",
                    "argentina",
                    "bosnia-herzegovina",
                    "iran",
                    "nigeria",
                    "alemania",
                    "portugal",
                    "ghana",
                    "estados-unidos",
                    "belgica",
                    "argelia",
                    "rusia",
                    "corea-del-sur",
                   
                };
                //Id Equipos!!
                string[] arrId = new string[]
                {   "187",
                    "194",
                    "207",
                    "188",
                    "196",
                    "201",
                    "189",
                    "184",
                    "190",
                    "200",
                    "192",
                    "206",
                    "214",
                    "193",
                    "203",
                    "205",
                    "213",
                    "195",
                    "198",
                    "202",
                    "183",
                    "186",
                    "204",
                    "208",
                    "181",
                    "211",
                    "199",
                    "197",
                    "185",
                    "182",
                    "212",
                    "191"
                   
                };


                int increment = 0;

                for (int i = 0; i < 32; i++)
                {



                    uri = uri + arrEquipos[increment];

                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
                    HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                    StreamReader sr = new StreamReader(response.GetResponseStream());
                    string data = sr.ReadToEnd();
                    MatchCollection jugadores = Regex.Matches(data, regularJugadores);

                    //Foreach Jugadores
                    foreach (Match item in jugadores)
                    {
                       
                     
                        string datos = item.Groups["TagText"].Value.Replace("</a><span class=\"plantilla-tercera-columna\">", "-");

                        int count = datos.IndexOf("-");

                        string title = datos.Remove(count).ToString();
                        string posicion = datos.Remove(0, count + 1).ToString();
                        int countPosicion = posicion.IndexOf("-");
                        posicion = posicion.Remove(0, countPosicion + 1).ToString();
                        string pais = arrEquipos[increment];
                        string id = arrId[increment];

                        
                        //Console.WriteLine(posicion);
                        Console.WriteLine(title+"  "+posicion+"  "+arrEquipos[increment]);

                        //Insertar jugadores

                        conexion obj = new conexion();
                        obj.InsertJugadores(title, posicion, "0", pais,id);



                    }


                  
                    increment++;
                    sourceCode = sr.ReadToEnd();
                    sr.Close();
                    response.Close();

                    uri = "http://www.mundial2014.com/selecciones/";
                }
          
                return sourceCode;
               
            }
            catch
            { 
                sourceCode = "ERROR"; 
            }
            return sourceCode;
        }

        private static string getSourceCodeCalendarioFechas(string uri)
        {
            string sourceCode = "";
            try
            {
                //Expresión regular
                //string regularGrupos = "<section>(.*)<\\/section>";
                string regularFechas = "<span class=\"resultados-fecha-dia\">(?<TagText>.*?)</span>";
                string regularHoras = "<time class=[^>]*?>(?<TagText>.*?)</time>";
                string regularHorasSegundaFase = "<span class=\"resultados-fecha-hora\">(?<TagText>.*?)</span>";
                string regularEquiposLocal = "<span itemprop=\"name\" class=\"local\">(?<TagText>.*?)</span>";
                string regularEquiposVisita = "<span itemprop=\"name\" class=\"visitante\">(?<TagText>.*?)</span>";
                string regularEquiposLocalFaseFinal = " <li class=\"resultados-resultado\"><span class=\"local\">(?<TagText>.*?)</span>";
                string regularEquiposVisitaFaseFinal = "<span class=\"ban-res-int res-bandera\"><span class=\"visitante\">(?<TagText>.*?)</span>";
                ////

                //Equipos Mundial

                string[] arrEquipos = new string[]
                {   "brasil",
                    "croacia",
                    "mexico",
                    "camerun",
                    "espana",
                    "holanda",
                    "chile",
                    "australia",
                    "colombia",
                    "grecia",
                    "costa-de-marfil",
                    "japon",
                    "uruguay",
                    "costa-rica",
                    "inglaterra",
                    "italia",
                    "suiza",
                    "ecuador",
                    "francia",
                    "honduras",
                    "argentina",
                    "bosnia-herzegovina",
                    "iran",
                    "nigeria",
                    "alemania",
                    "portugal",
                    "ghana",
                    "estados-unidos",
                    "belgica",
                    "argelia",
                    "rusia",
                    "corea-del-sur",
                   
                };
                //Id Equipos!!
                string[] arrId = new string[]
                {   "187",
                    "194",
                    "207",
                    "188",
                    "196",
                    "201",
                    "189",
                    "184",
                    "190",
                    "200",
                    "192",
                    "206",
                    "214",
                    "193",
                    "203",
                    "205",
                    "213",
                    "195",
                    "198",
                    "202",
                    "183",
                    "186",
                    "204",
                    "208",
                    "181",
                    "211",
                    "199",
                    "197",
                    "185",
                    "182",
                    "212",
                    "191"
                   
                };


                int increment = 0;

                //for (int i = 0; i < 32; i++)
                //{



                    //uri = uri + arrEquipos[increment];

                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
                    HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                    StreamReader sr = new StreamReader(response.GetResponseStream());
                    string datos = sr.ReadToEnd();
             
                    MatchCollection calendario = Regex.Matches(datos, regularFechas);
                    MatchCollection horarios = Regex.Matches(datos, regularHoras);
                    MatchCollection horariosFinales = Regex.Matches(datos, regularHorasSegundaFase);
                    MatchCollection equipoA = Regex.Matches(datos, regularEquiposLocal);
                    MatchCollection equipoB = Regex.Matches(datos, regularEquiposVisita);
                    MatchCollection equipoAfinales = Regex.Matches(datos, regularEquiposLocalFaseFinal);
                    MatchCollection equipoBfinales = Regex.Matches(datos, regularEquiposVisitaFaseFinal);

                    //Foreach Fechas
                    foreach (Match item in calendario)
                    {


                        string Fecha = item.Groups["TagText"].Value.Replace("<span class=\"resultados-fecha-dia\">", "").Replace("/","-")+"-2014";

                       
                        Console.WriteLine(Fecha+" "+increment);


                        conexion obj = new conexion();
                        //Insertar Fechas
                        obj.InsertFechasPartidos(Fecha, increment);

                        increment++;

                    }

                    increment = 0;
                    //Foreach Horas
                    foreach (Match item in horarios)
                    {


                        string Hora = item.Groups["TagText"].Value.Replace("<span class=\"resultados-fecha-dia\">", "").Replace("/", "-");

                     

                        conexion obj = new conexion();
                        //Insertar Hora
                        obj.InsertHorario(Hora,increment);

                        increment++;

                    }

                    //Foreach HorasFinales
                    foreach (Match item in horariosFinales)
                    {


                        string HoraFinal = item.Groups["TagText"].Value.Replace("<span class=\"resultados-fecha-dia\">", "").Replace("/", "-") ;

                        //int count = Fecha.IndexOf("-");

                        Console.WriteLine(HoraFinal + " " + increment);

                        //Insertar jugadores

                        conexion obj = new conexion();
                        //Insertar HorarioFinales
                        obj.InsertHorariosFinales(HoraFinal,increment);

                        increment++;

                    }
                   
                    sourceCode = sr.ReadToEnd();
                    sr.Close();
                    response.Close();


                return sourceCode;

            }
            catch
            {
                sourceCode = "ERROR";
            }
            return sourceCode;
        }

        private static string getSourceCodeEquipos(string uri)
        {
            string sourceCode = "";
            try
            {
                //Expresión regular
               
                string regularEquiposLocal = "<span itemprop=\"name\" class=\"local\">(?<TagText>.*?)</span>";
                string regularEquiposVisita = "<span itemprop=\"name\" class=\"visitante\">(?<TagText>.*?)</span>";
                string regularEquiposLocalFaseFinal = " <li class=\"resultados-resultado\"><span class=\"local\">(?<TagText>.*?)</span>";
                string regularEquiposVisitaFaseFinal = "<span class=\"ban-res-int res-bandera\"><span class=\"visitante\">(?<TagText>.*?)</span>";
                ////

            


                int increment = 0;
                int idEquipo=0;
                int idGrupo = 0;


                

                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                StreamReader sr = new StreamReader(response.GetResponseStream());
                string datos = sr.ReadToEnd();

                
                MatchCollection equipoA = Regex.Matches(datos, regularEquiposLocal);
                MatchCollection equipoB = Regex.Matches(datos, regularEquiposVisita);
                MatchCollection equipoAfinales = Regex.Matches(datos, regularEquiposLocalFaseFinal);
                MatchCollection equipoBfinales = Regex.Matches(datos, regularEquiposVisitaFaseFinal);

                #region Foreach EquipoA
                foreach (Match item in equipoA)
                {


                    string EquipoA = item.Groups["TagText"].Value.Replace("<span itemprop=\"name\" class=\"local\">", "");


                    Console.WriteLine(EquipoA);
                    #region Equipos
                    string imgA ="";
                    if (EquipoA == "Brasil")
                    {
                        imgA = "http://footstats.com.br/logos/brasil.png";
                        idEquipo = 187;
                        idGrupo = 109;
                    }
                    else if (EquipoA == "Alemania")
                    {
                        imgA = "http://footstats.com.br/logos/alemanha.png";
                        idEquipo = 181;
                        idGrupo = 115;
                    }
                    else if (EquipoA == "Argelia")
                    {
                        imgA = "http://footstats.com.br/logos/argelia.png";
                        idEquipo = 182;
                        idGrupo = 116;
                    }
                    else if (EquipoA == "Argentina")
                    {
                        imgA = "http://footstats.com.br/logos/argentina.png";
                        idEquipo = 183;
                        idGrupo = 114;
                    }
                    else if (EquipoA == "Australia")
                    {
                        imgA = "http://footstats.com.br/logos/australia.png";
                        idEquipo = 184;
                        idGrupo = 110;
                    }
                    else if (EquipoA == "Autralia")
                    {
                        EquipoA = "Australia";
                        imgA = "http://footstats.com.br/logos/australia.png";
                        idEquipo = 184;
                        idGrupo = 110;
                    }
                   
                    else if (EquipoA == "Bélgica")
                    {
                        imgA = "http://footstats.com.br/logos/belgica.png";
                        idEquipo = 185;
                        idGrupo = 116;
                    }
                    else if (EquipoA == "Bosnia")
                    {
                        imgA = "http://footstats.com.br/logos/boznia_herzegovina.png";
                        idEquipo = 186;
                        idGrupo = 114;
                    }
                    else if (EquipoA == "Bosnia")
                    {
                        imgA = "http://footstats.com.br/logos/boznia_herzegovina.png";
                        idEquipo = 186;
                        idGrupo = 114;
                    }
                    else if (EquipoA == "Camerún")
                    {
                        imgA = "http://footstats.com.br/logos/camaroes.png";
                        idEquipo = 188;
                        idGrupo = 109;
                    }
                    else if (EquipoA == "Colombia")
                    {
                        imgA = "http://footstats.com.br/logos/colombia.png";
                        idEquipo = 190;
                        idGrupo = 111;
                    }
                    else if (EquipoA == "Corea Sur")
                    {
                        imgA = "http://footstats.com.br/logos/coreia_do_sul.png";
                        idEquipo = 191;
                        idGrupo = 116;
                    }
                    else if (EquipoA == "Costa de Marfil")
                    {
                        imgA = "http://footstats.com.br/logos/costa_do_marfim.png";
                        idEquipo = 192;
                        idGrupo = 111;
                    }
                    else if (EquipoA == "Costa Rica")
                    {
                        imgA = "http://footstats.com.br/logos/costa_rica.png";
                        idEquipo = 193;
                        idGrupo = 112;
                    }
                    else if (EquipoA == "Croacia")
                    {
                        imgA = "http://footstats.com.br/logos/croacia.png";
                        idEquipo = 194;
                        idGrupo = 109;
                    }
                    else if (EquipoA == "Chile")
                    {
                        imgA = "http://footstats.com.br/logos/chile.png";
                        idEquipo = 189;
                        idGrupo = 110;
                    }
                    else if (EquipoA == "Ecuador")
                    {
                        imgA = "http://footstats.com.br/logos/equador.png";
                        idEquipo = 195;
                        idGrupo = 113;
                    }
                    else if (EquipoA == "España")
                    {
                        imgA = "http://footstats.com.br/logos/espanha.png";
                        idEquipo = 196;
                        idGrupo = 110;
                    }
                    else if (EquipoA == "Francia")
                    {
                        imgA = "http://footstats.com.br/logos/franca.png";
                        idEquipo = 198;
                        idGrupo = 113;
                    }
                    else if (EquipoA == "Ghana")
                    {
                        imgA = "http://footstats.com.br/logos/gana.png";
                        idEquipo = 199;
                        idGrupo = 115;
                    }
                    else if (EquipoA == "Grecia")
                    {
                        imgA = "http://footstats.com.br/logos/grecia.png";
                        idEquipo = 200;
                        idGrupo = 111;
                    }
                    else if (EquipoA == "Holanda")
                    {
                        imgA = "http://footstats.com.br/logos/holanda.png";
                        idEquipo = 201;
                        idGrupo = 110;
                    }
                    else if (EquipoA == "Honduras")
                    {
                        imgA = "http://footstats.com.br/logos/honduras.png";
                        idEquipo = 202;
                        idGrupo = 113;
                    }
                    else if (EquipoA == "Inglaterra")
                    {
                        imgA = "http://footstats.com.br/logos/inglaterra.png";
                        idEquipo = 203;
                        idGrupo = 112;
                    }
                    else if (EquipoA == "Iran")
                    {
                        EquipoA = "Irán";
                        imgA = "http://footstats.com.br/logos/Ira.png";
                        idEquipo = 204;
                        idGrupo = 114;
                    }
                    else if (EquipoA == "Irán")
                    {
                        imgA = "http://footstats.com.br/logos/Ira.png";
                        idEquipo = 204;
                    }
                    else if (EquipoA == "Italia")
                    {
                        imgA = "http://footstats.com.br/logos/italia.png";
                        idEquipo = 205;
                        idGrupo = 112;
                    }
                    else if (EquipoA == "Japón")
                    {
                        imgA = "http://footstats.com.br/logos/Japao.png";
                        idEquipo = 206;
                        idGrupo = 111;
                    }
                    else if (EquipoA == "México")
                    {
                        imgA = "http://footstats.com.br/logos/mexico.png";
                        idEquipo = 207;
                        idGrupo = 109;
                    }
                    else if (EquipoA == "Nigeria")
                    {
                        imgA = "http://footstats.com.br/logos/Nigeria.png";
                        idEquipo = 208;
                        idGrupo = 114;
                    }
                    else if (EquipoA == "Portugal")
                    {
                        imgA = "http://footstats.com.br/logos/portugal.png";
                        idEquipo = 211;
                        idGrupo = 115;
                    }
                    else if (EquipoA == "Rusia")
                    {
                        imgA = "http://footstats.com.br/logos/russia.png";
                        idEquipo = 212;
                        idGrupo = 116;
                    }
                    else if (EquipoA == "Suiza")
                    {
                        imgA = "http://footstats.com.br/logos/suica.png";
                        idEquipo = 213;
                        idGrupo = 113;
                    }
                    else if (EquipoA == "Uruguay")
                    {
                        imgA = "http://footstats.com.br/logos/uruguai.png";
                        idEquipo = 214;
                        idGrupo = 112;
                    }
                    else if (EquipoA == "USA")
                    {
                        imgA = "http://footstats.com.br/logos/eua.png";
                        idEquipo = 197;
                        idGrupo = 115;
                    }
                    else if (EquipoA == "''" || EquipoA == "") 
                    {
                        imgA = "http://190.215.44.18/img/Holder.png";
                        idGrupo = 0;
                    }
                    else
                    {
                        imgA = "http://190.215.44.18/img/Holder.png";
                        idGrupo = 115;
                    }
                    #endregion
                    conexion obj = new conexion();
                    //Insertar EquipoA
                    obj.InsertEquipoA(EquipoA,imgA,idEquipo,idGrupo,increment);

                    increment++;

                }
                    #endregion

                increment = 0;
                #region Foreach EquipoB
                foreach (Match item in equipoB)
                {


                    string EquipoB = item.Groups["TagText"].Value.Replace("<span itemprop=\"name\" class=\"visitante\">", "");


                    Console.WriteLine(EquipoB);
                    #region equipos
                    //Equipos
                    string imgB = "";
                    if (EquipoB == "Brasil")
                    {
                        imgB = "http://footstats.com.br/logos/brasil.png";
                        idEquipo = 187;
                        idGrupo = 109;
                    }
                    else if (EquipoB == "Alemania")
                    {
                        imgB = "http://footstats.com.br/logos/alemanha.png";
                        idEquipo = 181;
                        idGrupo = 115;
                    }
                    else if (EquipoB == "Argelia")
                    {
                        imgB = "http://footstats.com.br/logos/argelia.png";
                        idEquipo = 182;
                        idGrupo = 116;
                    }
                    else if (EquipoB == "Argentina")
                    {
                        imgB = "http://footstats.com.br/logos/argentina.png";
                        idEquipo = 183;
                        idGrupo = 114;
                    }
                    else if (EquipoB == "Australia")
                    {
                        imgB = "http://footstats.com.br/logos/australia.png";
                        idEquipo = 184;
                        idGrupo = 110;
                    }
                    else if (EquipoB == "Autralia")
                    {
                        EquipoB = "Australia";
                        imgB = "http://footstats.com.br/logos/australia.png";
                        idEquipo = 184;
                        idGrupo = 110;
                    }

                    else if (EquipoB == "Bélgica")
                    {
                        imgB = "http://footstats.com.br/logos/belgica.png";
                        idEquipo = 185;
                        idGrupo = 116;
                    }
                    else if (EquipoB == "Bosnia")
                    {
                        imgB = "http://footstats.com.br/logos/boznia_herzegovina.png";
                        idEquipo = 186;
                        idGrupo = 114;
                    }
                    else if (EquipoB == "Bosnia")
                    {
                        imgB = "http://footstats.com.br/logos/boznia_herzegovina.png";
                        idEquipo = 186;
                        idGrupo = 114;
                    }
                    else if (EquipoB == "Camerún")
                    {
                        imgB = "http://footstats.com.br/logos/camaroes.png";
                        idEquipo = 188;
                        idGrupo = 109;
                    }
                    else if (EquipoB == "Colombia")
                    {
                        imgB = "http://footstats.com.br/logos/colombia.png";
                        idEquipo = 190;
                        idGrupo = 111;
                    }
                    else if (EquipoB == "Corea Sur")
                    {
                        imgB = "http://footstats.com.br/logos/coreia_do_sul.png";
                        idEquipo = 191;
                        idGrupo = 116;
                    }
                    else if (EquipoB == "Costa de Marfil")
                    {
                        imgB = "http://footstats.com.br/logos/costa_do_marfim.png";
                        idEquipo = 192;
                        idGrupo = 111;
                    }
                    else if (EquipoB == "Costa Rica")
                    {
                        imgB = "http://footstats.com.br/logos/costa_rica.png";
                        idEquipo = 193;
                        idGrupo = 112;
                    }
                    else if (EquipoB == "Croacia")
                    {
                        imgB = "http://footstats.com.br/logos/croacia.png";
                        idEquipo = 194;
                        idGrupo = 109;
                    }
                    else if (EquipoB == "Chile")
                    {
                        imgB = "http://footstats.com.br/logos/chile.png";
                        idEquipo = 189;
                        idGrupo = 110;
                    }
                    else if (EquipoB == "Ecuador")
                    {
                        imgB = "http://footstats.com.br/logos/equador.png";
                        idEquipo = 195;
                        idGrupo = 113;

                    }
                    else if (EquipoB == "España")
                    {
                        imgB = "http://footstats.com.br/logos/espanha.png";
                        idEquipo = 196;
                        idGrupo = 110;
                    }
                    else if (EquipoB == "Francia")
                    {
                        imgB = "http://footstats.com.br/logos/franca.png";
                        idEquipo = 198;
                        idGrupo = 113;
                    }
                    else if (EquipoB == "Ghana")
                    {
                        imgB = "http://footstats.com.br/logos/gana.png";
                        idEquipo = 199;
                        idGrupo = 115;
                    }
                    else if (EquipoB == "Grecia")
                    {
                        imgB = "http://footstats.com.br/logos/grecia.png";
                        idEquipo = 200;
                        idGrupo = 111;
                    }
                    else if (EquipoB == "Holanda")
                    {
                        imgB = "http://footstats.com.br/logos/holanda.png";
                        idEquipo = 201;
                        idGrupo = 110;
                    }
                    else if (EquipoB == "Honduras")
                    {
                        imgB = "http://footstats.com.br/logos/honduras.png";
                        idEquipo = 202;
                        idGrupo = 113;
                    }
                    else if (EquipoB == "Inglaterra")
                    {
                        imgB = "http://footstats.com.br/logos/inglaterra.png";
                        idEquipo = 203;
                        idGrupo = 112;
                    }
                    else if (EquipoB == "Iran")
                    {
                        EquipoB = "Irán";
                        imgB = "http://footstats.com.br/logos/Ira.png";
                        idEquipo = 204;
                        idGrupo = 114;
                    }
                    else if (EquipoB == "Irán")
                    {
                        imgB = "http://footstats.com.br/logos/Ira.png";
                        idEquipo = 204;
                        idGrupo = 114;
                    }
                    else if (EquipoB == "Italia")
                    {
                        imgB = "http://footstats.com.br/logos/italia.png";
                        idEquipo = 205;
                        idGrupo = 112;
                    }
                    else if (EquipoB == "Japón")
                    {
                        imgB = "http://footstats.com.br/logos/Japao.png";
                        idEquipo = 206;
                        idGrupo = 111;
                    }
                    else if (EquipoB == "México")
                    {
                        imgB = "http://footstats.com.br/logos/mexico.png";
                        idEquipo = 207;
                        idGrupo = 109;
                    }
                    else if (EquipoB == "Nigeria")
                    {
                        imgB = "http://footstats.com.br/logos/Nigeria.png";
                        idEquipo = 208;
                        idGrupo = 114;
                    }
                    else if (EquipoB == "Portugal")
                    {
                        imgB = "http://footstats.com.br/logos/portugal.png";
                        idEquipo = 211;
                        idGrupo = 115;
                    }
                    else if (EquipoB == "Rusia")
                    {
                        imgB = "http://footstats.com.br/logos/russia.png";
                        idEquipo = 212;
                        idGrupo = 116;
                    }
                    else if (EquipoB == "Suiza")
                    {
                        imgB = "http://footstats.com.br/logos/suica.png";
                        idEquipo = 213;
                        idGrupo = 113;
                    }
                    else if (EquipoB == "Uruguay")
                    {
                        imgB = "http://footstats.com.br/logos/uruguai.png";
                        idEquipo = 214;
                        idGrupo = 112;
                    }
                    else if (EquipoB == "USA")
                    {
                        imgB = "http://footstats.com.br/logos/eua.png";
                        idEquipo = 197;
                        idGrupo = 115;
                    }
                    else if (EquipoB == "''" || EquipoB == "")
                    {
                        imgB = "http://190.215.44.18/img/Holder.png";
                        idGrupo = 0;
                    }
                    else
                    {
                        imgB = "http://190.215.44.18/img/Holder.png";
                        idGrupo = 0;
                    }
                    #endregion
                    conexion obj = new conexion();
                    //Insertar EquipoB
                    obj.InsertEquipoB(EquipoB, imgB,idEquipo,idGrupo,increment);

                    increment++;

                }
                #endregion

                #region Foreach LocalFaseFinal
                foreach (Match item in equipoAfinales)
                {


                    string equipoAFinal = item.Groups["TagText"].Value.Replace("<li class=\"resultados-resultado\"><span class=\"local\">", "");

                    //int count = Fecha.IndexOf("-");

                    Console.WriteLine(equipoAFinal);

                    #region Equipos A finales
                    string imgA = "";
                    if (equipoAFinal == "Brasil")
                    {
                        imgA = "http://footstats.com.br/logos/brasil.png";
                        idEquipo = 187;
                        idGrupo = 109;
                    }
                    else if (equipoAFinal == "Alemania")
                    {
                        imgA = "http://footstats.com.br/logos/alemanha.png";
                        idEquipo = 181;
                        idGrupo = 115;
                    }
                    else if (equipoAFinal == "Argelia")
                    {
                        imgA = "http://footstats.com.br/logos/argelia.png";
                        idEquipo = 182;
                        idGrupo = 116;
                    }
                    else if (equipoAFinal == "Argentina")
                    {
                        imgA = "http://footstats.com.br/logos/argentina.png";
                        idEquipo = 183;
                        idGrupo = 114;
                    }
                    else if (equipoAFinal == "Australia")
                    {
                        imgA = "http://footstats.com.br/logos/australia.png";
                        idEquipo = 184;
                    }
                    else if (equipoAFinal == "Autralia")
                    {
                        equipoAFinal = "Australia";
                        imgA = "http://footstats.com.br/logos/australia.png";
                        idEquipo = 184;
                        idGrupo = 110;
                    }

                    else if (equipoAFinal == "Bélgica")
                    {
                        imgA = "http://footstats.com.br/logos/belgica.png";
                        idEquipo = 185;
                        idGrupo = 116;
                    }
                    else if (equipoAFinal == "Bosnia")
                    {
                        imgA = "http://footstats.com.br/logos/boznia_herzegovina.png";
                        idEquipo = 186;
                        idGrupo = 114;
                    }
                    else if (equipoAFinal == "Bosnia")
                    {
                        imgA = "http://footstats.com.br/logos/boznia_herzegovina.png";
                        idEquipo = 186;
                        idGrupo = 114;
                    }
                    else if (equipoAFinal == "Camerún")
                    {
                        imgA = "http://footstats.com.br/logos/camaroes.png";
                        idEquipo = 188;
                        idGrupo = 109;
                    }
                    else if (equipoAFinal == "Colombia")
                    {
                        imgA = "http://footstats.com.br/logos/colombia.png";
                        idEquipo = 190;
                        idGrupo = 111;
                    }
                    else if (equipoAFinal == "Corea Sur")
                    {
                        imgA = "http://footstats.com.br/logos/coreia_do_sul.png";
                        idEquipo = 191;
                        idGrupo = 116;
                    }
                    else if (equipoAFinal == "Costa de Marfil")
                    {
                        imgA = "http://footstats.com.br/logos/costa_do_marfim.png";
                        idEquipo = 192;
                        idGrupo = 111;
                    }
                    else if (equipoAFinal == "Costa Rica")
                    {
                        imgA = "http://footstats.com.br/logos/costa_rica.png";
                        idEquipo = 193;
                        idGrupo = 112;
                    }
                    else if (equipoAFinal == "Croacia")
                    {
                        imgA = "http://footstats.com.br/logos/croacia.png";
                        idEquipo = 194;
                        idGrupo = 109;
                    }
                    else if (equipoAFinal == "Chile")
                    {
                        imgA = "http://footstats.com.br/logos/chile.png";
                        idEquipo = 189;
                        idGrupo = 110;
                    }
                    else if (equipoAFinal == "Ecuador")
                    {
                        imgA = "http://footstats.com.br/logos/equador.png";
                        idEquipo = 195;
                        idGrupo = 113;
                    }
                    else if (equipoAFinal == "España")
                    {
                        imgA = "http://footstats.com.br/logos/espanha.png";
                        idEquipo = 196;
                        idGrupo = 110;
                    }
                    else if (equipoAFinal == "Francia")
                    {
                        imgA = "http://footstats.com.br/logos/franca.png";
                        idEquipo = 198;
                        idGrupo = 113;
                    }
                    else if (equipoAFinal == "Ghana")
                    {
                        imgA = "http://footstats.com.br/logos/gana.png";
                        idEquipo = 199;
                        idGrupo = 115;
                    }
                    else if (equipoAFinal == "Grecia")
                    {
                        imgA = "http://footstats.com.br/logos/grecia.png";
                        idEquipo = 200;
                        idGrupo = 111;
                    }
                    else if (equipoAFinal == "Holanda")
                    {
                        imgA = "http://footstats.com.br/logos/holanda.png";
                        idEquipo = 201;
                        idGrupo = 110;
                    }
                    else if (equipoAFinal == "Honduras")
                    {
                        imgA = "http://footstats.com.br/logos/honduras.png";
                        idEquipo = 202;
                        idGrupo = 113;
                    }
                    else if (equipoAFinal == "Inglaterra")
                    {
                        imgA = "http://footstats.com.br/logos/inglaterra.png";
                        idEquipo = 203;
                        idGrupo = 112;
                    }
                    else if (equipoAFinal == "Iran")
                    {
                        equipoAFinal = "Irán";
                        imgA = "http://footstats.com.br/logos/Ira.png";
                        idEquipo = 204;
                        idGrupo = 114;
                    }
                    else if (equipoAFinal == "Irán")
                    {
                        imgA = "http://footstats.com.br/logos/Ira.png";
                        idEquipo = 204;
                        idGrupo = 114;
                    }
                    else if (equipoAFinal == "Italia")
                    {
                        imgA = "http://footstats.com.br/logos/italia.png";
                        idEquipo = 205;
                        idGrupo = 112;
                    }
                    else if (equipoAFinal == "Japón")
                    {
                        imgA = "http://footstats.com.br/logos/Japao.png";
                        idEquipo = 206;
                        idGrupo = 111;
                    }
                    else if (equipoAFinal == "México")
                    {
                        imgA = "http://footstats.com.br/logos/mexico.png";
                        idEquipo = 207;
                        idGrupo = 109;
                    }
                    else if (equipoAFinal == "Nigeria")
                    {
                        imgA = "http://footstats.com.br/logos/Nigeria.png";
                        idEquipo = 208;
                        idGrupo = 114;
                    }
                    else if (equipoAFinal == "Portugal")
                    {
                        imgA = "http://footstats.com.br/logos/portugal.png";
                        idEquipo = 211;
                        idGrupo = 115;
                    }
                    else if (equipoAFinal == "Rusia")
                    {
                        imgA = "http://footstats.com.br/logos/russia.png";
                        idEquipo = 212;
                        idGrupo = 116;
                    }
                    else if (equipoAFinal == "Suiza")
                    {
                        imgA = "http://footstats.com.br/logos/suica.png";
                        idEquipo = 213;
                        idGrupo = 113;
                    }
                    else if (equipoAFinal == "Uruguay")
                    {
                        imgA = "http://footstats.com.br/logos/uruguai.png";
                        idEquipo = 214;
                        idGrupo = 112;
                    }
                    else if (equipoAFinal == "USA")
                    {
                        imgA = "http://footstats.com.br/logos/eua.png";
                        idEquipo = 197;
                        idGrupo = 115;
                    }
                    else if (equipoAFinal == "''" || equipoAFinal == "")
                    {
                        imgA = "http://190.215.44.18/img/Holder.png";
                        idEquipo = 0;
                        idGrupo = 0;
                    }
                    else
                    {
                        imgA = "http://190.215.44.18/img/Holder.png";
                        idEquipo = 0;
                        idGrupo = 0;
                    }
                    #endregion
                    //Insertar EquipoAFinal

                    conexion obj = new conexion();

                    obj.InsertEquipoFinalesA(equipoAFinal, imgA, idEquipo, idGrupo,increment);

                    increment++;

                }
                #endregion
                increment = 48;
                #region Foreach VisitaFaseFinal
                foreach (Match item in equipoBfinales)
                {


                    string equipoBFinal = item.Groups["TagText"].Value.Replace("<span class=\"ban-res-int res-bandera\"><span class=\"visitante\">", "");

                    //int count = Fecha.IndexOf("-");

                    Console.WriteLine(equipoBFinal);
                    #region Equipos
                    string imgB = "";
                    if (equipoBFinal == "Brasil")
                    {
                        imgB = "http://footstats.com.br/logos/brasil.png";
                        idEquipo = 187;
                        idGrupo = 109;
                    }
                    else if (equipoBFinal == "Alemania")
                    {
                        imgB = "http://footstats.com.br/logos/alemanha.png";
                        idEquipo = 181;
                        idGrupo = 115;
                    }
                    else if (equipoBFinal == "Argelia")
                    {
                        imgB = "http://footstats.com.br/logos/argelia.png";
                        idEquipo = 182;
                        idGrupo = 116;
                    }
                    else if (equipoBFinal == "Argentina")
                    {
                        imgB = "http://footstats.com.br/logos/argentina.png";
                        idEquipo = 183;
                        idGrupo = 114;
                    }
                    else if (equipoBFinal == "Australia")
                    {
                        imgB = "http://footstats.com.br/logos/australia.png";
                        idEquipo = 184;
                        idGrupo = 110;
                    }
                    else if (equipoBFinal == "Autralia")
                    {
                        equipoBFinal = "Australia";
                        imgB = "http://footstats.com.br/logos/australia.png";
                        idEquipo = 184;
                        idGrupo = 110;
                    }

                    else if (equipoBFinal == "Bélgica")
                    {
                        imgB = "http://footstats.com.br/logos/belgica.png";
                        idEquipo = 185;
                        idGrupo = 116;
                    }
                    else if (equipoBFinal == "Bosnia")
                    {
                        imgB = "http://footstats.com.br/logos/boznia_herzegovina.png";
                        idEquipo = 186;
                        idGrupo = 114;
                    }
                    else if (equipoBFinal == "Bosnia")
                    {
                        imgB = "http://footstats.com.br/logos/boznia_herzegovina.png";
                        idEquipo = 186;
                        idGrupo = 114;
                    }
                    else if (equipoBFinal == "Camerún")
                    {
                        imgB = "http://footstats.com.br/logos/camaroes.png";
                        idEquipo = 188;
                        idGrupo = 109;
                    }
                    else if (equipoBFinal == "Colombia")
                    {
                        imgB = "http://footstats.com.br/logos/colombia.png";
                        idEquipo = 190;
                        idGrupo = 111;
                    }
                    else if (equipoBFinal == "Corea Sur")
                    {
                        imgB = "http://footstats.com.br/logos/coreia_do_sul.png";
                        idEquipo = 191;
                        idGrupo = 116;
                    }
                    else if (equipoBFinal == "Costa de Marfil")
                    {
                        imgB = "http://footstats.com.br/logos/costa_do_marfim.png";
                        idEquipo = 192;
                        idGrupo = 111;
                    }
                    else if (equipoBFinal == "Costa Rica")
                    {
                        imgB = "http://footstats.com.br/logos/costa_rica.png";
                        idEquipo = 193;
                        idGrupo = 112;
                    }
                    else if (equipoBFinal == "Croacia")
                    {
                        imgB = "http://footstats.com.br/logos/croacia.png";
                        idEquipo = 194;
                        idGrupo = 109;
                    }
                    else if (equipoBFinal == "Chile")
                    {
                        imgB = "http://footstats.com.br/logos/chile.png";
                        idEquipo = 189;
                        idGrupo = 110;
                    }
                    else if (equipoBFinal == "Ecuador")
                    {
                        imgB = "http://footstats.com.br/logos/equador.png";
                        idEquipo = 195;
                        idGrupo = 113;
                    }
                    else if (equipoBFinal == "España")
                    {
                        imgB = "http://footstats.com.br/logos/espanha.png";
                        idEquipo = 196;
                        idGrupo = 110;
                    }
                    else if (equipoBFinal == "Francia")
                    {
                        imgB = "http://footstats.com.br/logos/franca.png";
                        idEquipo = 198;
                        idGrupo = 113;
                    }
                    else if (equipoBFinal == "Ghana")
                    {
                        imgB = "http://footstats.com.br/logos/gana.png";
                        idEquipo = 199;
                        idGrupo = 115;
                    }
                    else if (equipoBFinal == "Grecia")
                    {
                        imgB = "http://footstats.com.br/logos/grecia.png";
                        idEquipo = 200;
                        idGrupo = 111;
                    }
                    else if (equipoBFinal == "Holanda")
                    {
                        imgB = "http://footstats.com.br/logos/holanda.png";
                        idEquipo = 201;
                        idGrupo = 110;
                    }
                    else if (equipoBFinal == "Honduras")
                    {
                        imgB = "http://footstats.com.br/logos/honduras.png";
                        idEquipo = 202;
                        idGrupo = 113;
                    }
                    else if (equipoBFinal == "Inglaterra")
                    {
                        imgB = "http://footstats.com.br/logos/inglaterra.png";
                        idEquipo = 203;
                        idGrupo = 112;
                    }
                    else if (equipoBFinal == "Iran")
                    {
                        equipoBFinal = "Irán";
                        imgB = "http://footstats.com.br/logos/Ira.png";
                        idEquipo = 204;
                        idGrupo = 114;
                    }
                    else if (equipoBFinal == "Irán")
                    {
                        imgB = "http://footstats.com.br/logos/Ira.png";
                        idEquipo = 204;
                        idGrupo = 114;
                    }
                    else if (equipoBFinal == "Italia")
                    {
                        imgB = "http://footstats.com.br/logos/italia.png";
                        idEquipo = 205;
                        idGrupo = 112;
                    }
                    else if (equipoBFinal == "Japón")
                    {
                        imgB = "http://footstats.com.br/logos/Japao.png";
                        idEquipo = 206;
                        idGrupo = 111;
                    }
                    else if (equipoBFinal == "México")
                    {
                        imgB = "http://footstats.com.br/logos/mexico.png";
                        idEquipo = 207;
                        idGrupo = 109;
                    }
                    else if (equipoBFinal == "Nigeria")
                    {
                        imgB = "http://footstats.com.br/logos/Nigeria.png";
                        idEquipo = 208;
                        idGrupo = 114;
                    }
                    else if (equipoBFinal == "Portugal")
                    {
                        imgB = "http://footstats.com.br/logos/portugal.png";
                        idEquipo = 211;
                        idGrupo = 115;
                    }
                    else if (equipoBFinal == "Rusia")
                    {
                        imgB = "http://footstats.com.br/logos/russia.png";
                        idEquipo = 212;
                        idGrupo = 116;
                    }
                    else if (equipoBFinal == "Suiza")
                    {
                        imgB = "http://footstats.com.br/logos/suica.png";
                        idEquipo = 213;
                        idGrupo = 113;
                    }
                    else if (equipoBFinal == "Uruguay")
                    {
                        imgB = "http://footstats.com.br/logos/uruguai.png";
                        idEquipo = 214;
                        idGrupo = 112;
                    }
                    else if (equipoBFinal == "USA")
                    {
                        imgB = "http://footstats.com.br/logos/eua.png";
                        idEquipo = 197;
                        idGrupo = 115;
                    }
                    else if (equipoBFinal == "''" || equipoBFinal == "")
                    {
                        imgB = "http://190.215.44.18/img/Holder.png";
                        idEquipo = 0;
                        idGrupo = 0;
                    }
                    else
                    {
                        imgB = "http://190.215.44.18/img/Holder.png";
                        idEquipo = 0;
                        idGrupo = 0;
                    }
                    #endregion
                    //Insertar  EquipoBFinal

                    conexion obj = new conexion();
                    //Insertar EquipoBFinal
                    obj.InsertEquipoFinalesB(equipoBFinal,imgB,idEquipo,idGrupo,increment);

                    increment++;

                }
                #endregion
                sourceCode = sr.ReadToEnd();
                sr.Close();
                response.Close();


                return sourceCode;

            }
            catch
            {
                sourceCode = "ERROR";
            }
            return sourceCode;
        }

        private static string getSourceCodeTablas(string uri)
        {
            string retorno = "";
            try
            {
                string regularEquipos = "<td class=\"participant-name\">[^>]*?>(?<TagText>.*?)</td>";
                string regularPuntos = "<td class=\"standing-data standing-data-points\">(?<TagText>.*?)</td>";
                string regularJugados = "<td class=\"standing-data standing-data-played\">(?<TagText>.*?)</td>";
                string regularGanados = "<td class=\"standing-data standing-data-wins\">(?<TagText>.*?)</td>";
                string regularEmpatados = "<td class=\"standing-data standing-data-draws\">(?<TagText>.*?)</td>";
                string regularPerdidos = "<td class=\"standing-data standing-data-defeits\">(?<TagText>.*?)</td>";
                string regularGolesFavor = "<td class=\"standing-data standing-data-goalsfor\">(?<TagText>.*?)</td>";
                string regularGolesContra = "<td class=\"standing-data standing-data-goalsagainst\">(?<TagText>.*?)</td>";
                string regularDif = "<td class=\"standing-data standing-data-goalsdiff\">(?<TagText>.*?)</td>";
                //string regularGrupos = "<td class=\"participant-name\">[^>]*>(.*?)(?<TagText>.*?)</tr>"; 

                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                StreamReader sr = new StreamReader(response.GetResponseStream());
                string datos = sr.ReadToEnd();

                MatchCollection Equipos = Regex.Matches(datos, regularEquipos);
                MatchCollection Puntos = Regex.Matches(datos, regularPuntos);
                MatchCollection Jugados = Regex.Matches(datos, regularJugados);
                MatchCollection Ganados = Regex.Matches(datos, regularGanados);
                MatchCollection Empatados = Regex.Matches(datos, regularEmpatados);
                MatchCollection Perdidos = Regex.Matches(datos, regularPerdidos);
                MatchCollection GolesFavor = Regex.Matches(datos, regularGolesFavor);
                MatchCollection GolesContra = Regex.Matches(datos, regularGolesFavor);
                MatchCollection dif = Regex.Matches(datos, regularDif);
                conexion obj = new conexion();


                #region EQUIPOS!!
                int increment=1;
                foreach (Match item in Equipos)
                {
                    #region Equipos

                    string imgA = "";
                    string Equipo = item.Groups["TagText"].Value.Replace("<td class=\"participant-name\"><a  href=\"/futbol/francia/equipo-francia-8003846.html\"><span>", "").Replace("</span></a>", "").Replace("<span>","").Trim();
                    int idEquipo = 0;
                    int idGrupo = 0;

                    
                    if (Equipo == "Brasil")
                    {
                        imgA = "http://footstats.com.br/logos/brasil.png";
                        idEquipo = 187;
                        idGrupo = 109;
                    }
                    else if (Equipo == "Alemania")
                    {
                        imgA = "http://footstats.com.br/logos/alemanha.png";
                        idEquipo = 181;
                        idGrupo = 115;
                    }
                    else if (Equipo == "Argelia")
                    {
                        imgA = "http://footstats.com.br/logos/argelia.png";
                        idEquipo = 182;
                        idGrupo = 116;
                    }
                    else if (Equipo == "Argentina")
                    {
                        imgA = "http://footstats.com.br/logos/argentina.png";
                        idEquipo = 183;
                        idGrupo = 114;
                    }
                    else if (Equipo == "Australia")
                    {
                        imgA = "http://footstats.com.br/logos/australia.png";
                        idEquipo = 184;
                        idGrupo = 110;
                    }
                    else if (Equipo == "Autralia")
                    {
                        Equipo = "Australia";
                        imgA = "http://footstats.com.br/logos/australia.png";
                        idEquipo = 184;
                        idGrupo = 110;
                    }

                    else if (Equipo == "Bélgica")
                    {
                        imgA = "http://footstats.com.br/logos/belgica.png";
                        idEquipo = 185;
                        idGrupo = 116;
                    }
                    else if (Equipo == "Bosnia")
                    {
                        imgA = "http://footstats.com.br/logos/boznia_herzegovina.png";
                        idEquipo = 186;
                        idGrupo = 114;
                    }
                   
                    else if (Equipo == "Camerún")
                    {
                        imgA = "http://footstats.com.br/logos/camaroes.png";
                        idEquipo = 188;
                        idGrupo = 109;
                    }
                    else if (Equipo == "Colombia")
                    {
                        imgA = "http://footstats.com.br/logos/colombia.png";
                        idEquipo = 190;
                        idGrupo = 111;
                    }
                    else if (Equipo == "Corea del Sur")
                    {
                        imgA = "http://footstats.com.br/logos/coreia_do_sul.png";
                        idEquipo = 191;
                        idGrupo = 116;
                    }
                    else if (Equipo == "Costa de Marfil")
                    {
                        imgA = "http://footstats.com.br/logos/costa_do_marfim.png";
                        idEquipo = 192;
                        idGrupo = 111;
                    }
                    else if (Equipo == "Costa Rica")
                    {
                        imgA = "http://footstats.com.br/logos/costa_rica.png";
                        idEquipo = 193;
                        idGrupo = 112;
                    }
                    else if (Equipo == "Croacia")
                    {
                        imgA = "http://footstats.com.br/logos/croacia.png";
                        idEquipo = 194;
                        idGrupo = 109;
                    }
                    else if (Equipo == "Chile")
                    {
                        imgA = "http://footstats.com.br/logos/chile.png";
                        idEquipo = 189;
                        idGrupo = 110;
                    }
                    else if (Equipo == "Ecuador")
                    {
                        imgA = "http://footstats.com.br/logos/equador.png";
                        idEquipo = 195;
                        idGrupo = 113;
                    }
                    else if (Equipo == "España")
                    {
                        imgA = "http://footstats.com.br/logos/espanha.png";
                        idEquipo = 196;
                        idGrupo = 110;
                    }
                    else if (Equipo == "Francia")
                    {
                        imgA = "http://footstats.com.br/logos/franca.png";
                        idEquipo = 198;
                        idGrupo = 113;
                    }
                    else if (Equipo == "Ghana")
                    {
                        imgA = "http://footstats.com.br/logos/gana.png";
                        idEquipo = 199;
                        idGrupo = 115;
                    }
                    else if (Equipo == "Grecia")
                    {
                        imgA = "http://footstats.com.br/logos/grecia.png";
                        idEquipo = 200;
                        idGrupo = 111;
                    }
                    else if (Equipo == "Holanda")
                    {
                        imgA = "http://footstats.com.br/logos/holanda.png";
                        idEquipo = 201;
                        idGrupo = 110;
                    }
                    else if (Equipo == "Honduras")
                    {
                        imgA = "http://footstats.com.br/logos/honduras.png";
                        idEquipo = 202;
                        idGrupo = 113;
                    }
                    else if (Equipo == "Inglaterra")
                    {
                        imgA = "http://footstats.com.br/logos/inglaterra.png";
                        idEquipo = 203;
                        idGrupo = 112;
                    }
                    else if (Equipo == "Irán")
                    {
                        Equipo = "Irán";
                        imgA = "http://footstats.com.br/logos/Ira.png";
                        idEquipo = 204;
                        idGrupo = 114;
                    }
                   
                    else if (Equipo == "Italia")
                    {
                        imgA = "http://footstats.com.br/logos/italia.png";
                        idEquipo = 205;
                        idGrupo = 112;
                    }
                    else if (Equipo == "Japón")
                    {
                        imgA = "http://footstats.com.br/logos/Japao.png";
                        idEquipo = 206;
                        idGrupo = 111;
                    }
                    else if (Equipo == "México")
                    {
                        imgA = "http://footstats.com.br/logos/mexico.png";
                        idEquipo = 207;
                        idGrupo = 109;
                    }
                    else if (Equipo == "Nigeria")
                    {
                        imgA = "http://footstats.com.br/logos/Nigeria.png";
                        idEquipo = 208;
                        idGrupo = 114;
                    }
                    else if (Equipo == "Portugal")
                    {
                        imgA = "http://footstats.com.br/logos/portugal.png";
                        idEquipo = 211;
                        idGrupo = 115;
                    }
                    else if (Equipo == "Rusia")
                    {
                        imgA = "http://footstats.com.br/logos/russia.png";
                        idEquipo = 212;
                        idGrupo = 116;
                    }
                    else if (Equipo == "Suiza")
                    {
                        imgA = "http://footstats.com.br/logos/suica.png";
                        idEquipo = 213;
                        idGrupo = 113;
                    }
                    else if (Equipo == "Uruguay")
                    {
                        imgA = "http://footstats.com.br/logos/uruguai.png";
                        idEquipo = 214;
                        idGrupo = 112;
                    }
                    else if (Equipo == "EEUU")
                    {
                        imgA = "http://footstats.com.br/logos/eua.png";
                        idEquipo = 197;
                        idGrupo = 115;
                    }
                  
                  
                    //insert Grupo/Equipo!!
                    obj.InsertDatoTablasUno(idEquipo, idGrupo,increment);
                    increment++;
                    #endregion
                }
                #endregion
                Console.WriteLine("EQUIPOS TABLA");
                increment = 1;

                #region PUNTOS!!
                foreach (Match item in Puntos)
                {
                    #region Puntos
                    string puntos = item.Groups["TagText"].Value.Replace("<td class=\"standing-data standing-data-points\">", "").Replace("</td>", "").Trim();
                    obj.InsertDatoTablasDos(puntos,increment);
                    increment++;
                    #endregion

                }
                #endregion
                Console.WriteLine("PUNTOS TABLA");
                increment = 1;

                #region JUGADOS!!
                foreach (Match item in Jugados)
                {

                }
                #endregion

                #region GANADOS!!
                foreach (Match item in Ganados)
                {
                    #region Ganados
                    string Wins = item.Groups["TagText"].Value.Replace("<td class=\"standing-data standing-data-points\">", "").Replace("</td>", "").Trim();
                    obj.InsertDatoTablasTres(Wins, increment);
                    increment++;
                    #endregion
                }
                #endregion
                Console.WriteLine("GANADOS TABLA");
                increment = 1;

                #region EMPATADOS!!
                foreach (Match item in Empatados)
                {
                    #region Empatados
                    string empate = item.Groups["TagText"].Value.Replace("<td class=\"standing-data standing-data-points\">", "").Replace("</td>", "").Trim();
                    obj.InsertDatoTablasCuatro(empate, increment);
                    increment++;
                    #endregion
                }
                #endregion
                Console.WriteLine("EMPATADOS TABLA");
                increment = 1;

                #region PERDIDOS!!
                foreach (Match item in Perdidos)
                {
                    #region Perdidos
                    string perd = item.Groups["TagText"].Value.Replace("<td class=\"standing-data standing-data-points\">", "").Replace("</td>", "").Trim();
                    obj.InsertDatoTablasSeis(perd, increment);
                    increment++;
                    #endregion
                }
                #endregion
                Console.WriteLine("PERDIDOS TABLA");
                increment = 1;

                //#region GOLESFAVOR!!
                //foreach (Match item in GolesFavor)
                //{
                //}
                //#endregion

                //#region GOLESCONTRA!!
                //foreach (Match item in GolesContra)
                //{
                //}
                //#endregion

                #region DIF!!
                foreach (Match item in dif)
                {
                    #region Diferencia
                    string dife = item.Groups["TagText"].Value.Replace("<td class=\"standing-data standing-data-points\">", "").Replace("</td>", "").Trim();
                    obj.InsertDatoTablasCinco(dife, increment);
                    increment++;
                    #endregion
                }
                #endregion
                Console.WriteLine("DIF TABLA");
                increment = 1;
            }
            catch (Exception ex)
            { 
            }
            return retorno;
        }

    }
}
