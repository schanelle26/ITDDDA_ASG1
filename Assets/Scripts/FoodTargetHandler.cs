using UnityEngine;

public class FoodTargetHandler : MonoBehaviour
{
    public GameObject infoButton; // assign in prefab

    private void OnMouseDown()
    {
        if (infoButton != null)
        {
            infoButton.SetActive(true); // Show info / recipe button
        }
    }
}
