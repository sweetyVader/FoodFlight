using UnityEngine;

public class LifeChanged : Subject
{
    [Header(nameof(LifeChanged))]
    [Range(-1f, 1f)]
    [SerializeField] private float _life;
    private int _numLife;

    
    protected void ApplyEffect(Collision2D col)
    {
        if (_life > 0)
            _numLife = 1;

        else
            _numLife = -1;

        GameManager.Instance.ChangeLife(_numLife);
    }
}