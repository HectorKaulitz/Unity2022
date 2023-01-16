using Assets.Script;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScriptRecursoJuegoVocal : MonoBehaviour
{
    private List<Sprite> listaFondosSprite,spriteValidos,spritesDiferentes;
    private Image imagenFondo;
    private GameObject fondoObjeto;
    
    // Start is called before the first frame update
    void Start()
    {
       
       
        StaticVariablesGenerales.puntuacionNivelActual = 100;
        
        StaticVariablesGenerales.aciertos = 0;
        CargarRecursos();
        StaticVariablesGenerales.tiempoJugado=Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        JuegoTerminado();
    }

    private void JuegoTerminado()
    {
        if(StaticVariablesGenerales.aciertos==StaticVariablesGenerales.dificultadNivel)
        {
            StaticVariablesGenerales.tiempoJugado = (Time.time) - (StaticVariablesGenerales.tiempoJugado);
            SceneManager.LoadScene("EscenaPuntuacion");
        }

    }
    private void CargarRecursos()
    {
        //desactivar los estados
        for(int i=1;i<5;i++)
        {
            GameObject.Find("Estado" + i).GetComponent<SpriteRenderer>().color = new Color(255,255,255,0);
        }
        List<int> numerosUsados = new List<int>();
        List<int> contenedorUsado = new List<int>();
        //LISTAS
        listaFondosSprite = new List<Sprite>();
        spriteValidos = new List<Sprite>();
        spritesDiferentes = new List<Sprite>();
        //FONDOS
        int min = 0, max = 0;
        fondoObjeto = GameObject.Find("fondoInterno");
        listaFondosSprite.Add(Resources.Load<Sprite>("Fondos/cueva"));
        listaFondosSprite.Add(Resources.Load<Sprite>("Fondos/desierto"));
        listaFondosSprite.Add(Resources.Load<Sprite>("Fondos/isla"));
        listaFondosSprite.Add(Resources.Load<Sprite>("Fondos/mar"));
        listaFondosSprite.Add(Resources.Load<Sprite>("Fondos/nubePasto"));
        max = listaFondosSprite.Count();
        fondoObjeto.GetComponent<SpriteRenderer>().sprite=listaFondosSprite[ Random.Range(min,max)];
        if (StaticVariablesGenerales.tipoJuego == 1)//vocales
        {
            //IMAGEN VOCAL 
            GameObject.Find("Recurso").GetComponent<Image>().sprite = Resources.Load<Sprite>("Abecedario/" + StaticVariablesGenerales.recurso.ToString().ToUpper()); ;

            //SPRITES VOCAL VALIDA
            for (int i = 1; i < 6; i++)
            {
                spriteValidos.Add(Resources.Load<Sprite>("ObjetosVocales/" + StaticVariablesGenerales.recurso.ToString().ToUpper() + "" + i));
            }

            for (int i = 0; i < StaticVariablesGenerales.dificultadNivel; i++)
            {
                int cont = -1;
                while (cont == -1)
                {
                    cont = Random.Range(1, 5);
                    foreach (int cu in contenedorUsado)
                    {
                        if (cu == cont)
                        {
                            cont = -1;
                            break;
                        }
                    }

                }
                int pos = -1;
                while (pos == -1)
                {

                    pos = Random.Range(0, spriteValidos.Count);
                    foreach (int nu in numerosUsados)
                    {
                        if (pos == nu)
                        {
                            pos = -1;
                            break;
                        }
                    }

                }
                GameObject.Find("btnContenedor" + cont).GetComponent<Image>().sprite = spriteValidos[pos];
                contenedorUsado.Add(cont);
                numerosUsados.Add(pos);
            }

            //sprites diferentes
            numerosUsados.Clear();
            for (int i = 1; i < 13; i++)
            {
                spritesDiferentes.Add(Resources.Load<Sprite>("ObjetosDiferentes/d" + i));
            }
            bool usado;
            for (int c = 1; c < 5; c++)
            {
                usado = false;
                foreach (int cu in contenedorUsado)
                {
                    if (c == cu)
                    {
                        usado = true;
                        break;
                    }
                }
                if (!usado)
                {

                    int pos = -1;
                    while (pos == -1)
                    {

                        pos = Random.Range(0, spritesDiferentes.Count);
                        foreach (int nu in numerosUsados)
                        {
                            if (pos == nu)
                            {
                                pos = -1;
                                break;
                            }
                        }

                    }
                    GameObject.Find("btnContenedor" + c).GetComponent<Image>().sprite = spritesDiferentes[pos];
                    contenedorUsado.Add(c);
                    numerosUsados.Add(pos);
                }
            }
        }
        else
        {
            //numeros
            //IMAGEN Numero
            GameObject.Find("Recurso").GetComponent<Image>().sprite = Resources.Load<Sprite>("Numeros/" + StaticVariablesGenerales.recurso.ToString().ToUpper()); ;

            //SPRITES numero valido
            for (int i = 1; i < 2; i++)
            {
                spriteValidos.Add(Resources.Load<Sprite>("NumerosAgrupacion/" + StaticVariablesGenerales.recurso.ToString().ToUpper()));
            }

            int cont = -1;
            while (cont == -1)
            {
                cont = Random.Range(1, 5);
                foreach (int cu in contenedorUsado)
                {
                    if (cu == cont)
                    {
                        cont = -1;
                        break;
                    }
                }

            }
            int pos = -1;
            while (pos == -1)
            {

                pos = Random.Range(0, spriteValidos.Count);
                foreach (int nu in numerosUsados)
                {
                    if (pos == nu)
                    {
                        pos = -1;
                        break;
                    }
                }

            }
            GameObject.Find("btnContenedor" + cont).GetComponent<Image>().sprite = spriteValidos[pos];
            contenedorUsado.Add(cont);
            numerosUsados.Add(pos);


            //sprites diferentes
            numerosUsados.Clear();

            for (int i = 1; i < 10; i++)
            {
                if (i != int.Parse(StaticVariablesGenerales.recurso))
                {
                    spritesDiferentes.Add(Resources.Load<Sprite>("NumerosAgrupacion/" + i));
                }
            }

            bool usado;
            for (int c = 1; c < 5; c++)
            {
                usado = false;
                foreach (int cu in contenedorUsado)
                {
                    if (c == cu)
                    {
                        usado = true;
                        break;
                    }
                }
                if (!usado)
                {

                    int pos2 = -1;
                    while (pos2 == -1)
                    {

                        pos2 = Random.Range(0, spritesDiferentes.Count);
                        foreach (int nu in numerosUsados)
                        {
                            if (pos2 == nu)
                            {
                                pos2 = -1;
                                break;
                            }
                        }

                    }
                    GameObject.Find("btnContenedor" + c).GetComponent<Image>().sprite = spritesDiferentes[pos2];
                    contenedorUsado.Add(c);
                    numerosUsados.Add(pos2);
                }
            }
        }
            
    }
}
