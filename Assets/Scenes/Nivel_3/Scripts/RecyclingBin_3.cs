using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.SceneManagement;
using Photon.Pun;

public class RecyclingBin_3 : MonoBehaviour
{
    public TextMeshProUGUI txtObjective;
    public GameObject timer;
    public Animator pAnim;
    private List<string> targets = new List<string>();
    private List<GameObject> basuraTotal = new List<GameObject>();
    private List<GameObject> basuraNoRecogida = new List<GameObject>();

    private void Start() {
        targets.Add("objReciclable");
        targets.Add("objNoReciclable");

        foreach (var tag in targets)
        {
            GameObject[] obj = GameObject.FindGameObjectsWithTag(tag);
            foreach (var gameObject in obj)
            {
                basuraTotal.Add(gameObject);
            }
        }
    }

    private void reloadData(){
        basuraNoRecogida.Clear();
        foreach (var tag in targets)
        {
            GameObject[] obj = GameObject.FindObjectsOfType<GameObject>(false);
            foreach (var gameObject in obj)
            {
                if (gameObject.CompareTag(tag)) {
                    basuraNoRecogida.Add(gameObject);
                }
            }
        }
    }

    private void finish() {
        if (basuraNoRecogida.Count == 0) {
            timer.GetComponent<Timer_3>().timerIsRunning = false;
            timer.GetComponent<TextMeshProUGUI>().SetText("<color=green><b>¡Limpieza finalizada correctamente!</b></color>");
            pAnim.Play("FadeOut");
            Invoke("Finished", 4);
        }
    }

    private void Finished() {
        if (PhotonNetwork.IsConnected) PhotonNetwork.Disconnect();
        SceneManager.LoadScene("Finish_3");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Player player = other.GetComponent<Player>();
            Animator anim = other.GetComponent<Animator>();

            if (player.objPick != null)
            {
                if (this.CompareTag("cReciclar") && player.objPick.CompareTag("objReciclable"))
                {
                    Debug.Log("Objeto reciclable depositado en el contenedor reciclable.");
                    player.objPick = null;
                    anim.SetBool("isTirar", true);
                    player.canMove = false;
                    StartCoroutine(HandlePickup(anim, player));
                    reloadData();
                    txtObjective.SetText($"Basura recogida: {basuraTotal.Count - basuraNoRecogida.Count}/{basuraTotal.Count}");
                    finish();
                }
                else if (this.CompareTag("cNoReciclar") && player.objPick.CompareTag("objNoReciclable"))
                {
                    Debug.Log("Objeto no reciclable depositado en el contenedor no reciclable.");
                    player.objPick = null;
                    anim.SetBool("isTirar", true);
                    player.canMove = false;
                    StartCoroutine(HandlePickup(anim, player));
                    reloadData();
                    txtObjective.SetText($"Basura recogida: {basuraTotal.Count - basuraNoRecogida.Count}/{basuraTotal.Count}");
                    finish();
                }
                else
                {
                    Debug.Log("Tipo de objeto no coincide con el contenedor.");
                }
            }
            else
            {
                Debug.Log("No hay objeto para depositar.");
            }
        }
    }

    private IEnumerator HandlePickup(Animator anim, Player obj) {
        yield return new WaitForSeconds(3);
        anim.SetBool("isTirar", false);
        obj.canMove = true;
    }
}