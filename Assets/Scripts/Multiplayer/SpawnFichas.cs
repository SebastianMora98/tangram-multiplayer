using ExitGames.Client.Photon;
using Photon.Pun;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SpawnFichas : MonoBehaviour
{
    public GameObject[] fichasPrefab;

    GameObject goP1Fig1;
    GameObject goP1Fig2;
    GameObject goP1Fig3;
    GameObject goP1Fig4;
    GameObject goP1Fig5;

    GameObject goP2Fig1;
    GameObject goP2Fig2;
    GameObject goP2Fig3;
    GameObject goP2Fig4;
    GameObject goP2Fig5;

    Vector2 P1Pos1 = new Vector2(-11, -2);
    Vector2 P1Pos2 = new Vector2(-7, -2);
    Vector2 P1Pos3 = new Vector2(-3, -2);
    Vector2 P1Pos4 = new Vector2(-9, -6);
    Vector2 P1Pos5 = new Vector2(-5, -6);

    Vector2 P2Pos1 = new Vector2(11, -2);
    Vector2 P2Pos2 = new Vector2(7, -2);
    Vector2 P2Pos3 = new Vector2(3, -2);
    Vector2 P2Pos4 = new Vector2(9, -6);
    Vector2 P2Pos5 = new Vector2(5, -6);

    public GameObject tablero1;
    public GameObject tablero2;

    public TMPro.TextMeshProUGUI textPuntosP1;
    public TMPro.TextMeshProUGUI textPuntosP2;

    public TMPro.TextMeshProUGUI textFinal;


    public GameObject timerText;
    public float timeRemaining = 30;
    public float timeTaken = 0;
    public bool timerIsRunning = false;

    public int puntosP1 = 0;
    public int puntosP2 = 0;


    bool started = false;

    bool canStart = true;

    public GameObject buttonSalir;

    void Start()
    {
        buttonSalir.SetActive(false);
        PhotonNetwork.SendRate = 3;
        PhotonNetwork.SerializationRate = 10;

        Hashtable setValue = new Hashtable();
        setValue.Add("puntosP1", 0);
        setValue.Add("puntosP2", 0);
        PhotonNetwork.CurrentRoom.SetCustomProperties(setValue);


        timerText.GetComponent<TMPro.TextMeshProUGUI>().text = "Tiempo: \n30";
        if (PhotonNetwork.LocalPlayer.IsMasterClient)
        {
            goP1Fig1 = PhotonNetwork.Instantiate(fichasPrefab[0].name, P1Pos1, Quaternion.identity);
            goP1Fig2 = PhotonNetwork.Instantiate(fichasPrefab[1].name, P1Pos2, Quaternion.identity);
            goP1Fig3 = PhotonNetwork.Instantiate(fichasPrefab[2].name, P1Pos3, Quaternion.identity);
            goP1Fig4 = PhotonNetwork.Instantiate(fichasPrefab[3].name, P1Pos4, Quaternion.identity);
            goP1Fig5 = PhotonNetwork.Instantiate(fichasPrefab[4].name, P1Pos5, Quaternion.identity);
        }
        else
        {
            goP2Fig1 = PhotonNetwork.Instantiate(fichasPrefab[0].name, P2Pos1, Quaternion.identity);
            goP2Fig2 = PhotonNetwork.Instantiate(fichasPrefab[1].name, P2Pos2, Quaternion.identity);
            goP2Fig3 = PhotonNetwork.Instantiate(fichasPrefab[2].name, P2Pos3, Quaternion.identity);
            goP2Fig4 = PhotonNetwork.Instantiate(fichasPrefab[3].name, P2Pos4, Quaternion.identity);
            goP2Fig5 = PhotonNetwork.Instantiate(fichasPrefab[4].name, P2Pos5, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (PhotonNetwork.CurrentRoom != null)
        {
            if (PhotonNetwork.CurrentRoom.PlayerCount == 2)
            {

                if (timeRemaining > 0)
                {
                    timeRemaining -= Time.deltaTime;
                    timerText.GetComponent<TMPro.TextMeshProUGUI>().text = "Tiempo: \n" + (int)timeRemaining;

                    if (PhotonNetwork.LocalPlayer.IsMasterClient)
                    {
                        if (goP1Fig1.GetComponent<DragAndDropMultiplayer>().inCorretPosition &&
                         goP1Fig2.GetComponent<DragAndDropMultiplayer>().inCorretPosition &&
                         goP1Fig3.GetComponent<DragAndDropMultiplayer>().inCorretPosition &&
                         goP1Fig4.GetComponent<DragAndDropMultiplayer>().inCorretPosition &&
                         goP1Fig5.GetComponent<DragAndDropMultiplayer>().inCorretPosition)
                        {
                            puntosP1++;
                            textPuntosP1.text = "Puntos: " + puntosP1;
                            updateScore(true, puntosP1);
                            restablecer();
                        }

                    }
                    else
                    {
                        if (goP2Fig1.GetComponent<DragAndDropMultiplayer>().inCorretPosition &&
                         goP2Fig2.GetComponent<DragAndDropMultiplayer>().inCorretPosition &&
                         goP2Fig3.GetComponent<DragAndDropMultiplayer>().inCorretPosition &&
                         goP2Fig4.GetComponent<DragAndDropMultiplayer>().inCorretPosition &&
                         goP2Fig5.GetComponent<DragAndDropMultiplayer>().inCorretPosition)
                        {
                            puntosP2++;
                            textPuntosP2.text = "Puntos: " + puntosP2;
                            updateScore(false, puntosP2);
                            restablecer();
                        }
                    }

                    textPuntosP1.text = "Puntos: " + PhotonNetwork.CurrentRoom.CustomProperties["puntosP1"];
                    textPuntosP2.text = "Puntos: " + PhotonNetwork.CurrentRoom.CustomProperties["puntosP2"];
                }
                else
                {

                    int puntosPlayer1 = (int)PhotonNetwork.CurrentRoom.CustomProperties["puntosP1"];
                    int puntosPlayer2 = (int)PhotonNetwork.CurrentRoom.CustomProperties["puntosP2"];

                    if (puntosPlayer1 > puntosPlayer2)
                    {
                        textFinal.text = "Player 1 WINS";
                    }
                    if (puntosPlayer2 > puntosPlayer1)
                    {
                        textFinal.text = "Player 2 WINS";
                    }
                    if (puntosPlayer1 == puntosPlayer2)
                    {
                        textFinal.text = "DRAW";
                    }


                    timerText.GetComponent<TMPro.TextMeshProUGUI>().text = "Fin";
                    timerIsRunning = false;
                    buttonSalir.SetActive(true);
                }


            }
        }

    }

    void CambiarColor(GameObject go)
    {
        go.GetComponent<SpriteRenderer>().color = new Color(0, 1, 0, 0);
    }

    public void Salir()
    {

        PhotonNetwork.LeaveRoom();
        SceneManager.LoadScene("Lobby");
    }

    void updateScore(bool esficha1, int cantidad)
    {
        if (esficha1)
        {

            Hashtable setValue = new Hashtable();
            setValue.Add("puntosP1", cantidad);
            setValue.Add("puntosP2", PhotonNetwork.CurrentRoom.CustomProperties["puntosP2"]);
            PhotonNetwork.CurrentRoom.SetCustomProperties(setValue);

            textPuntosP1.text = "Puntos: " + PhotonNetwork.CurrentRoom.CustomProperties["puntosP1"];
            textPuntosP2.text = "Puntos: " + PhotonNetwork.CurrentRoom.CustomProperties["puntosP2"];
        }
        else
        {
            Hashtable setValue = new Hashtable();
            setValue.Add("puntosP1", PhotonNetwork.CurrentRoom.CustomProperties["puntosP1"]);
            setValue.Add("puntosP2", cantidad);
            PhotonNetwork.CurrentRoom.SetCustomProperties(setValue);
            textPuntosP1.text = "Puntos: " + PhotonNetwork.CurrentRoom.CustomProperties["puntosP1"];
            textPuntosP2.text = "Puntos: " + PhotonNetwork.CurrentRoom.CustomProperties["puntosP2"];
        }

    }

    public void restablecer()
    {

        //timerText.GetComponent<TMPro.TextMeshProUGUI>().text = "Tiempo: \n" + timeRemaining;

        if (PhotonNetwork.LocalPlayer.IsMasterClient)
        {
            goP1Fig1.transform.position = P1Pos1;
            goP1Fig2.transform.position = P1Pos2;
            goP1Fig3.transform.position = P1Pos3;
            goP1Fig4.transform.position = P1Pos4;
            goP1Fig5.transform.position = P1Pos5;
        }
        else
        {
            goP2Fig1.transform.position = P2Pos1;
            goP2Fig2.transform.position = P2Pos2;
            goP2Fig3.transform.position = P2Pos3;
            goP2Fig4.transform.position = P2Pos4;
            goP2Fig5.transform.position = P2Pos5;
        }

    }
    [PunRPC]
    public void iniciar()
    {
        if (canStart)
        {
            timerIsRunning = true;
            canStart = false;
        }

    }
}
