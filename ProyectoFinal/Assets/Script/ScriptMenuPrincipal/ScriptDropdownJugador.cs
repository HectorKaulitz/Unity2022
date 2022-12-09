using Assets.Script;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScriptDropdownJugador : MonoBehaviour
{
    //Create a List of new Dropdown options
    //List<string> opciones = new List<string> { "Jugador 1", "Jugador 2" };
    //This is the Dropdown
    Dropdown dropdown;
    // Start is called before the first frame update
    void Start()
    {
        //Fetch the Dropdown GameObject the script is attached to
        dropdown = GetComponent<Dropdown>();
        //Clear the old options of the Dropdown menu
        dropdown.ClearOptions();
        //Add the options created in the List above
        List<string> jugadores = new Procedimientos().ObtenerJugadores();
        dropdown.AddOptions(jugadores);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
