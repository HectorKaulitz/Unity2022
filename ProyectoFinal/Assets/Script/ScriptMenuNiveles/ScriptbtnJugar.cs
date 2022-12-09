using Assets.Script;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScriptbtnJugar : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Jugar()
    {
        try
        {
            GameObject.Find("SonidoClip").GetComponent<AudioSource>().Play();
        }
        catch (Exception ex)
        {
        }
        StaticVariablesGenerales.escenaAnterior = "EscenaSeleccion";
        StaticVariablesGenerales.recurso = GameObject.Find("ImagenNivel").GetComponent<Image>().sprite.name.ToString();
        if (StaticVariablesGenerales.tipoJuego == 1 || (StaticVariablesGenerales.tipoJuego == 2 && StaticVariablesGenerales.tipoSubNivel==1))
        {
            SceneManager.LoadScene("EscenaJuegoVocal");
        }
        else
        {
            if(StaticVariablesGenerales.tipoJuego == 2 && StaticVariablesGenerales.tipoSubNivel == 0)
            {
                SceneManager.LoadScene("sceneJuegoNum");
            }
        }



    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
