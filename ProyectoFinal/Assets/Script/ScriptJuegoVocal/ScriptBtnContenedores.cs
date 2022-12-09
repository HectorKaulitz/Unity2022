using Assets.Script;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScriptBtnContenedores : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void VerificarContenedor(int c)
    {


      
        char[] caracteres = null;
        GameObject estado= GameObject.Find("Estado"+c);
        GameObject contenedor=GameObject.Find("btnContenedor"+c);
        string nombreSprite = contenedor.GetComponent<Image>().sprite.name;
        if(nombreSprite.Length>0)
        {
            caracteres = nombreSprite.ToCharArray();
        }
        if (caracteres!=null)
        {   
            estado.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 255); ;
            if (StaticVariablesGenerales.tipoJuego == 1)
            {
                if (caracteres[0].Equals('d'))
                {
                    try
                    {
                        GameObject.Find("AudioIncorrecto").GetComponent<AudioSource>().Play();
                    }
                    catch (Exception ex)
                    {
                    }
                    estado.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Botones/incorrecto");
                    StaticVariablesGenerales.puntuacionNivelActual -= 25;
                }
                else
                {
                    try
                    {
                        GameObject.Find("AudioCorrecto").GetComponent<AudioSource>().Play();
                    }
                    catch (Exception ex)
                    {
                    }
                    estado.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Botones/correcto");
                    StaticVariablesGenerales.aciertos++;
                }
            }
            else
            {
                if (!(caracteres[0] + "").Equals("" + StaticVariablesGenerales.recurso))
                {

                    estado.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Botones/incorrecto");
                    StaticVariablesGenerales.puntuacionNivelActual -= 25;
                }
                else
                {
                    estado.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Botones/correcto");
                    StaticVariablesGenerales.aciertos++;
                }
            }
            contenedor.GetComponent<Button>().enabled = false;
        }
    }
}

