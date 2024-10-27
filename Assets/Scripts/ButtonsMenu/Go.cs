using UnityEngine;
using UnityEngine.SceneManagement;

public class Go : MonoBehaviour
{
    public Animator pAnim;

    private void Start() {
        pAnim = pAnim.GetComponent<Animator>();
    }

    public void onClick() {
        Invoke("changeScene", 3.5f);
        pAnim.Play("FadeOut");
    }

    private void changeScene() {
        SceneManager.LoadScene("Intructions_0");
    }
}
