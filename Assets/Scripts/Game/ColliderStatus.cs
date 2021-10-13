using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderStatus : MonoBehaviour
{
    public bool isColliding;

    void Start()
    {
        isColliding = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        isColliding = true;

    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        isColliding = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        isColliding = false;
    }

}
