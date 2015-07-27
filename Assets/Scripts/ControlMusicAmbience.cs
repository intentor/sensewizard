using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class ControlMusicAmbience : MonoBehaviour {
    private AudioSource audioSource;

    public bool isPlaying = false;
    public AudioClip[] musicClips;

	// Use this for initialization
	void Start () {
        this.audioSource = this.GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
        if (this.isPlaying) {
            if (!this.audioSource.isPlaying && (musicClips.Length > 0)) {
                AudioClip clip = musicClips[Random.Range(0, musicClips.Length)];
                this.audioSource.PlayOneShot(clip);
                isPlaying = false;
                Invoke("rePlay", clip.length);
            }
        }
	}

    void rePlay() {
        this.isPlaying = true;
    }
}
