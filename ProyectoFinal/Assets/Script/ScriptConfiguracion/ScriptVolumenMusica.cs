using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScriptVolumenMusica : MonoBehaviour
{
    private Slider sliderVolumen;
    private Text txtVolumenMusica;
    private float valorVolumen = 0;
    private AudioSource musicaAmbiente;
    // Start is called before the first frame update
    void Start()
    {
        sliderVolumen = GameObject.Find("SliderVolumenMusica").GetComponent<Slider>();
        txtVolumenMusica = GameObject.Find("txtVolumenMusica").GetComponent<Text>();
        musicaAmbiente = GameObject.Find("AudioAmbiente").GetComponent<AudioSource>();
        sliderVolumen.onValueChanged.AddListener(delegate { VolumenMusica(); });
        musicaAmbiente.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
        //VolumenMusica();
    }
    private void VolumenMusica()
    {
        //if (musicaAmbiente.isPlaying)
        //{
        //    musicaAmbiente.Stop();
        //}
        valorVolumen = sliderVolumen.value;
        txtVolumenMusica.text = valorVolumen+"";
        musicaAmbiente.volume = valorVolumen / 100;
       

    }
}
