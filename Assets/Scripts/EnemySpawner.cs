using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour{

    //parameters
    [SerializeField] List<EnemyWaveConfig> WaveConfigs;
    [SerializeField] int firstWaveIndex = 0;


    // Start is called before the first frame update
    void Start(){
        StartCoroutine(spawnAllWaves());
    }
    private IEnumerator spawnAllWaves() {
        for (int i = firstWaveIndex; i < WaveConfigs.Count; i++) {
            var currentWave = WaveConfigs[i];
            yield return StartCoroutine(SpawnAllEnemiesInWave(currentWave));

        }
    }
    private IEnumerator SpawnAllEnemiesInWave(EnemyWaveConfig waveConfig) {
        for (int enemyCount = 0; enemyCount < waveConfig.getNumberOfEnemies(); enemyCount++) {
            var newEnemy = Instantiate(
                waveConfig.getEnemyPrefab(),
                waveConfig.getWaypointsForPath()[0].transform.position,
                Quaternion.identity);
            newEnemy.GetComponent<EnemyPathing>().setWaveConfig(waveConfig);

            yield return new WaitForSeconds(waveConfig.getTimeBetweenSpawns()); 
        }
    }

}
