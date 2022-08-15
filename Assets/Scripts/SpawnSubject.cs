using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnSubject : MonoBehaviour
{
    [Header("Subjects")]
    [Range(0f, 1f)]
    [SerializeField] private float _subjectSpawnChance;
    [SerializeField] private SubjectInfo[] _subjectArray;

    private float _randX;
    private Vector2 _whereToSpawn;

    void Start()
    {
        InvokeRepeating("Spawn", 2.0f, 1.2f);
    }

    private void Update()
    {
        if (GameManager.Instance.IsStarted)
            return;
        Time.timeScale = 0;
    }

    private void OnValidate()
    {
        if (_subjectArray == null)
            return;

        foreach (SubjectInfo subjectInfo in _subjectArray)
        {
            subjectInfo.UpdateName();
        }
    }

    private void Spawn()
    {
        if (_subjectArray == null || _subjectArray.Length == 0)
            return;

        float random = Random.Range(0f, 1f);
        if (random > _subjectSpawnChance)
            return;
        int chanceSum = 0;

        foreach (SubjectInfo subjectInfo in _subjectArray)
            chanceSum += subjectInfo.SpawnChance;


        int randomChance = Random.Range(0, chanceSum);
        int currentChance = 0;
        int currentIndex = 0;

        for (int i = 0; i < _subjectArray.Length; i++)
        {
            SubjectInfo subject = _subjectArray[i];
            currentChance += subject.SpawnChance;

            if (currentChance >= randomChance)
            {
                currentIndex = i;
                break;
            }
        }

        _randX = Random.Range(-12f, 12f);
        _whereToSpawn = new Vector2(_randX, transform.position.y);

        Subject spawnSubject = _subjectArray[currentIndex].SubjectPrefab;
        Instantiate(spawnSubject, _whereToSpawn, Quaternion.identity);
    }
}