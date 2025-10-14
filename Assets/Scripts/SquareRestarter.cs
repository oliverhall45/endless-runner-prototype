using UnityEngine;
using UnityEngine.SceneManagement;

public class SquareRestarter : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Transform playerTransform;      // Reference to the circle object
    private Collider2D squareCollider;

    void Start()
    {
        squareCollider = GetComponent<Collider2D>();
    }

    void Update()
    {
        if (squareCollider != null && playerTransform != null)
        {
            // Check if circle's position is within the square's collider bounds
            if (squareCollider.bounds.Contains(playerTransform.position))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }
    //Vector3 newPos = transform.position;
    //newPos.x = 10f;
    //transform.position = newPos;
}
