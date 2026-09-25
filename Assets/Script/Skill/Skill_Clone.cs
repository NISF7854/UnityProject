using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_Clone : Skill
{
    [SerializeField] private GameObject clonePrefab;
    [SerializeField] private float cloneDuration;
    [Space]
    [SerializeField] private bool canCloneAttack = true;

    public void CreateClone(Transform trans)
    {
        GameObject newClone = Instantiate(clonePrefab);
        newClone.GetComponent<SkillCloneController>().SetupClone(trans, cloneDuration, canCloneAttack);
    }
}
