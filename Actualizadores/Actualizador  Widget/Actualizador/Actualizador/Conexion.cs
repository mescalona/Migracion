using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Npgsql;
using System.Data;

namespace Actualizador
{
    class Conexion
    {
        string sCnn = String.Format("Server=190.215.44.18;Port=5432;" +
                          "User Id=Widgets;Password=$martb0xTv;Database=Widget;");
       

       
        

        public DataSet Insertar_Tiempo( string fechaHoy, string temperaturaMaxHoy, string temperaturaMinHoy, string imagenHoy, string fechaMañana, 
                                        string temperaturaMaxMañana, string temperaturaMinMañana, string imagenMañana, string fechaProximo, string temperaturaMaxProximo, 
                                        string temperaturaMinProximo, string imagenProximo, string fechaIngreso,string region)
        {
            string sSel = "INSERT INTO \"tiempo\"";
            sSel += "(\"fechaHoy\",\"temperaturaMaxHoy\",\"temperaturaMinHoy\",\"imagenHoy\",\"fechaMañana\",\"temperaturaMaxMañana\",\"temperaturaMinMañana\",\"imagenMañana\",\"fechaProximo\",\"temperaturaMaxProximo\",\"temperaturaMinProximo\" ,\"imagenProximo\",\"fechaIngreso\" ,\"region\")";

            sSel += "VALUES('" + fechaHoy + "','" + temperaturaMaxHoy + "','" + temperaturaMinHoy + "','" + imagenHoy + "','" + fechaMañana +
                "','" + temperaturaMaxMañana + "','" + temperaturaMinMañana + "','" + imagenMañana + "','" + fechaProximo + "','" + temperaturaMaxProximo +
                "','" + temperaturaMinProximo + "','" + imagenProximo + "','" + fechaIngreso + "','" + region + "')";



                NpgsqlDataAdapter da;
                 DataSet dt = new DataSet();

                try
                {
                    da = new NpgsqlDataAdapter(sSel, this.sCnn);
                    da.Fill(dt);
                }
                catch (Exception ex)
                {

                }
                return dt;

            }
        }
    }



