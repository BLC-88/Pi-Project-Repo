using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroToMainMenu : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(ToMenu());
    }

    IEnumerator ToMenu()
    {
        yield return new WaitForSeconds(7);
        SceneManager.LoadScene(1);
    }

}
