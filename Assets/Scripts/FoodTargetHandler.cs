using UnityEngine;

public class FoodTargetHandler : MonoBehaviour
{
    public class FoodInteract : MonoBehaviour
    {
        public GameObject infoButton;
        private void OnMouseDown()
        {
            infoButton.SetActive(true);
        }
    }
}
