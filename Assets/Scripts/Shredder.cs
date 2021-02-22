using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shredder : MonoBehaviour{
    [SerializeField] bool destroysEnemies;
    // Start is called before the first frame update
    void Start(){
        
    }

    void OnTriggerEnter2D(Collider2D collider) {
        //TODO make sure trigger object is not enemy
        if (collider.tag == "Laser") {
            Destroy(collider.gameObject);
        } else if (destroysEnemies) {
            Destroy(collider.gameObject);
        }
    
    }


}
