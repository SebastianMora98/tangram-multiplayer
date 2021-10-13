using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshEvent : MonoBehaviour
{

    public bool isColliding = true;
    public bool disable = false;

    // Start is called before the first frame update
    void Start()
    {
        isColliding = true;
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 worldPt = transform.TransformPoint(this.gameObject.GetComponent<MeshFilter>().mesh.vertices[0]);
        Vector3 worldPt2 = transform.TransformPoint(this.gameObject.GetComponent<MeshFilter>().mesh.vertices[1]);
        //Debug.Log("World pos: " + worldPt.ToString()+ "| World pos: " + worldPt2.ToString());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!disable) 
        {
            isColliding = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!disable)
        {
            isColliding = false;
        }
    }
}
