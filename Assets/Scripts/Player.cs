using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour{


    [SerializeField] ModifiableParameters gameParameters;

    // Start is called before the first frame update
    void Start(){
        
    }

    // Update is called once per frame
    void Update(){
        
    }

    private void move() {
        var newXPos = transform.position.x + deltaX;
        var deltaX = Input.GetAxis();
        
    }
}
