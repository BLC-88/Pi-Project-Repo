using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayOnEscButton : MonoBehaviour
{
    public AudioSource EscButton;

    private void Start()
    {

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            EscButton.Play();
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

        }
    }
}
