using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour{

    //parameters
    [SerializeField] List<EnemyWaveConfig> WaveConfigs;
    [SerializeField] int firstWaveIndex = 0;
    [SerializeField] bool looping = false;
    [SerializeField] float secondsBetweenWaves;
    [SerializeField] bool spawnerIsActive = true;


    // Start is called before the first frame update
    IEnumerator Start(){

        if (spawnerIsActive) {
            do {
                yield return StartCoroutine(spawnAllWaves());
                //yield return StartCoroutine(waitXSeconds(secondsBetweenWaves));
            } while (looping); 
        }
           
    }
    private IEnumerator spawnAllWaves() {
        for (int i = firstWaveIndex; i < WaveConfigs.Count; i++) {
            var currentWave = WaveConfigs[i];
            //Calling overloaded method depending on whether there are multiple enemies randomized or not
            if (currentWave.enemiesAreRandomized()) {
                yield return StartCoroutine(SpawnAllEnemiesInWave(currentWave, true));
            } else {
                yield return StartCoroutine(SpawnAllEnemiesInWave(currentWave));
            }
            yield return new WaitForSeconds(secondsBetweenWaves);
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

    private IEnumerator SpawnAllEnemiesInWave(EnemyWaveConfig waveConfig, bool random) {
        for (int enemyCount = 0; enemyCount < waveConfig.getNumberOfEnemies(); enemyCount++) {

            int randomEnemyIndex = UnityEngine.Random.Range(0, waveConfig.getNumberOfEnemyPrefabs());

            var newEnemy = Instantiate(
                waveConfig.getEnemyPrefab(randomEnemyIndex),
                waveConfig.getWaypointsForPath()[0].transform.position,
                Quaternion.identity);
            newEnemy.GetComponent<EnemyPathing>().setWaveConfig(waveConfig);

            yield return new WaitForSeconds(waveConfig.getTimeBetweenSpawns());
        }
    }


}
