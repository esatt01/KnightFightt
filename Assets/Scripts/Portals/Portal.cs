using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    private float timeInside = 0f;
    public float requiredTime = 1.2f;
    private bool playerInside = false;

    private SpriteRenderer spriteRenderer;
    private Color originalColor;
    private Color targetColor = new Color(0.5f, 0f, 1f); // Mor (RGB: 128, 0, 255)

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalColor = spriteRenderer.color;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInside = true;
            timeInside = 0f;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInside = false;
            timeInside = 0f;
            spriteRenderer.color = originalColor; // Renk sıfırlansın
        }
    }

    private void Update()
    {
        if (playerInside)
        {
            timeInside += Time.deltaTime;

            // Renk geçişi (morlaşma)
            float t = Mathf.Clamp01(timeInside / requiredTime);
            spriteRenderer.color = Color.Lerp(originalColor, targetColor, t);

            if (timeInside >= requiredTime)
            {
                SceneManager.LoadScene(2); // Sahne adını düzenlemeyi unutma
            }
        }
    }
}
