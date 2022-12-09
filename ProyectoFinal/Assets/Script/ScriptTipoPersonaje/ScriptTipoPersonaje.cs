using Assets.Script;
using Assets.Script.getset;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScriptTipoPersonaje : MonoBehaviour
{

    private List<getsetPersonaje> listaPersonajes;
    private Image imagenPersonaje;
    private GameObject fondo;
    private int pos = 0;
    private Button btnNext, btnPreview;

    // Start is called before the first frame update
    void Start()
    {
        btnNext = GameObject.Find("btnNext").GetComponent<Button>();
        btnPreview = GameObject.Find("btnPreview").GetComponent<Button>();
        StaticVariablesGenerales.escenaActual = "SeleccionTipoPersonaje";
        StaticVariablesGenerales.numeroActualPersonaje = pos;
        imagenPersonaje = GameObject.Find("ImagenPersonaje").GetComponent<Image>();
        fondo = GameObject.Find("fondoInterno");
        
        LlenarPersonajes();
    }

    // Update is called once per frame
    void Update()
    {
        if (StaticVariablesGenerales.numeroPersonajeMinimo == StaticVariablesGenerales.numeroActualPersonaje)
        {
            btnPreview.gameObject.SetActive(false);
        }
        else
        {
            btnPreview.gameObject.SetActive(true);
        }
        if (StaticVariablesGenerales.numeroPersonajeMaximo == StaticVariablesGenerales.numeroActualPersonaje)
        {

            btnNext.gameObject.SetActive(false);

        }
        else
        {
            btnNext.gameObject.SetActive(true);
        }
    }

    private void LlenarPersonajes()
    {
        StaticVariablesGenerales.numeroPersonajeMinimo = 0;
        //inicializa la lista 
        listaPersonajes = new List<getsetPersonaje>();
        Sprite f = Resources.Load<Sprite>("Fondos/castillo");
        for (int i=2;i<17;i++)
        {
            string nombre = "Personajes/Castle" + i;
            listaPersonajes.Add(new getsetPersonaje(Resources.Load<Sprite>(nombre),nombre,f,"Castle",0.22f,0.25f));
        } 
        f = Resources.Load<Sprite>("Fondos/forest");
        for (int i=2;i<17;i++)
        {
            string nombre = "Personajes/Forest" + i;
            listaPersonajes.Add(new getsetPersonaje(Resources.Load<Sprite>(nombre),nombre,f, "forest",2.9f,2.9f));
        }
        f = Resources.Load<Sprite>("Fondos/sear");
        for (int i=2;i<17;i++)
        {
            string nombre = "Personajes/Sea" + i;
            listaPersonajes.Add(new getsetPersonaje(Resources.Load<Sprite>(nombre),nombre,f, "sear",0.3f,0.35f));
        } 
        f = Resources.Load<Sprite>("Fondos/village");
        for (int i=2;i<17;i++)
        {
            string nombre = "Personajes/Village" + i;
            listaPersonajes.Add(new getsetPersonaje(Resources.Load<Sprite>(nombre),nombre,f, "village",2.55f,2.8f));
        }
        StaticVariablesGenerales.numeroPersonajeMaximo = listaPersonajes.Count-1;
        if (listaPersonajes.Count > 0)
        {
            imagenPersonaje.sprite = listaPersonajes[pos].spritePersonaje;
            fondo.GetComponent<SpriteRenderer>().sprite = listaPersonajes[pos].fondo;
        }
        CargarPersonaje();
    }
    public void CargarPersonaje()
    {
       
        try
        {
            imagenPersonaje.sprite = listaPersonajes[StaticVariablesGenerales.numeroActualPersonaje].spritePersonaje;
            fondo.GetComponent<SpriteRenderer>().sprite = listaPersonajes[StaticVariablesGenerales.numeroActualPersonaje].fondo;
            fondo.transform.localScale = new Vector3(listaPersonajes[StaticVariablesGenerales.numeroActualPersonaje].scalaX, listaPersonajes[StaticVariablesGenerales.numeroActualPersonaje].scalay, 0);

        }
        catch (Exception ex)
        {

        }
    }
}
