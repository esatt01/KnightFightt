using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Princess : MonoBehaviour
{
    public Player_Movement pm;
    public GameObject balon;
    public float delayBeforeSceneChange = 5f;
    public Animator animator; // Inspector üzerinden atanmalý

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            pm.canMove = false;
            balon.SetActive(true);
            // Sadece animasyonu bir defa tetikle
            if (animator != null)
                animator.SetTrigger("Celebrate");  // Animator'da 'Celebrate' trigger'ý tanýmlý olmalý

            // Sahne geçiþini gecikmeli baþlat
            StartCoroutine(LoadSceneAfterDelay(delayBeforeSceneChange));
        }
    }

    private IEnumerator LoadSceneAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(3);
    }
}
