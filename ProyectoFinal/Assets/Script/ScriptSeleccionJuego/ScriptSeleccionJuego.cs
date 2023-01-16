using Assets.Script;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScriptSeleccionJuego : MonoBehaviour
{
    private CursorMode cursorMode = CursorMode.ForceSoftware;
    private int juegoSeleccionado = 0;
    private Image imagen;
    private Button btnNext, btnPreview;
    public Texture2D cursorTexture;
    private int juegoMinimo = 0, juegoMaximo;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.SetCursor(cursorTexture, Vector2.zero, cursorMode);
        btnNext = GameObject.Find("btnNext").GetComponent<Button>();
        btnPreview = GameObject.Find("btnPreview").GetComponent<Button>();
        //StaticVariablesGenerales.escenaActual = "MenuSeleccionEscolar";
        //StaticVariablesGenerales.nivelEscolarActual = pos;
        imagen = GameObject.Find("ImagenJuego").GetComponent<Image>();

        List<Nivel> nivelesLetras = new List<Nivel> {
                                                    new Nivel("Abecedario/A",0),
                                                    new Nivel("Abecedario/E",1),
                                                    new Nivel("Abecedario/I",2),
                                                    new Nivel("Abecedario/O",3),
                                                    new Nivel("Abecedario/U",4)
                                                    };
        List<Dificultad> dificultadesLetras = new List<Dificultad> { new Dificultad("Principiante", 2), new Dificultad("Avanzado", 1) };
        Juego letras = new Juego("letrasFondo", "EscenaJuegoVocal", nivelesLetras,dificultadesLetras);

        StaticVariablesGenerales.listaJuegosLetras = new List<Juego> { letras };
        
        
        List<Nivel> nivelesOperacionesBasicas = new List<Nivel> {
                                                    new Nivel("Operadores/suma",0),
                                                    new Nivel("Operadores/resta",1),
                                                    new Nivel("Operadores/multiplicacion",2),
                                                    new Nivel("Operadores/division",3)
                                                    };
        List<Dificultad> dificultadesOperacionesBasicas = new List<Dificultad> { new Dificultad("Una numero", 1),
                                                                                    new Dificultad("Dos numeros", 2),
                                                                                    new Dificultad("Tres numeros", 3),
                                                                                    new Dificultad("Cuatro numeros", 4)
                                                                                };
        Juego juegoOperacionesBasicas = new Juego("numeros", "EscenaJuegoOperacionesBasicas", nivelesOperacionesBasicas,dificultadesOperacionesBasicas);
        
        
        List<Nivel> nivelesAgrupacionNumeros = new List<Nivel> {
                                                    new Nivel("Numeros/1",1),
                                                    new Nivel("Numeros/2",2),
                                                    new Nivel("Numeros/3",3),
                                                    new Nivel("Numeros/4",4),
                                                    new Nivel("Numeros/5",5),
                                                    new Nivel("Numeros/6",6),
                                                    new Nivel("Numeros/7",7),
                                                    new Nivel("Numeros/8",8),
                                                    new Nivel("Numeros/9",9)
                                                    };
        List<Dificultad> dificultadAgrupacionNumeros = new List<Dificultad> { new Dificultad("Principiante", 0) };
        Juego juegoAgrupaciones = new Juego("agrupaciones", "EscenaJuegoVocal", nivelesAgrupacionNumeros, dificultadAgrupacionNumeros);

        StaticVariablesGenerales.listaJuegosNumericos = new List<Juego> { juegoAgrupaciones,juegoOperacionesBasicas };
        CargarJuego();

    }

    public void CargarJuego()
    {
        switch (StaticVariablesGenerales.tipoJuego)
        {
            case 1:
                juegoMaximo = StaticVariablesGenerales.listaJuegosLetras.Count-1;
                imagen.sprite = StaticVariablesGenerales.listaJuegosLetras[juegoSeleccionado].imagen;
                break;
            case 2:
                juegoMaximo = StaticVariablesGenerales.listaJuegosNumericos.Count-1;
                imagen.sprite = StaticVariablesGenerales.listaJuegosNumericos[juegoSeleccionado].imagen;
                break;
        }

        try
        {

            if (juegoMinimo == juegoSeleccionado)
            {
                btnPreview.gameObject.SetActive(false);
            }
            else
            {
                btnPreview.gameObject.SetActive(true);
            }
            if (juegoMaximo == juegoSeleccionado)
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


    public void Siguiente()
    {
        if (juegoSeleccionado < juegoMaximo)
        {
           juegoSeleccionado = juegoSeleccionado + 1;
        }
        try
        {
            GameObject.Find("SonidoClip").GetComponent<AudioSource>().Play();
        }
        catch (Exception ex)
        {
        }
        CargarJuego();
    }

    public void Anterior()
    {
        if (juegoSeleccionado > juegoMinimo)
        {
            juegoSeleccionado= juegoSeleccionado - 1;
        }
        try
        {
            GameObject.Find("SonidoClip").GetComponent<AudioSource>().Play();
        }
        catch (Exception ex)
        {
        }
        CargarJuego();
    }

    public void SeleccionJuego()
    {
        try
        {

            GameObject.Find("SonidoClip").GetComponent<AudioSource>().Play();
            
        }
        catch (Exception ex)
        {
        }
    }
}
