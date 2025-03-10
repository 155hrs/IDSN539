using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RestartButton : MonoBehaviour
{
    private void Start()
    {
        // Ensure the button triggers the function when clicked
        GetComponent<Button>().onClick.AddListener(LoadTruthRoom);
    }

    public void LoadTruthRoom()
    {
        SceneManager.LoadScene("TruthRoom"); // Make sure "TruthRoom" is added to Build Settings
    }
}
