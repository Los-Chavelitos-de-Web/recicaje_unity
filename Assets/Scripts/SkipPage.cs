using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkipPage : MonoBehaviour
{
    public GameObject p1;
    public GameObject p2;
    public GameObject p3;
    private GameObject[] paneles;
    private int indice = 0;

    private void Start() {
        paneles = new GameObject[] { p1, p2, p3 };
        activePane(indice);
    }

    private void disableAllPanels() {
        foreach (var p in paneles) {
            p.SetActive(false);
        }
    }

    private void activePane(int i) {
        if (i < 0) {
            indice = 0;
        } else if (i >= paneles.Length) {
            indice = paneles.Length - 1;
        } else {
            indice = i;
        }

        disableAllPanels();
        paneles[indice].SetActive(true);
    }

    public void onClick() {
        if (this.CompareTag("btnAfter")) {
            activePane(indice + 1);
        } else if (this.CompareTag("btnBefore")) {
            activePane(indice - 1);
        }
    }
}
