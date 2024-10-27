using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish_3 : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(ExecuteFunctionAfterDelay(23f));
    }

    private IEnumerator ExecuteFunctionAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        MyFunction();
    }

    private void MyFunction()
    {
        SceneManager.LoadScene("Cinematic_3");
    }
}
