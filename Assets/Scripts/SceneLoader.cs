using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour{
    // Start is called before the first frame update
    [SerializeField] float gameOverDelay = 1.5f;

    public void loadScene(int sceneIndex) {
        SceneManager.LoadScene(sceneIndex);
    }

    public void loadScene(string sceneName) {
        SceneManager.LoadScene(sceneName);
    }

    public void reloadScene() {
        if (FindObjectsOfType<GameSession>().Length == 1) {
            FindObjectOfType<GameSession>().resetScore();
        }
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void loadMainMenu() {
        if (FindObjectsOfType<GameSession>().Length == 1) {
            Destroy(FindObjectOfType<GameSession>(), 0.1f);
        }
        SceneManager.LoadScene(0);
    }

    public void quitGame() {
        Application.Quit();
    }

    public void GameOver() {
        StartCoroutine(WaitAndLoad());
        
    }

    IEnumerator WaitAndLoad() {
        FindObjectOfType<MusicPlayer>().BossBattleHappening = false;
        yield return new WaitForSeconds(gameOverDelay);
        SceneManager.LoadScene("GameOver");
    }
}
