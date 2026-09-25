using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_HealthFlash : MonoBehaviour
{
    public RectTransform rectTransform;
    public Image image;

    float timer;


    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        image = GetComponent<Image>();
        timer = 0.15f;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer > 0)
        {
            float newHeight = 1f + (0.15f - timer) * 10f;
            float newWidth = 1f - (0.15f - timer) * 4f;
            float newa = 1f - (0.15f - timer) * 1.5f;
            rectTransform.localScale = new Vector2(newWidth, newHeight);
            image.color = new Color(image.color.r, image.color.g, image.color.b, newa);

        }
        else
            Destroy(gameObject);

        
        

    }

    public void SetUp(float _startPos,float _length)
    {
        rectTransform = GetComponent<RectTransform>();

        float PosX = _startPos * rectTransform.sizeDelta.x;
        float length = _length * rectTransform.sizeDelta.x;



        rectTransform.anchoredPosition = new Vector3(PosX, 0, 0);
        rectTransform.sizeDelta = new Vector2(length, rectTransform.sizeDelta.y);
        rectTransform.rotation = Quaternion.Euler(0,0,0);



    }

    
}
