using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Timeout_2 : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(ExecuteFunctionAfterDelay(22f));
    }

    private IEnumerator ExecuteFunctionAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        MyFunction();
    }

    private void MyFunction()
    {
        SceneManager.LoadScene("Playing_2");
    }
}
