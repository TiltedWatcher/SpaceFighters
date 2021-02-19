using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ModifiableParameters : MonoBehaviour{

    //game parameters
    [SerializeField] float playerMoveSpeed;
    [SerializeField] float projectileSpeedPlayer = 10f;
    [SerializeField] float projectileFireRecoveryTime = 0.1f;
    [SerializeField] float playSpacePaddingY;
    [SerializeField] float playSpacePaddingX;

    public float PlayerMoveSpeed {
        get => playerMoveSpeed;
        set => playerMoveSpeed = value;
    }
 
    public float PlaySpacePaddingX {
        get => playSpacePaddingX;
        set => playSpacePaddingX = value;
    }
    public float PlaySpacePaddingY {
        get => playSpacePaddingY;
        set => playSpacePaddingY = value;
    }
    public float ProjectileSpeedPlayer {
        get => projectileSpeedPlayer;
        set => projectileSpeedPlayer = value;
    }
    public float ProjectileFireRecoveryTime {
        get => projectileFireRecoveryTime;
        set => projectileFireRecoveryTime = value;
    }


    // Start is called before the first frame update
    void Start(){
        
    }

    // Update is called once per frame
    void Update(){
        
    }
}
