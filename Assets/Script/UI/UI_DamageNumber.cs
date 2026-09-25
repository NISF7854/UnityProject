using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI_DamageNumber : MonoBehaviour
{
    public TextMeshProUGUI number;
   
    public float loseTimer;
    public float bornTime;

    public Rigidbody2D rb;


    private void Awake()
    {

        rb = GetComponent<Rigidbody2D>();   
    }

    private void Update()
    {
        //实现数字渐渐消失
        number.color = new Color(number.color.r,number.color.g,number.color.b, 1-((Time.time - bornTime) / loseTimer));

        if (Time.time >= bornTime + loseTimer)
        {
            Destroy(gameObject);
        }
    }



    public void Setup(float _value,Color _color,float _size)
    {
        bornTime = Time.time;
        number.text = _value.ToString();
        number.color = _color;  
        number.fontSize = _size;
        rb.velocity = new Vector2(Random.Range(-0.8f,0.8f),Random.Range(2f,3f));
    }
    public void Setup(float _value, Color _color, float _size,float x1,float x2,float y1,float y2 )
    {
        bornTime = Time.time;
        number.text = _value.ToString();
        number.color = _color;
        number.fontSize = _size;
        rb.velocity = new Vector2(Random.Range(x1, x2), Random.Range(y1, y2));
       
    }

}
