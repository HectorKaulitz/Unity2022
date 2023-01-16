using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class ScriptRelacionLinea : MonoBehaviour
{
    private List<Sprite> colorPunto;
    private int dificultad = 2;//0 principiante,1medio,2 avanzado
    private GameObject primerSeleccion;
    private bool pintando = false,enMetodo=false;
    private List<GameObject> lineas;
    private List<Material> mats;
    private List<int> materialUsado;
    LineRenderer lr;
    string lado = "",ultimoladopintado="";
    // Start is called before the first frame update
    void Start()
    {
        lineas = new List<GameObject>();
        mats = new List<Material>();
        colorPunto = new List<Sprite>();
        materialUsado = new List<int>();
        for (int i = 0; i < 9; i++)
        {
            colorPunto.Add(Resources.Load<Sprite>("Color/b" + i));
        }
        mats.AddRange(Resources.LoadAll("Materials", typeof(Material)).Cast<Material>().ToArray());
        
        ObtenerYEliminarObjetos();

        //for()

    }

    private void ObtenerYEliminarObjetos()
    {
        int puntos = -1;
        int ale = (int)Random.Range(0f, 8f);
        int ale2 = ale;
        while(ale2==ale)
        {
            ale2=(int)Random.Range(0f, 8f);
        }
        //derechos
        switch (dificultad)
        {
            case 2://deja los 5 puntos
                puntos = 5;
                break;
            case 1://deja 4 puntos
                GameObject.Find("d2").transform.localPosition = new Vector3(1600f, 650f);
                GameObject.Find("d3").transform.localPosition = new Vector3(1600f, 400f);
                GameObject.Find("d4").transform.localPosition = new Vector3(1600f, 125f);
                

                GameObject.Find("i2").transform.localPosition = new Vector3(800f, 650f);
                GameObject.Find("i3").transform.localPosition = new Vector3(800f, 400f);
                GameObject.Find("i4").transform.localPosition = new Vector3(800f, 125f);

                GameObject.Find("v2").transform.localPosition = new Vector3(-4.113085f, 2.8f);
                GameObject.Find("v3").transform.localPosition = new Vector3(-4.113085f, 0.5f);
                GameObject.Find("v4").transform.localPosition = new Vector3(-4.113085f, -2.085469f);

                GameObject.Find("r2").transform.localPosition = new Vector3(6.5f, 2.8f);
                GameObject.Find("r3").transform.localPosition = new Vector3(6.5f, 0.5f);
                GameObject.Find("r4").transform.localPosition = new Vector3(6.5f, -2.085469f);

                Destroy(GameObject.Find("d5"));

                Destroy(GameObject.Find("i5"));

                Destroy(GameObject.Find("v5"));

                Destroy(GameObject.Find("r5"));

                puntos = 4;
                break;
            case 0://deja 3 puntos
                GameObject.Find("d2").transform.localPosition = new Vector3(1600f, 525f);
                GameObject.Find("d3").transform.localPosition = new Vector3(1600f, 125f);

                

                GameObject.Find("i2").transform.localPosition = new Vector3(800f, 525f);
                GameObject.Find("i3").transform.localPosition = new Vector3(800f, 125f);

                GameObject.Find("v2").transform.localPosition = new Vector3(-4.113085f, 1.614531f);
                GameObject.Find("v3").transform.localPosition = new Vector3(-4.113085f, -2.085469f);

                GameObject.Find("r2").transform.localPosition = new Vector3(6.5f, 1.614531f);
                GameObject.Find("r3").transform.localPosition = new Vector3(6.5f, -2.085469f);
                
                Destroy(GameObject.Find("d4"));
                Destroy(GameObject.Find("d5"));

                Destroy(GameObject.Find("i4"));
                Destroy(GameObject.Find("i5"));

                Destroy(GameObject.Find("v4"));
                Destroy(GameObject.Find("v5"));

                Destroy(GameObject.Find("r4"));
                Destroy(GameObject.Find("r5"));

                puntos = 3;
                break;
        }
        if (colorPunto.Count > 0)
        {
            for (int i = 1; i < puntos + 1; i++)
            {
                GameObject.Find("d" + i).GetComponent<Image>().sprite = colorPunto[ale];
                GameObject.Find("i" + i).GetComponent<Image>().sprite = colorPunto[ale2];
            }
        }
        
        
    }
    // Update is called once per frame
    void Update()
    {
        if (pintando & lr!=null)
        {
            lr.SetPosition(1, new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y, 1));
        }
        //if (Input.GetMouseButtonDown(0) & pintando && !enMetodo)
        //{
        //    PintarLinea(-1);
        //}
    }
      
    public void setLado(string lado)
    {
        this.lado = lado;
    }
    public void PintarLinea(int punto)
    {
        bool encontro = true;
        if (!enMetodo)
        {
            enMetodo = true;
            if (!pintando)
            {
                //creamos el objeto que contendra la linea
                GameObject myLine = new GameObject();
                myLine.transform.position = new Vector3(0, 0, 0);
                myLine.AddComponent<LineRenderer>();
                lineas.Add(myLine);
                //le ponemos la linea
                lr = myLine.GetComponent<LineRenderer>();
                //lr.material = new Material(Shader.Find("Particles/Alpha Blended Premultiply"));
                lr.textureMode = LineTextureMode.Tile;
                if (mats.Count > 0)
                {
                    int ale=-1;
                    while (encontro)
                    {
                        encontro = false;
                        ale = (int)Random.Range(0f, mats.Count - 1f);
                        if (materialUsado.Count > 0)
                        {
                            foreach (int m in materialUsado)
                            {
                                if (ale == m)
                                {
                                    encontro = true;
                                    break;
                                }
                            }
                        }
                    }
                    if (ale != -1)
                    {
                        lr.material = mats[ale];
                        materialUsado.Add(ale);
                    }
                }
                //lr.SetColors(Color.black, new Color(1f, 1f, 1f, 1f));

                //grosor
                lr.SetWidth(0.25f, 0.25f);
                //primera posicion
                //lr.SetPosition(0, pd1.transform.position);

                lr.SetPosition(0, new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y, 1));
                pintando = true;
                ultimoladopintado = lado;
            }
            else
            {
                if (!lado.Equals(ultimoladopintado))//no pinte 2 puntos del mismo lado entre ellos
                {
                    lr.SetPosition(1, new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y, 1));
                    pintando = false;
                }
            }
            enMetodo = false;
            lado = "";
        }
    }
}
