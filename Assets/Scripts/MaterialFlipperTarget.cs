using System;
using UnityEngine;

public class MaterialFlipperTarget : MonoBehaviour {
    public MeshRenderer meshRenderer;

    private void Awake()
    {
        make_red();
    }

    public void make_red()
    {
        meshRenderer.material.color = Color.red;
    }
    
    public void make_orange()
    {
        meshRenderer.material.color = Color.orange;
    }
    
    public void make_yellow()
    {
        meshRenderer.material.color = Color.yellow;
    }
    
    public void make_green()
    {
        meshRenderer.material.color = Color.green;
    }
    
    public void make_blue()
    {
        meshRenderer.material.color = Color.blue;
    }
    
    public void make_purple()
    {
        meshRenderer.material.color = Color.purple;
    }

    public void metalness_slider(float value)
    {
        meshRenderer.material.SetFloat("_Metallic", value);
    }
    
    public void smoothness_slider(float value)
    {
        meshRenderer.material.SetFloat("_Smoothness", value);
    }
}
