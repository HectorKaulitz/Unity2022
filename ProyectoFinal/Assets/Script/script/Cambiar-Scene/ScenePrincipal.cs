using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;


public class ScenePrincipal : MonoBehaviour
{
    public int nivel;
    init init;


    void Start()
    {
        init = FindObjectOfType<init>();
    }

    public void CambiarEscena()
    {
        SceneManager.LoadScene(nivel);
    }

    // Update is called once per frame

}