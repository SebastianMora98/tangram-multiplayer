using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class GameController : MonoBehaviour
{

    public GameObject piezas;
    private List<Pieza> piezasArray = new List<Pieza>();
    private int curretIndex;
    private bool solutionFound = false;
    string text = "";

    // Start is called before the first frame update
    void Start()
    {

        //for (var i = 0; i < piezas.transform.childCount; i++) {
        //    Pieza pieza = new Pieza(piezas.transform.GetChild(i));
        //    piezasArray.Add(pieza);
        //}


        //foreach (Transform child in piezas.transform) {

        //    if (child.name == "TrapecioRectangulo" || child.name == "CuadradoGrande" || child.name == "TrianguloGrande1" || child.name == "CuadradoPequeño1") {
        //        Pieza pieza = new Pieza(child);
        //        piezasArray.Add(pieza);
        //    }
    

        //}


        //for (var i = 0; i < 2; i++)
        //{
        //    Pieza pieza = new Pieza(piezas.transform.GetChild(i));
        //    piezasArray.Add(pieza);
        //}

        // Calls TestCondition after 0 seconds 
        // and repeats every 5 seconds.
       //InvokeRepeating("LaunchProjectile", 2.0f, 1f); //time needs to be > 0


    }

    void LaunchProjectile()
    {
        if (!solutionFound)
        {
            solutionFound = true;
            text = "";
            for (var i = 0; i < piezasArray.Count; i++)
            {
                piezasArray[i].setRandom();
              
                text += piezasArray[i]._isColliding + ",";
            }
            InvokeRepeating("collitionDetect", 10.0f, 0f); //time needs to be > 0


            Debug.Log(text);

          

        }
    }

    void collitionDetect()
    {
        Debug.Log("validando");
        for (var i = 0; i < piezasArray.Count; i++)
        {
            if (piezasArray[i]._isColliding)
            {
                solutionFound = false;
            }

        }
        if (solutionFound)
        {
            Debug.Log("Encontrada");
            //Time.timeScale = 0;
        }

    }




    // Update is called once per frame
    void Update()
    {

       


    }
}


interface IPosicion
{
     UnityEngine.Transform PiezaGO { get; set; }
}

class Pieza : IPosicion
{
    // Constructor:
    public Pieza( UnityEngine.Transform piezaGO)
    {
        PiezaGO = piezaGO;
    }

    // Property implementation:

    public bool _isColliding { get; set; }

    public float getX()
    {
        return PiezaGO.transform.position.x;
    }
    public void setX(float x)
    {
         PiezaGO.transform.position = new Vector3(x,PiezaGO.transform.position.y, PiezaGO.transform.position.z) ;
    }

    public float getY()
    {
        return PiezaGO.transform.position.y;
    }
    public void setY(float y)
    {
        PiezaGO.transform.position = new Vector3( PiezaGO.transform.position.x,y, PiezaGO.transform.position.z);
    }

    public float getRotation()
    {
        return PiezaGO.transform.rotation.eulerAngles.z;
    }
    public void setRotation(float z)
    {
        PiezaGO.transform.rotation = Quaternion.Euler(PiezaGO.transform.rotation.eulerAngles.x, PiezaGO.transform.rotation.eulerAngles.y, z);
    }

    public bool getFlip() {
        return PiezaGO.GetChild(0).GetComponent<SpriteRenderer>().flipX;
    }

    public void setFlip(bool flip)
    {
        PiezaGO.GetChild(0).GetComponent<SpriteRenderer>().flipX = flip;
    }

    public bool isColliding() {
        return PiezaGO.GetChild(0).GetComponent<ChildCollider>().isColliding;
    }

    public bool setColliding(bool isColliding)
    {
        return PiezaGO.GetChild(0).GetComponent<ChildCollider>().isColliding = isColliding;
    }

    public void setRandom() {
    
        setX(Mathf.Floor(Random.Range(0.0f, 8f)));
        setY(Mathf.Floor(Random.Range(0.0f, 8f)));
        //setFlip(Random.value > 0.5f);
       
        float[] degrees = new float[] { 0.0f, 45.0f, 90.0f, 135.0f, 180.0f, 225.0f, -90.0f, -45.0f };
        setRotation(degrees[Random.Range(0, 8)]);

        _isColliding = isColliding();
        Debug.Log(PiezaGO.GetChild(0).name + isColliding());
    }

    public float Rotation { get; set; }

    public Transform PiezaGO { get; set; }

}

