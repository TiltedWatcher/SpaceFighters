using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ModifiableParameters : MonoBehaviour{

    //game parameters
    [SerializeField] float playerMoveSpeed;
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


    // Start is called before the first frame update
    void Start(){
        
    }

    // Update is called once per frame
    void Update(){
        
    }
}
