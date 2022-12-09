using Assets.Script;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScriptBtnPreviewPersonaje : MonoBehaviour
{
    private AudioSource sonidoClick;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void AnteriorPersonaje()
    {
        if (StaticVariablesGenerales.numeroActualPersonaje > StaticVariablesGenerales.numeroPersonajeMinimo)
        {
            StaticVariablesGenerales.numeroActualPersonaje = StaticVariablesGenerales.numeroActualPersonaje - 1;
        }
        try
        {
            GameObject.Find("SonidoClip").GetComponent<AudioSource>().Play();
        }
        catch (Exception ex)
        {
        }

        GameObject.Find("fondoInterno").GetComponent<ScriptTipoPersonaje>().CargarPersonaje();
    }
}
