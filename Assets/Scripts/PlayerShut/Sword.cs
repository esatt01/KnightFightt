using System.Collections;
using UnityEngine;

public class Sword : MonoBehaviour
{
    public float lifetime = 3f; // 3 saniye sonra yok olacak

    void Start()
    {
        Destroy(gameObject, lifetime); // Otomatik yok etme
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            ScoreManager.instance.AddScore(10); // 10 puan ekle
            Destroy(collision.gameObject); // Düþmaný yok et
            Destroy(gameObject); // Kýlýcý da yok et
        }
        else if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            Destroy(gameObject);
        }
    }

}
