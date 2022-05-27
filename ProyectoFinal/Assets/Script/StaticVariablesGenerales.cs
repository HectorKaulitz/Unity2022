using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Script
{
    static class StaticVariablesGenerales
    {
        public static int tipoJuego { get; set; }//si son vocales o numero 

        public static int tipoNivel { get; set; }// saber que numero o letra es

        public static int numeroNivelMinimo {get;set;}//saber cual es el nivel minimo

        public static int numeroNivelMaximo{ get; set; }//saber cuale s el nivel maximo

        public static string idJugador { get; set; }//id unico del jugador que esta cargado

        public static string nombreJugador { get; set; }//Nombre del jugador cargado

        public static int puntuacion { get; set; }//puntuacion del jugador

        public static string caracter { get; set; }//representacion de letra o vocal que toca
    }
}
