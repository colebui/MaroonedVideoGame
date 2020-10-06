using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaveSoundController : MonoBehaviour
{
    public bool inside;
    private string lastTouched = "";
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip caveAmbient;
    [SerializeField] float FADETIME = 5.0f;

    public void InnerWallTriggered(Collider other) {
        if (lastTouched == "outer") {
            GameObject.Find("/Managers/MinimapManager").GetComponent<minimapManager>().setToCave();
            PlayMusic();
        }
        lastTouched = "inner";
    }

    public void OuterWallTriggered(Collider other) {
        if (lastTouched == "inner") {
            StopMusic();
            GameObject.Find("/Managers/MinimapManager").GetComponent<minimapManager>().setToSurface();
        }
        lastTouched = "outer";
    }
    void PlayMusic() {
        Debug.Log("play music");
        if (!audioSource.isPlaying) {
            audioSource.PlayOneShot(caveAmbient, 0.4f);
        }
    }

    void StopMusic() {//cole fix later
        Debug.Log("stop music");
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
