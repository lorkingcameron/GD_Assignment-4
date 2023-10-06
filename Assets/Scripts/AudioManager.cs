using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioClip backgroundIntro;
    public AudioClip backgroundNormal;
    private AudioSource audioSource;

    private void Start() {
        audioSource = GetComponent<AudioSource>();
        PlayAudio(backgroundIntro);
    }

    private void Update() {
        if (!audioSource.isPlaying) {
            PlayAudio(backgroundNormal);
        }
    }

    private void PlayAudio(AudioClip clip) {
        audioSource.clip = clip;
        audioSource.Play();
    }
}