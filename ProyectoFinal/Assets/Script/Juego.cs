using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Script
{
    public class Juego
    {
       public Sprite imagen;
       public string escena;
       public  List<Nivel> niveles;
       public List<Dificultad> dificultades;

        public Juego(string rutaImagen,string escena, List<Nivel> niveles, List<Dificultad> dificultades)
        {
            this.imagen = Resources.Load<Sprite>(rutaImagen);
            this.escena = escena;
            this.niveles = niveles;
            this.dificultades = dificultades;
        }
    }


    public class Nivel
    {
        public Sprite imagen;
        public int valor;
        public Nivel(string rutaImagen,int valor)
        {
            this.imagen = Resources.Load<Sprite>(rutaImagen);
            this.valor = valor;
        }
    }

    public class Dificultad
    {
        public string nombre;
        public int valor;
        public Dificultad(string nombre, int valor)
        {
            this.nombre=nombre;
            this.valor = valor;
        }

    }
}
