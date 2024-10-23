using System.Collections.Generic;
using Photon.Pun;
using TMPro;
using UnityEngine;

public class Launcher : MonoBehaviourPunCallbacks
{

    public PhotonView playerPrefab;
    public Transform spawnPoint;
    public TextMeshProUGUI txtLoad;
    public TextMeshProUGUI txtObjective;
    public Timer txtTimerOut;
    private Camera main;
    private List<string> targets = new List<string>();
    private List<GameObject> basuraTotal = new List<GameObject>();
    private List<GameObject> basuraNoRecogida = new List<GameObject>();

    void Start()
    {
        targets.Add("objReciclable");
        targets.Add("objNoReciclable");
        PhotonNetwork.ConnectUsingSettings();
        main = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        txtLoad = txtLoad.GetComponent<TextMeshProUGUI>();
        txtTimerOut = txtTimerOut.GetComponent<Timer>();

        foreach (var tag in targets)
        {
            GameObject[] obj = GameObject.FindGameObjectsWithTag(tag);
            foreach (var gameObject in obj)
            {
                basuraTotal.Add(gameObject);

                if (!gameObject.activeSelf) {
                    basuraNoRecogida.Add(gameObject);
                }
            }
        }

    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("🚀 Connect to server");
        PhotonNetwork.JoinRandomOrCreateRoom();
    }

    public override void OnJoinedRoom()
    {
        GameObject player = PhotonNetwork.Instantiate(playerPrefab.name, spawnPoint.position, spawnPoint.rotation);
        Destroy(main.gameObject);
        txtLoad.SetText("");
        txtObjective.SetText($"Basura recogida: {basuraNoRecogida.Count}/{basuraTotal.Count}");

        if (!txtTimerOut.timerIsRunning) {
            txtTimerOut.StartTimer();
        }

        Camera playerCamera = player.GetComponentInChildren<Camera>();
        if (playerCamera != null)
        {
            playerCamera.enabled = true;
        }
    }

}
