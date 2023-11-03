using UnityEngine;

public class CherryController : MonoBehaviour
{
    public GameObject cherryPrefab; // Assign the cherry prefab in the Inspector
    public float spawnInterval = 10f; // Time between cherry spawns
    public float moveSpeed = 5f; // Cherry movement speed

    private float nextSpawnTime;
    private Camera mainCamera;
    private Tweener tweener;
    private Vector3 centerPoint = new Vector3(14f, -15f, 0f);
    private float spawnBuffer = 1.0f;

    private void Start()
    {
        mainCamera = Camera.main;
        nextSpawnTime = Time.time + spawnInterval;
        tweener = GetComponent<Tweener>();
    }

    private void Update()
    {
        if (Time.time >= nextSpawnTime)
        {
            SpawnCherry();
            nextSpawnTime = Time.time + spawnInterval;
        }
    }

    void SpawnCherry()
    {
        Vector3 spawnPosition = GetRandomSpawnPosition();
        GameObject newCherry = Instantiate(cherryPrefab, spawnPosition, Quaternion.identity);

        // Calculate the direction from the center point to the spawn position
        Vector3 direction = newCherry.transform.position - centerPoint;

        // Calculate the target position on the opposite side of the center point
        Vector3 targetPosition = centerPoint - direction;

        var moveSpeed = 8.0f;

        // Use your tweener function to move the cherry
        tweener.AddTween(newCherry.transform, spawnPosition, targetPosition, moveSpeed);
        // Destroy the cherry when it reaches the target position
        Destroy(newCherry, Vector3.Distance(newCherry.transform.position, targetPosition) / moveSpeed);
    }

    Vector2 GetRandomSpawnPosition()
    {
        float halfHeight = mainCamera.orthographicSize;
        float halfWidth = halfHeight * mainCamera.aspect;

        int randomSide = Random.Range(0, 4); // 0, 1, 2, or 3 representing top, right, bottom, or left sides

        float randomX = 0f;
        float randomY = 0f;

        switch (randomSide)
        {
            case 0: // Top side
                randomX = Random.Range(centerPoint.x - halfWidth + spawnBuffer, centerPoint.x + halfWidth - spawnBuffer);
                randomY = centerPoint.y + halfHeight + spawnBuffer;
                break;
            case 1: // Right side
                randomX = centerPoint.x + halfWidth + spawnBuffer;
                randomY = Random.Range(centerPoint.y - halfHeight + spawnBuffer, centerPoint.y + halfHeight - spawnBuffer);
                break;
            case 2: // Bottom side
                randomX = Random.Range(centerPoint.x - halfWidth + spawnBuffer, centerPoint.x + halfWidth - spawnBuffer);
                randomY = centerPoint.y - halfHeight - spawnBuffer;
                break;
            case 3: // Left side
                randomX = centerPoint.x - halfWidth - spawnBuffer;
                randomY = Random.Range(centerPoint.y - halfHeight + spawnBuffer, centerPoint.y + halfHeight - spawnBuffer);
                break;
        }

        return new Vector2(randomX, randomY);
    }
}