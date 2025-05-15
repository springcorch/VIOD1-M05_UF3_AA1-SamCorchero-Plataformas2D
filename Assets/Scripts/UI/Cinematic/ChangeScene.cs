using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public string SceneName;

    public void SceneChanging()
    {
        SceneManager.LoadScene(SceneName);
    }
}
