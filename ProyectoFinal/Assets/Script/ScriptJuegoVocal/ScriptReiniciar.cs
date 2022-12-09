using Assets.Script;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScriptReiniciar : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CargarEscenaEspecifica(string escena)
    {
        if(escena.Equals("-1"))
        {
            if (StaticVariablesGenerales.tipoJuego == 1 || (StaticVariablesGenerales.tipoJuego == 2 && StaticVariablesGenerales.tipoSubNivel == 1))
            {
                escena = "EscenaJuegoVocal";
            }
            else
            {
                if (StaticVariablesGenerales.tipoJuego == 2 && StaticVariablesGenerales.tipoSubNivel == 0)
                {
                    escena = "sceneJuegoNum";
                }
            }
          
        }
        try
        {
            GameObject.Find("SonidoClip").GetComponent<AudioSource>().Play();
        }
        catch(Exception ex)
        {

        }
        SceneManager.LoadScene(escena);
    }

    public void ReiniciarEscena()
    {
        GameObject.Find("SonidoClip").GetComponent<AudioSource>().Play();
        SceneManager.LoadScene(StaticVariablesGenerales.escenaActual);
    }
}
