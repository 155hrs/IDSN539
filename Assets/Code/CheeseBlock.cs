// using UnityEngine;

// public class CheeseBlock : MonoBehaviour
// {
//     public GameObject explosionEffect; // Drag your explosion prefab here

//     void OnMouseDown()
//     {
//         // Instantiate explosion at the cheese block's position
//         if (explosionEffect != null)
//         {
//             Instantiate(explosionEffect, transform.position, transform.rotation);
//         }

//         // Inform GameManager that a cheese block was collected
//         GameManager.instance.CollectCheese();

//         // Destroy the cheese block
//         Destroy(gameObject);
//     }
// }

using UnityEngine;

public class CheeseBlock : MonoBehaviour
{
    public GameObject explosionEffect;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void OnMouseDown()
    {
        if (explosionEffect != null)
        {
            Instantiate(explosionEffect, transform.position, transform.rotation);
        }

        // Play sound effect
        if (audioSource != null)
        {
            audioSource.Play();
        }

        GameManager.instance.CollectCheese();

        // Destroy after sound finishes playing
        Destroy(gameObject, audioSource.clip.length);
    }
}
