using UnityEngine;
using UnityEngine.SceneManagement;

public class Change_Instruct : MonoBehaviour
{
    public string sceneBefore = "Menu";
    public string sceneAfter = "Menu";

    public void before() {
        SceneManager.LoadScene(sceneBefore);
    }

    public void after() {
        SceneManager.LoadScene(sceneAfter);
    }
}
