using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDropController : MonoBehaviour
{
    public float gridSize = 1f;
    public bool snapToGrid = true;
    public bool smartDrag = true;
    public bool isDraggable = true;
    public bool isDragged = false;
    Vector2 initialPositionMouse;
    Vector2 initialPositionObject;
    public bool isInside = true;

    public Vector3[] vertexPositions;


    void Update()
    {
        if (isDragged)
        {
            if (!smartDrag)
            {
                transform.position = (Vector2)(Camera.main.ScreenToWorldPoint(Input.mousePosition));
            }
            else
            {
                transform.position = initialPositionObject + (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition) - initialPositionMouse;
            }
            if (snapToGrid)
            {
                transform.position = new Vector2(Mathf.RoundToInt(transform.position.x / gridSize) * gridSize, Mathf.RoundToInt(transform.position.y / gridSize) * gridSize);

                for (int j = 0; j < gameObject.GetComponent<MeshFilter>().mesh.vertices.Length; j++)
                {
                    Vector3 worldPt = transform.TransformPoint(gameObject.GetComponent<MeshFilter>().mesh.vertices[j]);
                    //Debug.Log(worldPt);
                }

            }
        }

        //Vector3 worldPt2 = transform.TransformPoint(gameObject.GetComponent<MeshFilter>().mesh.vertices[0]);
        //Debug.Log(worldPt2);


    }

    private void OnMouseOver()
    {

        if (isDraggable && Input.GetMouseButtonDown(0))
        {
            if (smartDrag)
            {
                initialPositionMouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                initialPositionObject = gameObject.transform.position;
            }
            isDragged = true;
        }

        if (Input.GetMouseButtonDown(1))
        {
            float yRotation = gameObject.transform.eulerAngles.z + 45.0f;
            gameObject.transform.eulerAngles = new Vector3(gameObject.transform.eulerAngles.x, gameObject.transform.eulerAngles.y, yRotation);
        }
        if (Input.GetMouseButtonDown(2))
        {

            gameObject.transform.localScale = new Vector3(gameObject.transform.localScale.x * -1, gameObject.transform.localScale.y, gameObject.transform.localScale.z);
        }
    }

    private void OnMouseUp()
    {
        isDragged = false;

        vertexPositions = this.gameObject.GetComponent<MeshFilter>().mesh.vertices;
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        isInside = true;
    }
    private void OnTriggerStay2D(Collider2D collision)
    {

        isInside = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isInside = false;
    }


}
