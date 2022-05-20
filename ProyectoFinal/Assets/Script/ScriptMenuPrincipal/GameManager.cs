using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private Texture2D cursorTexture;
    private CursorMode cursorMode = CursorMode.Auto;
    private Vector2 hotSpot = Vector2.zero;

    private AudioSource sonidoClick;
    private Button btnVocales, btnNumeros;


    void Start()
    {
      

        //btnVocales=GameObject.Find("BtnVocales").GetComponent<Button>();
        //btnNumeros = GameObject.Find("BtnNumeros").GetComponent<Button>();
        //btnVocales.onClick.AddListener(OnclickVocales);
        //btnNumeros.onClick.AddListener(OnclickNumeros);
    }
    // Update is called once per frame
    void Update()
    {
        

    }
    private void OnclickVocales()
    {
        ReproducirSonidoClick();
    }

    private void OnclickNumeros()
    {
        ReproducirSonidoClick();
    }

    private void ReproducirSonidoClick()
    {
        sonidoClick = GameObject.Find("SonidoClip").GetComponent<AudioSource>();
        sonidoClick.Play();
    }

    void OnGUI()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    void OnMouseEnter()
    {
        Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);
    }

    void OnMouseExit()
    {
        Cursor.SetCursor(null, Vector2.zero, cursorMode);
    }
}
