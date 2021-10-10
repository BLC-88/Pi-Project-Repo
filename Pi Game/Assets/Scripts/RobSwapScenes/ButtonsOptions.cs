using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonsOptions : MonoBehaviour
{
    public void PlayGame()
    {
        StartCoroutine(LoadScene("EndlessRunner", 2f));
    }

    public void MainMenu()
    {
        StartCoroutine(LoadScene("MainMenu", 0.1f));
    }
   
    public void CreditsScene()
    {
        StartCoroutine(LoadScene("Credits", 0.1f));
    }

    public void GameOver()
    {
        StartCoroutine(LoadScene("GameOver", 0.1f));
    }

    IEnumerator LoadScene(string sceneName, float delay) {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(sceneName);
    }
}
