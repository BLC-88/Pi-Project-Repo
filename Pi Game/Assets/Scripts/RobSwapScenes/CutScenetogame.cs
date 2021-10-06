using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CutScenetogame : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(ToMenu());
    }

    IEnumerator ToMenu()
    {
        yield return new WaitForSeconds(12.5f);
        SceneManager.LoadScene(2);
    }


}
