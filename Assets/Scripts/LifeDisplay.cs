using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LifeDisplay : MonoBehaviour{
    //cached references
    TextMeshProUGUI lifesText;
    Player player;

    // Start is called before the first frame update
    void Start() {
        lifesText = GetComponent<TextMeshProUGUI>();
        player = FindObjectOfType<Player>();

    }

    // Update is called once per frame
    void Update() {
        displayLifesRemaining();

    }

    private void displayLifesRemaining() {
        lifesText.text = player.getPlayerLifes().ToString();

    }
}
