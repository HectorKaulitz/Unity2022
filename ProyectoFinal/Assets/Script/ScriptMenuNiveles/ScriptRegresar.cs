using Assets.Script;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScriptRegresar : MonoBehaviour
{
    private AudioSource sonidoClick;
    // Start is called before the first frame update
    void Start()
    {
        StaticVariablesGenerales.escenaActual = "EscenaSeleccion";

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RegresarMenuPrincipal()
    {
        sonidoClick = GameObject.Find("SonidoClip").GetComponent<AudioSource>();
        sonidoClick.Play();
        //Thread.Sleep(3000);
        SceneManager.LoadScene("Menu");
    }    
}
