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

    void Start() {
        if (watchCutscene) {
            StartCoroutine(PlayGame());
        }
        else {
            cutscene.SetActive(false);
        }
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            StartGame();
            enabled = false;
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
    }
}
