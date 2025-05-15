using UnityEngine;
using UnityEngine.SceneManagement;

public class LongObstacle : MonoBehaviour
{
    public float speed = 2f;
    public float minY = 1f;
    public float maxY = 3f;
    private bool goingUp = true;

    void Update()
    {
        if (goingUp)
        {
            transform.position += Vector3.up * speed * Time.deltaTime;
            if (transform.position.y >= maxY)
                goingUp = false;
        }
        else
        {
            transform.position += Vector3.down * speed * Time.deltaTime;
            if (transform.position.y <= minY)
                goingUp = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Player_Controller bileþenini al
            Player_Controller player = collision.gameObject.GetComponent<Player_Controller>();

            if (player != null)
            {
                player.TakeDamage(1); // 1 can eksilt
            }
        }
    }
}
