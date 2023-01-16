using Assets.Script;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Texture2D cursorTexture;
    private CursorMode cursorMode = CursorMode.ForceSoftware;
    

    private AudioSource sonidoClick;
    private Button btnVocales, btnNumeros;


    void Start()
    {
        
       
        //btnVocales=GameObject.Find("BtnVocales").GetComponent<Button>();
        //btnNumeros = GameObject.Find("BtnNumeros").GetComponent<Button>();
        //btnVocales.onClick.AddListener(OnclickVocales);
        //btnNumeros.onClick.AddListener(OnclickNumeros);
        Cursor.SetCursor(cursorTexture, Vector2.zero, cursorMode);
        GameObject.Find("imagenPersonaje").GetComponent<Image>().sprite = Resources.Load<Sprite>("Personajes/"+StaticVariablesGenerales.PersonajeActual);
       


    }
    // Update is called once per frame
    void Update()
    {


    }

    private void ReproducirSonidoClick()
    {
        sonidoClick = GameObject.Find("SonidoClip").GetComponent<AudioSource>();
        sonidoClick.Play();
        
    }

    //void OnGUI()
    //{
    //    Cursor.lockState = CursorLockMode.None;
    //    Cursor.visible = true;
    //}

    //void OnMouseEnter()
    //{
    //    Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);
    //}

    //void OnMouseExit()
    //{
    //    Cursor.SetCursor(null, Vector2.zero, cursorMode);
    //}
}
