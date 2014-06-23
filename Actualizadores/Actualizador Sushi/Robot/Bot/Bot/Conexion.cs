using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Npgsql;

namespace Bot
{
    class Conexion
    {
        public static string cnxSushiSmart = "Server=190.196.157.186;Port=5432;User Id=postgres;Password=pa$$w0rd;Database=SushiHouse";
        public static string cnxSushiHouse = "Data Source=190.98.237.10;Initial Catalog=SMARTBOX;Persist Security Info=True;User ID=smartbox;Password=smartbox";

       
        public DataSet UpdatePreguntas(string idProd,int idProducto, string descripcion, double precio, string imagen, string unidad, string codigo, string DescWeb)
        {
            string sSel;
            sSel = "UPDATE \"tbl_Product\"SET \"idProduct\"='" + idProd + "',\"idProductType\"='" + idProducto + "',\"idRestaurantType\"=" + 1 + ",\"productName\"='" + descripcion + "',\"productPrice\"=" + precio + ",\"productImage\"='" + imagen + "',\"productDescription\"='"+DescWeb+"',\"productDiscount\"='" + true + "',\"productLot\"='" + 1 + "',\"productUnit\"='" + unidad + "',\"codigoSushiHouse\"='" + codigo + "'WHERE \"idProduct\"='" + idProd + "';";





            NpgsqlDataAdapter da;
            DataSet dt = new DataSet();

            try
            {
                da = new NpgsqlDataAdapter(sSel, Conexion.cnxSushiSmart);
                da.Fill(dt);
            }
            catch (Exception ex)
            {

            }
            return dt;
        }

        public DataSet InsertPreguntas(string idProd,int idProducto, string descripcion, double precio, string imagen, string unidad, string codigo,string discWeb)
        {
            string sSel;
            sSel = "Insert into \"tbl_Product\" (\"idProduct\",\"idProductType\",\"idRestaurantType\",\"productName\",\"productPrice\",\"productImage\",\"productDescription\",\"productDiscount\",\"productLot\",\"productUnit\",\"codigoSushiHouse\") ";
            sSel += "values('" + idProd + "','" + idProducto + "','1','" + descripcion + "','" + precio + "','" + imagen + "','"+discWeb+"','TRUE','1','" + unidad + "','" + codigo + "');";




            NpgsqlDataAdapter da;
            DataSet dt = new DataSet();

            try
            {
                da = new NpgsqlDataAdapter(sSel, Conexion.cnxSushiSmart);
                da.Fill(dt);
            }
            catch (Exception ex)
            {

            }
            return dt;
        }
    }

    
}
