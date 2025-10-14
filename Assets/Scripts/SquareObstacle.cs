using UnityEngine;

public class SquareObstacle : MonoBehaviour
{
    public float speed = 2f;
    public float resetX = 10f;
    public float leftLimitX = -10f;
    

    void Update()
    {
        // Move left every frame
        transform.position += Vector3.left * speed * Time.deltaTime;

        // Check if past left edge
        if (transform.position.x < leftLimitX)
        {
            // Move to right side
            Vector3 newPos = transform.position;
            newPos.x = resetX;
            transform.position = newPos;
        }

       
    }

    
}
