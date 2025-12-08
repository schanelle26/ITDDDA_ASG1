using UnityEngine;
using Firebase.Database;
using Firebase.Auth;

public class DatabaseManager : MonoBehaviour
{
    public Gamemanager gameManager; // Ref to game manager

    public void UpdateFoodCollected(string foodName)
    {
        // Ensure user is logged in
        if (FirebaseAuth.DefaultInstance.CurrentUser == null)
        {
            Debug.LogWarning("No user logged in. Cannot update database.");
            return;
        }

        // Prevent double-counting of food items
        if (gameManager.IsFoodAlreadyCollected(foodName))
        {
            Debug.Log($"{foodName} already collected.");
            return;
        }

        string userId = FirebaseAuth.DefaultInstance.CurrentUser.UserId;
        DatabaseReference reference = FirebaseDatabase.DefaultInstance.RootReference;

        // to mark individual food as collected in Firebase
        reference.Child("users").Child(userId).Child("foodsCollected").Child(foodName).SetValueAsync(true);

        // Update total foods collected 
        gameManager.foodsFound++; 
        gameManager.MarkFoodCollected(foodName);

        // Update progress bar
        gameManager.progressBar.currentFoods = gameManager.foodsFound;
        gameManager.progressBar.UpdateProgress();

        // Update total foods collected in Firebase
        reference.Child("users").Child(userId).Child("totalCollected").SetValueAsync(gameManager.foodsFound);

        Debug.Log($"Updated database: {foodName} collected. Total: {gameManager.foodsFound}");
    }
}
