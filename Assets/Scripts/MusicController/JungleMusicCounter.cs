using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JungleMusicCounter : MonoBehaviour
{
    public bool inside;
    public int colliderCount;
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip jungleAmbient;
    [SerializeField] float FADETIME = 5.0f;

    public void Enter(Collider other) {
            colliderCount += 1;
            UpdateState();
    }

    public void Exit(Collider other) {
            colliderCount -= 1;
            UpdateState();
    }

    void UpdateState() {
        Debug.Log("colliderCount: " + colliderCount);
        if (colliderCount == 0) {
            inside = false;
            StopMusic();
        }
        else if (colliderCount > 0 && !audioSource.isPlaying) { 
            inside = true;
            PlayMusic();
        }
    }

    void PlayMusic() {
        if (!audioSource.isPlaying) {
            audioSource.PlayOneShot(jungleAmbient, 1.0f);
        }
    }

    void StopMusic() {//cole fix later
        if (audioSource.isPlaying) {
            float startVolume = audioSource.volume;
            while (audioSource.volume > 0) {
                audioSource.volume -= startVolume * Time.deltaTime / FADETIME;
            }
            audioSource.Stop();
            audioSource.volume = startVolume;
        }
    }
}
