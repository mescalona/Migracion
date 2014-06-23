using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Npgsql;

namespace Jugadores
{
    class conexion
    {
        string conexionStringChile = String.Format("Server=190.215.44.18;Port=5432;" +
                  "User Id=postgres;Password=$martb0xTv;Database=SporTV;");


        public void InsertJugadores(string nombre, string posicion, string estado, string equipo, string idTeam)
        {
            try
            {
                string name = null;

                using (NpgsqlConnection conn = new NpgsqlConnection(conexionStringChile))
                {
                    conn.Open();

                    NpgsqlCommand sSlc = new NpgsqlCommand("select*from \"Player\" WHERE \"name\"='" + nombre + "'", conn);
                    NpgsqlDataReader ds = sSlc.ExecuteReader();
                    while (ds.Read())
                    {
                        name = Convert.ToString(ds[4].ToString());
                    }

                    bool state = false;

                    //NpgsqlCommand sIns = new NpgsqlCommand("  INSERT INTO \"Player\"(\"country\", \"position\", \"idTeam\", \"name\", \"state\") VALUES ( '" + equipo + "','" + posicion + "'," + idTeam + ", '" + nombre + "'," + state + ");", conn);
                    //    NpgsqlDataReader di = sIns.ExecuteReader();



                    if (nombre != name)
                    {
                        NpgsqlCommand sIns = new NpgsqlCommand("INSERT INTO \"Player\"(\"country\", \"position\", \"idTeam\", \"name\", \"state\") VALUES ( '" + equipo + "','" + posicion + "'," + idTeam + ", '" + nombre + "'," + state + ");", conn);
                        NpgsqlDataReader di = sIns.ExecuteReader();


                    }
                    else if (nombre == name)
                    {
                        state = true;
                        NpgsqlCommand sIns = new NpgsqlCommand("UPDATE \"Player\" SET  \"country\"='" + equipo + "', \"position\"='" + posicion + "', \"idTeam\"='" + idTeam + "', \"name\"='" + nombre + "', state=" + state + " WHERE \"name\"='" + nombre + "';", conn);
                        NpgsqlDataReader di = sIns.ExecuteReader();

                    }

                    conn.Close();
                }




            }


            catch (Exception e)
            {

            }

        }


        public void InsertFechasPartidos(string Fecha,int Increment)
        {
            try
            {
                string fechas = null;

                using (NpgsqlConnection conn = new NpgsqlConnection(conexionStringChile))
                {
                    conn.Open();

                    NpgsqlCommand sSlc = new NpgsqlCommand("select*from \"Calendario\"", conn);
                    NpgsqlDataReader ds = sSlc.ExecuteReader();
                    while (ds.Read())
                    {
                        fechas = Convert.ToString(ds[1].ToString());
                    }

                    bool state = false;

                    NpgsqlCommand sIns = new NpgsqlCommand("  INSERT INTO \"Calendario\"(fecha,incrementable)VALUES ( '" + Fecha + "'," + Increment + ");", conn);
                    NpgsqlDataReader di = sIns.ExecuteReader();



                    //if (Fecha != fechas)
                    //{
                    //    NpgsqlCommand sIns = new NpgsqlCommand("INSERT INTO \"Player\"(\"country\", \"position\", \"idTeam\", \"name\", \"state\") VALUES ( '" + equipo + "','" + posicion + "'," + idTeam + ", '" + nombre + "'," + state + ");", conn);
                    //    NpgsqlDataReader di = sIns.ExecuteReader();


                    //}
                    //else if (Fecha == fechas)
                    //{
                    //    NpgsqlCommand sIns = new NpgsqlCommand("UPDATE \"Player\" SET  \"country\"='" + equipo + "', \"position\"='" + posicion + "', \"idTeam\"='" + idTeam + "', \"name\"='" + nombre + "', state=" + state + " WHERE \"name\"='" + nombre + "';", conn);
                    //    NpgsqlDataReader di = sIns.ExecuteReader();

                    //}

                    conn.Close();
                }




            }


            catch (Exception e)
            {

            }

        }

