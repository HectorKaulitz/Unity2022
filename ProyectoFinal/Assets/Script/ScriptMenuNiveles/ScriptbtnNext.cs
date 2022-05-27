using Assets.Script;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScriptbtnNext : MonoBehaviour
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

    public void NivelSiguiente()
    {
        if (StaticVariablesGenerales.tipoNivel < StaticVariablesGenerales.numeroNivelMaximo)
        {
            StaticVariablesGenerales.tipoNivel = StaticVariablesGenerales.tipoNivel + 1;
        }
        sonidoClick = GameObject.Find("SonidoClip").GetComponent<AudioSource>();
        sonidoClick.Play();
        Image imagen = GameObject.Find("ImagenNivel").GetComponent<Image>();
        imagen.GetComponent<ScriptRecursosG>().CargarNivel(StaticVariablesGenerales.tipoNivel);
    }
}
