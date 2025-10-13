using System.Collections;
using TMPro; // For UI text
using UnityEngine;
using UnityEngine.UI; // For the button
using UnityEngine.Splines; // Needed for SplineContainer

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
    private bool waitingForNextWave = true;

    [Header("Spawn Settings")]
    public Transform[] spawnPoints;
    public float timeBetweenWaves = 5f;

    [Header("Spline Reference")]
    public SplineContainer enemyPathSpline;

    [Header("UI Elements")]
    public TextMeshProUGUI waveInfoText;
    public TextMeshProUGUI countdownText;
    public Button startWaveButton;

    private float countdown = 0f;

    void Start()
    {
        if (startWaveButton != null)
            startWaveButton.onClick.AddListener(StartNextWave);

        UpdateUI();
    }

    void Update()
    {
        if (!waitingForNextWave || spawningWave)
            return;

        if (countdown > 0)
        {
            countdown -= Time.deltaTime;
            countdownText.text = $"Next wave in: {countdown:F1}s";
            if (countdown <= 0)
            {
                countdown = 0;
                startWaveButton.interactable = true;
                countdownText.text = "Ready!";
            }
        }
    }

    public void StartNextWave()
    {
        if (spawningWave || currentWaveIndex >= waves.Length)
            return;

        StartCoroutine(SpawnWave(waves[currentWaveIndex]));
    }

    IEnumerator SpawnWave(Wave wave)
    {
        spawningWave = true;
        waitingForNextWave = false;
        startWaveButton.interactable = false;

        // Show current wave number
        waveInfoText.text = $"Wave {currentWaveIndex + 1}";

        for (int i = 0; i < wave.enemyCount; i++)
        {
            SpawnEnemy(wave.enemyPrefab);
            yield return new WaitForSeconds(1f / wave.spawnRate);
        }

        currentWaveIndex++;
        spawningWave = false;

        if (currentWaveIndex < waves.Length)
        {
            countdown = timeBetweenWaves;
            waitingForNextWave = true;
        }

        UpdateUI();
    }

    void SpawnEnemy(GameObject enemyPrefab)
    {
        Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
        GameObject newEnemy = Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);

        // Assign spline
        MoveAlongSpline moveScript = newEnemy.GetComponent<MoveAlongSpline>();
        if (moveScript != null && enemyPathSpline != null)
        {
            moveScript.Spline = enemyPathSpline;
        }
    }

    void UpdateUI()
    {
        if (currentWaveIndex < waves.Length)
        {
            waveInfoText.text = $"Wave {currentWaveIndex + 1}";
            startWaveButton.interactable = !spawningWave && countdown <= 0f;
        }
    }
}