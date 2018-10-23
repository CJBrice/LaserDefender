using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    [SerializeField] List<WaveConfig> waveConfigs;
    [SerializeField] int startingWave = 0;
    [SerializeField] bool looping = false;

    // Use this for initialization
    IEnumerator Start ()
    {
        do
        {
            yield return StartCoroutine(SpawnAllWaves());
        }
        while (looping);
        
    }

    private IEnumerator SpawnAllWaves()
    {
        for (int waveIndex = startingWave; waveIndex < waveConfigs.Count; waveIndex++)
        {
            var currentWave = waveConfigs[waveIndex];
            yield return StartCoroutine(SpawnAllEnemiesInWave(currentWave));
        }
    }

    private IEnumerator SpawnAllEnemiesInWave(WaveConfig waveConfigs)
    {
        for (int enemyCount = 0; enemyCount < waveConfigs.GetNumberOfEnemies(); enemyCount++)
        {
            var newEnemy = Instantiate(
                waveConfigs.GetEnemyPrefab(),
                waveConfigs.GetWaypoints()[0].transform.position,
                Quaternion.identity);
            newEnemy.GetComponent<EnemyPathing>().SetWaveConfig(waveConfigs);
            yield return new WaitForSeconds(waveConfigs.GetTimeBetweenSpawns());
        }
    }
}