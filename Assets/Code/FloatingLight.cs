using UnityEngine;

public class FloatingLight : MonoBehaviour
{
    public float bobSpeed = 2f;
    public float bobHeight = 0.5f;
    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        // Simple floating motion
        float newY = startPos.y + (Mathf.Sin(Time.time * bobSpeed) * bobHeight);
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Light collected!
            LightManager.Instance.CollectLight();
            Destroy(gameObject);
        }
    }
}