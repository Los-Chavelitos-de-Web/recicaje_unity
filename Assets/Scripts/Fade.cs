using UnityEngine;

public class Fade : MonoBehaviour
{

    public Animator anim;

    void Start()
    {
        Invoke("FadeOut", 18);
    }

    private void FadeOut() {
        anim.Play("FadeOut");
    }
}
