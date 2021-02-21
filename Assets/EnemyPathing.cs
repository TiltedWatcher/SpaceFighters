using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathing : MonoBehaviour{

    //parameters
    

    //cached variables
    List<Transform> waypoints;
    int waypointIndex = 0;
    float speed;
    EnemyWaveConfig waveConfig; //assigned by the Spawner right after creation
    
    
    // Start is called before the first frame update
    void Start(){
        waypoints = waveConfig.getWaypointsForPath();
        transform.position = waypoints[waypointIndex].transform.position;
        speed = gameObject.GetComponent<Enemy>().Speed;
    }

    // Update is called once per frame
    void Update() {
        Move();
    }

    private void Move() {
        if (waypointIndex <= waypoints.Count - 1) {
            var targetPosition = waypoints[waypointIndex].transform.position;
            var movementThisFrame = speed * Time.deltaTime;
            transform.position = Vector2.MoveTowards
                (transform.position, targetPosition, movementThisFrame);

            if (transform.position == targetPosition) {
                waypointIndex++;
            }

        }
    }

    public void setWaveConfig(EnemyWaveConfig config) {
        waveConfig = config;
    }

}
