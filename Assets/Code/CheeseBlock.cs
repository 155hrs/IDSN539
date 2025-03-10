using UnityEngine;

public class CheeseBlock : MonoBehaviour
{
    public GameObject explosionEffect; // Drag your explosion prefab here

    void OnMouseDown()
    {
        // Instantiate explosion at the cheese block's position
        if (explosionEffect != null)
        {
            Instantiate(explosionEffect, transform.position, transform.rotation);
        }

        // Inform GameManager that a cheese block was collected
        GameManager.instance.CollectCheese();

        // Destroy the cheese block
        Destroy(gameObject);
    }
}