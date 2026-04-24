using System;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class PostProcessControls : MonoBehaviour {
    public Volume postProcessVolume;
    public Bloom bloom;
    public LensDistortion lensDistortion;
    public WhiteBalance whiteBalance;
    // private

    private void Start()
    {
        postProcessVolume.profile.TryGet<Bloom>(out bloom);
        postProcessVolume.profile.TryGet<LensDistortion>(out lensDistortion);
        postProcessVolume.profile.TryGet<WhiteBalance>(out whiteBalance);
    }

    public void bloom_control(float value)
    {
        bloom.intensity.value = value;
    }

    public void distortion_control(float value)
    {
        lensDistortion.intensity.value = value;
    }

    public void temperature_control(float value)
    {
        whiteBalance.temperature.value = value;
    }
}
