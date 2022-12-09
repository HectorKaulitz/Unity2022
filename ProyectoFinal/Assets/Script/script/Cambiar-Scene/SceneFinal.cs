using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class SceneFinal : MonoBehaviour
{
    public int scene;

   
    public void CambiarEscena()
    {
        SceneManager.LoadScene(scene);
    }

}
