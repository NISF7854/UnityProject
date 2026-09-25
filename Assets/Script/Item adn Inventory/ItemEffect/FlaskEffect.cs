using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlaskEffect : ItemEffect
{

    public int flaskLevel;
    public int amount; 

    private void Awake()
    {
        amount = 3;
        flaskLevel = 1;
    }

}
