using Assets.Script;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScriptBtnVocales : MonoBehaviour
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
        StaticVariablesGenerales.tipoJuego = 1;
        StaticVariablesGenerales.tipoNivel = 0;
        StaticVariablesGenerales.numeroNivelMinimo = 0;
        StaticVariablesGenerales.numeroNivelMaximo = 4;
        StaticVariablesGenerales.escenaAnterior = "Menu";
        //StaticVariablesGenerales.escenaActual = "EscenaSeleccion";
        sonidoClick = GameObject.Find("SonidoClip").GetComponent<AudioSource>();
        sonidoClick.Play();
        //Thread.Sleep(3000);
        SceneManager.LoadScene("EscenaSeleccion");
    }

}
