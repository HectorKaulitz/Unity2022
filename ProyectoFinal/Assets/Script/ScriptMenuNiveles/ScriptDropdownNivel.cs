using Assets.Script;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScriptDropdownNivel : MonoBehaviour
{
    Dropdown dropdown;
        List<string> opciones;
    // Start is called before the first frame update
    void Start()
    {
        if (StaticVariablesGenerales.tipoJuego == 1)
        {
            opciones = new List<string> { "Principiante", "Avanzado" };
        }
        else
        {
            opciones = new List<string> { "Relacion", "Atrapar" };
        }
        dropdown =GameObject.Find("DropdownNivel"). GetComponent<Dropdown>();
        //Clear the old options of the Dropdown menu
        dropdown.ClearOptions();
        //Add the options created in the List above
        dropdown.AddOptions(opciones);
        Dificultad();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Dificultad()
    {
        if (StaticVariablesGenerales.tipoJuego == 1)
        {
            switch (dropdown.value)
            {
                case 0://principiante
                    StaticVariablesGenerales.dificultadNivel = 2;
                    break;
                case 1://dificil
                    StaticVariablesGenerales.dificultadNivel = 1;
                    break;
            }
        }
        else
        {
            switch (dropdown.value)
            {
                case 0://Relacion
                    StaticVariablesGenerales.dificultadNivel = 1;
                    StaticVariablesGenerales.tipoSubNivel = 1;
                    break;
                case 1://Atrapar
                    StaticVariablesGenerales.dificultadNivel = 1;
                    StaticVariablesGenerales.tipoSubNivel = 0;
                    break;
            }
        }
    }
}
