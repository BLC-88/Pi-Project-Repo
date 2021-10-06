using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonsOptions : MonoBehaviour
{
    public void PlayGame()
    {

        {
            StartCoroutine(ToMenu());
        }

        IEnumerator ToMenu()
        {
            yield return new WaitForSeconds(1.5f);
            SceneManager.LoadScene(3);
        }
    }

    public void MainMenu()
    {
        {
            StartCoroutine(ToMenu());
        }
        IEnumerator ToMenu()
        {
            yield return new WaitForSeconds(1.5f);
            SceneManager.LoadScene(1);
        }

    }
   
    public void CreditsScene()
    {
        {
            StartCoroutine(Tocreditscene());
        }

        IEnumerator Tocreditscene()
        {
            yield return new WaitForSeconds(1.5f);
            SceneManager.LoadScene(5);
        }
    }

    public void GameOver()
    {

        {
            StartCoroutine(ToScoreboardscene());
        }

        IEnumerator ToScoreboardscene()
        {
            yield return new WaitForSeconds(1.5f);
            SceneManager.LoadScene(4);
        }
    }

}
