using Assets.Script;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScriptBtnNumeros : MonoBehaviour
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

    public void Iniciar()
    {
        StaticVariablesGenerales.tipoJuego = 2;
        StaticVariablesGenerales.tipoNivel = 1;
        StaticVariablesGenerales.numeroNivelMinimo = 1;
        StaticVariablesGenerales.numeroNivelMaximo = 9;
        //StaticVariablesGenerales.escenaActual = "EscenaSeleccion";
        sonidoClick = GameObject.Find("SonidoClip").GetComponent<AudioSource>();
        sonidoClick.Play();
        StaticVariablesGenerales.MostrarEscena("EscenaSeleccion");
    }

}
