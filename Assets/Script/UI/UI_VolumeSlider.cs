using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class UI_VolumeSlider : MonoBehaviour
{
    [SerializeField] Slider slider;
    [SerializeField] AudioMixer audioMixer;

    public float multiplier;
    public string par;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeVolum(float _value)
    {
        float value = slider.value;
        audioMixer.SetFloat(par, Mathf.Log10(_value) * multiplier);
    }

}
