using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScriptIluminacion : MonoBehaviour
{
    private Slider sliderIluminacion;
    private Text txtIluminacion;
    private float valorIluminacion = 0;
    // Start is called before the first frame update
    void Start()
    {
        sliderIluminacion = GameObject.Find("SliderIluminacion").GetComponent<Slider>();
        txtIluminacion = GameObject.Find("txtIluminacion").GetComponent<Text>();
        sliderIluminacion.onValueChanged.AddListener(delegate { Iluminacion(); });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void Iluminacion()
    {
        valorIluminacion = sliderIluminacion.value;
        txtIluminacion.text = valorIluminacion + "";
      
    }
}
