using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine.SceneManagement;

namespace Assets.Script
{
    static class StaticVariablesGenerales
    {
        //seleccion tipo de juego
        public static List<Juego> listaJuegosLetras;
    public static List<Juego> listaJuegosNumericos;
        public static int tipoJuego { get; set; }//si son vocales o numero 

        public static int tipoNivel { get; set; }// saber que numero o letra es

        public static int tipoSubNivel { get; set; }//tipo d ejuego dentro del tipo

        public static string recurso { get; set; }//vocal,numero

        public static int puntuacionNivelActual { get; set; }

        public static int dificultadNivel { get; set; }

        public static int aciertos { get; set; }

        public static float tiempoJugado{get;set;}

        public static int numeroNivelMinimo { get; set; }//saber cual es el nivel minimo

        public static int numeroNivelMaximo { get; set; }//saber cuale s el nivel maximo

        public static string idJugador { get; set; }//id unico del jugador que esta cargado

        public static string nombreJugador { get; set; }//Nombre del jugador cargado

        public static int puntuacion { get; set; }//puntuacion del jugador

        public static string caracter { get; set; }//representacion de letra o vocal que toca
        //configuracion
        public static int volumenMusica { get; set; }//volumen de las musica ambiente

        public static int volumenSonido { get; set; }//volumen de los sonidos,como click etc

        public static int iluminacion { get; set; }//iluminacion


        //cambio escenas
        private static List<string> escenas { get; set; }

        public static void MostrarEscena(string escena)
        {
            if (escenas == null)
            {
                escenas = new List<string>();
                escenas.Add("Inicio");
            }
            escenas.Add(escena);
            SceneManager.LoadScene(escena);

        }

        public static void RegresarEscenaAnterior()
        {
            if (escenas != null && escenas.Count > 0)
            {
                //SceneManager.UnloadScene(escenas[escenas.Count - 1]);
                escenas.RemoveAt(escenas.Count - 1);
                SceneManager.LoadScene(escenas[escenas.Count - 1]);
            }
        }

        public static void ReiniciarEscena() 
        {
            SceneManager.LoadScene(escenas[escenas.Count - 1]);

        }
        //public static string escenaActual { get; set; }//saber que escena esta cargada

        //public static string escenaAnterior { get; set; }//saber que escena venimos

        //personajes
        public static string PersonajeActual { get; set; }
        public static int numeroActualPersonaje { get; set; }
        public static int numeroPersonajeMinimo { get; set; }//saber cual es el nivel minimo

        public static int numeroPersonajeMaximo { get; set; }//saber cuale s el nivel maximo

        //niveles escolares
        public static int nivelEscolarActual { get; set; }
        public static int nivelEscolarMinimo { get; set; }//saber cual es el nivel minimo

        public static int nivelEscolarMaximo { get; set; }//saber cuale s el nivel maximo
    }
}
