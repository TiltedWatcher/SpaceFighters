using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour{
    // Start is called before the first frame update

    public void loadScene(int sceneIndex) {
        SceneManager.LoadScene(sceneIndex);
    }

    public void loadScene(string sceneName) {
        SceneManager.LoadScene(sceneName);
    }

    public void reloadScene() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void loadMainMenu() {
        SceneManager.LoadScene(0);
    }

    public void quitGame() {
        Application.Quit();
    }

    public void GameOver() {
        SceneManager.LoadScene("GameOver");
    }
}
