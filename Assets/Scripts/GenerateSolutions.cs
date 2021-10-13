using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;



public class GenerateSolutions : MonoBehaviour
{
    private MeshGenerator[] fichas;
    private MeshGenerator[][] soluciones = new MeshGenerator[9000][];

    public bool generar = false;

    public float[] baseArea = new float[] { -16, 0 };
    public float[] alturaArea = new float[] { 0, 16 };

    public int iterator = 0;
    public int iteratorPause = 0;
    public int iteratorSolution = 0;

    public bool posicionValida = true;

    public bool notSolution = false;

    public Material[] materiales;
    MeshGenerator TRect1;
    MeshGenerator TRect2;
    MeshGenerator TRect3;
    MeshGenerator TRect4;
    MeshGenerator TRect5;
    MeshGenerator CPequeño1;
    MeshGenerator CPequeño2;
    MeshGenerator T1;
    MeshGenerator T2;
    MeshGenerator T3;
    MeshGenerator T4;
    MeshGenerator CGrande1;
    MeshGenerator Paralelogramo1;
    MeshGenerator Paralelogramo2;
    MeshGenerator TrapecioRectangulo;

    public GameObject Text;
    public GameObject ColliderStatus;
    void Start()
    {
        if (!generar)
        {
            baseArea = new float[] { -12, 0 };
            alturaArea = new float[] { -7, 8 };
            Text.GetComponent<Text>().text = "Contruye el Tangram";
        }
        fichas = new MeshGenerator[] {
        //*
        //* *
        //* * *
        new MeshGenerator(
            "TRect1",
            true,
            new Vector3[]
            {
                new Vector3(0,0,0),
                new Vector3(0,2,0),
                new Vector3(2,0,0)
            },
            new int[]
            {
                0,1,2
            },
            new Vector3[]
            {
                new Vector3(0.1f,0.1f,0),
                new Vector3(0.1f,1.8f,0),
                new Vector3(1.8f,0.1f,0)
            },
            materiales[0],
            baseArea,
            alturaArea
        ),
        //*
        //* *
        //* * *
        new MeshGenerator(
           "TRect2",
            true,
          new Vector3[]
          {
                new Vector3(0,0,0),
                new Vector3(0,2,0),
                new Vector3(2,0,0)
          },
          new int[]
          {
                0,1,2
          },
          new Vector3[]
          {
                new Vector3(0.1f,0.1f,0),
                new Vector3(0.1f,1.8f,0),
                new Vector3(1.8f,0.1f,0)
          },
            materiales[1],
            baseArea,
           alturaArea
      ),
        //*
        //* *
        //* * *
        new MeshGenerator(
           "TRect3",
            true,
           new Vector3[]
           {
                new Vector3(0,0,0),
                new Vector3(0,2,0),
                new Vector3(2,0,0)
           },
           new int[]
           {
                0,1,2
           },
           new Vector3[]
           {
                new Vector3(0.1f,0.1f,0),
                new Vector3(0.1f,1.8f,0),
                new Vector3(1.8f,0.1f,0)
           },
            materiales[2],
            baseArea,
            alturaArea
       ),
        //*
        //* *
        //* * *
        new MeshGenerator(
           "TRect4",
            true,
          new Vector3[]
          {
                new Vector3(0,0,0),
                new Vector3(0,2,0),
                new Vector3(2,0,0)
          },
          new int[]
          {
                0,1,2
          },
          new Vector3[]
          {
                new Vector3(0.1f,0.1f,0),
                new Vector3(0.1f,1.8f,0),
                new Vector3(1.8f,0.1f,0)
          },
            materiales[3],
            baseArea,
           alturaArea
      ),
        //*
        //* *
        //* * *
        new MeshGenerator(
            "TRect5",
             true,
           new Vector3[]
           {
                new Vector3(0,0,0),
                new Vector3(0,2,0),
                new Vector3(2,0,0)
           },
           new int[]
           {
                0,1,2
           },
           new Vector3[]
           {
                new Vector3(0.1f,0.1f,0),
                new Vector3(0.1f,1.8f,0),
                new Vector3(1.8f,0.1f,0)
           },
            materiales[4],
            baseArea,
            alturaArea
       ),
        //* * *
        //*   *
        //* * *
        new MeshGenerator(
           "CPequeño1",
            false,
           new Vector3[]
           {
                new Vector3(0,0,0),
                new Vector3(0,2,0),
                new Vector3(2,0,0),
                new Vector3(2,2,0),
           },
           new int[]
           {
                0,1,2,
                1,3,2
           },
           new Vector3[]
           {
                new Vector3(0.1f,0.1f,0),
                new Vector3(0.1f,1.9f,0),
                new Vector3(1.9f,1.9f,0),
                new Vector3(1.9f,0.1f,0),
           },
            materiales[5],
            baseArea,
           alturaArea
       ),

        //* * *
        //*   *
        //* * *
        new MeshGenerator(
           "CPequeño2",
           false,
           new Vector3[]
           {
                new Vector3(0,0,0),
                new Vector3(0,2,0),
                new Vector3(2,0,0),
                new Vector3(2,2,0),
           },
           new int[]
           {
                0,1,2,
                1,3,2
           },
           new Vector3[]
           {
                new Vector3(0.1f,0.1f,0),
                new Vector3(0.1f,1.9f,0),
                new Vector3(1.9f,1.9f,0),
                new Vector3(1.9f,0.1f,0),
           },
            materiales[6],
            baseArea,
           alturaArea
       ),

        //* * *
        //*   *
        //* * *
        new MeshGenerator(
            "CGrande1",
            false,
            new Vector3[]
            {
                new Vector3(0,0,0),
                new Vector3(2,2,0),
                new Vector3(4,0,0),
                new Vector3(2,-2,0),
            },
            new int[]
            {
                0,1,2,
                0,2,3
            },
            new Vector3[]
            {
               new Vector3(0.1f,0,0),
               new Vector3(2f,1.9f,0),
               new Vector3(3.9f,0,0),
               new Vector3(2,-1.9f,0),
            },
            materiales[7],
            baseArea,
           alturaArea
        ),

        //   *
        //  * *
        //* * * *
        new MeshGenerator(
           "T1",
           true,
           new Vector3[]
           {
                new Vector3(0,0,0),
                new Vector3(2,2,0),
                new Vector3(4,0,0)
           },
           new int[]
           {
                0,1,2
           },
           new Vector3[]
           {
                new Vector3(0.2f,0.1f,0),
                new Vector3(2f,1.9f,0),
                new Vector3(3.8f,0.1f,0)
           },
            materiales[8],
            baseArea,
           alturaArea
       ),

        //   *
        //  * *
        //* * * *
        new MeshGenerator(
            "T2",
            true,
           new Vector3[]
           {
                new Vector3(0,0,0),
                new Vector3(2,2,0),
                new Vector3(4,0,0)
           },
           new int[]
           {
                0,1,2
           },
           new Vector3[]
           {
                new Vector3(0.2f,0.1f,0),
                new Vector3(2f,1.9f,0),
                new Vector3(3.8f,0.1f,0)
           },
            materiales[9],
            baseArea,
           alturaArea
       ),

        //   *
        //  * *
        //* * * *
        new MeshGenerator(
           "T3",
           true,
           new Vector3[]
           {
                new Vector3(0,0,0),
                new Vector3(2,2,0),
                new Vector3(4,0,0)
           },
           new int[]
           {
                0,1,2
           },
           new Vector3[]
           {
                new Vector3(0.2f,0.1f,0),
                new Vector3(2f,1.9f,0),
                new Vector3(3.8f,0.1f,0)
           },
            materiales[10],
            baseArea,
           alturaArea
       ),
        //   *
        //  * *
        //* * * *
        new MeshGenerator(
            "T4",
            true,
            new Vector3[]
            {
                new Vector3(0,0,0),
                new Vector3(2,2,0),
                new Vector3(4,0,0)
            },
            new int[]
            {
                0,1,2
            },
            new Vector3[]
            {
                new Vector3(0.2f,0.1f,0),
                new Vector3(2f,1.9f,0),
                new Vector3(3.8f,0.1f,0)
            },
            materiales[11],
            baseArea,
           alturaArea
        ),
        //*
        //* *
        //*    * 
        //*    *
        //*    *
        //  *  *
        //     *
        new MeshGenerator(
            "Paralelogramo1",
            true,
           new Vector3[]
           {
                new Vector3(0,0,0),
                new Vector3(0,4,0),
                new Vector3(2,2,0),
                new Vector3(2,-2,0),
           },
           new int[]
           {
                0,1,2,
                0,2,3
           },
           new Vector3[]
           {
               new Vector3(0.1f,0.1f,0),
               new Vector3(0.1f,3.8f,0),
               new Vector3(1.9f,1.9f,0),
               new Vector3(1.9f,-1.8f,0),
           },
            materiales[12],
            baseArea,
           alturaArea
       ),
        //*
        //* *
        //*    * 
        //*    *
        //*    *
        //  *  *
        //     *
        new MeshGenerator(
            "Paralelogramo2",
            true,
           new Vector3[]
           {
                new Vector3(0,0,0),
                new Vector3(0,4,0),
                new Vector3(2,2,0),
                new Vector3(2,-2,0),
           },
           new int[]
           {
                0,1,2,
                0,2,3
           },
           new Vector3[]
           {
               new Vector3(0.1f,0.1f,0),
               new Vector3(0.1f,3.8f,0),
               new Vector3(1.9f,1.9f,0),
               new Vector3(1.9f,-1.8f,0),
           },
            materiales[13],
            baseArea,
           alturaArea
       ),

        //*
        //* *
        //*    * 
        //*    *
        //* *  *
        new MeshGenerator(
            "TrapecioRectangulo",
            true,
           new Vector3[]
           {
                new Vector3(0,0,0),
                new Vector3(0,2,0),
                new Vector3(2,4,0),
                new Vector3(2,0,0),
           },
           new int[]
           {
                0,1,2,
                0,2,3
           },
           new Vector3[]
           {
                new Vector3(0.1f,0.1f,0),
                new Vector3(0.1f,1.9f,0),
                new Vector3(1.9f,3.8f,0),
                new Vector3(1.9f,0.1f,0),
           },
            materiales[14],
            baseArea,
           alturaArea
       ),
       };


        if (!generar)
        {
            fichas[0].getGameObject().transform.position = new Vector3(-16, 7, 0);
            fichas[1].getGameObject().transform.position = new Vector3(-12, 7, 0);
            fichas[2].getGameObject().transform.position = new Vector3(-8, 7, 0);
            fichas[3].getGameObject().transform.position = new Vector3(-4, 7, 0);
            fichas[4].getGameObject().transform.position = new Vector3(-0, 7, 0);
            fichas[5].getGameObject().transform.position = new Vector3(-16, 3, 0);
            fichas[6].getGameObject().transform.position = new Vector3(-12, 3, 0);
            fichas[7].getGameObject().transform.position = new Vector3(-8, 3, 0);
            fichas[8].getGameObject().transform.position = new Vector3(-4, 3, 0);
            fichas[9].getGameObject().transform.position = new Vector3(-0, 3, 0);
            fichas[10].getGameObject().transform.position = new Vector3(-16, -1, 0);
            fichas[11].getGameObject().transform.position = new Vector3(-12, -1, 0);
            fichas[12].getGameObject().transform.position = new Vector3(-8, -1, 0);
            fichas[13].getGameObject().transform.position = new Vector3(-4, -1, 0);
            fichas[14].getGameObject().transform.position = new Vector3(-0, -5, 0);
        }
    }

