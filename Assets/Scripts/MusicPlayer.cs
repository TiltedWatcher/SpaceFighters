using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour{

    //Parameters
    [SerializeField] AudioClip[] generalMusic;
    [SerializeField] AudioClip[] bossMusic;
    [SerializeField] [Range(0,1)] float volume = 0.1f;

    //states
    bool bossBattleHapening;
    int currentIndex = 0;

    //cached
    AudioSource audioPlayer;

    // Start is called before the first frame update
    void Awake(){
        SetUpSingleton();
        audioPlayer = GetComponent<AudioSource>();
        audioPlayer.volume = volume;
        audioPlayer.loop = false;
        audioPlayer.clip = generalMusic[currentIndex];
        audioPlayer.Play();
        
    }

    private void SetUpSingleton() {
        if (FindObjectsOfType(GetType()).Length > 1) {
            Destroy(gameObject);
        } else {
            DontDestroyOnLoad(gameObject);
        }
    }

    // Update is called once per frame
    void Update(){
        if (!bossBattleHapening) {
            switchTracks();
        }
        
        
    }

    public IEnumerator bossTrack() {
        bossBattleHapening = true;
        audioPlayer.Stop();
        audioPlayer.clip = bossMusic[0];
        audioPlayer.Play();
        yield return new WaitForSeconds(bossMusic[0].length);
        audioPlayer.loop = true;
        audioPlayer.clip = bossMusic[1];
        audioPlayer.Play();
        yield return new WaitWhile(() => bossBattleHapening);
        Debug.Log("Swapping off the boss track");
        audioPlayer.loop = false;
        audioPlayer.Stop();
        currentIndex = UnityEngine.Random.Range(1, generalMusic.Length);
        audioPlayer.clip = generalMusic[currentIndex];
        audioPlayer.Play();
    }

    public void startBossTrack() {
        StartCoroutine(bossTrack());
    }

    private void switchTracks() {
        if (!audioPlayer.isPlaying) {
            currentIndex = UnityEngine.Random.Range(1, generalMusic.Length);
            audioPlayer.clip = generalMusic[currentIndex];
            audioPlayer.Play();
        }
    }

    public bool BossBattleHappening {
        get => bossBattleHapening;
        set => bossBattleHapening = value;
    }

}
