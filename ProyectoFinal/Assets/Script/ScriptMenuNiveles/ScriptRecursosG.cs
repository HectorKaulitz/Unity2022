using Assets.Script;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScriptRecursosG : MonoBehaviour
{
    // Start is called before the first frame update
    private List<Sprite> sprites;
    private List<Sprite> titulosSprites;
    private Image imagen;
    private RectTransform t;
    private Button btnNext, btnPreview;
    private GameObject obG;
    private SpriteRenderer sr;

    void Start()
    {

        btnNext = GameObject.Find("btnNext").GetComponent<Button>();
        btnPreview = GameObject.Find("btnPreview").GetComponent<Button>();
        sprites = new List<Sprite>();
        titulosSprites = new List<Sprite>();
        try
        {
            if (StaticVariablesGenerales.tipoJuego == 1)
            {
                titulosSprites.Add(Resources.Load<Sprite>("Textos/txtVocal"));
                sprites.Add(Resources.Load<Sprite>("Vocales/A"));
                sprites.Add(Resources.Load<Sprite>("Vocales/E"));
                sprites.Add(Resources.Load<Sprite>("Vocales/I"));
                sprites.Add(Resources.Load<Sprite>("Vocales/O"));
                sprites.Add(Resources.Load<Sprite>("Vocales/U"));
            }
            else
            {
                titulosSprites.Add(Resources.Load<Sprite>("Textos/txtNumero"));
                sprites.Add(Resources.Load<Sprite>("Numeros/0"));
                sprites.Add(Resources.Load<Sprite>("Numeros/1"));
                sprites.Add(Resources.Load<Sprite>("Numeros/2"));
                sprites.Add(Resources.Load<Sprite>("Numeros/3"));
                sprites.Add(Resources.Load<Sprite>("Numeros/4"));
                sprites.Add(Resources.Load<Sprite>("Numeros/5"));
                sprites.Add(Resources.Load<Sprite>("Numeros/6"));
                sprites.Add(Resources.Load<Sprite>("Numeros/7"));
                sprites.Add(Resources.Load<Sprite>("Numeros/8"));
                sprites.Add(Resources.Load<Sprite>("Numeros/9"));
            }
        }
        catch (Exception ex)
        {

        }

        obG = GameObject.Find("TituloTipoJuego");
        sr = obG.GetComponent<SpriteRenderer>();
        sr.sprite = titulosSprites[0];
        CargarNivel(StaticVariablesGenerales.tipoNivel);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (StaticVariablesGenerales.numeroNivelMinimo == StaticVariablesGenerales.tipoNivel)
        {
            btnPreview.gameObject.SetActive(false);
        }
        else
        {
            btnPreview.gameObject.SetActive(true);
        }
        if (StaticVariablesGenerales.numeroNivelMaximo == StaticVariablesGenerales.tipoNivel)
        {

            btnNext.gameObject.SetActive(false);

        }
        else
        {
            btnNext.gameObject.SetActive(true);
        }
    }
  

    public void CargarNivel(int tipo)
    {
        imagen = GetComponent<Image>();
       

        try
        {
            t = imagen.rectTransform;
            t.rect.Set(0, 0, 250, 250);
            //t.sizeDelta = new Vector2(64, 64);
            imagen.sprite = sprites[StaticVariablesGenerales.tipoNivel];
        }
        catch (Exception ex)
        {

        }
    }
}
