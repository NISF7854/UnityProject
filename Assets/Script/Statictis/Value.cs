using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public enum ModifierType
{
    Add,
    Multi
}


[System.Serializable]

public class Value
{
    [SerializeField] private float baseValue;

    public List<float> modifiersAdd;
    public List<float> modifiersMulti;

    public float GetValue()
    {
        float finalValue = baseValue;

        foreach (var modifier in modifiersAdd)
        {
            finalValue += modifier;
        }
        float totalModifiers = 1.0f;
        foreach (var modifier in modifiersMulti)
        {
            totalModifiers += modifier;
        }

        finalValue *= totalModifiers;

        return finalValue;
    }

    public void SetValue(float value)
    {
        baseValue = value;
    }
    public float GetBaseValue()
    { 
        return baseValue;
    }

    public void AddModifier(float modifier,ModifierType type)
    {
        if(type == ModifierType.Add)
            modifiersAdd.Add(modifier);

        if(type == ModifierType.Multi)
            modifiersMulti.Add(modifier);
    }

    public void RemoveModifier(float modifier,ModifierType type)
    {
        if(type == ModifierType.Add)
            modifiersAdd.Remove(modifier);

        if(type==ModifierType.Multi)
            modifiersMulti.Remove(modifier);
    }
}
