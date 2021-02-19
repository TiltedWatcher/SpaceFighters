using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathing : MonoBehaviour{

    //parameters
    [SerializeField] ModifiableParameters gameParameters;
    [SerializeField] List<Transform> waypoints;
    int waypointIndex = 0;

    // Start is called before the first frame update
    void Start(){
        transform.position = waypoints[waypointIndex].transform.position;
    }

    // Update is called once per frame
    void Update() {
        Move();
    }

    private void Move() {
        if (waypointIndex <= waypoints.Count - 1) {
            var targetPosition = waypoints[waypointIndex].transform.position;
            var movementThisFrame = gameParameters.EnemyMoveSpeed * Time.deltaTime;
            transform.position = Vector2.MoveTowards
                (transform.position, targetPosition, movementThisFrame);

            if (transform.position == targetPosition) {
                waypointIndex++;
            }

        }
    }
}
