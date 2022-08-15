using System;
using UnityEngine;

[Serializable]
public class SubjectInfo
{
    [HideInInspector]
    public string name;
    public Subject SubjectPrefab;
    public int SpawnChance;

    public void UpdateName()
    {
        name = SubjectPrefab == null ? string.Empty : SubjectPrefab.name;
    }
}