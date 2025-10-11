using System.Collections;
using UnityEngine;
using UnityEngine.Splines;

public class WaveSpawner : MonoBehaviour
{
    [System.Serializable]
    public class Wave
    {
        public string waveName;
        public GameObject enemyPrefab;
        public int enemyCount;
        public float spawnRate; // enemies per second
    }

    [Header("Wave Settings")]
    public Wave[] waves;
    private int currentWaveIndex = 0;
    private bool spawningWave = false;

    [Header("Spawn Settings")]
    public Transform[] spawnPoints;
    public float timeBetweenWaves = 5f;
    private float countdown = 2f;

    [Header("Spline Reference")]
    public SplineContainer enemyPathSpline; // assign in inspector

    void Update()
    {
        if (spawningWave)
            return;

        if (currentWaveIndex < waves.Length)
        {
            if (countdown <= 0f)
            {
                StartCoroutine(SpawnWave(waves[currentWaveIndex]));
                countdown = timeBetweenWaves;
            }
            countdown -= Time.deltaTime;
        }
        else
        {
            // All waves done
            Debug.Log("✅ All waves complete!");
        }
    }

    IEnumerator SpawnWave(Wave wave)
    {
        Debug.Log($"🚨 Spawning Wave: {wave.waveName}");
        spawningWave = true;

        for (int i = 0; i < wave.enemyCount; i++)
        {
            SpawnEnemy(wave.enemyPrefab);
            yield return new WaitForSeconds(1f / wave.spawnRate);
        }

        currentWaveIndex++;
        spawningWave = false;
    }

    void SpawnEnemy(GameObject enemyPrefab)
    {
        Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
        GameObject newEnemy = Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);

        // Assign the spline reference if the enemy has MoveAlongSpline
        MoveAlongSpline moveScript = newEnemy.GetComponent<MoveAlongSpline>();
        if (moveScript != null && enemyPathSpline != null)
        {
            moveScript.Spline = enemyPathSpline;
        }
        else if (moveScript == null)
        {
            Debug.LogWarning($"Spawned enemy {newEnemy.name} missing MoveAlongSpline script!");
        }
        else if (enemyPathSpline == null)
        {
            Debug.LogWarning("No spline assigned to WaveSpawner!");
        }
    }
}