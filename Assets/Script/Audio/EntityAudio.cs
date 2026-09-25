using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityAudio : MonoBehaviour
{
    [SerializeField] private AudioSource[] sfx;

    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    public void PlaySFX(int _index)
    {
        if (_index < sfx.Length)
            sfx[_index].PlayOneShot(sfx[_index].clip);
    }

    public void StopSFX(int _index)
    {
        if (_index < sfx.Length)
            sfx[_index].Stop();
    }
}
