using System;
using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Assets.Script
{
    class ConexionBD
    {
        private SqlConnection con;
        public bool AbrirConexionBD()
        {

            bool abrioCon = false;
            //string servidor = "bodegavalleverde.ddns.net,1440";
            string servidor = "LAPTOP-NE8FB5J0";
            string cadenaConexion = "Data Source=" + servidor + ";Initial Catalog=Unity2022;User Id=hector21;Password=kaulitz354;";

            con = new SqlConnection(cadenaConexion);
            try
            {
                con.Open();
                //using (SqlCommand cmd = new SqlCommand("SET ARITHABORT ON", con))
                //{
                //    cmd.ExecuteNonQuery();
                //}
                abrioCon = true;
            }
            catch (System.Threading.ThreadAbortException te)
            {
                try
                {
                    CerrarConexionBD();
                }
                catch
                {

                }
                abrioCon = false;

            }
            catch (Exception ex)
            {
                try
                {
                    CerrarConexionBD();
                }
                catch
                {

                }
                abrioCon = false;
            }
            return abrioCon;
        }

        public SqlConnection ObtenerConexion()
        {
            return con;
        }

        public void CerrarConexionBD()
        {
            if (con != null)
            {
                con.Close();
                con.Dispose();
                con = null;
            }
        }
    }
    
}
