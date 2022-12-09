using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class drag : MonoBehaviour
{
    private float posXinicial, posYinicial;
    private bool esMovido = false;
    

    void Update()
    {
        if (esMovido == true)
        {
            Vector3 posMouse;
            posMouse = Input.mousePosition;
            posMouse = Camera.main.ScreenToWorldPoint(posMouse);

            this.gameObject.transform.localPosition
                    = new Vector3(posMouse.x, posMouse.y, 0);
        }
    }

    private void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 posMouse;

            posMouse = Input.mousePosition;
            posMouse = Camera.main.ScreenToWorldPoint(posMouse);

            esMovido = true;
        }
    }

    private void OnMouseUp()
    {
        esMovido = false;
    }

}

