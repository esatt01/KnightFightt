using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Shot : MonoBehaviour
{
    public GameObject swordPrefab;  // Kýlýç prefab'ý
    public Transform firePoint;     // Kýlýcýn çýkacaðý nokta
    public float swordSpeed = 10f;

    public float fireCooldown = 0.5f; // Kaç saniyede bir atýþ yapýlabilir
    private float lastFireTime = -999f;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && Time.time >= lastFireTime + fireCooldown)
        {
            ThrowSword();
            lastFireTime = Time.time;
        }
    }

    public void ThrowSword()
    {
        int yon = GetComponent<Player_Movement>().yon;

        Quaternion rotation = (yon == 1)
            ? Quaternion.Euler(0, 0, -90)
            : Quaternion.Euler(0, 0, 90);

        GameObject sword = Instantiate(swordPrefab, firePoint.position, rotation);

        Rigidbody2D rb = sword.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(swordSpeed * yon, 0);

        Vector3 originalScale = sword.transform.localScale;
        sword.transform.localScale = new Vector3(Mathf.Abs(originalScale.x) * yon, originalScale.y, originalScale.z);
    }
}