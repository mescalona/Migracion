using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using Npgsql;
using System.Data;
using System.Globalization;

namespace Bot
{
    class Program
    {
        static void Main(string[] args)
        {
            int id = 1;
            int idProducto = 0;
            using (SqlConnection con = new SqlConnection(Conexion.cnxSushiHouse))
            using (NpgsqlConnection conn = new NpgsqlConnection(Conexion.cnxSushiSmart))
            {
                //
                // Open the SqlConnection.
                //
                con.Open();
                conn.Open();
                //

                //
                using (SqlCommand command = new SqlCommand
                    ("SELECT PROD.CODIGO,PROD.DESCRICORT,PROD.UNIDAD,PROD.BRUTO,PROD.DESPACHO,PROD.FOTO,GRUP.DESCRIPCIO, GRUP.CODIGO,GRAN.DESCRIPCIO,GRUP.GRANGRUPO,PROD.DESCWEB FROM dbo.PRODUCTOS PROD , dbo.GRANGRUPO GRAN , dbo.GRUPOS GRUP WHERE GRUP.GRANGRUPO=GRAN.CODIGO AND PROD.CODIGOGR=GRUP.CODIGO AND GRUP.GRANGRUPO != 'G08' AND PROD.BRUTO!=0 AND DESPACHO=1  UNION ALL  SELECT PROD.CODIGO,PROD.DESCRICORT,PROD.UNIDAD,PROD.BRUTO,PROD.DESPACHO,PROD.FOTO,GRUP.DESCRIPCIO, GRUP.CODIGO,GRAN.DESCRIPCIO,GRUP.GRANGRUPO,PROD.DESCWEB FROM dbo.PRODUCTOS PROD , dbo.GRANGRUPO GRAN , dbo.GRUPOS GRUP WHERE GRUP.GRANGRUPO=GRAN.CODIGO AND GRUP.GRANGRUPO=PROD.CODIGOGG AND GRUP.CODIGO=(PROD.CODIGOGG+PROD.CODIGOGR) AND GRUP.GRANGRUPO != 'G08'AND PROD.BRUTO!=0 AND DESPACHO=1 order by GRUP.GRANGRUPO ASC", con))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    int j = Convert.ToInt32(reader.VisibleFieldCount.ToString());
                   
                    while (reader.Read())
                 
                    {
                        System.Globalization.TextInfo TI = new System.Globalization.CultureInfo("en-US", false).TextInfo;                      
                        string idProd=id.ToString();
                        string codigo = reader.GetString(0);
                        string descripcion = TI.ToLower(reader.GetString(1)).ToString();
                        string descripcion2 = TI.ToTitleCase(descripcion).Trim();
                        string unidad = reader.GetString(2).Trim();
                        double precio =Math.Truncate(reader.GetDouble(3));
                        bool despacho = reader.GetBoolean(4);
                        string fotos = reader.GetString(5).Trim();
                        string categoria = reader.GetString(6).Trim();
                        string idCategoria = reader.GetString(7).Trim();
                        string DescWeb = reader.GetString(10).Trim();
                        if (idCategoria == "G01001")
                        {
                            idProducto = 1;
                        }
                        else if(idCategoria=="G01002"||idCategoria=="G02002") 
                        {
                            idProducto = 2;
                        }
                        else if (idCategoria == "G01003" || idCategoria == "G02006")
                        {
                            idProducto = 3 ;
                        }

                        else if (idCategoria == "G01004" || idCategoria == "G02007")
                        {
                            idProducto = 4;
                        }

                        //else if (idCategoria == "G02002")
                        //{
                        //    idProducto = 5;
                        //}

                        else if (idCategoria == "G02003")
                        {
                            idProducto = 5;
                        }

                        else if (idCategoria == "G02004")
                        {
                            idProducto = 6;
                        }
                        else if (idCategoria == "G02005")
                        {
                            idProducto = 7;
                        }

                        else if (idCategoria == "G03003")
                        {
                            idProducto = 8;
                        }

                        else if (idCategoria == "G04001")
                        {
                            idProducto = 9;
                        }
                        //else if (idCategoria == "G05001")
                        //{
                        //    idProducto = 11;
                        //}
                        else if (idCategoria == "G07001")
                        {
                            idProducto = 10;
                        }
                        //else if (idCategoria == "G09001")
                        //{
                        //    idProducto = 13;
                        //}
                        string imagen = "http://3.bp.blogspot.com/-JhwpoJYi55Q/T5aYvYaLr5I/AAAAAAAABV4/fjLOZhOMcg8/s1600/sushi+salmon.jpg";


                        //using (NpgsqlCommand command2 = new NpgsqlCommand("UPDATE \"tbl_Product\"SET \"idProduct\"='" + 43 + "',\"idProductType\"='" + idProducto + "',\"idRestaurantType\"=" + 1 + ",\"productName\"='" + descripcion + "',\"productPrice\"=" + precio + ",\"productImage\"='" + imagen + "',\"productDescription\"='',\"productDiscount\"='" + true + "',\"productUnit\"='" + unidad + "',\"codigoSushiHouse\"='"+ codigo +"'WHERE \"idProduct\"='43';", conn))

         
                            //("Insert into \"tbl_Product\" (\"idProduct\",\"idProductTyp\") values('" + id + "','" + idProducto + "')", conn))

                        //if (id > 6)
                        //{
                          Conexion obj = new Conexion();
                          DataSet dss = obj.InsertPreguntas(idProd, idProducto, descripcion2, precio, imagen, unidad, codigo,DescWeb);

                        //}
                         DataSet ds_ = obj.UpdatePreguntas(idProd, idProducto, descripcion2, precio, imagen, unidad, codigo,DescWeb);
                        id++;


                        Console.WriteLine("Actualizando Producto "+id+"");

                    }
                    Console.WriteLine("Terminado");
                    con.Close();
                    conn.Close();
                   
                    //Console.Read();
                   
                }
            }

           
        }
        
    }
}