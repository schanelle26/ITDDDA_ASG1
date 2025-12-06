using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public GameObject StartBackground;
    public GameObject LoginSignUp;
    public GameObject ThirdPage;
    public GameObject InstructionsPanel;
    public GameObject ExplorePanel;

    void Start()
    {
        ShowStartBackground();
    }

    private void HideAll()
    {
        if (StartBackground != null) StartBackground.SetActive(false);
        if (LoginSignUp != null) LoginSignUp.SetActive(false);
        if (ThirdPage != null) ThirdPage.SetActive(false);
        if (InstructionsPanel != null) InstructionsPanel.SetActive(false);
        if (ExplorePanel != null) ExplorePanel.SetActive(false);
    }

    public void ShowStartBackground()
    {
        HideAll();
        if (StartBackground != null) StartBackground.SetActive(true);
    }

    public void ShowLoginSignUp()
    {
        HideAll();
        if (LoginSignUp != null) LoginSignUp.SetActive(true);
    }

    public void ShowThirdPage()
    {
        HideAll();
        if (ThirdPage != null) ThirdPage.SetActive(true);
    }

    public void ShowInstructions()
    {
        HideAll();
        if (InstructionsPanel != null) InstructionsPanel.SetActive(true);
    }

    public void ShowExplore()
    {
        HideAll();
        if (ExplorePanel != null) ExplorePanel.SetActive(true);
    }

    public void LoadARScene()
    {
        SceneManager.LoadScene("ARScene");
    }
}

