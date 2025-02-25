using UnityEngine;

// Manage the counter for the light collection in the dare room challenge.
public class LightManager : MonoBehaviour
{
    public static LightManager Instance;
    public int totalLights = 5;
    private int collectedLights = 0;
    public GameObject doorToUnlock;

    void Awake()
    {
        Instance = this;
    }

    public void CollectLight()
    {
        collectedLights++;
        if(collectedLights >= totalLights)
        {
            // All lights collected!
            doorToUnlock.SetActive(true);
        }
    }
}
