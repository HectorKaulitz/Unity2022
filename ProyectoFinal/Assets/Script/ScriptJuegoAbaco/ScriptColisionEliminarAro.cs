using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptColisionEliminarAro : MonoBehaviour
{
    // Start is called before the first frame update
    private ScriptJuegoAbaco script;

    // Start is called before the first frame update
    void Start()
    {
        script = GameObject.Find("base").GetComponent<ScriptJuegoAbaco>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        script.CollisionEliminar(collision);

    }

    private void OnCollisionExit2D(Collision2D collision)
    {

    }
}
