using UnityEngine;
using TMPro;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.SceneManagement;
using Photon.Pun;

public class Timer : MonoBehaviour
{
    public Animator pAnim;
    public bool timerIsRunning = false;
    public List<GameObject> players = new List<GameObject>();
    private TextMeshProUGUI timerText;
    private float timeRemaining = 200f;

    void Start()
    {
        timerText = GetComponent<TextMeshProUGUI>();
        pAnim = pAnim.GetComponent<Animator>();
        players.AddRange(GameObject.FindGameObjectsWithTag("Player"));
    }

    void Update()
    {
        if (timerIsRunning)
        {
            timeRemaining -= Time.deltaTime;

            if (timeRemaining <= 0)
            {
                timeRemaining = 0;
                timerIsRunning = false;
                EndTimer();
            }
            else
            {
                UpdateTimerText();
            }
        }
    }

    public void StartTimer()
    {
        timerIsRunning = true;
    }

    private void UpdateTimerText()
    {
        int minutes = Mathf.FloorToInt(timeRemaining / 60);
        int seconds = Mathf.FloorToInt(timeRemaining % 60);

        timerText.SetText($"{minutes}:{seconds:D2}");
    }

    private void EndTimer()
    {
        foreach (GameObject p in players) {
            p.GetComponent<Player>().canMove = false;
        }

        timerText.SetText("<color=red><b>¡Tiempo finalizado!</b></color>");

        pAnim.Play("FadeOut");
        Invoke("ReturnScene", 4);
    }

    private void ReturnScene() {
        if (PhotonNetwork.IsConnected) PhotonNetwork.Disconnect();
        SceneManager.LoadScene("Cinematic");
    }
}