    void Update()
    {

        if (generar)
        {
            if (!posicionValida || iteratorPause == 60)
            {
                iteratorPause = 0;
                iterator = 0;
                for (int i = 0; i < 15; i++)
                {
                    fichas[i].disable();
                }
                posicionValida = true;

            }


            if (posicionValida)
            {
                posicionValida = true;

                if (iterator < 15 && (iteratorPause % 2 == 0 || iteratorPause == 0))
                {
                    fichas[iterator].enable();
                    fichas[iterator].setRandomPosition();

                    for (int i = 0; i < fichas[iterator].getGameObject().GetComponent<MeshFilter>().mesh.vertices.Length; i++)
                    {

                        Vector3 worldPt = transform.TransformPoint(fichas[iterator].getGameObject().GetComponent<MeshFilter>().mesh.vertices[i]);

                        if (!(worldPt.x <= baseArea[1] || worldPt.x >= baseArea[0] || worldPt.y <= alturaArea[1] || worldPt.y >= alturaArea[0]))
                        {
                            iteratorPause = 0;
                            iterator = 0;
                            posicionValida = false;
                            return;
                        }
                    }
                    iterator++;
                }

                if (iteratorPause == 45)
                {
                    if (!existenColisiones())
                    {
                        for (int i = 0; i < 15; i++)
                        {
                            fichas[i].disableCollitions();
                        }
                        soluciones[iteratorSolution] = fichas;
                        mostrarSoluciones();
                        iteratorSolution++;
                        Debug.Log("Solucion Encontrada");
                    }

                }
                iteratorPause++;
            }
        }
        else
        {
            baseArea = new float[] { -12, 0 };
            alturaArea = new float[] { -7, 8 };
            Text.GetComponent<Text>().text = "Contruye el Tangram";


            bool ganar = true;
            //Comprueba que este dentro del tangram
            for (int i = 0; i < 15; i++)
            {
                if (fichas[i].getGameObject().GetComponent<DragAndDropController>().isInside)
                {
                    Debug.Log("false1");
                    ganar = false;
                }

                if (ColliderStatus.GetComponent<ColliderStatus>().isColliding)
                {
                    Debug.Log("false2");
                    ganar = false;
                }

                for (int j = 0; j < fichas[i].getGameObject().GetComponent<MeshFilter>().mesh.vertices.Length; j++)
                {
                    Vector3 worldPt = transform.TransformPoint(fichas[i].getGameObject().GetComponent<MeshFilter>().mesh.vertices[j]);
                    if (i == 0)
                    {
                        Debug.Log(fichas[i].getGameObject().name);
                        Debug.Log(worldPt.x + "  |   " + worldPt.y);
                    }
                    if (!(worldPt.x <= 13 && worldPt.x >= 5 && worldPt.y <= 8 && worldPt.y >= 0))
                    {
                        Debug.Log("false3");
                        ganar = false;
                    }
                }
            }


            if (ganar)
            {
                Text.GetComponent<Text>().text = "Ganaste!";
            }
            else
            {
                Text.GetComponent<Text>().text = "Contruye el Tangram";
            }


        }

    }




