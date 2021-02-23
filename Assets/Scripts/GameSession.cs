using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameSession : MonoBehaviour{

    //Parameters:
    [SerializeField] int deathPenaltyToScore;

    int currentScore;

    // Start is called before the first frame update
    void Awake(){
        createSimpleton();
    }

    private void Start() {
        currentScore = 0;
    }

    // Update is called once per frame
    void Update(){
        
    }

    void createSimpleton() {
        if (FindObjectsOfType(GetType()).Length > 1) {
            Destroy(gameObject);
        } else {
            DontDestroyOnLoad(gameObject);
        }
    }

    public void enemyEscaped(int enemyValue) {
        currentScore -= enemyValue;
    }

    public void enemyKilled(int enemyValue) {
        currentScore += enemyValue;
    }

    public void resetScore() {
        currentScore = 0;
    }

    public int getScore() {
        return currentScore;
    }
}
