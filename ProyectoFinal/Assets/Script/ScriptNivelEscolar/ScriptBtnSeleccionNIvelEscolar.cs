using Assets.Script;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScriptBtnSeleccionNIvelEscolar : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SeleccionarNivelEscolar()
    {
        try
        {
            GameObject.Find("SonidoClip").GetComponent<AudioSource>().Play();
        }
        catch (Exception ex)
        {
        }
        StaticVariablesGenerales.PersonajeActual = "Castle2";
        StaticVariablesGenerales.escenaAnterior = "MenuSeleccionEscolar";
        SceneManager.LoadScene("Menu");
    }
}
