using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Text scoreText;
    public Text highScoreText;

    void Start()
    {
        int finalScore = PlayerPrefs.GetInt("Score", 0);
        int highScore = PlayerPrefs.GetInt("HighScore", 0);

        scoreText.text = "Toplam Puan: " + finalScore.ToString();
        highScoreText.text = "En Yüksek Puan: " + highScore.ToString();
    }

    void Update()
    {
        
    }

    public void Mainmenu()
    {
        //PlayerPrefs.DeleteKey("Score"); // Puaný tamamen temizle
        //PlayerPrefs.Save();             // Deðiþiklikleri hemen diske yaz
        SceneManager.LoadScene(0);
    }

}
