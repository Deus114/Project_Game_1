using UnityEngine;

public class BackgroundBoundary : MonoBehaviour
{
    private Vector2 minBoundary; // 
    private Vector2 maxBoundary; // 

    private void Start()
    {
        // 
        float backgroundWidth = GetComponent<SpriteRenderer>().bounds.size.x - 2 ;
        float backgroundHeight = GetComponent<SpriteRenderer>().bounds.size.y - 3;

        // 
        minBoundary = new Vector2(transform.position.x - backgroundWidth / 2, transform.position.y - backgroundHeight / 2);
        maxBoundary = new Vector2(transform.position.x + backgroundWidth / 2, transform.position.y + backgroundHeight / 2);
    }

    private void Update()
    {
        if (GameObject.FindGameObjectWithTag("Player"))
        {
            // 
            Vector2 playerPosition = GameObject.FindGameObjectWithTag("Player").transform.position;

            // 
            float clampedX = Mathf.Clamp(playerPosition.x, minBoundary.x, maxBoundary.x);
            float clampedY = Mathf.Clamp(playerPosition.y, minBoundary.y, maxBoundary.y);

            //
            GameObject.FindGameObjectWithTag("Player").transform.position = new Vector2(clampedX, clampedY);
        }

        if (GameObject.FindGameObjectWithTag("Enemies"))
        {
            // 
            Vector2 enemiesPosition = GameObject.FindGameObjectWithTag("Enemies").transform.position;

            // 
            float EclampedX = Mathf.Clamp(enemiesPosition.x, minBoundary.x, maxBoundary.x);
            float EclampedY = Mathf.Clamp(enemiesPosition.y, minBoundary.y, maxBoundary.y);

            //
            GameObject.FindGameObjectWithTag("Enemies").transform.position = new Vector2(EclampedX, EclampedY);
        }
    }
}