    bool existenColisiones()
    {
        bool colision = false;
        for (int i = 0; i < fichas.Length; i++)
        {
            if (fichas[i].isGOColliding())
            {
                colision = true;
            }
        }
        return colision;
    }

    //bool existenColisiones()
    //{
    //    bool colision = false;
    //    List<Vector3> positions = new List<Vector3>();


    //    for (int j = 0; j < fichas.Length; j++)
    //    {
    //        for (int i = 0; i < fichas[j].getGameObject().GetComponent<MeshFilter>().mesh.vertices.Length; i++)
    //        {
    //            positions.Add(transform.TransformPoint(fichas[j].getGameObject().GetComponent<MeshFilter>().mesh.vertices[i]));
    //        }
    //    }
    //    for (int j = 0; j < fichas.Length; j++)
    //    {
    //        for (int i = 0; i < positions.Count; i++)
    //        {
    //            if (i != j && fichas[j].isGOColliding() && fichas[j].getGameObject().GetComponent<PolygonCollider2D>().bounds.Contains(positions[i]))
    //            {
    //                colision = true;
    //            }
    //        }
    //    }
    //    return colision;
    //}

    void mostrarSoluciones()
    {
        GameObject go = new GameObject();

        for (int i = 0; i < 15; i++)
        {
            GameObject copia = Instantiate(soluciones[iteratorSolution][i].getGameObject(), go.transform);
            copia.name = i + "";
        }


        go.transform.position = new Vector3((alturaArea[1] * 2 + (iteratorSolution * alturaArea[1] * 2)), 0, 0);

        // resetear valores

        for (int i = 0; i < fichas.Length; i++)
        {
            fichas[i].enableCollitions();
        }

    }
}

