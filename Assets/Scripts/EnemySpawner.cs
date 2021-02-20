using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour{

    //parameters
    [SerializeField] List<EnemyWaveConfig> WaveConfigs;
    int firstWaveIndex = 0;


    // Start is called before the first frame update
    void Start(){
        var currentWave = WaveConfigs[firstWaveIndex];
        StartCoroutine(SpawnAllEnemiesInWave(currentWave));
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
