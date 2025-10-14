using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject enemy;
    public Transform target; // Assign the enemy's Transform when firing
    public float hitDistance = 0.1f; // Distance threshold for "hit"
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null) return;

        float distance = Vector2.Distance(transform.position, target.position);
        if (distance < hitDistance)
        {
            Destroy(gameObject);
            Destroy(enemy);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject); // Destroy bullet
            
        }
    }
}
