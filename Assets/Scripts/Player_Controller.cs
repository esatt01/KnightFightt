using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.VirtualTexturing;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player_Controller : MonoBehaviour
{
    public int health = 3;
    public Image[] hearts;
    private bool recentlyDamaged = false; // Ayný düþmana tekrar tekrar temas için koruma
    private float damageCooldown = 0.7f; // Hasar aldýktan sonra bekleme süresi
    private float damageTimer = 0f;

    public int yon;
    public float knock;
    public bool carpma;
    public float carpleft;
    public bool carpti;

    private Rigidbody2D rb;
    private float distance;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        yon = this.GetComponent<Player_Movement>().yon;

        if (recentlyDamaged)
        {
            damageTimer -= Time.deltaTime;
            if (damageTimer <= 0)
            {
                recentlyDamaged = false;
            }
        }

        Collider2D col = Physics2D.OverlapCircle(transform.position, 1f, this.GetComponent<Player_Movement>().enemy);
        if (col != null && !recentlyDamaged)
        {
            distance = Mathf.Clamp(transform.position.x - col.gameObject.transform.position.x, -2, 2);
            Debug.Log("çarptým");
            carpma = true;

            TakeDamage(1);
            recentlyDamaged = true;
            damageTimer = damageCooldown;
        }

        if (carpma)
        {
            carpti = true;
        }

        if (carpti)
        {
            //GetComponent<Player_Movement>().canMove = false;
            if (carpleft > 0)
            {
                carpleft -= Time.deltaTime;
                carpma = false;
                transform.position = Vector2.Lerp(transform.position, new Vector2(transform.position.x + 1.5f * (distance), transform.position.y + 1f), carpleft * Time.deltaTime * 4f);
            }
            else if (carpleft <= 0)
            {
                //GetComponent<Player_Movement>().canMove = true;
                carpleft = 1f;
                carpti = false;
            }
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health < 0) health = 0;

        UpdateHearts();

        if (health <= 0)
        {
            Debug.Log("Karakter öldü!");
            if (ScoreManager.instance != null)
            {
                ScoreManager.instance.ResetScore(); // Singleton üzerinden eriþ
            }

            Destroy(gameObject);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    void UpdateHearts()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < health)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }
    }

}
