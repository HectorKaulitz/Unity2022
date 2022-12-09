using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Script.getset
{
    class getsetPersonaje
    {

         public getsetPersonaje(Sprite spritePersonaje, string nombreSprite,Sprite fondo,string tipo,float scalaX,float scalaY)
        {
            this.spritePersonaje = spritePersonaje;
            this.nombreSprite = nombreSprite;
            this.fondo = fondo;
            this.tipo = tipo;
            this.scalaX = scalaX;
            this.scalay = scalaY;
        }

        public float scalaX { get; set; }
        public float scalay { get; set; }
        public Sprite spritePersonaje { get; set; }

        public string nombreSprite { get; set; }

        public Sprite fondo { get; set; }

        public string tipo { get; set; }
    }
}
