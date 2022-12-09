using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScriptVolumenSonido : MonoBehaviour
{
    private Slider sliderVolumen;
    private Text txtVolumenMusica;
    private float valorVolumen = 0;
    private AudioSource sonido;
    // Start is called before the first frame update
    void Start()
    {
        sliderVolumen = GameObject.Find("SliderVolumenSonido").GetComponent<Slider>();
        txtVolumenMusica = GameObject.Find("txtVolumenSonido").GetComponent<Text>();
        sonido = GameObject.Find("AudioEfectos").GetComponent<AudioSource>();
        sliderVolumen.onValueChanged.AddListener(delegate { VolumenMusica(); });
        
    }

    // Update is called once per frame
    void Update()
    {
        //VolumenMusica();
    }
    
    public void ReproducirSonido()
    {
        //if (sonido.isPlaying)
        //{
        //    sonido.Stop();
        //}
        //sonido.Play();
    }
    private void VolumenMusica()
    {
       
        valorVolumen = sliderVolumen.value;
        txtVolumenMusica.text = valorVolumen + "";
        sonido.volume = valorVolumen / 100;
       

    }
}
