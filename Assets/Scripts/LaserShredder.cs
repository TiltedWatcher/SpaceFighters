using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserShredder : MonoBehaviour{
    // Start is called before the first frame update
    void Start(){
        
    }

    void OnTriggerEnter2D(Collider2D collider) {
        //TODO make sure trigger object is not enemy
        if(true){
            Destroy(collider.gameObject);
        }
    
    }
}
