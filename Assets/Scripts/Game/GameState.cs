using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameState : MonoBehaviour
{
    bool juegoGanado = false;
    public GameObject Text;

    // Start is called before the first frame update
    void Start()
    {
        Text.GetComponent<Text>().text = "Contruye el Tangram";
    }

    // Update is called once per frame
    void Update()
    {
       
        bool ganado = true;
        foreach (Transform child in transform.Find("Forma1").transform) 
        {
            
            if (!child.GetComponent<DragAndDropController>().isInside)
            {
                ganado = false;
            }
           
        }
        //Debug.Log(texto);
        juegoGanado = ganado;

        if (juegoGanado)
        {
            Text.GetComponent<Text>().text = "Ganaste!";
        }
        else 
        {
            Text.GetComponent<Text>().text = "Contruye el Tangram";
        }

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("OnTriggerEnter2D");
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("OnTriggerExit2D");
    }

}
