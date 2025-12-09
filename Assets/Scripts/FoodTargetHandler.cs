using UnityEngine;

public class FoodTargetHandler : MonoBehaviour
{
    public GameObject infoPanel; // assign in prefab

    private void OnMouseDown()
    {
        if (infoPanel != null)
    {
        infoPanel.SetActive(true); // shows info and recipie buttons from canvas 
    }
    }
}
