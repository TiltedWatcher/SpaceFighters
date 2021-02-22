using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ModifiableParameters : MonoBehaviour{

    //game parameters
    [Range(0.1f, 20f)] [SerializeField] float timescale = 1;
    bool paused = false;



    // Start is called before the first frame update
    void Start(){
        
    }

    // Update is called once per frame
    void Update(){
        if (Time.timeScale == 0) {
            paused = true;
        } else {
            paused = false;
        }

        if (!paused) {
            Time.timeScale = timescale;
        }
        
    }
}
