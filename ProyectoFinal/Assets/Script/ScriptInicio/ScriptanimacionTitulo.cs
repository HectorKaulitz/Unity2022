using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptanimacionTitulo : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject titulo,pajaro;
    private List<AudioClip> sonidos;
    private AudioSource audio;

    [SerializeField]float velocidad = 3, frecuencia = 22, magnitud = (float)0.5;
    private Vector3 pos, escala;
    bool movDerecha = false;

    private List<Sprite> pajaroImagenes;

    private int oculto = -1;



    void Start()
    {
       titulo= GameObject.Find("Titulos");
        sonidos = new List<AudioClip>();
        sonidos.Add(Resources.Load<AudioClip>("Sound/leon"));
        sonidos.Add(Resources.Load<AudioClip>("Sound/mono"));
        audio=GameObject.Find("sonidoAmbiente").GetComponent<AudioSource>();

        pajaro=GameObject.Find("Pajaro");
        pajaroImagenes = new List<Sprite>();
        for (int i = 1; i < 74; i++)
        {
            pajaroImagenes.Add(Resources.Load<Sprite>("Gif/Pajaro/p"+i+ "-removebg-preview"));
           
        }
        if (sonidos.Count > 0)
        {
            audio.PlayOneShot(sonidos[1]);
        }

        pajaro.transform.position = new Vector3((float)-7.9, (float)-4.0, 0);//lo ubicamos al iniciar
        pos = pajaro.transform.position;
        escala = pajaro.transform.localScale;
        velocidad = 4;
        frecuencia = 4;
        magnitud = (float)0.3;

        StartCoroutine(Mover());
        StartCoroutine(Pajaro());


    }

    // Update is called once per frame
    void Update()
    {
        // Mover();
        //hacer secuencia (space)NAME, si se presiona otra tecla entre teclas ya no (space)NHAME,(space)NNAME, la e marca final
        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.N) || Input.GetKeyDown(KeyCode.A)
            || Input.GetKeyDown(KeyCode.M) || Input.GetKeyDown(KeyCode.E)) && oculto==1)
        {
            if (Input.GetKeyDown(KeyCode.Space) && oculto == -1)//se presiono el espacio, la bandera esta en estado inicial
            {
                oculto = 1;
            }
            else//se presiono otra tecla o la bandera esta en el siguiente estado
            {
                if (Input.GetKeyDown(KeyCode.Space) && oculto == 1)
                {
                    oculto = -1;//se reincia porque se presiono el espacio despues del espacio
                }
            }

            if (Input.GetKeyDown(KeyCode.N) && oculto == 1)//se presiono la N despues del espacio
            {
                oculto = 2;
            }
            else
            {
                if (Input.GetKeyDown(KeyCode.Space) && oculto == 2)
                {
                    oculto = -1;//se reincia porque se presiono el espacio despues del espacio
                }
            }
        }
        else//no fue ninguna tecla (space,N,A,M,E).
        {
            oculto = -1;
        }

    }

    private IEnumerator Pajaro()
    {
        while (true)
        {
            foreach (Sprite s in pajaroImagenes)
            {
                pajaro.GetComponent<SpriteRenderer>().sprite = s;
                if (pos.x < -7.8f)
                {

                    pajaro.GetComponent<SpriteRenderer>().flipX = false;
                    movDerecha = true;
                }
                else
                if (pos.x > 7.76f)
                {
                    pajaro.GetComponent<SpriteRenderer>().flipX = true;
                    movDerecha = false;
                }


                if (((movDerecha) && (escala.x < 0)) && ((!movDerecha) && (escala.x > 0)))
                {
                    escala.x *= -1;
                }
                pajaro.transform.localScale = escala;

                if (movDerecha)
                {
                    pos += (Time.deltaTime * (velocidad * pajaro.transform.right));
                }
                else
                {
                    pos -= (Time.deltaTime * (velocidad * pajaro.transform.right));
                }
                pajaro.transform.position = (pos + (pajaro.transform.up * Mathf.Sin(Time.time * frecuencia) * magnitud));

                yield return new WaitForSeconds(0.05f);
                yield return null;
            }
            
        }
    }

    private IEnumerator Mover()
    {
       
         float sumar= 0.01f;
        float limteSuperior=0.35f, limiteInferiro=-0.8f;
        while (true)
        //{
        //if (mover)
        {

            titulo.transform.position = new Vector3((float)0, (titulo.transform.position.y+sumar), 0);
            if (sumar > 0 && titulo.transform.position.y > limteSuperior)
                sumar *= -1.0f;
            else
                if (sumar < 0 && titulo.transform.position.y < limiteInferiro)
                sumar *= -1.0f;
            //yield return new WaitForSeconds(0.1f);
            yield return null;
        }
        //else
        //{
        //    timer += Time.deltaTime;
        //    if (timer > 0.25)
        //    {
        //        // do something
        //        mover = true;
        //        timer = 0;
        //    }
        //}
        //}
    }
}
