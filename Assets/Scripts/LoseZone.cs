using UnityEngine;

public class LoseZone : MonoBehaviour
{
    public void OnCollisionEnter2D(Collision2D col)
    {
        if (!col.gameObject.CompareTag(Tags.Subject))
            return;
        GameManager.Instance.GameOver();
        Destroy(col.gameObject);
    }
}