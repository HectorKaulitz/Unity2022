using Assets.Script;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eliminarse : MonoBehaviour
{
    public int contador = 0;
    public init init;
    

    private void OnCollisionEnter2D(Collision2D collision)
    {
        init = FindObjectOfType<init>();
      
        char[] val = gameObject.name.ToCharArray();
        string nombre = "";

        for(int i=0;i<val.Length-8;i++)
        {
            nombre += val[i];
        }

        print(nombre);
        //Condicion para nombres
        if (collision.gameObject.name == "AreaArrastre"  && init.nombre == nombre)
        {
            Destroy(gameObject);
            init.contadorAnamales++;
        }
        else
        {
            StaticVariablesGenerales.puntuacionNivelActual-= 25;
            init.vidas--;
        }
       
    }


}
