using UnityEngine;
using UnityEngine.UI;
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

      void HideAll()
    {
        StartBackground.SetActive(false);
        LoginSignUp.SetActive(false);
        ThirdPage.SetActive(false);
        InstructionsPanel.SetActive(false);
        ExplorePanel.SetActive(false);
    }

    public void ShowStartBackground()
    {
        HideAll();
        StartBackground.SetActive(true);
    }

    public void ShowLoginSignUp()
    {
        HideAll();
        LoginSignUp.SetActive(true);
    }

    public void ShowThirdPage()
    {
        HideAll();
        ThirdPage.SetActive(true);
    }

    public void ShowInstructions()
    {
        HideAll();
        InstructionsPanel.SetActive(true);
    }

    public void ShowExplore()
    {
        HideAll();
        ExplorePanel.SetActive(true);
    }


    public void LoadARScene()
    { 
        SceneManager.LoadScene("ARScene");

    }

}
