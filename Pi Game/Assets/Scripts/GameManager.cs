using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

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

    IEnumerator PlayGame() {
        player.SetActive(false);
        gameplayCamera.SetActive(false);
        flood.SetActive(false);
        cutscene.SetActive(true);
        yield return new WaitForSeconds(cutsceneDuration);
        player.SetActive(true);
        gameplayCamera.SetActive(true);
        flood.SetActive(true);
        cutscene.SetActive(false);
    }
}
