using Assets.Script;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScriptInformacionPuntuacion : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject.Find("Personaje").GetComponent<Image>().sprite = Resources.Load<Sprite>("Personajes/" + StaticVariablesGenerales.PersonajeActual);
        GameObject.Find("txtPuntuacion").GetComponent<Text>().text = StaticVariablesGenerales.puntuacionNivelActual+"";
        GameObject.Find("txtTiempo").GetComponent<Text>().text = StaticVariablesGenerales.tiempoJugado+"";
        GameObject rankin = GameObject.Find("iconoRanking");
        switch(StaticVariablesGenerales.puntuacionNivelActual)
        {
            case 100:
                rankin.GetComponent<Image>().sprite = Resources.Load<Sprite>("Rank/Oro");
                GameObject.Find("estrella1").GetComponent<SpriteRenderer>().sprite= Resources.Load<Sprite>("Rank/estrellaE");
                GameObject.Find("estrella2").GetComponent<SpriteRenderer>().sprite= Resources.Load<Sprite>("Rank/estrellaE");
                GameObject.Find("estrella3").GetComponent<SpriteRenderer>().sprite= Resources.Load<Sprite>("Rank/estrellaE");
                break;
            case 75:
                rankin.GetComponent<Image>().sprite = Resources.Load<Sprite>("Rank/Plata");
                GameObject.Find("estrella1").GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Rank/estrellaE");
                GameObject.Find("estrella2").GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Rank/estrellaE");
                GameObject.Find("estrella3").GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Rank/estrellaA");
                break;
            case 50:
                rankin.GetComponent<Image>().sprite = Resources.Load<Sprite>("Rank/Plata2");
                GameObject.Find("estrella1").GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Rank/estrellaE");
                GameObject.Find("estrella2").GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Rank/estrellaA");
                GameObject.Find("estrella3").GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Rank/estrellaA");
                break;
            case 25:
                rankin.GetComponent<Image>().sprite = Resources.Load<Sprite>("Rank/Bronce");
                GameObject.Find("estrella1").GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Rank/estrellaA");
                GameObject.Find("estrella2").GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Rank/estrellaA");
                GameObject.Find("estrella3").GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Rank/estrellaA");
                break;

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
