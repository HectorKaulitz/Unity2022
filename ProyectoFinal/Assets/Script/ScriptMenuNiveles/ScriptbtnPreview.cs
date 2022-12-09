using Assets.Script;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScriptbtnPreview : MonoBehaviour
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

    public void NivelAnterior()
    {
        if(StaticVariablesGenerales.tipoNivel>StaticVariablesGenerales.numeroNivelMinimo)
        {
            StaticVariablesGenerales.tipoNivel = StaticVariablesGenerales.tipoNivel - 1;
        }
        sonidoClick = GameObject.Find("SonidoClip").GetComponent<AudioSource>();
        sonidoClick.Play();
        Image imagen = GameObject.Find("ImagenNivel").GetComponent<Image>();
        imagen.GetComponent<ScriptRecursosG>().CargarNivel();
    }
}
