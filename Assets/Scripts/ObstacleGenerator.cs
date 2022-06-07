using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleGenerator : MonoBehaviour
{
    public GameObject obstaclePrefab;
    [SerializeField] private float spawnRate;
    [SerializeField] private float obstacleSpeed;

    private void Start()
    {
        StartCoroutine(SpawnObstacle());
    }

    private IEnumerator SpawnObstacle()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnRate);
            GameObject obstacle = Instantiate(obstaclePrefab, transform.position, 
                Quaternion.LookRotation(Vector3.right), transform);
            obstacle.GetComponent<Obstacle>().SetSpeed(obstacleSpeed);
        }
    }
}
