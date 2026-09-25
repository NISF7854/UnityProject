using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_FadeScreen : MonoBehaviour
{
    Animator ain;

    // Start is called before the first frame update
    void Start()
    {
        ain = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FadeIn()
    {
        ain.SetTrigger("FadeIn");
    }

    public void FadeOut()
    {
        ain.SetTrigger("FadeOut");
    }
}
