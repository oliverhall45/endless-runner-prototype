using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float jumpForce = 5f;
    private Rigidbody2D rb;
    public GameObject bulletPrefab;
    public Transform squareObstacle;
    public float bulletSpeed = 10f;
    public float jetThrustForce = 5f;
    private float lastFireTime = -Mathf.Infinity;
    public float fireCooldown = 2f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && transform.position.y <= -3.8f)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode2D.Impulse);
        }



        if (Input.GetMouseButtonDown(0) && Time.time >= lastFireTime + fireCooldown)
        {
            ShootWithThrust();
        }

        
    }

    

    void ShootWithThrust()
    {
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseWorldPos.z = 0f;

        Vector2 shootDirection = (mouseWorldPos - transform.position).normalized;

        // Instantiate and fire bullet
        GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);

        Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>();
        if (bulletRb != null)
        {
            bulletRb.linearVelocity = shootDirection * bulletSpeed;
        }

        if(transform.position.y >= -3.7f)
        {
            // Apply opposite force to the player
            rb.AddForce(-shootDirection * jetThrustForce, ForceMode2D.Impulse);
        }
        

        // Destroy bullet after 3 seconds
        Destroy(bullet, 3f);

        // Ignore collision with player
        Collider2D playerCollider = GetComponent<Collider2D>();
        Collider2D bulletCollider = bullet.GetComponent<Collider2D>();
        if (playerCollider != null && bulletCollider != null)
        {
            Physics2D.IgnoreCollision(playerCollider, bulletCollider);
        }

        // Update last fire time
        lastFireTime = Time.time;
    }
}

