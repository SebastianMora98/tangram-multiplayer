using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class DragAndDropMultiplayer : MonoBehaviour
{
    public float gridSize = 1f;
    public bool snapToGrid = true;
    public bool smartDrag = true;
    public bool isDraggable = true;
    public bool isDragged = false;
    Vector2 initialPositionMouse;
    Vector2 initialPositionObject;
    public bool inCorretPosition = false;

    List<GameObject> currentCollisions = new List<GameObject>();

    PhotonView view;

    void Start()
    {
        view = GetComponent<PhotonView>();
    }


    void Update()
    {
        if (view.IsMine)
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

                }
            }
        }


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
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {

        currentCollisions.Add(collision.gameObject);
        inCorretPosition = false;
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        inCorretPosition = false;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        currentCollisions.Remove(collision.gameObject);

        if (currentCollisions.Count == 0)
        {
            inCorretPosition = true;
        }
    }
}
