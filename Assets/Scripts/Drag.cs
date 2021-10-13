using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drag : MonoBehaviour
{
    public bool snapToGrid = true;
    private Vector3 screenPoint;
    private Vector3 startPosition;

    public GameObject dropPlace_GO;
    private Vector3 dropPlacePosition;

    private bool isCorrectPlace = false;
    private bool alreadySticked = false;

    // Start is called before the first frame update
    void Start()
    {
        dropPlacePosition = dropPlace_GO.GetComponent<Transform>().position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1)) {
            Debug.Log("rotate");
            float yRotation = transform.eulerAngles.z + 45.0f;
            this.transform.eulerAngles = new Vector3( transform.eulerAngles.x,  transform.eulerAngles.y , yRotation);
        };
    }



    void OnMouseDown()
    {
        //startPosition = this.gameObject.transform.position;
        screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);

    }

    //El GameObject debe tener un colider
     void OnMouseDrag()
    {
        if (!alreadySticked) {
            //Debug.Log("OnMouseDrag");
            Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
            Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint);
            this.transform.position = curPosition;
        }
       
    }

    private void OnMouseUp()
    {
        if (isCorrectPlace)
        {
            this.gameObject.transform.position = dropPlacePosition;
        }
        else {
            //this.gameObject.transform.position = startPosition;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
      
        if (other.gameObject.name == "pato_figura") {
            Debug.Log("Figura Dentro de Pato Figura");
            isCorrectPlace = true;
            alreadySticked = true;
        }
        
    }

}
