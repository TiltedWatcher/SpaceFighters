using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class HealthDisplay : MonoBehaviour{

    //cached references
    TextMeshProUGUI healthText;
    Player player;

    // Start is called before the first frame update
    void Start(){
        healthText = GetComponent<TextMeshProUGUI>();
        player = FindObjectOfType<Player>();
        
    }

    // Update is called once per frame
    void Update(){
        displayHealth();
        
    }

    private void displayHealth() {
        if (player.getCurrentHealth() >= 0) {
            healthText.text = ((int) player.getCurrentHealth()).ToString("D3");
        } else {
            healthText.text = "000";
        }
        
    }
}
