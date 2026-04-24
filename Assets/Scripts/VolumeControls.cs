using System;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeControls : MonoBehaviour {
    public Slider volumeSlider;
    public Toggle volumeToggle;
    public AudioMixer mixer;
    public AudioSource audioSource;
    
    public void Awake() {
        var manager = FindObjectsByType<SceneManager>(FindObjectsSortMode.None)[0];
        audioSource = manager.backgroundMusic;

        mixer.GetFloat("MasterVolume", out var volume);
        if(volumeToggle.isOn)
            audioSource.Play();
        else audioSource.Pause();
    }

    public void toggle_playing(bool enable) {
        if(audioSource.isPlaying)
            audioSource.Pause();
        else
            audioSource.Play();
    }
    
    public void volume_control(float volume)
    {
        mixer.SetFloat("MasterVolume", volume);
    }

}