class MeshGenerator
{

    GameObject go;
    Mesh mesh;
    Vector3[] vertices;
    int[] triangles;
    bool isColliding;
    bool canFlip;
    float[] baseArea;
    float[] alturaArea;

    public MeshGenerator(string _nombre, bool _canFlip, Vector3[] _vertices, int[] _triangles, Vector3[] _verticesCollider, Material _material, float[] _baseArea, float[] _alturaArea)
    {

        canFlip = _canFlip;
        alturaArea = _alturaArea;
        baseArea = _baseArea;
        setupGameObject(_nombre, _verticesCollider);
        mesh = new Mesh();
        go.GetComponent<MeshFilter>().mesh = mesh;
        go.GetComponent<MeshRenderer>().material = _material;
        vertices = _vertices;
        triangles = _triangles;
        updateMesh();
    }

    void updateMesh()
    {
        mesh.Clear();
        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.RecalculateNormals();
    }

    void setupGameObject(string nombre, Vector3[] _verticesCollider)
    {

        go = new GameObject();
        go.name = nombre;
        go.AddComponent<DragAndDropController>();
        go.AddComponent<MeshFilter>();
        go.AddComponent<MeshRenderer>();

        go.AddComponent<PolygonCollider2D>();
        go.AddComponent<Rigidbody2D>();
        go.GetComponent<PolygonCollider2D>().isTrigger = true;
        go.GetComponent<Rigidbody2D>().gravityScale = 0;

        Vector2[] points = new Vector2[_verticesCollider.Length];

        for (var i = 0; i < _verticesCollider.Length; i++)
        {
            points[i] = (new Vector2(_verticesCollider[i].x, _verticesCollider[i].y));
        }

        go.GetComponent<PolygonCollider2D>().points = points;
        go.AddComponent<MeshEvent>();
    }

