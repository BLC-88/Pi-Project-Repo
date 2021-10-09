using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RatAnimations : MonoBehaviour {

    [SerializeField] AudioSource audioSource;
    [SerializeField] Vector2 audioPitchRange;
    [SerializeField] AudioClip[] footstep;
    [SerializeField] AudioClip jump;
    [SerializeField] AudioClip land;

    [HideInInspector] public Animator anim;

    void Awake() {
        anim = GetComponent<Animator>();
    }

    public void Footstep() {
        audioSource.pitch = Random.Range(audioPitchRange.x, audioPitchRange.y);
        int rand = Random.Range(0, footstep.Length - 1);
        audioSource.PlayOneShot(footstep[rand]);
    }

    public void Jump() {
        audioSource.pitch = Random.Range(audioPitchRange.x, audioPitchRange.y);
        audioSource.PlayOneShot(jump);
    }

    public void Land() {
        audioSource.pitch = Random.Range(audioPitchRange.x, audioPitchRange.y);
        audioSource.PlayOneShot(land);
    }
}
