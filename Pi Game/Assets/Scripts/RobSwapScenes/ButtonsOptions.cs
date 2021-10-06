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
            yield return new WaitForSeconds(2f);
            SceneManager.LoadScene(1);
        }
    }


    public void Cutscene()
    {
        {
            StartCoroutine(ToMenu());
        }
        IEnumerator ToMenu()
        {
            yield return new WaitForSeconds(1.5f);
            SceneManager.LoadScene(2);
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
            SceneManager.LoadScene(0);
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
            SceneManager.LoadScene(4);
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
            SceneManager.LoadScene(3);
        }
    }

}