    public void disableCollading()
    {
        go.GetComponent<MeshEvent>().disable = true;
    }

    public void enableCollading()
    {
        go.GetComponent<MeshEvent>().disable = false;
    }

    public void disableCollitions()
    {
        go.GetComponent<PolygonCollider2D>().enabled = false;
        go.GetComponent<MeshEvent>().enabled = false;
        disableCollading();

    }

    public void enableCollitions()
    {
        go.GetComponent<PolygonCollider2D>().enabled = true;
        go.GetComponent<MeshEvent>().enabled = true;
        enableCollading();
        go.GetComponent<MeshEvent>().isColliding = true;
    }


    public void setRandomPosition()
    {
        setX(Mathf.Floor(Random.Range(baseArea[1], baseArea[0])));
        setY(Mathf.Floor(Random.Range(alturaArea[1], alturaArea[0])));
        if (canFlip)
        {
            setFlip(Random.value > 0.5f);
        }
        float[] degrees = new float[] { 0.0f, 90.0f, 180.0f, -90.0f };
        setRotation(degrees[Random.Range(0, 4)]);

        isColliding = isGOColliding();
    }

    public void setX(float x)
    {
        go.transform.position = new Vector3(x, go.transform.position.y, go.transform.position.z);
    }
    public void setY(float y)
    {
        go.transform.position = new Vector3(go.transform.position.x, y, go.transform.position.z);
    }

    public void setRotation(float z)
    {
        go.transform.rotation = Quaternion.Euler(go.transform.rotation.eulerAngles.x, go.transform.rotation.eulerAngles.y, z);
    }

    public void setFlip(bool flip)
    {
        if (flip)
        {
            go.transform.localScale = new Vector3(go.transform.localScale.x * -1, go.transform.localScale.y, go.transform.localScale.z);
        }
    }

    public void disable()
    {
        this.getGameObject().SetActive(false);
    }
    public void enable()
    {
        this.getGameObject().SetActive(true);
    }

    public bool isGOColliding()
    {
        return go.GetComponent<MeshEvent>().isColliding;
    }

    public bool setColliding(bool isColliding)
    {
        return go.GetComponent<ChildCollider>().isColliding = isColliding;
    }

    public GameObject getGameObject()
    {
        return go;
    }

}


