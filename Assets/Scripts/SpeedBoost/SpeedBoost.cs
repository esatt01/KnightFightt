using UnityEngine;
using DG.Tweening; // DoTween namespace'ini dahil et

public class SpeedBoost : MonoBehaviour
{
    public float boostDuration = 5f;  // Boost s�resi
    public float bobbingHeight = 0.5f;  // Sallanma y�ksekli�i
    public float bobbingSpeed = 2f;  // Sallanma h�z�

    private void Start()
    {
        // Starttaki sallanma animasyonunu ba�lat
        StartBobbing();
    }

    private void StartBobbing()
    {
        // DoTween ile sallanma animasyonu ba�lat
        transform.DOMoveY(transform.position.y + bobbingHeight, bobbingSpeed)
            .SetLoops(-1, LoopType.Yoyo)  // Sonsuz loop, yukar� ve a�a�� hareket eder
            .SetEase(Ease.InOutSine);  // Yumu�ak bir ge�i�
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<Player_Movement>().ActivateSpeedBoost(boostDuration);  // H�z art�r
            Destroy(gameObject);  // Boost objesini yok et
        }
    }
}
