using UnityEngine;
using UnityEngine.UI; 

public class ProgressBar : MonoBehaviour
{
    public Image fillImage;  
    public int currentFoods = 0;
    public int totalFoods = 3;   

    public Gamemanager gameManager;  

    public void UpdateProgress()
    {
        float progress = (float)currentFoods / gameManager.totalFoods; //Calculate foods found
        fillImage.fillAmount = progress; //update progress bar
    }


}
