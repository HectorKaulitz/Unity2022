using Assets.Script;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScriptBtnPreviewNivelEscolar : MonoBehaviour
{
    private AudioSource sonidoClick;
    private GameObject recurso;
    // Start is called before the first frame update
    void Start()
    {
        recurso = GameObject.Find("fondoInterno");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            AnteriorNivelEscolar();
        }
    }
    public void AnteriorNivelEscolar()
    {
        if (StaticVariablesGenerales.nivelEscolarActual > StaticVariablesGenerales.nivelEscolarMinimo)
        {
            StaticVariablesGenerales.nivelEscolarActual = StaticVariablesGenerales.nivelEscolarActual - 1;
        }
        try
        {
            GameObject.Find("SonidoClip").GetComponent<AudioSource>().Play();
        }
        catch (Exception ex)
        {
        }
        recurso.GetComponent<ScriptaRecursosNivelEscolar>().CargarNivelEscolar();
    }
}
