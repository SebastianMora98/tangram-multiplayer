using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using Photon.Pun;
using static Photon.Pun.PhotonTransformViewPositionModel;

public class GenerateTree : MonoBehaviour
{
    private MeshGeneratorTree[] fichas;
    public Material[] materiales;


    private GenerateCombinations generateCombinations;


    public List<EstadoPieza> estados = new List<EstadoPieza>();


    // Start is called before the first frame update
    void Start()
    {
        fichas = new MeshGeneratorTree[] {
        
        
            
        //*
        //* *
        //* * *
        new MeshGeneratorTree(
            "TPequeño",
            2,
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
            materiales[0]

        ),
        //* * *
        //  * *
        //    *
        new MeshGeneratorTree(
            "TPequeño2",
            3,
            new Vector3[]
            {
                new Vector3(0,2,0),
                new Vector3(2,2,0),
                new Vector3(2,0,0)
            },
            new int[]
            {
                0,1,2
            },
            new Vector3[]
            {
                new Vector3(0.1f,1.8f,0),
                new Vector3(1.1f,1.8f,0),
                new Vector3(1.8f,0.1f,0)
            },
            materiales[1]

        ),
        //* * *
        //  * *
        //    *
        new MeshGeneratorTree(
            "TPequeño3",
            4,
            new Vector3[]
            {
                new Vector3(0,2,0),
                new Vector3(2,2,0),
                new Vector3(2,0,0)
            },
            new int[]
            {
                0,1,2
            },
            new Vector3[]
            {
                new Vector3(0.1f,1.8f,0),
                new Vector3(1.8f,1.8f,0),
                new Vector3(1.8f,0.1f,0)
            },
            materiales[2]

        ),
        
        
        //* * *
        //*   *
        //* * * 
        new MeshGeneratorTree(
            "Cuadrado",
            5,
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
                new Vector3(1.9f,0.1f,0),
                new Vector3(1.9f,1.9f,0),
            },
            materiales[4]

        ),
        //     *
        //  *  *
        //*    * 
        //*    *
        //* *  *
        new MeshGeneratorTree(
            "TrapecioRectangulo",
            6,
            new Vector3[]
            {
                new Vector3(0,0,0),
                new Vector3(0,4,0),
                new Vector3(2,2,0),
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
                new Vector3(0.1f,3.9f,0),
                new Vector3(1.9f,1.9f,0),
                new Vector3(1.9f,0.1f,0),
            },
            materiales[3]
        ),

        // 8 piezas
        #region

               // //*
               // //* *
               // //* * *
               // new MeshGeneratorTree(
               //     "TPequeño",
               //     false,
               //     new Vector3[]
               //     {
               //         new Vector3(0,0,0),
               //         new Vector3(0,2,0),
               //         new Vector3(2,0,0)
               //     },
               //     new int[]
               //     {
               //         0,1,2
               //     },
               //     new Vector3[]
               //     {
               //         new Vector3(0.1f,0.1f,0),
               //         new Vector3(0.1f,1.8f,0),
               //         new Vector3(1.8f,0.1f,0)
               //     },
               //     materiales[0]

               // ),
               // new MeshGeneratorTree(
               //     "TGrande",
               //     false,
               //     new Vector3[]
               //     {
               //         new Vector3(0,0,0),
               //         new Vector3(0,4,0),
               //         new Vector3(4,0,0)
               //     },
               //     new int[]
               //     {
               //         0,1,2
               //     },
               //     new Vector3[]
               //     {
               //         new Vector3(0.1f,0.1f,0),
               //         new Vector3(0.1f,3.8f,0),
               //         new Vector3(3.8f,0.1f,0)
               //     },
               //     materiales[1]

               // ),
               // //* * * * *
               // //*       *
               // //* * * * *
               // new MeshGeneratorTree(
               //    "Rectangulo",
               //    false,
               //    new Vector3[]
               //    {
               //         new Vector3(0,0,0),
               //         new Vector3(0,2,0),
               //         new Vector3(4,0,0),
               //         new Vector3(4,2,0),
               //    },
               //    new int[]
               //    {
               //         0,1,2,
               //         1,3,2
               //    },
               //    new Vector3[]
               //    {
               //         new Vector3(0.1f,0.1f,0),
               //         new Vector3(0.1f,1.9f,0),
               //         new Vector3(3.9f,0.1f,0),
               //         new Vector3(3.9f,1.9f,0),
               //    },
               //     materiales[2]

               //),

        

               // //   *
               // //  * *
               // //* * * *
               // new MeshGeneratorTree(
               //    "TrianguloMediano",
               //    false,
               //    new Vector3[]
               //    {
               //         new Vector3(0,0,0),
               //         new Vector3(2,2,0),
               //         new Vector3(4,0,0)
               //    },
               //    new int[]
               //    {
               //         0,1,2
               //    },
               //    new Vector3[]
               //    {
               //         new Vector3(0.2f,0.1f,0),
               //         new Vector3(2f,1.9f,0),
               //         new Vector3(3.8f,0.1f,0)
               //    },
               //     materiales[3]



               //),

               // //     *
               // //   *   *
               // // *       * 
               // //* * * * *  *
               // new MeshGeneratorTree(
               //     "TrianguloGigante",
               //     false,
               //    new Vector3[]
               //    {
               //         new Vector3(0,0,0),
               //         new Vector3(4,4,0),
               //         new Vector3(8,0,0)
               //    },
               //    new int[]
               //    {
               //         0,1,2
               //    },
               //    new Vector3[]
               //    {
               //         new Vector3(0.2f,0.1f,0),
               //         new Vector3(3.9f,3.9f,0),
               //         new Vector3(7.8f,0.1f,0)
               //    },
               //     materiales[4]
               //),
      
        
               // //*
               // //* *
               // //*    * 
               // //*    *
               // //*    *
               // //  *  *
               // //     *
               // new MeshGeneratorTree(
               //     "Paralelogramo1",
               //     true,
               //    new Vector3[]
               //    {
               //         new Vector3(0,0,0),
               //         new Vector3(0,4,0),
               //         new Vector3(2,2,0),
               //         new Vector3(2,-2,0),
               //    },
               //    new int[]
               //    {
               //         0,1,2,
               //         0,2,3
               //    },
               //    new Vector3[]
               //    {
               //        new Vector3(0.1f,0.1f,0),
               //        new Vector3(0.1f,3.8f,0),
               //        new Vector3(1.9f,1.9f,0),
               //        new Vector3(1.9f,-1.8f,0),
               //    },
               //     materiales[5]



               //),
               // //*
               // //* *
               // //*   * 
               // //*   *
               // //*   *
               // //*   *
               // //* *    
               // //*
               // new MeshGeneratorTree(
               //     "Trapecio",
               //     true,
               //    new Vector3[]
               //    {
               //         new Vector3(0,0,0),
               //         new Vector3(2,2,0),
               //         new Vector3(4,0,0),
               //         new Vector3(6,2,0),
               //         new Vector3(8,0,0),
               //    },
               //    new int[]
               //    {
               //         0,1,2,
               //         1,3,2,
               //         2,3,4
               //    },
               //    new Vector3[]
               //    {
               //        new Vector3(0.1f,0.1f,0),
               //        new Vector3(1.9f,1.9f,0),
               //        new Vector3(3.9f,0.1f,0),
               //        new Vector3(5.9f,1.9f,0),
               //        new Vector3(7.9f,0.1f,0),
               //    },
               //     materiales[6]



               //),
               // //*
               // //* *
               // //*    * 
               // //*    *
               // //* *  *
               // new MeshGeneratorTree(
               //     "TrapecioRectangulo",
               //     true,
               //    new Vector3[]
               //    {
               //         new Vector3(0,0,0),
               //         new Vector3(0,2,0),
               //         new Vector3(2,4,0),
               //         new Vector3(2,0,0),
               //    },
               //    new int[]
               //    {
               //         0,1,2,
               //         0,2,3
               //    },
               //    new Vector3[]
               //    {
               //         new Vector3(0.1f,0.1f,0),
               //         new Vector3(0.1f,1.9f,0),
               //         new Vector3(1.9f,3.8f,0),
               //         new Vector3(1.9f,0.1f,0),
               //    },
               //     materiales[7]
               //),

        #endregion

        };
        generateCombinations = new GenerateCombinations(fichas);


