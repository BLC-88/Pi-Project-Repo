using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RatAnimations : MonoBehaviour {

    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip footstep;
    [SerializeField] AudioClip jump;
    [SerializeField] AudioClip land;

    [HideInInspector] public Animator anim;

    void Awake() {
        anim = GetComponent<Animator>();
    }

    public void Footstep() {
        audioSource.PlayOneShot(footstep);
    }

    public void Jump() {
        audioSource.PlayOneShot(jump);
    }

    public void Land() {
        audioSource.PlayOneShot(land);
    }
}
