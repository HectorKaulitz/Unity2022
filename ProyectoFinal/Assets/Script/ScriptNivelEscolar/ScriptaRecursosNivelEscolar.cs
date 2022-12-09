using Assets.Script;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScriptaRecursosNivelEscolar : MonoBehaviour
{
    private Image imagenEscolar;
    //private GameObject fondo;
    private int pos = 0;
    private Button btnNext, btnPreview;
    private List<Sprite> niveles;
    public Texture2D cursorTexture;
    private CursorMode cursorMode = CursorMode.ForceSoftware;

    

    // Start is called before the first frame update
    void Start()
    {
        Cursor.SetCursor(cursorTexture, Vector2.zero, cursorMode);

        btnNext = GameObject.Find("btnNext").GetComponent<Button>();
        btnPreview = GameObject.Find("btnPreview").GetComponent<Button>();
        StaticVariablesGenerales.escenaActual = "MenuSeleccionEscolar";
        StaticVariablesGenerales.nivelEscolarActual = pos;
        imagenEscolar = GameObject.Find("ImagenNivelEscolar").GetComponent<Image>();
        //fondo = GameObject.Find("fondoInterno");

        LlenarNivelesEscolares();
    }

    private void LlenarNivelesEscolares()
    {
        StaticVariablesGenerales.nivelEscolarMinimo = 0;
        niveles = new List<Sprite>();
        //inicializa la lista 

        niveles.Add(Resources.Load<Sprite>("opcionPreescolar"));
        niveles.Add(Resources.Load<Sprite>("opcionPrimaria"));

        StaticVariablesGenerales.nivelEscolarMaximo = niveles.Count - 1;
        if (niveles.Count > 0)
        {
            // imagenEscolar.sprite = niveles[pos];
            CargarNivelEscolar();
        }
    }
    public void CargarNivelEscolar()
    {

        try
        {
            imagenEscolar.sprite = niveles[StaticVariablesGenerales.nivelEscolarActual];
            if (StaticVariablesGenerales.nivelEscolarMinimo == StaticVariablesGenerales.nivelEscolarActual)
            {
                btnPreview.gameObject.SetActive(false);
            }
            else
            {
                btnPreview.gameObject.SetActive(true);
            }
            if (StaticVariablesGenerales.nivelEscolarMaximo == StaticVariablesGenerales.nivelEscolarActual)
            {

                btnNext.gameObject.SetActive(false);

            }
            else
            {
                btnNext.gameObject.SetActive(true);
            }

        }
        catch (Exception ex)
        {

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
