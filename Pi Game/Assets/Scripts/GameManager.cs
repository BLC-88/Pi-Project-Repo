using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    [SerializeField] GameObject playerScore;
    [SerializeField] GameObject blackScreenUI;
    [SerializeField] GameObject player;
    [SerializeField] GameObject gameplayCamera;
    [SerializeField] GameObject flood;
    [SerializeField] float cutsceneDuration;
    [SerializeField] bool watchCutscene;
    [SerializeField] GameObject cutscene;
    [SerializeField] GameObject skipCutsceneUI;
    bool playing;

    void Start() {
        if (watchCutscene) {
            StartCoroutine(PlayGame());
        }
        else {
            cutscene.SetActive(false);
        }
    }

    void Update() {
        if (!playing) {
            if (Input.GetKeyDown(KeyCode.Space)) {
                if (skipCutsceneUI.activeSelf) {
                    skipCutsceneUI.SetActive(false);
                    StartGame();
                    playing = true;
                }
                else {
                    skipCutsceneUI.SetActive(true);
                }
            }
        }
    }

    IEnumerator PlayGame() {
        gameplayCamera.SetActive(false);
        cutscene.SetActive(true);
        yield return new WaitForEndOfFrame();
        playerScore.SetActive(false);
        player.SetActive(false);
        flood.SetActive(false);
        blackScreenUI.SetActive(false);
        yield return new WaitForSeconds(cutsceneDuration);
        StartGame();
    }

    void StartGame() {
        playerScore.SetActive(true);
        player.SetActive(true);
        gameplayCamera.SetActive(true);
        flood.SetActive(true);
        cutscene.SetActive(false);
        skipCutsceneUI.SetActive(false);
        playing = true;
    }
}
