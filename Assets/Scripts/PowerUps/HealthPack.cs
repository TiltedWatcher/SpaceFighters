using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPack : PowerUp{

    [SerializeField] int restoreHealthAmount = 50;
    // Start is called before the first frame update


    private void OnTriggerEnter2D(Collider2D collision) {
        
    }

    void Start(){
        StartCoroutine(startDespawnTimer());
    }

    // Update is called once per frame
    void Update(){
        
    }

    public override void ProcessPowerUp(Player player) {
        this.player = player;
        healPlayer();
        Destroy(gameObject);
     }

    public void healPlayer() {
        player.healPlayer(restoreHealthAmount);
    
    }
}
