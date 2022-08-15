using System;
using UnityEngine;

public class GameManager : SingletonMonoBehaviour<GameManager>
{
    #region Variables

    private bool _isGameOver;
    private int _lifes = 3;

    [Header("Subjects")]
    [Range(0f, 1f)]
    [SerializeField] private float _subjectSpawnChance;
    [SerializeField] private SubjectInfo[] _subjectArray;

    #endregion


    #region Properties

    public int Lifes { get; private set; }
    public bool IsStarted { get; private set; }

    #endregion


    #region Events

    public event Action<int> OnLifeChanged;
    public event Action<bool> OnGameOver;

    #endregion


    #region Unity lifecycle

    protected override void Awake()
    {
        base.Awake();
        Lifes = _lifes;
        IsStarted = true;
    }

    #endregion


    #region Public methods

    public void RestartGame()
    {
        SceneLoader.LoadScene(Objects.GameScene);
    }

    public void CheckEdible(LayerMask layerMask)
    {
        if (layerMask.ToString() != Layers.Food)
        {
        }
    }

    public void GameOver()
    {
        Lifes--;

        if (Lifes != 0)
            OnLifeChanged?.Invoke(Lifes);
        
        else
        {
            Lifes = _lifes;
            _isGameOver = true;
            IsStarted = false;
            OnGameOver?.Invoke(true);
        }
    }

    public void ExitGame()
    {
        UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }

    public void ChangeLife(int num)
    {
        Lifes += num;
        OnLifeChanged?.Invoke(Lifes);
    }
    #endregion
}