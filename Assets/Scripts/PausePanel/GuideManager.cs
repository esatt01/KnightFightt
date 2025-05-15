using UnityEngine;

public class GuideManager : MonoBehaviour
{
    public GameObject guidePanel; // A��lacak panel

    public void CloseGuide()
    {
        guidePanel.SetActive(false);
    }

    public void OpenGuide()
    {
        guidePanel.SetActive(true);
    }
}