        public void InsertHorario(string Hora,int Increment)
        {
            try
            {
                string id = null;

                using (NpgsqlConnection conn = new NpgsqlConnection(conexionStringChile))
                {
                    conn.Open();

                    NpgsqlCommand sIns = new NpgsqlCommand("UPDATE \"Calendario\" SET  horario=to_timestamp('" + Hora + "','HH24:MI') WHERE incrementable=" + Increment + ";", conn);
                    NpgsqlDataReader di = sIns.ExecuteReader();
                  
                  
                    conn.Close();
                }
            }
            catch (Exception e)
            {

            }
        }

        public void InsertHorariosFinales(string HoraFinal,int Increment)
        {
            try
            {
                

                using (NpgsqlConnection conn = new NpgsqlConnection(conexionStringChile))
                {
                    conn.Open();
                    NpgsqlCommand sIns = new NpgsqlCommand("UPDATE \"Calendario\" SET  horario=to_timestamp('" + HoraFinal + "','HH24:MI') WHERE incrementable=" + Increment + ";", conn);
                    NpgsqlDataReader di = sIns.ExecuteReader();

                   

                    conn.Close();
                }
            }
            catch (Exception e)
            {

            }
        }

        public void InsertEquipoA(string EquipoA,string imgA,int idEquipo,int idGrupo, int Increment)
        {
            try
            {


                using (NpgsqlConnection conn = new NpgsqlConnection(conexionStringChile))
                {
                    conn.Open();
                    NpgsqlCommand sIns = new NpgsqlCommand("UPDATE \"Calendario\" SET  \"EquipoA\"='" + EquipoA + "',\"imgA\"='" + imgA + "',\"idEquipoA\"=" + idEquipo + ",\"idGrupo\"=" + idGrupo + " WHERE incrementable=" + Increment + ";", conn);
                    NpgsqlDataReader di = sIns.ExecuteReader();



                    conn.Close();
                }
            }
            catch (Exception e)
            {

            }
        }

        public void InsertEquipoB(string EquipoB, string imgB, int idEquipo, int idGrupo, int Increment)
        {
            try
            {


                using (NpgsqlConnection conn = new NpgsqlConnection(conexionStringChile))
                {
                    conn.Open();
                    NpgsqlCommand sIns = new NpgsqlCommand("UPDATE \"Calendario\" SET  \"EquipoB\"='" + EquipoB + "',\"imgB\"='" + imgB + "',\"idEquipoB\"=" + idEquipo + ",\"idGrupo\"=" + idGrupo + " WHERE incrementable=" + Increment + ";", conn);
                    NpgsqlDataReader di = sIns.ExecuteReader();



                    conn.Close();
                }
            }
            catch (Exception e)
            {

            }
        }

        public void InsertEquipoFinalesA(string equipoAFinal,string imgA,int idEquipo,int idGrupo,int Increment)
        {
            try
            {


                using (NpgsqlConnection conn = new NpgsqlConnection(conexionStringChile))
                {
                    conn.Open();
                    NpgsqlCommand sIns = new NpgsqlCommand("UPDATE \"Calendario\" SET  \"EquipoA\"='" + equipoAFinal + "',\"imgA\"='" + imgA + "',\"idEquipoA\"=" + idEquipo + ",\"idGrupo\"=" + idGrupo + " WHERE incrementable=" + Increment + ";", conn);
                    NpgsqlDataReader di = sIns.ExecuteReader();



                    conn.Close();
                }
            }
            catch (Exception e)
            {

            }
        }

