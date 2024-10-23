using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class Timer : MonoBehaviour
{
    public Animator pAnim;
    public bool timerIsRunning = false;
    private TextMeshProUGUI timerText;
    private float timeRemaining = 30f;
    private GameObject[] players;

    void Start()
    {
        timerText = GetComponent<TextMeshProUGUI>();
        pAnim = pAnim.GetComponent<Animator>();
        players = GameObject.FindGameObjectsWithTag("Player");
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
        timerText.SetText("<color=red><b>¡Tiempo finalizado!</b></color>");

        foreach (GameObject p in players) {
            p.GetComponent<Player>().canMove = false;
        }

        pAnim.Play("FadeOut");
    }
}