using UnityEngine;
using System.Collections;
using static UnityEngine.UI.ScrollRect;

public class EnemySpawner : MonoBehaviour
{
    public GameObject EnemyPrefab; // The enemy to spawn
    public Transform SpawnPointQuadratic; // Spawn location for quadratic movement
    public Transform SpawnPointCubic; // Spawn location for cubic movement
    public Transform EndPoint; // The destination where enemies move towards
    public float SpawnRate = 2f; // Time between spawns

    void Start()
    {
        StartCoroutine(SpawnEnemiesContinuously());
    }

    IEnumerator SpawnEnemiesContinuously()
    {
        while (true)
        {
            yield return new WaitForSeconds(SpawnRate);

            // Randomly choose which spawn point to use
            bool SpawnQuadratic = Random.value > 0.5f;

            GameObject enemy = Instantiate(EnemyPrefab,
                SpawnQuadratic ? SpawnPointQuadratic.position : SpawnPointCubic.position,
                Quaternion.identity);

            // Set enemy movement type
            Enemy Movement = enemy.GetComponent<Enemy>();
            Movement.SetMovementType(SpawnQuadratic ? MovementType.Quadratic : MovementType.Cubic);
            Movement.SetTarget(EndPoint);
        }
    }
}
