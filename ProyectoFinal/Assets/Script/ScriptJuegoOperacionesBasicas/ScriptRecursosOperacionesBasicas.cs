using Assets.Script;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptRecursosOperacionesBasicas : MonoBehaviour
{
    public Texture2D cursorTexture;
    private CursorMode cursorMode = CursorMode.ForceSoftware;
    private List<Sprite> numeros,reaccionesBuenas,reaccionesMalas;
    private string tipoOperador;
    private GameObject operador;
    private Sprite sprite;
    private int numeroSuperior, numeroInferior,resultado,cifrasSuperiores=3,cifrasInferiores=3,posRespuestaCorrecta;
    private GameObject unidadSuperior, unidadInferior;
    private GameObject decenaSuperior, decenaInferior;
    private GameObject centenaSuperior, centenaInferior;
    private GameObject millarSuperior, millarInferior;
    
    

    private AudioSource sonidoClick;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.SetCursor(cursorTexture, Vector2.zero, cursorMode);
        tipoOperador = "-";

        StaticVariablesGenerales.escenaActual = "EscenaJuegoOperacionesBasicas";
        numeros = new List<Sprite>();
        reaccionesBuenas = new List<Sprite>();
        reaccionesMalas = new List<Sprite>();
        for(int i =0;i<10;i++)
        {
           numeros.Add(Resources.Load<Sprite>("Numeros/"+i));
        }
        for(int i =0;i<5;i++)
        {
           reaccionesBuenas.Add(Resources.Load<Sprite>("Reacciones/B"+i));
        } 
        for(int i =0;i<5;i++)
        {
           reaccionesMalas.Add(Resources.Load<Sprite>("Reacciones/M"+i));
        }
        operador = GameObject.Find("operador");
        unidadSuperior = GameObject.Find("unidadSuperior");
        unidadInferior = GameObject.Find("unidadInferior");
        decenaSuperior = GameObject.Find("decenaSuperior");
        decenaInferior = GameObject.Find("decenaInferior");
        centenaSuperior = GameObject.Find("centenaSuperior");
        centenaInferior = GameObject.Find("centenaInferior");
        millarSuperior = GameObject.Find("millarSuperior");
        millarInferior = GameObject.Find("millarInferior");

        switch (tipoOperador)
        {
            case "+":
                sprite = Resources.Load<Sprite>("Operadores/suma");
                break;
            case "-":
                sprite = Resources.Load<Sprite>("Operadores/resta");
                break;
            case "*":
                sprite = Resources.Load<Sprite>("Operadores/multiplicacion");
                break;
            case "/":
                sprite = Resources.Load<Sprite>("Operadores/division");
                break;
        }
        operador.GetComponent<SpriteRenderer>().sprite = sprite;
        EliminarObjetos();
        GenerarOperacion();
        GenerarRespuestas();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void EliminarObjetos()
    {
        switch (cifrasSuperiores)
        {
            case 3:
                Destroy(millarSuperior);
                break;
            case 2:
                Destroy(millarSuperior);
                Destroy(centenaSuperior);
                break;
            case 1:
                Destroy(millarSuperior);
                Destroy(centenaSuperior);
                Destroy(decenaSuperior);
                break;
        }

        switch (cifrasInferiores)
        {
            case 3:
                Destroy(millarInferior);
                break;
            case 2:
                Destroy(millarInferior);
                Destroy(centenaInferior);
                break;
            case 1:
                Destroy(millarInferior);
                Destroy(centenaInferior);
                Destroy(decenaInferior);
                break;
        }
    }
    private void GenerarOperacion()
    {   
        

        string num="";
        int ale;
        string temp;
        for (int i= 0;i < cifrasSuperiores;i++)
        {
            temp = num;
            ale = (int)Random.Range(0f, 10f);
            num =""+ale+temp;
            switch (i)
            {
                case 0:
                    unidadSuperior.GetComponent<SpriteRenderer>().sprite = numeros[int.Parse(""+ale)];
                    break;
                case 1:
                    decenaSuperior.GetComponent<SpriteRenderer>().sprite = numeros[int.Parse("" + ale)];
                    break;
                case 2:
                    centenaSuperior.GetComponent<SpriteRenderer>().sprite = numeros[int.Parse("" + ale)];
                    break;
                case 3:
                    millarSuperior.GetComponent<SpriteRenderer>().sprite = numeros[int.Parse("" + ale)];
                    break;
            }
        }
        numeroSuperior = int.Parse(num);

        num = "";
        for (int i = 0; i < cifrasInferiores; i++)
        {
             temp = num;
            ale = (int)Random.Range(0f, 10f);
            num = "" + ale + temp;
            switch (i)
            {
                case 0:
                    unidadInferior.GetComponent<SpriteRenderer>().sprite = numeros[int.Parse("" + ale)];
                    break;
                case 1:
                    decenaInferior.GetComponent<SpriteRenderer>().sprite = numeros[int.Parse("" + ale)];
                    break;
                case 2:
                    centenaInferior.GetComponent<SpriteRenderer>().sprite = numeros[int.Parse("" + ale)];
                    break;
                case 3:
                    millarInferior.GetComponent<SpriteRenderer>().sprite = numeros[int.Parse("" + ale)];
                    break;
            }
        }
        numeroInferior = int.Parse(num);

        switch (tipoOperador)
        {
            case "+":
                resultado = numeroSuperior + numeroInferior;
                break;
            case "-":
                resultado = numeroSuperior - numeroInferior;
                break;
            case "*":
                resultado = numeroSuperior * numeroInferior; ;
                break;
            case "/":
                resultado = numeroSuperior / numeroInferior;
                break;
        }
       
    }
    private void GenerarRespuestas()
    {
        GameObject objeto = null ;
        int cifra,ale;
        
        posRespuestaCorrecta = (int)Random.Range(1f, 5f);//lugar aleatorio donde estara la respuesta

        for (int r=1;r<5;r++)
        {//r = numero de la repsuesta
            if (r == posRespuestaCorrecta)//si es donde va la respuestaCorrecta
            {
                switch (resultado.ToString().Length)
                {
                    case 4:
                        Destroy(GameObject.Find("R" + r + "millon"));
                        break;
                    case 3:
                        Destroy(GameObject.Find("R" + r + "millon"));
                        Destroy(GameObject.Find("R" + r + "millar"));
                        break;
                    case 2:
                        Destroy(GameObject.Find("R" + r + "millon"));
                        Destroy(GameObject.Find("R" + r + "millar"));
                        Destroy(GameObject.Find("R" + r + "centena"));
                        break;
                    case 1:
                        Destroy(GameObject.Find("R" + r + "millon"));
                        Destroy(GameObject.Find("R" + r + "millar"));
                        Destroy(GameObject.Find("R" + r + "centena"));
                        Destroy(GameObject.Find("R" + r + "decena"));
                        break;
                }
                int pos = 0;
                for (int c = resultado.ToString().Length-1; c>-1 ; c--)
                {
                    switch (pos)
                    {
                        case 0:
                            objeto = GameObject.Find("R" + r + "unidad");
                            break;
                        case 1:
                            objeto = GameObject.Find("R" + r + "decena");
                            break;
                        case 2:
                            objeto = GameObject.Find("R" + r + "centena");
                            break;
                        case 3:
                            objeto = GameObject.Find("R" + r + "millar");
                            break;
                        case 4:
                            objeto = GameObject.Find("R" + r + "millon");
                            break;
                    }
                    objeto.GetComponent<SpriteRenderer>().sprite = numeros[int.Parse(resultado.ToString()[c]+"")];
                    pos++;

                }
            }
            else//genera incorrectas
            {
                cifra = (int)Random.Range(1f, 6f);//cuantas cifras va a tener la respuesta
                switch (cifra)
                {
                    case 4:
                        Destroy(GameObject.Find("R" + r + "millon"));
                        break;
                    case 3:
                        Destroy(GameObject.Find("R" + r + "millon"));
                        Destroy(GameObject.Find("R" + r + "millar"));
                        break;
                    case 2:
                        Destroy(GameObject.Find("R" + r + "millon"));
                        Destroy(GameObject.Find("R" + r + "millar"));
                        Destroy(GameObject.Find("R" + r + "centena"));
                        break;
                    case 1:
                        Destroy(GameObject.Find("R" + r + "millon"));
                        Destroy(GameObject.Find("R" + r + "millar"));
                        Destroy(GameObject.Find("R" + r + "centena"));
                        Destroy(GameObject.Find("R" + r + "decena"));
                        break;
                }
                for (int c = 0; c < cifra; c++)
                {
                    ale = (int)Random.Range(0f, 10f);
                    switch (c)
                    {
                        case 0:
                            objeto = GameObject.Find("R" + r + "unidad");
                            break;
                        case 1:
                            objeto = GameObject.Find("R" + r + "decena");
                            break;
                        case 2:
                            objeto = GameObject.Find("R" + r + "centena");
                            break;
                        case 3:
                            objeto = GameObject.Find("R" + r + "millar");
                            break;
                        case 4:
                            objeto = GameObject.Find("R" + r + "millon");
                            break;
                    }
                    objeto.GetComponent<SpriteRenderer>().sprite = numeros[ale];

                }
            }
        }
    }
    public void ValidarRespuesta(int posSeleccionada)
    {
        GameObject reaccion = GameObject.Find("reaccion");
        if(posSeleccionada==posRespuestaCorrecta)
        {
            reaccion.GetComponent<SpriteRenderer>().sprite = reaccionesBuenas[(int)Random.Range(0f, reaccionesBuenas.Count)];
        }
        else
        {
            reaccion.GetComponent<SpriteRenderer>().sprite = reaccionesMalas[(int)Random.Range(0f, reaccionesMalas.Count)];
        }
    }
}
