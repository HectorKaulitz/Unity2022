using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptJuegoPares : MonoBehaviour
{
    int dificultad = 2;//0 principiante 8 cartas,1 medio 12 cartas,2 dificil 16 cartas
    Sprite tarjetaFrontal, tarjetaPosterior;
    // Start is called before the first frame update
    List<string> cartasSinUsar;
    private int tarjetasNivel=8,primeraPos=-1;
    private bool voletando = false;
    void Start()
    {
        tarjetaFrontal = Resources.Load<Sprite>("Tarjeta/FrenteTarjeta");
        tarjetaPosterior = Resources.Load<Sprite>("Tarjeta/AtrasTarjeta");
        switch(dificultad)
        {
            case 0:
                tarjetasNivel = 8;
                break;
            case 1:
                tarjetasNivel = 12;
                break;
            case 2:
                tarjetasNivel = 16;
                break;
        }
        cartasSinUsar = new List<string>();
        for(int i=1;i<tarjetasNivel;i++)
        {
            cartasSinUsar.Add(i+"");
        }
        
        AcomodoTarjetas();
        AcomodoBotones();
        AcomodoObjetos();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void AcomodoBotones()
    {
        switch (dificultad)
        {
            case 0://elimina las ultimas 8 tarjetas,y acomoda
                GameObject.Find("b1").transform.localPosition = new Vector3(-180f, 70f);
                GameObject.Find("b2").transform.localPosition = new Vector3(-58f, 70f);
                GameObject.Find("b3").transform.localPosition = new Vector3(58f, 70f);
                GameObject.Find("b4").transform.localPosition = new Vector3(180f, 70f);

                GameObject.Find("b5").transform.localPosition = new Vector3(-180f, -70f);
                GameObject.Find("b6").transform.localPosition = new Vector3(-58f, -70f);
                GameObject.Find("b7").transform.localPosition = new Vector3(58f, -70f);
                GameObject.Find("b8").transform.localPosition = new Vector3(180f, -70f);
                for (int i = 9; i < 17; i++)
                {
                    Destroy(GameObject.Find("b"+i + ""));
                }

                break;
            case 1://elimina las ultimas 4 tarjetas,y acomoda
                GameObject.Find("b1").transform.localPosition = new Vector3(-180f, 158f);
                GameObject.Find("b2").transform.localPosition = new Vector3(-58f, 158f);
                GameObject.Find("b3").transform.localPosition = new Vector3(58f, 158f);
                GameObject.Find("b4").transform.localPosition = new Vector3(180f, 158f);

                GameObject.Find("b5").transform.localPosition = new Vector3(-180f, 25f);
                GameObject.Find("b6").transform.localPosition = new Vector3(-58f, 25f);
                GameObject.Find("b7").transform.localPosition = new Vector3(58f, 25f);
                GameObject.Find("b8").transform.localPosition = new Vector3(180f, 25f);

                GameObject.Find("b9").transform.localPosition = new Vector3(-180f, -110f);
                GameObject.Find("b10").transform.localPosition = new Vector3(-58f, -110f);
                GameObject.Find("b11").transform.localPosition = new Vector3(58f, -110f);
                GameObject.Find("b12").transform.localPosition = new Vector3(180f, -110f);
                for (int i = 13; i < 17; i++)
                {
                    Destroy(GameObject.Find("b" + i + ""));
                }
                break;
            case 2://solo acomoda
                GameObject.Find("b1").transform.localPosition = new Vector3(-180f, 158f);
                GameObject.Find("b2").transform.localPosition = new Vector3(-58f, 158f);
                GameObject.Find("b3").transform.localPosition = new Vector3(58f, 158f);
                GameObject.Find("b4").transform.localPosition = new Vector3(180f, 158f);

                GameObject.Find("b5").transform.localPosition = new Vector3(-180f, 25f);
                GameObject.Find("b6").transform.localPosition = new Vector3(-58f, 25f);
                GameObject.Find("b7").transform.localPosition = new Vector3(58f, 25f);
                GameObject.Find("b8").transform.localPosition = new Vector3(180f, 25f);

                GameObject.Find("b9").transform.localPosition = new Vector3(-180f, -110f);
                GameObject.Find("b10").transform.localPosition = new Vector3(-58f, -110f);
                GameObject.Find("b11").transform.localPosition = new Vector3(58f, -110f);
                GameObject.Find("b12").transform.localPosition = new Vector3(180f, -110f);

                GameObject.Find("b13").transform.localPosition = new Vector3(-293f, 110f);
                GameObject.Find("b14").transform.localPosition = new Vector3(-293f, -15f);
                GameObject.Find("b15").transform.localPosition = new Vector3(293f, 110f);
                GameObject.Find("b16").transform.localPosition = new Vector3(293f, -15f);
                break;
        }
    }

    private void AcomodoObjetos()
    {
        switch (dificultad)
        {
            case 0://elimina las ultimas 8 tarjetas,y acomoda
                GameObject.Find("obj1").transform.localPosition = new Vector3(-4f, 1.5f);
                GameObject.Find("obj2").transform.localPosition = new Vector3(-1.3f, 1.5f);
                GameObject.Find("obj3").transform.localPosition = new Vector3(1.3f, 1.5f);
                GameObject.Find("obj4").transform.localPosition = new Vector3(4f, 1.5f);

                GameObject.Find("obj5").transform.localPosition = new Vector3(-4f, -1.5f);
                GameObject.Find("obj6").transform.localPosition = new Vector3(-1.3f, -1.5f);
                GameObject.Find("obj7").transform.localPosition = new Vector3(1.3f, -1.5f);
                GameObject.Find("obj8").transform.localPosition = new Vector3(4f, -1.5f);
                for (int i = 9; i < 17; i++)
                {
                    Destroy(GameObject.Find("obj" + i + ""));
                }

                break;
            case 1://elimina las ultimas 4 tarjetas,y acomoda
                GameObject.Find("obj1").transform.localPosition = new Vector3(-4f, 3.5f);
                GameObject.Find("obj2").transform.localPosition = new Vector3(-1.3f, 3.5f);
                GameObject.Find("obj3").transform.localPosition = new Vector3(1.3f, 3.5f);
                GameObject.Find("obj4").transform.localPosition = new Vector3(4f, 3.5f);

                GameObject.Find("obj5").transform.localPosition = new Vector3(-4f, 0.5f);
                GameObject.Find("obj6").transform.localPosition = new Vector3(-1.3f, 0.5f);
                GameObject.Find("obj7").transform.localPosition = new Vector3(1.3f, 0.5f);
                GameObject.Find("obj8").transform.localPosition = new Vector3(4f, 0.5f);

                GameObject.Find("obj9").transform.localPosition = new Vector3(-4f, -2.5f);
                GameObject.Find("obj10").transform.localPosition = new Vector3(-1.3f, -2.5f);
                GameObject.Find("obj11").transform.localPosition = new Vector3(1.3f, -2.5f);
                GameObject.Find("obj12").transform.localPosition = new Vector3(4f, -2.5f);
                for (int i = 13; i < 17; i++)
                {
                    Destroy(GameObject.Find("obj" + i + ""));
                }
                break;
            case 2://solo acomoda
                GameObject.Find("obj1").transform.localPosition = new Vector3(-4f, 3.5f);
                GameObject.Find("obj2").transform.localPosition = new Vector3(-1.3f, 3.5f);
                GameObject.Find("obj3").transform.localPosition = new Vector3(1.3f, 3.5f);
                GameObject.Find("obj4").transform.localPosition = new Vector3(4f, 3.5f);

                GameObject.Find("obj5").transform.localPosition = new Vector3(-4f, 0.5f);
                GameObject.Find("obj6").transform.localPosition = new Vector3(-1.3f, 0.5f);
                GameObject.Find("obj7").transform.localPosition = new Vector3(1.3f, 0.5f);
                GameObject.Find("obj8").transform.localPosition = new Vector3(4f, 0.5f);

                GameObject.Find("obj9").transform.localPosition = new Vector3(-4f, -2.5f);
                GameObject.Find("obj10").transform.localPosition = new Vector3(-1.3f, -2.5f);
                GameObject.Find("obj11").transform.localPosition = new Vector3(1.3f, -2.5f);
                GameObject.Find("obj12").transform.localPosition = new Vector3(4f, -2.5f);

                GameObject.Find("obj13").transform.localPosition = new Vector3(-6.5f, 2.4f);
                GameObject.Find("obj14").transform.localPosition = new Vector3(-6.5f, -0.3f);
                GameObject.Find("obj15").transform.localPosition = new Vector3(6.5f, 2.4f);
                GameObject.Find("obj16").transform.localPosition = new Vector3(6.5f, -0.3f);
                break;
        }
    }

    private void AcomodoTarjetas()
    {
        switch (dificultad)
        {
            case 0://elimina las ultimas 8 tarjetas,y acomoda
                GameObject.Find("1").transform.localPosition = new Vector3(-4f, 1.5f);
                GameObject.Find("2").transform.localPosition = new Vector3(-1.3f, 1.5f);
                GameObject.Find("3").transform.localPosition = new Vector3(1.3f, 1.5f);
                GameObject.Find("4").transform.localPosition = new Vector3(4f, 1.5f);

                GameObject.Find("5").transform.localPosition = new Vector3(-4f, -1.5f);
                GameObject.Find("6").transform.localPosition = new Vector3(-1.3f, -1.5f);
                GameObject.Find("7").transform.localPosition = new Vector3(1.3f, -1.5f);
                GameObject.Find("8").transform.localPosition = new Vector3(4f, -1.5f);
                for (int i = 9; i < 17; i++)
                {
                    Destroy(GameObject.Find(i + ""));
                }

                break;
            case 1://elimina las ultimas 4 tarjetas,y acomoda
                GameObject.Find("1").transform.localPosition = new Vector3(-4f, 3.5f);
                GameObject.Find("2").transform.localPosition = new Vector3(-1.3f, 3.5f);
                GameObject.Find("3").transform.localPosition = new Vector3(1.3f, 3.5f);
                GameObject.Find("4").transform.localPosition = new Vector3(4f, 3.5f);

                GameObject.Find("5").transform.localPosition = new Vector3(-4f, 0.5f);
                GameObject.Find("6").transform.localPosition = new Vector3(-1.3f, 0.5f);
                GameObject.Find("7").transform.localPosition = new Vector3(1.3f, 0.5f);
                GameObject.Find("8").transform.localPosition = new Vector3(4f, 0.5f);

                GameObject.Find("9").transform.localPosition = new Vector3(-4f, -2.5f);
                GameObject.Find("10").transform.localPosition = new Vector3(-1.3f, -2.5f);
                GameObject.Find("11").transform.localPosition = new Vector3(1.3f, -2.5f);
                GameObject.Find("12").transform.localPosition = new Vector3(4f, -2.5f);
                for(int i =13;i<17;i++)
                {
                    Destroy(GameObject.Find(i+""));
                }
                break;
            case 2://solo acomoda
                GameObject.Find("1").transform.localPosition = new Vector3(-4f, 3.5f);
                GameObject.Find("2").transform.localPosition = new Vector3(-1.3f, 3.5f);
                GameObject.Find("3").transform.localPosition = new Vector3(1.3f, 3.5f);
                GameObject.Find("4").transform.localPosition = new Vector3(4f, 3.5f);

                GameObject.Find("5").transform.localPosition = new Vector3(-4f, 0.5f);
                GameObject.Find("6").transform.localPosition = new Vector3(-1.3f, 0.5f);
                GameObject.Find("7").transform.localPosition = new Vector3(1.3f, 0.5f);
                GameObject.Find("8").transform.localPosition = new Vector3(4f, 0.5f);

                GameObject.Find("9").transform.localPosition = new Vector3(-4f, -2.5f);
                GameObject.Find("10").transform.localPosition = new Vector3(-1.3f, -2.5f);
                GameObject.Find("11").transform.localPosition = new Vector3(1.3f, -2.5f);
                GameObject.Find("12").transform.localPosition = new Vector3(4f, -2.5f);

                GameObject.Find("13").transform.localPosition = new Vector3(-6.5f, 2.4f);
                GameObject.Find("14").transform.localPosition = new Vector3(-6.5f, -0.3f);
                GameObject.Find("15").transform.localPosition = new Vector3(6.5f, 2.4f);
                GameObject.Find("16").transform.localPosition = new Vector3(6.5f, -0.3f);
                break;
        }
    }

    private IEnumerator Girar(GameObject go)
    {
        float x = 0;
        while (voletando)
        {
            x += 1 * 10;
            go.transform.rotation = Quaternion.Euler(x, 0, 0);
            if (x < 190)
                yield return new WaitForSeconds(0.2f);
            else
                voletando = false;

        }
        yield return null;
    }

    public void VoltearCarta(int pos)
    {
        GameObject go = GameObject.Find("" + pos);
        if (go != null)
        {
            SpriteRenderer sp = go.GetComponent<SpriteRenderer>();
            //se voltean ambas tarjetas al inicio
            if (sp != null)
            {
                if (primeraPos != pos)//si  selecciono ya la primer carta no la vuelva a voltear debe seleccionar la 2da
                {
                    SpriteRenderer ob = GameObject.Find("obj" + pos).GetComponent<SpriteRenderer>();
                    float x = 0;
                    voletando = true;
                    StartCoroutine(Girar(go));
                    while(voletando)
                    {
                        x++;
                    }
                    StopCoroutine(Girar(go));
                    go.transform.rotation = Quaternion.Euler(x, 0, 0);
                    if (sp.sprite.name.Equals("AtrasTarjeta"))
                    {
                        sp.sprite = tarjetaFrontal;
                        ob.sortingOrder = 2;
                    }
                    else
                    {
                        sp.sprite = tarjetaPosterior;
                        ob.sortingOrder = 0;
                    }
                    if (primeraPos == -1)//va a ser la primera carta volteada
                    {
                        primeraPos = pos;

                    }
                    else//ya volteo la primera,es la segunda y debe comparar
                    {
                        //hay que hacer la comparacion
                        if (GameObject.Find("obj" + primeraPos).GetComponent<SpriteRenderer>().sprite.name == sp.name)
                        {
                            //si el sprite del objeto de la primera carta es igual a la segunda
                        }
                        else
                        {
                            //no son pares se voltean las 2 cartas
                        }
                        //primeraPos = -1;

                    }
                    
                }
            }
        }
    }

}

                   
