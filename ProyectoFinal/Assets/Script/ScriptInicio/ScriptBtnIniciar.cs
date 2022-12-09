using Assets.Script;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScriptBtnIniciar : MonoBehaviour
{
    public Texture2D cursorTexture;
    private CursorMode cursorMode = CursorMode.ForceSoftware;
    private GameObject dialogoCOnexion,btnIniciar,fondoBtn;
    private bool ejecutando = false;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.SetCursor(cursorTexture, Vector2.zero, cursorMode);
        dialogoCOnexion = GameObject.Find("DialogoConexion");
        dialogoCOnexion.SetActive(false);
        btnIniciar = GameObject.Find("BtnIniciar");
        btnIniciar.SetActive(true);
        fondoBtn = GameObject.Find("GUI_17");
        fondoBtn.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AbrirMenu()
    {
        if (!ejecutando)
            StartCoroutine(Menu());
        //StaticVariablesGenerales.escenaAnterior = "Inicio";
        StaticVariablesGenerales.PersonajeActual = "Castle2";
        //SceneManager.LoadScene("Menu");
    }

    private IEnumerator Menu()
    {
        ejecutando = true;
        try
        {
            GameObject.Find("SonidoClip").GetComponent<AudioSource>().Play();
        }
        catch (Exception ex)
        {
        }
       
        /*if (new ConexionBD().AbrirConexionBD())//existe conexion con bd de datos
        {*/

            StaticVariablesGenerales.escenaAnterior = "Inicio";
            dialogoCOnexion.SetActive(false);
            btnIniciar.SetActive(true);
            fondoBtn.SetActive(true);
            SceneManager.LoadScene("Menu");
       /* }
        else
        {
            dialogoCOnexion.SetActive(true);
            btnIniciar.SetActive(false);
            fondoBtn.SetActive(false);
        }*/
        yield return null;
    }
}
