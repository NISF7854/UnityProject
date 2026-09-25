using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThunderStrikeAniEven : MonoBehaviour
{
    private ThunderStrikeController thunderStrikeController;

    private void Awake()
    {
        thunderStrikeController = GetComponentInParent<ThunderStrikeController>();
    }

    public void DoDamage()
    {

    }

    public void Destory() 
    {
        thunderStrikeController.DestoryThis();
    }
}
