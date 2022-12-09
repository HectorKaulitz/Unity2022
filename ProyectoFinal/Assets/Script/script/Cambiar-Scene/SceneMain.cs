using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMain : MonoBehaviour
{
    public int scene;

    public void Cambiarscena()
    {
        SceneManager.LoadScene(scene);

    }
}
