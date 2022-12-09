using Assets.Script;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class btnSeleccionTipoJuego : MonoBehaviour
{
    private Image imagen;
    //private GameObject fondo;
    private int pos = 0;
    private Button btnNext, btnPreview;
    private List<Sprite> niveles;
    public Texture2D cursorTexture;
    private int tipoMinimo = 0, tipoMaximo;
    private CursorMode cursorMode = CursorMode.ForceSoftware;



    // Start is called before the first frame update
    void Start()
    {
        Cursor.SetCursor(cursorTexture, Vector2.zero, cursorMode);
        StaticVariablesGenerales.tipoJuego = 1;
        btnNext = GameObject.Find("btnNext").GetComponent<Button>();
        btnPreview = GameObject.Find("btnPreview").GetComponent<Button>();
        //StaticVariablesGenerales.escenaActual = "MenuSeleccionEscolar";
        //StaticVariablesGenerales.nivelEscolarActual = pos;
        imagen = GameObject.Find("ImagenTipoJuegos").GetComponent<Image>();
        //fondo = GameObject.Find("fondoInterno");

        LlenarTipos();
    }

    private void LlenarTipos()
    {
        
        niveles = new List<Sprite>();
        //inicializa la lista 

        niveles.Add(Resources.Load<Sprite>("letrasFondo"));
        niveles.Add(Resources.Load<Sprite>("numeros"));

        tipoMaximo = niveles.Count - 1;
        if (niveles.Count > 0)
        {
            // imagenEscolar.sprite = niveles[pos];
            CargarTipo();
        }
    }
    public void CargarTipo()
    {

        try
        {
            imagen.sprite = niveles[StaticVariablesGenerales.tipoJuego-1];
            if (tipoMinimo== StaticVariablesGenerales.tipoJuego - 1)
            {
                btnPreview.gameObject.SetActive(false);
            }
            else
            {
                btnPreview.gameObject.SetActive(true);
            }
            if (tipoMaximo == StaticVariablesGenerales.tipoJuego - 1)
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
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Anterior();
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            Siguiente();
        }
    }

    public void SeleccionTipoJuego()
    {
        try
        {
            StaticVariablesGenerales.escenaAnterior = "Menu";
            GameObject.Find("SonidoClip").GetComponent<AudioSource>().Play();
            switch (StaticVariablesGenerales.tipoJuego)
            {
                case 1:
                    StaticVariablesGenerales.tipoJuego = 1;
                    StaticVariablesGenerales.tipoNivel = 0;
                    StaticVariablesGenerales.numeroNivelMinimo = 0;
                    StaticVariablesGenerales.numeroNivelMaximo = 4;
                    break;
                case 2:
                    StaticVariablesGenerales.tipoJuego = 2;
                    StaticVariablesGenerales.tipoNivel = 1;
                    StaticVariablesGenerales.numeroNivelMinimo = 1;
                    StaticVariablesGenerales.numeroNivelMaximo = 9;
                   
                    
                    break;
            }
            SceneManager.LoadScene("EscenaSeleccion");
        }
        catch (Exception ex)
        {
        }
    }

    public void Siguiente()
    {
        if (StaticVariablesGenerales.tipoJuego-1 < tipoMaximo)
        {
            StaticVariablesGenerales.tipoJuego = StaticVariablesGenerales.tipoJuego + 1;
        }
        try
        {
            GameObject.Find("SonidoClip").GetComponent<AudioSource>().Play();
        }
        catch (Exception ex)
        {
        }
        CargarTipo();
    }

    public void Anterior()
    {
        if (StaticVariablesGenerales.tipoJuego-1 > tipoMinimo)
        {
            StaticVariablesGenerales.tipoJuego = StaticVariablesGenerales.tipoJuego - 1;
        }
        try
        {
            GameObject.Find("SonidoClip").GetComponent<AudioSource>().Play();
        }
        catch (Exception ex)
        {
        }
        CargarTipo();
    }
}
