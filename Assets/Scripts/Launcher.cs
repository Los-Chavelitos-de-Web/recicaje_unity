using Photon.Pun;
using Unity.VisualScripting;
using UnityEngine;

public class Launcher : MonoBehaviourPunCallbacks
{

    public PhotonView playerPrefab;
    public Transform spawnPoint;
    private Camera main;

    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
        main = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
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

        Camera playerCamera = player.GetComponentInChildren<Camera>();
        if (playerCamera != null)
        {
            playerCamera.enabled = true;
        }
    }

}
