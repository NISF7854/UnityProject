using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    public static AudioManager instance;

    [SerializeField] private AudioSource[] sfx;
    [SerializeField] private AudioSource[] bgm;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
            Destroy(instance.gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        PlayBGM(2);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlaySFX(int _index)
    {
        if(_index < sfx.Length)
        {
            sfx[_index].Play();
        }
    }

    public void StopSFX(int _index)
    {
        sfx[_index].Stop();
    }

    public void PlayBGM(int _index)
    {
        for(int i = 0; i < bgm.Length; i++) 
        {
            bgm[i].Stop();
        }
        if(_index < bgm.Length)
        {
            bgm[_index].Play();
        }
    }

    public void StopBGM()
    {
        for(int i = 0;i < bgm.Length;i++)
        {
            bgm[i].Stop();
        }
    }



} 
