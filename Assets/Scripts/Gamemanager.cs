using UnityEngine;
using System.Collections.Generic;

public class Gamemanager : MonoBehaviour
{
    public int totalFoods = 3;
    public int foodsFound = 0;
    // to track foods collected by name 
    public Dictionary<string, bool> foodsCollected = new Dictionary<string, bool>(); 
     public ProgressBar progressBar;


     private void Awake()
    {
        // Initialize all foods as not collected
        foodsCollected["ChickenRice"] = false;
        foodsCollected["NasiLemak"] = false;
        foodsCollected["Noodles"] = false;
    }
    
    public bool IsFoodAlreadyCollected(string foodName) //Check if food collected 
    {
        return foodsCollected.ContainsKey(foodName) && foodsCollected[foodName];
    }

    public void MarkFoodCollected(string foodName)
    {
        if (foodsCollected.ContainsKey(foodName))
        {
            foodsCollected[foodName] = true; //To mark food as collected
        }
    }


}
