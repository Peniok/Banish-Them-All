using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToStartScene : MonoBehaviour
{
    public void OnGoToMenuClick()
    {
        SceneManager.LoadScene(0);
    }
}
