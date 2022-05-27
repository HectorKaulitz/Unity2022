using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScriptControlVolumen : MonoBehaviour
{
    public Slider sliderVolumen;
    private float valorVolumen=0;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        VolumenAmbiente();

    }

    private void VolumenAmbiente()
    {
        sliderVolumen = GameObject.Find("SliderVolumenAmbiente").GetComponent<Slider>();
        valorVolumen = sliderVolumen.value;
    }
}
