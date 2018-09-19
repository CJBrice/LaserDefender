using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner1 : MonoBehaviour {

    [SerializeField] List<WaveConfig> waveConfigs;
    int startingWave = 0;

	// Use this for initialization
	void Start () {
        var currentWave = waveConfigs[startingWave];
        StartCoroutine(SpawnAllEnemiesInWave(currentWave));

	}

    private IEnumerator SpawnAllEnemiesInWave(WaveConfig waveConfigs)
    {
        for (int enemyCount = 0; enemyCount < waveConfigs.GetNumberOfEnemies(); enemyCount++)
        {
            Instantiate(
                waveConfigs.GetEnemyPrefab(),
                waveConfigs.GetWaypoints()[0].transform.position,
                Quaternion.identity);
            yield return new WaitForSeconds(waveConfigs.GetTimeBetweenSpawns());
        }
    }
}