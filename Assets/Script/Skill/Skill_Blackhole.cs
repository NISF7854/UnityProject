using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_Blackhole : Skill
{
    [SerializeField] private GameObject blackHolePrefab;
    [SerializeField] private float blackHoleRadius;
    [SerializeField] private float growSpeed;
   
    public void CreatBlackHole()
    {
        GameObject blackhole = Instantiate(blackHolePrefab);
        blackhole.GetComponent<SkillBlackholeController>().SetupBlackHole(player.transform, blackHoleRadius, growSpeed);
    }


}
