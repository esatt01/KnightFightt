using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Playz: MonoBehaviour
{

    //public GameObject guidePnl;
    public GameObject mainPnl;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayBtn()
    {
        SceneManager.LoadScene(1);
    }

    //public void GuideON()
    //{
    //    mainPnl.SetActive(false);
    //    guidePnl.SetActive(true);
    //}
    //public void GuideOFF()
    //{
    //    mainPnl.SetActive(true); 
    //    guidePnl.SetActive(false);
    //}

    public void QuitBtn()
    {
        Application.Quit();
    }
}
