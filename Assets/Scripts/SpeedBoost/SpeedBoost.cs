using UnityEngine;
using DG.Tweening; // DoTween namespace'ini dahil et

public class SpeedBoost : MonoBehaviour
{
    public float boostDuration = 5f;  // Boost süresi
    public float bobbingHeight = 0.5f;  // Sallanma yüksekliði
    public float bobbingSpeed = 2f;  // Sallanma hýzý

    private void Start()
    {
        // Starttaki sallanma animasyonunu baþlat
        StartBobbing();
    }

    private void StartBobbing()
    {
        // DoTween ile sallanma animasyonu baþlat
        transform.DOMoveY(transform.position.y + bobbingHeight, bobbingSpeed)
            .SetLoops(-1, LoopType.Yoyo)  // Sonsuz loop, yukarý ve aþaðý hareket eder
            .SetEase(Ease.InOutSine);  // Yumuþak bir geçiþ
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<Player_Movement>().ActivateSpeedBoost(boostDuration);  // Hýz artýr
            Destroy(gameObject);  // Boost objesini yok et
        }
    }
}
