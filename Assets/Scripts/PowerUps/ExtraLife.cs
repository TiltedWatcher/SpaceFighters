using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtraLife : PowerUp{
    // Start is called before the first frame update
    [SerializeField] int amountOfExtraLifes;
    void Start(){
        
    }

    // Update is called once per frame
    void Update(){
        
    }

    public override void ProcessPowerUp(Player player) {
        this.player = player;
        giveExtraLife();
        Destroy(gameObject);
    }

    private void giveExtraLife() {
        Debug.Log("1up");
        player.giveExtraLifes(amountOfExtraLifes);
    }

}
