using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "EnemyWaveConfig")]
public class EnemyWaveConfig : ScriptableObject{

    [SerializeField] GameObject[] enemyPrefabs;
    [SerializeField] GameObject pathPrefab;
    [SerializeField] float timeBetweenSpawns = 0.5f;
    [SerializeField] float spawnTimerRandomizer = 0.3f;
    [SerializeField] int numberOfEnemiesInWave;
    [SerializeField] bool randomizeEnemies;

    [SerializeField] bool isBossWave;

    public GameObject getEnemyPrefab() {
        return enemyPrefabs[0];
    }

    public GameObject getEnemyPrefab(int index) {
        if (index < enemyPrefabs.Length && index >= 0) {
            return enemyPrefabs[index];
        } else {
            Debug.LogError("Error: Requested Enemy does not exist in this array. Problem occured in: " + this.name + "\n" +"Index tried: " + index);
            return enemyPrefabs[0];
        }
    }

    public List<Transform> getWaypointsForPath() {
        var waveWayPoints = new List<Transform>();
        foreach (Transform child in pathPrefab.transform) {
            waveWayPoints.Add(child);
        }
        return waveWayPoints ;
    }


    public float getTimeBetweenSpawns() {
        return timeBetweenSpawns;
    }

    public float getTimeRandomizer() {
        return spawnTimerRandomizer;
    }

    public float getNumberOfEnemies() {
        return numberOfEnemiesInWave;
    }


    public bool enemiesAreRandomized() {
        return randomizeEnemies;
    }

    public int getNumberOfEnemyPrefabs() {
        return enemyPrefabs.Length;
    }

    public bool IsBossWave() {
        return isBossWave;
    }

}