        public void InsertEquipoFinalesB(string equipoBFinal, string imgB, int idEquipo, int idGrupo, int Increment)
        {
            try
            {


                using (NpgsqlConnection conn = new NpgsqlConnection(conexionStringChile))
                {
                    conn.Open();
                    NpgsqlCommand sIns = new NpgsqlCommand("UPDATE \"Calendario\" SET  \"EquipoB\"='" + equipoBFinal + "',\"imgB\"='" + imgB + "',\"idEquipoB\"=" + idEquipo + ",\"idGrupo\"=" + idGrupo + " WHERE incrementable=" + Increment + ";", conn);
                    NpgsqlDataReader di = sIns.ExecuteReader();



                    conn.Close();
                }
            }
            catch (Exception e)
            {

            }
        }

      

        public void InsertDatoTablasUno(int idEquipo, int idGrupo,int increment)
        {
            try
            {


                using (NpgsqlConnection conn = new NpgsqlConnection(conexionStringChile))
                {
                    conn.Open();
                    NpgsqlCommand sIns = new NpgsqlCommand("UPDATE \"Leaderboard2\" SET  \"SeasonTeamId\"='" + idEquipo + "',\"GroupId\"='" + idGrupo + "'where \"Id\"='" + increment + "';", conn);
                    NpgsqlDataReader di = sIns.ExecuteReader();



                    conn.Close();
                }
            }
            catch (Exception e)
            {

            }
        }

        public void InsertDatoTablasDos(string puntos, int increment)
        {
            try
            {


                using (NpgsqlConnection conn = new NpgsqlConnection(conexionStringChile))
                {
                    conn.Open();
                    NpgsqlCommand sIns = new NpgsqlCommand("UPDATE \"Leaderboard2\" SET  \"Pto\"='" + puntos + "'where \"Id\"='" + increment + "';", conn);
                    NpgsqlDataReader di = sIns.ExecuteReader();



                    conn.Close();
                }
            }
            catch (Exception e)
            {

            }
        }

        public void InsertDatoTablasTres(string Wins, int increment)
        {
            try
            {


                using (NpgsqlConnection conn = new NpgsqlConnection(conexionStringChile))
                {
                    conn.Open();
                    NpgsqlCommand sIns = new NpgsqlCommand("UPDATE \"Leaderboard2\" SET  \"Wins\"='" + Wins + "'where \"Id\"='" + increment + "';", conn);
                    NpgsqlDataReader di = sIns.ExecuteReader();



                    conn.Close();
                }
            }
            catch (Exception e)
            {

            }
        }

        public void InsertDatoTablasCuatro(string empate, int increment)
        {
            try
            {


                using (NpgsqlConnection conn = new NpgsqlConnection(conexionStringChile))
                {
                    conn.Open();
                    NpgsqlCommand sIns = new NpgsqlCommand("UPDATE \"Leaderboard2\" SET  \"TiesOrGB\"='" + empate + "'where \"Id\"='" + increment + "';", conn);
                    NpgsqlDataReader di = sIns.ExecuteReader();



                    conn.Close();
                }
            }
            catch (Exception e)
            {

            }
        }

        public void InsertDatoTablasCinco(string dife, int increment)
        {
            try
            {


                using (NpgsqlConnection conn = new NpgsqlConnection(conexionStringChile))
                {
                    conn.Open();
                    NpgsqlCommand sIns = new NpgsqlCommand("UPDATE \"Leaderboard2\" SET  \"dif\"='" + dife + "'where \"Id\"='" + increment + "';", conn);
                    NpgsqlDataReader di = sIns.ExecuteReader();



                    conn.Close();
                }
            }
            catch (Exception e)
            {

            }
        }

        public void InsertDatoTablasSeis(string perd, int increment)
        {
            try
            {


                using (NpgsqlConnection conn = new NpgsqlConnection(conexionStringChile))
                {
                    conn.Open();
                    NpgsqlCommand sIns = new NpgsqlCommand("UPDATE \"Leaderboard2\" SET  \"Losses\"='" + perd + "'where \"Id\"='" + increment + "';", conn);
                    NpgsqlDataReader di = sIns.ExecuteReader();



                    conn.Close();
                }
            }
            catch (Exception e)
            {

            }
        }
    }


}