using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;
using Assets.Script;

public class init : MonoBehaviour
{
    public Transform pos;   

    public GameObject[] animales = new GameObject[12]; //Vector de todos los animales

    System.Random ran = new System.Random();
    public int posx, posy, ranC, ranAux, vidas;
    public int num, contadorAnamales = 0;//Contador de animales eliminados                      
    public Text t;
    public String nombre;
    char[] nombrechar;

    SceneFinal scf;
    
 
    void Start()
    {
        vidas = 3;
       
        StaticVariablesGenerales.puntuacionNivelActual = 100;
        StaticVariablesGenerales.tiempoJugado = Time.time;
        scf = FindObjectOfType<SceneFinal>();


        num =int.Parse( StaticVariablesGenerales.recurso); //numero de animales a agarrar
        ranC = ran.Next(0, 4);//Animal principal que se va a agarrar

        switch (ranC)
        {
            case 0: ranAux = ran.Next(0, 3);
                    break;

            case 1: ranAux = ran.Next(0, 3);
                     ranC = 3;
                    break;
            case 2:
                    ranAux = ran.Next(0, 3);
                    ranC = 6;
                    break;

            case 3: ranAux = ran.Next(0, 3);
                    ranC = 9;
                    break;

        }

        nombrechar = animales[ranC].name.ToCharArray();// Se obtiene el nombre del animal
        
        for(int i=0; i < nombrechar.Length-1; i++)
        {
            nombre += nombrechar[i];
        }

       
        GameObject.Find("texto").GetComponent<Text>().text = "Atrapar "+num+" " + nombre; //Texto 
        t.transform.position = new Vector3(900,950,0);

    

        ImprimirAnimal();
        ImprimirAnimalSecundario();
    }


    void Update()
    {
       
          
        if (contadorAnamales == num || vidas <= 0)
        {
            StaticVariablesGenerales.tiempoJugado = (Time.time) - (StaticVariablesGenerales.tiempoJugado);
            SceneManager.LoadScene("EscenaPuntuacion");
        }
        
    }

    private void ImprimirAnimal()
    {
        for (int i = 0; i < num; i++)
        {
            ranAux = ran.Next(0, 3);
            posx = ran.Next(0, 1800);
            posy = ran.Next(400, 750);

            //Controlar que no salgan en el granero
            if (posx < 750)
            {
                posy = ran.Next(30, 450);
                Instantiate(animales[ranC+ranAux], new Vector3(posx, posy, 0), transform.rotation);
            }
            else
            {
                Instantiate(animales[ranC+ranAux], new Vector3(posx, posy, 0), transform.rotation);
            }
        }  
    }

    private void ImprimirAnimalSecundario()
    {
        int nums = ran.Next(1, 9);//variables para imprimir esa cantidad de animales

        for (int i = 0; i < animales.Length; i++)//For para imprimir todos los animales del vector
        {
            // print("ranc: " + ranC +" ranc1: "+(ranC+1));
            if (i != ranC && i != (ranC + 1) && i != (ranC + 2))//Si el animalSecundario es diferente del principal mas sus 2 variantes
            {
                for (int e = 0; e < (nums/3); e++)
                {
                    posx = ran.Next(750, 1800);
                    posy = ran.Next(50, 750);

                    Instantiate(animales[i], new Vector3(posx, posy, 0), transform.rotation);
                }
            }
        }
    }
}
