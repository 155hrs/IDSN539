using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public void LoadNextScene()
    {
        SceneManager.LoadScene(0);
        
    }
    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene(2);
        
    }
}
