using Assets.Script;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScriptbtnSeleccionar : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SeleccionarPersonaje()
    {
        StaticVariablesGenerales.PersonajeActual = GameObject.Find("ImagenPersonaje").GetComponent<Image>().sprite.name;
        try
        {
            GameObject.Find("SonidoClip").GetComponent<AudioSource>().Play();
        }
        catch (Exception ex)
        {
        }
        StaticVariablesGenerales.RegresarEscenaAnterior();
       
    }
}
