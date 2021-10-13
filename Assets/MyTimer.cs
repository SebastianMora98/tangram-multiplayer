using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;

public class MyTimer : MonoBehaviour
{

    bool startTimer = false;
    double timerIncrementValue;
    double startTime;
    [SerializeField] double timer = 20;
    ExitGames.Client.Photon.Hashtable CustomeValue;

    public Text texto;

    void Start()
    {
        if (PhotonNetwork.LocalPlayer.IsMasterClient)
        {
            CustomeValue = new ExitGames.Client.Photon.Hashtable();
            startTime = PhotonNetwork.Time;
            startTimer = true;
            CustomeValue.Add("StartTime", startTime);
            PhotonNetwork.LocalPlayer.SetCustomProperties(CustomeValue);
        }
        else
        {
            startTime = double.Parse(PhotonNetwork.LocalPlayer.CustomProperties["StartTime"].ToString());
            startTimer = true;
        }
    }

    void Update()
    {
        if (!startTimer) return;
        timerIncrementValue = PhotonNetwork.Time - startTime;
        if (timerIncrementValue >= timer)
        {

            CustomeValue["StartTime"] = timer;

            PhotonNetwork.LocalPlayer.CustomProperties = CustomeValue;

            texto.text = (string)PhotonNetwork.LocalPlayer.CustomProperties["StartTime"];

            //Timer Completed
            //Do What Ever You What to Do Here
        }
    }
}
