using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        StartCoroutine(LoadSceneWithDelay(0.3f));
    }

    IEnumerator LoadSceneWithDelay(float delay)
    {
        if (ScoreManager.instance != null)
        {
            ScoreManager.instance.ResetScore(); // Singleton üzerinden eriþ
        }

        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