        //Text.GetComponent<Text>().text = "Contruye el Tangram";
        generateCombinations.getArbol().TransversaPreO(generateCombinations.getArbol().raiz);

        //Text.GetComponent<Text>().text = generateCombinations.getArbol().text;

    }

    // Update is called once per frame
    void Update()
    {

    }
}


class MeshGeneratorTree
{
    public GameObject go;
    public Mesh mesh;
    public Vector3[] vertices;
    public int[] triangles;
    public bool isColliding;


    public MeshGeneratorTree(string _nombre, int _id, Vector3[] _vertices, int[] _triangles, Vector3[] _verticesCollider, Material _material)
    {


        setupGameObject(_nombre, _id, _verticesCollider);
        mesh = new Mesh();
        go.GetComponent<MeshFilter>().mesh = mesh;
        go.GetComponent<MeshRenderer>().material = _material;
        vertices = _vertices;
        triangles = _triangles;
        updateMesh();
    }

    public string toString()
    {
        return "Ficha: " + go.name + "; Posx: " + go.transform.position.x + "; Posy: " + go.transform.position.y + "; Rotation: " + getRotation(); ;
    }

    void updateMesh()
    {
        mesh.Clear();
        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.RecalculateNormals();
    }

    void setupGameObject(string nombre, int _id, Vector3[] _verticesCollider)
    {


        go = new GameObject();
        go.name = nombre;
        go.AddComponent<DragAndDropController>();
        go.AddComponent<MeshFilter>();
        go.AddComponent<MeshRenderer>();

        go.AddComponent<PhotonView>();
        go.GetComponent<PhotonView>().ViewID = _id;

        go.AddComponent<PhotonTransformViewClassic>();
        go.GetComponent<PhotonTransformViewClassic>().m_PositionModel.SynchronizeEnabled = true;

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



    public void setX(float x)
    {
        go.transform.position = new Vector3(x, go.transform.position.y, go.transform.position.z);
    }
    public float getX()
    {
        return go.transform.position.x;
    }
    public void setY(float y)
    {
        go.transform.position = new Vector3(go.transform.position.x, y, go.transform.position.z);
    }

    public float getY()
    {
        return go.transform.position.y;
    }

    public void setRotation(float z)
    {
        go.transform.rotation = Quaternion.Euler(go.transform.rotation.eulerAngles.x, go.transform.rotation.eulerAngles.y, z);
    }

    public float getRotation()
    {
        return go.transform.rotation.eulerAngles.z;
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

    public MeshGeneratorTree Clone()
    {
        return (MeshGeneratorTree)this.MemberwiseClone();
    }

    public GameObject getGameObject()
    {
        return go;
    }

}

class GenerateCombinations
{
    Arbol arbol;

    public GenerateCombinations(MeshGeneratorTree[] fichas)
    {
        arbol = new Arbol();

        Nodo raiz = arbol.insertar(new EstadoPieza(), null);

        List<List<Nodo>> nodos = new List<List<Nodo>>();


        for (var i = 0; i < fichas.Length; i++)
        {

            List<EstadoPieza> temp = new List<EstadoPieza>();

            for (var x = 0; x <= 4; x++)
            {
                for (var y = 0; y <= 4; y++)
                {
                    //fichas[i].setRotation(degree);
                    fichas[i].setX(x);
                    fichas[i].setY(y);

                    bool valido = true;

                    // SI ESTA DENTRO DEL RANGO
                    foreach (Vector3 vertices in fichas[i].getGameObject().GetComponent<MeshFilter>().mesh.vertices)
                    {
                        Vector3 vertexWorld = fichas[i].getGameObject().transform.TransformPoint(vertices);


                        if (vertexWorld.x < 0.0f || vertexWorld.x > 4.0f || vertexWorld.y < 0.0f || vertexWorld.y > 4.0f)
                        {
                            valido = false;
                        }

                    }

                    //AGREGAR LA COMBINACION VALIDA A LA LISTA
                    if (valido)
                    {
                        temp.Add(new EstadoPieza(fichas[i].getGameObject().name, fichas[i].getX(), fichas[i].getY()));

                    }
                }
            }
            if (i == 0)
            {
                foreach (EstadoPieza estadoPieza in temp)
                {

                    List<Nodo> tempList = new List<Nodo>();
                    tempList.Add(arbol.insertar(estadoPieza, raiz));
                    nodos.Add(tempList);

                }

            }
            else
            {
                foreach (Nodo nodoTemporal in nodos[i - 1])
                {
                    foreach (EstadoPieza estadoPieza in temp)
                    {
                        Debug.Log(i + ":" + (i - 1) + "-" + nodos.Count);
                        if (nodos.Count == 3 && i == 3)
                        {
                            Debug.Log("para");
                        }

                        nodos[i].Add(arbol.insertar(estadoPieza, nodoTemporal));
                    }
                }

            }
        }

        //"TPequeño",
        //"TPequeño2",
        //"TPequeño3",
        //"Cuadrado",
        //"TrapecioRectangulo",

        Nodo Tpequeño2 = null;
        Nodo Tpequeño3 = null;


        Nodo Tpequeño = arbol.Buscar(new EstadoPieza("TPequeño", 2, 2), raiz);

        if (Tpequeño != null)
        {
            Tpequeño2 = arbol.Buscar(new EstadoPieza("TPequeño2", 0, 2), Tpequeño);
        }

        Debug.Log(arbol);
        //arbol.TransversaPreO(raiz);
    }

    public Arbol getArbol()
    {
        return arbol;
    }
}


[Serializable]
public class EstadoPieza
{
    string nombrePieza;
    float xPos;
    float yPos;
    public bool esMeta = false;

    public EstadoPieza(string _nombrePieza, float _xPos, float _yPos)
    {
        nombrePieza = _nombrePieza;
        xPos = _xPos;
        yPos = _yPos;

    }

    public EstadoPieza()
    {
        nombrePieza = "inicial";
        xPos = 0;
        yPos = 0;

    }

    public void establecerComoNodoMeta()
    {
        esMeta = true;
    }



    public string toString()
    {
        return "Ficha: " + nombrePieza + "; Posx: " + xPos + "; Posy: " + yPos;

    }

    //public int CompareTo(object other)
    //{
    //    if (other is EstadoPieza other1)
    //    {
    //        return nombrePieza.CompareTo(other1.nombrePieza);
    //    }
    //    throw new Exception("Can't compare Object1 to other things");
    //}

    //public int CompareTo(object obj)
    //{
    //    throw new NotImplementedException();
    //}
}



public class SaveData
{

    public SaveData(Arbol data)
    {
        //string dat = JsonConvert.SerializeObject(data);
        //Debug.Log(dat);
        //System.IO.File.WriteAllText(Application.persistentDataPath + "/data.json", dat);
    }

}
[Serializable]
public class Nodo
{

    public EstadoPieza pieza;

    public Nodo hijo;

    public Nodo hermano;

    public EstadoPieza Pieza { get => pieza; set => pieza = value; }

    public Nodo Hijo { get => hijo; set => hijo = value; }

    public Nodo Hermano { get => hermano; set => hermano = value; }

    public Nodo()
    {
        pieza = null;
        hijo = null;
        hermano = null;
    }

}

[Serializable]
public class Arbol
{
    public Nodo raiz;
    public Nodo trabajo;
    public int i = 0;

    public string text = "";

    public Arbol()
    {
        raiz = new Nodo();
    }

    public Nodo insertar(EstadoPieza _pieza, Nodo _nodo)
    {

        if (_nodo == null)
        {
            raiz = new Nodo();
            raiz.Pieza = _pieza;

            raiz.Hijo = null;

            raiz.Hermano = null;

            return raiz;
        }

        if (_nodo.Hijo == null)
        {
            Nodo nodoTemporal = new Nodo();
            nodoTemporal.Pieza = _pieza;
            _nodo.Hijo = nodoTemporal;

            return nodoTemporal;
        }
        else
        {
            trabajo = _nodo.Hijo;

            while (trabajo.Hermano != null)
            {
                trabajo = trabajo.Hermano;
            }

            Nodo nodoTemporal = new Nodo();
            nodoTemporal.Pieza = _pieza;
            trabajo.Hermano = nodoTemporal;

            return nodoTemporal;
        }

    }

    public Nodo Buscar(EstadoPieza _pieza, Nodo _nodo)
    {
        Nodo encontrado = null;

        if (_nodo == null)
        {
            return encontrado;
        }

        if (_nodo.pieza.toString() == _pieza.toString())
        {

            encontrado = _nodo;
            return encontrado;
        }

        // luego se procesa al hijo
        if (_nodo.Hijo != null)
        {
            encontrado = Buscar(_pieza, _nodo.Hijo);

            if (encontrado != null)
            {
                return encontrado;
            }
        }

        // si tiene hermanos

        if (_nodo.Hermano != null)
        {
            encontrado = Buscar(_pieza, _nodo.Hermano);

            if (encontrado != null)
            {
                return encontrado;
            }
        }

        return encontrado;

    }

    public void TransversaPreO(Nodo _nodo)
    {
        if (_nodo == null)
        {
            return;
        }
        var espaces = "";
        for (int n = 0; n < i; n++)
        {
            Console.WriteLine(" ");
            text += "   ";
            espaces += "\t";
        }
        Debug.Log(espaces + _nodo.Pieza.toString());
        Console.WriteLine(_nodo.Pieza.toString());
        text += _nodo.Pieza.toString() + "\n";

        if (_nodo.Hijo != null)
        {
            i++;
            TransversaPreO(_nodo.Hijo);
            i--;
        }


        if (_nodo.Hermano != null)
        {
            TransversaPreO(_nodo.Hermano);
        }
    }
}