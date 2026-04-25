using System;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAttributes : MonoBehaviour
{
    [SerializeField] private List<AttributeData> _attributes = new();

    public event Action<AttributeType> AttributeChanged;
    public event Action<AttributeType, int> AttributeUpgraded;

    public int GetLevel(AttributeType type)
    {
        AttributeData data = GetData(type);
        return data != null ? data.level : 0;
    }

    public int GetCurrentExperience(AttributeType type)
    {
        AttributeData data = GetData(type);
        return data != null ? data.currentExperience : 0;
    }

    public int GetExperienceToUpgrade(AttributeType type)
    {
        AttributeData data = GetData(type);
        return data != null ? data.experienceToUpgrade : 0;
    }

    public void AddExperience(AttributeType type)
    {
        int amount = GetData(type).addedExperience;

        AttributeData data = GetData(type);
        if (data == null)
            return;

        data.currentExperience += amount;
        AttributeChanged?.Invoke(type);
    }

    public void TryUpgrade(AttributeType type)
    {
        AttributeData data = GetData(type);
        if (data == null)
            return;

        bool upgraded = false;

        while (data.currentExperience >= data.experienceToUpgrade)
        {
            data.currentExperience -= data.experienceToUpgrade;
            data.level++;
            data.experienceToUpgrade = Mathf.Max(1, Mathf.RoundToInt(data.experienceToUpgrade * data.upgradeMultiplier));
            upgraded = true;
        }

        if (upgraded)
        {
            AttributeChanged?.Invoke(type);
            AttributeUpgraded?.Invoke(type, data.level);
        }
    }

    private AttributeData GetData(AttributeType type)
    {
        return _attributes.Find(a => a.type == type);
    }
}