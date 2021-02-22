using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour{

    [SerializeField] Canvas pauseMenu;
    [SerializeField] float timeScale;
    bool isPaused = false;
    void Start(){
        pauseMenu.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update(){
        checkInput();
        pauseGame(isPaused);
        timeScale = Time.timeScale;
    }

    private void checkInput() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            isPaused = !isPaused;
            pauseGame(isPaused);
        }
    }

    public void pauseGame(bool isPaused) {

        switch (isPaused) {

            case true:
                pauseMenu.gameObject.SetActive(isPaused);
                Time.timeScale = 0;
                this.isPaused = isPaused;
                
                break;

            case false:
                pauseMenu.gameObject.SetActive(isPaused);
                Time.timeScale = 1;
                this.isPaused = isPaused;
                break;
        
        }
    }

}
