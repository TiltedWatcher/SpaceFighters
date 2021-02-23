using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreDisplay : MonoBehaviour{

    //parameters
    [SerializeField] int numberOfScoreDigits = 8;

    //cached references
    TextMeshProUGUI scoreText;
    GameSession currentGameSession;

    // Start is called before the first frame update
    void Start(){
        currentGameSession = FindObjectOfType<GameSession>();
        scoreText = GetComponent<TextMeshProUGUI>();
        Debug.Log(scoreText.name);
    }

    // Update is called once per frame
    void Update(){
        scoreText.text = currentGameSession.getScore().ToString("D" + numberOfScoreDigits);
    }
}
