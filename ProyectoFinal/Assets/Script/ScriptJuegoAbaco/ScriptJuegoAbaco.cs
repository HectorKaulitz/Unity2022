using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ScriptJuegoAbaco : MonoBehaviour
{
    public Texture2D cursorTexture;
    private CursorMode cursorMode = CursorMode.ForceSoftware;
    private List<GameObject> lineas;
    private List<List<GameObject>> matriz;
    private List<Material> mats;
    private GameObject objetoClonado,objetoEliminar;
    private float inicioObjetos = 1;
    private float cantidadSeparacion = 0.37f;
    private bool enMetodo, clonando, colisionValida=false,insertando=false,eliminando=false;
    private string nombreObjetoClonado, nombreObjetoColisionadoValido;
    private int resultado = 0,resultadoSuma=0;
    private List<Sprite> numeros;
    
    // Start is called before the first frame update
    void Start()
    {
        Cursor.SetCursor(cursorTexture, Vector2.zero, cursorMode);
        objetoClonado = null;
        lineas = new List<GameObject>();
        matriz = new List<List<GameObject>>();
        for (int i = 0; i < 4; i++)
        {
            matriz.Add(new List<GameObject>());
        }
         CrearLineas();
        GenerarNumero();
        enMetodo = false;
        clonando = false;
        StartCoroutine(Col());
    }
    private IEnumerator Col()
    {
        while (true)
        {
            if (Input.GetMouseButton(0) && colisionValida)
            {//0.9-4.6
                
                float inicio = 0.9f, suma = 0.37f;
                int pos = 0;
                clonando = false;
                insertando = true;
                GameObject objetoInsertar = GameObject.Instantiate(objetoClonado);
                SpriteRenderer spriteRenderer = objetoInsertar.GetComponent<SpriteRenderer>();
                spriteRenderer.sortingOrder = 1;
                switch (nombreObjetoColisionadoValido)
                {
                    case "0":
                        pos = matriz[0].Count;
                        objetoInsertar.transform.localPosition = new Vector3(-3f, inicio + (suma * pos));
                        Destroy(objetoInsertar.GetComponent<BoxCollider2D>());
                        matriz[0].Add(objetoInsertar);
                        break;
                    case "1":
                        pos = matriz[1].Count;
                        objetoInsertar.transform.localPosition = new Vector3(-1f, inicio + (suma * pos));
                        Destroy(objetoInsertar.GetComponent<BoxCollider2D>());
                        matriz[1].Add(objetoInsertar);
                        break;
                    case "2":
                        pos = matriz[2].Count;
                        objetoInsertar.transform.localPosition = new Vector3(1f, inicio + (suma * pos));
                        Destroy(objetoInsertar.GetComponent<BoxCollider2D>());
                        matriz[2].Add(objetoInsertar);
                        break;
                    case "3":
                        pos = matriz[3].Count;
                        objetoInsertar.transform.localPosition = new Vector3(3f, inicio + (suma * pos));
                        Destroy(objetoInsertar.GetComponent<BoxCollider2D>());
                        matriz[3].Add(objetoInsertar);
                        break;
                }
                Destroy(objetoClonado);
                CalcularResultado();
                insertando = false;
            }
            yield return new WaitForSeconds(0.01f);
                yield return null;
            

        }
    }

    private void CalcularResultado()
    {

        resultadoSuma = 0;
        resultadoSuma = resultadoSuma + (matriz[0].Count * 1);
        resultadoSuma = resultadoSuma + (matriz[1].Count * 10);
        resultadoSuma = resultadoSuma + (matriz[2].Count * 100);
        resultadoSuma = resultadoSuma + (matriz[3].Count * 1000);
        GenerarNumero(resultadoSuma);
    }
    // Update is called once per frame
    void Update()
    {
        if (clonando & objetoClonado != null & Input.GetMouseButton(1))
        {
            Destroy(objetoClonado);
            objetoClonado = null;
            clonando = false;
        }
        if (eliminando & objetoEliminar != null & Input.GetMouseButton(1))
        {
            Destroy(objetoEliminar);
            objetoEliminar = null;
            eliminando = false;
        }
        if (clonando & objetoClonado != null)
        {
            objetoClonado.transform.localPosition= new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y, 1);
           
        }
        if (eliminando & objetoEliminar != null)
        {
            objetoEliminar.transform.localPosition = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y, 1);
           
        }



    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //if (clonando & objetoClonado != null)
        //{
        //}
    }

    public void CambiarBandera(bool ban)
    {
        colisionValida = ban;
    }
   
    private void CrearLineas()
    {

        Material material = null;
        mats = new List<Material>();
        mats.AddRange(Resources.LoadAll("Materials", typeof(Material)).Cast<Material>().ToArray());
        foreach(Material m in mats)
        {
            if(m.name.ToString().Equals("Vol_35_3_Lava"))
            {
                material = m;
            }
        }
        float inicio = -3;
        for (int i = 0; i < 4; i++)
        {
            GameObject myLine = new GameObject();
            //myLine.transform.position = new Vector3(inicio, 1.6f, 0);
            myLine.AddComponent<LineRenderer>();
            LineRenderer lr;
            lr = myLine.GetComponent<LineRenderer>();
            lr.SetPosition(0, new Vector3(inicio, 0.90f, 0));
            // lr.material = (Material)Resources.Load("Materials/Vol_35_3_Lava.mat");Assets/Resources/Materials/Vol_35_3_Lava.mat
            lr.material = material;
            lr.textureMode = LineTextureMode.Tile;
            lr.SetWidth(0.40f, 0.40f);
            lr.SetPosition(1, new Vector3(inicio, 4.6f, 0));
            
            myLine.AddComponent<Rigidbody2D>();
            Rigidbody2D rg = myLine.GetComponent<Rigidbody2D>();
            rg.bodyType = RigidbodyType2D.Static;
            //rg.gravityScale = 0;

            myLine.AddComponent<BoxCollider2D>();
            BoxCollider2D box= myLine.GetComponent<BoxCollider2D>();
            box.size = new Vector2(0.63f,3.9f);
            box.offset = new Vector2(inicio,2.7f);
            myLine.name = "" + i;

            inicio = inicio + 2;
            lineas.Add(myLine);
        }
    }

    public void Collision(Collision2D collision)
    {
        if (clonando & objetoClonado != null)
        {
            //colisionValida = false;
            nombreObjetoClonado = objetoClonado.name;
            nombreObjetoClonado = nombreObjetoClonado.Substring(0, nombreObjetoClonado.IndexOf("-"));
            string nombreObjetoColisionado = collision.collider.name;
            if (nombreObjetoColisionado == "0" && nombreObjetoClonado == "1")
            {
                colisionValida = true;
                nombreObjetoColisionadoValido = collision.collider.name;
            }
            if (nombreObjetoColisionado == "1" && nombreObjetoClonado == "10")
            {
                colisionValida = true;
                nombreObjetoColisionadoValido = collision.collider.name;
            }
            if (nombreObjetoColisionado == "2" && nombreObjetoClonado == "100")
            {
                colisionValida = true;
                nombreObjetoColisionadoValido = collision.collider.name;
            }
            if (nombreObjetoColisionado == "3" && nombreObjetoClonado == "1000")
            {
                colisionValida = true;
                nombreObjetoColisionadoValido = collision.collider.name;
            }
            
        }
    }
    
    public void CollisionEliminar(Collision2D collision)
    {
        if (eliminando & objetoEliminar != null)
        {
            string nombreObjetoColisionado = collision.collider.name;
            if (nombreObjetoColisionado == "0" )
            {
                if(matriz[0].Count>0)
                {
                    Destroy(matriz[0][matriz[0].Count - 1]);
                    matriz[0].RemoveAt(matriz[0].Count - 1);
                }
            }
            if (nombreObjetoColisionado == "1")
            {
                if (matriz[1].Count > 0)
                {
                    Destroy(matriz[1][matriz[1].Count - 1]);
                    matriz[1].RemoveAt(matriz[1].Count - 1);
                }
            }
            if (nombreObjetoColisionado == "2")
            {
                if (matriz[2].Count > 0)
                {
                    Destroy(matriz[2][matriz[2].Count - 1]);
                    matriz[2].RemoveAt(matriz[2].Count - 1);
                }
            }
            if (nombreObjetoColisionado == "3")
            {
                if (matriz[3].Count > 0)
                {
                    Destroy(matriz[3][matriz[3].Count - 1]);
                    matriz[3].RemoveAt(matriz[3].Count - 1);
                }
            }
            CalcularResultado();

        }
    }

    public void DuplicarObjeto(int pos)
    {
        if (!enMetodo && !insertando && !eliminando)
        {
            enMetodo = true;
            if (!clonando)
            {
                objetoClonado = new GameObject();
                objetoClonado.SetActive(false);

                objetoClonado.AddComponent<Rigidbody2D>();
                Rigidbody2D rg = objetoClonado.GetComponent<Rigidbody2D>();
                rg.bodyType = RigidbodyType2D.Dynamic;
                rg.gravityScale = 0;
                rg.angularDrag = 0;
                rg.constraints = RigidbodyConstraints2D.FreezeAll;
                rg.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
                
                objetoClonado.AddComponent<ScriptColisionAros>();

                objetoClonado.AddComponent<SpriteRenderer>();
                SpriteRenderer spriteRenderer = objetoClonado.GetComponent<SpriteRenderer>();
                spriteRenderer.sortingOrder = 2;

                objetoClonado.transform.localScale = new Vector3(0.35f, 0.2f, 0);

                objetoClonado.AddComponent<BoxCollider2D>();
                BoxCollider2D box = objetoClonado.GetComponent<BoxCollider2D>();
                box.size = new Vector2(4.3f, 3.394865f);
                box.offset = new Vector2(0f, 0.05756736f);
               
                
                    switch (pos)
                    {
                        case 1:
                            if (matriz[0].Count < 10)
                            {
                                spriteRenderer.sprite = Resources.Load<Sprite>("Abaco/unidad");
                                objetoClonado.name = pos + "-" + matriz[0].Count;
                                objetoClonado.SetActive(true);
                            }
                            else
                            {
                                Destroy(objetoClonado);
                                objetoClonado = null;
                            }
                            break;
                        case 10:
                            if (matriz[1].Count < 10)
                            {
                                spriteRenderer.sprite = Resources.Load<Sprite>("Abaco/decena");
                                objetoClonado.name = pos + "-" + matriz[1].Count;
                                objetoClonado.SetActive(true);
                            }
                            else
                            {
                                Destroy(objetoClonado);
                                objetoClonado = null;
                            }
                            break;
                        case 100:
                            if (matriz[2].Count < 10)
                            {
                                spriteRenderer.sprite = Resources.Load<Sprite>("Abaco/centena");
                                objetoClonado.name = pos + "-" + matriz[2].Count;
                                objetoClonado.SetActive(true);
                            }
                            else
                            {
                                Destroy(objetoClonado);
                                objetoClonado = null;
                            }
                            break;
                        case 1000:
                            if (matriz[3].Count < 10)
                            {
                                spriteRenderer.sprite = Resources.Load<Sprite>("Abaco/millar");
                                objetoClonado.name = pos + "-" + matriz[3].Count;
                                objetoClonado.SetActive(true);
                            }
                            else
                            {
                                Destroy(objetoClonado);
                                objetoClonado = null;
                            }
                            break;
                    }
                     if(objetoClonado!=null)
                        clonando = true;
                

            }
            enMetodo = false;
        }
    }

    private void GenerarNumero()
    {
        int r = 1;
        numeros= new List<Sprite>();
        float  limite = 11110f;
        GameObject objeto = null;
        
        for(int i =0;i<10;i++)
        {
           numeros.Add(Resources.Load<Sprite>("Numeros/"+i));
        }

        resultado = (int)Random.Range(1f, limite);
        //switch (resultado.ToString().Length)
        //{
        //    case 4:
        //        Destroy(GameObject.Find("R" + r + "millon"));
        //        break;
        //    case 3:
        //        Destroy(GameObject.Find("R" + r + "millon"));
        //        Destroy(GameObject.Find("R" + r + "millar"));
        //        break;
        //    case 2:
        //        Destroy(GameObject.Find("R" + r + "millon"));
        //        Destroy(GameObject.Find("R" + r + "millar"));
        //        Destroy(GameObject.Find("R" + r + "centena"));
        //        break;
        //    case 1:
        //        Destroy(GameObject.Find("R" + r + "millon"));
        //        Destroy(GameObject.Find("R" + r + "millar"));
        //        Destroy(GameObject.Find("R" + r + "centena"));
        //        Destroy(GameObject.Find("R" + r + "decena"));
        //        break;
        //}
        int pos = 0;
        for (int c = resultado.ToString().Length - 1; c > -1; c--)
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
            objeto.GetComponent<SpriteRenderer>().sprite = numeros[int.Parse(resultado.ToString()[c] + "")];
            pos++;
        }

              
    }

    private void GenerarNumero(int res)
    {
        int r = 2;

         GameObject.Find("R" + r + "unidad").GetComponent<SpriteRenderer>().sprite = numeros[0]; 
         GameObject.Find("R" + r + "decena").GetComponent<SpriteRenderer>().sprite = numeros[0]; 
        GameObject.Find("R" + r + "centena").GetComponent<SpriteRenderer>().sprite = numeros[0];
        GameObject.Find("R" + r + "millar").GetComponent<SpriteRenderer>().sprite = numeros[0];
        GameObject.Find("R" + r + "millon").GetComponent<SpriteRenderer>().sprite = numeros[0];

        GameObject objeto = null;
        int pos = 0;
        for (int c = res.ToString().Length - 1; c > -1; c--)
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
            objeto.GetComponent<SpriteRenderer>().sprite = numeros[int.Parse(res.ToString()[c] + "")];
            pos++;
        }


    }

    public void ModoEliminar()
    {
        if (!enMetodo && !insertando && !clonando)
        {
            enMetodo = true;
            if (!eliminando)
            {

                objetoEliminar = new GameObject();
                objetoEliminar.AddComponent<Rigidbody2D>();
                Rigidbody2D rg = objetoEliminar.GetComponent<Rigidbody2D>();
                rg.bodyType = RigidbodyType2D.Dynamic;
                rg.gravityScale = 0;
                rg.angularDrag = 0;
                rg.constraints = RigidbodyConstraints2D.FreezeAll;
                rg.collisionDetectionMode = CollisionDetectionMode2D.Continuous;

                objetoEliminar.AddComponent<ScriptColisionEliminarAro>();

                objetoEliminar.AddComponent<SpriteRenderer>();
                SpriteRenderer spriteRenderer = objetoEliminar.GetComponent<SpriteRenderer>();
                spriteRenderer.sortingOrder = 2;

                objetoEliminar.transform.localScale = new Vector3(0.12f, 0.12f, 0);

                objetoEliminar.AddComponent<BoxCollider2D>();
                BoxCollider2D box = objetoEliminar.GetComponent<BoxCollider2D>();
                box.size = new Vector2(4.3f, 3.394865f);
                box.offset = new Vector2(0f, 0.05756736f);
                spriteRenderer.sprite = Resources.Load<Sprite>("Botones/incorrecto");
                eliminando = true;
            }
            
            enMetodo = false;
        }
    }
                


}
