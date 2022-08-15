using UnityEngine;

public class Subject : MonoBehaviour
{
    [SerializeField] private int _hp;

    [Header("Music")]
    [SerializeField] private AudioClip _audioClip;

    private Transform _cachedTransform;



    #region Unity lifecycle

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag(Tags.Box))
            DestroyFood();

        else if (col.gameObject.CompareTag(Tags.LoseZone))
            ScoreManager.Instance.ChangeScore(-_hp);
    }

    private void DestroyFood()
    {
        AudioPlayer.Instance.PlaySound(_audioClip);

        LayerMask layerMask = gameObject.layer;
        GameManager.Instance.CheckEdible(layerMask);

        Destroy(gameObject);
        ScoreManager.Instance.ChangeScore(_hp);
    }

    #endregion


}