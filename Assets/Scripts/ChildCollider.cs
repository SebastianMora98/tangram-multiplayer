using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildCollider : MonoBehaviour
{
    public bool isColliding = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("Entra");
        isColliding = true;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        isColliding = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //Debug.Log("Sale");
        isColliding = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log("Entra");
        isColliding = true;
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        isColliding = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        Debug.Log("Sale");
        isColliding = false;
    }
}
