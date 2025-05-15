using UnityEngine;

public class GuideManager : MonoBehaviour
{
    public GameObject guidePanel; // Açýlacak panel

    public void CloseGuide()
    {
        guidePanel.SetActive(false);
    }

    public void OpenGuide()
    {
        guidePanel.SetActive(true);
    }
}
