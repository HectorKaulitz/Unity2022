using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Script
{
    public class Procedimientos
    {
        
        public List<string>  ObtenerJugadores()
        {
            List<string> jugadores = new List<string>();

            ConexionBD obc = new ConexionBD();
            if (obc.AbrirConexionBD())
            {
                SqlCommand cmd = new SqlCommand("ObtenerJugadores", obc.ObtenerConexion());
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                //cmd.Parameters.Add(new SqlParameter("@idUsuario", idUsuario));
               // cmd.Parameters.Add(new SqlParameter("@contrasena", contraseña));

                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {

                    jugadores.Add(rdr[0] + "");
                }
                obc.CerrarConexionBD();
            }

            return jugadores;
        }
    }
}
