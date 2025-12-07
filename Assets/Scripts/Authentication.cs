using UnityEngine;
using Firebase;
using Firebase.Extensions;
using Firebase.Auth;
using TMPro;

public class Authentication : MonoBehaviour
{
    public TMP_InputField emailInput;
    public TMP_InputField passwordInput;
    public UIManager uiManager; 

    private bool isFirebaseReady = false;

    void Start()
    {
        // Initialize Firebase before proceeding 
        FirebaseApp.CheckAndFixDependenciesAsync().ContinueWithOnMainThread(task =>
        {
            var dependencyStatus = task.Result;
            if (dependencyStatus == DependencyStatus.Available)
            {
                isFirebaseReady = true;
                Debug.Log("Firebase is ready!");
            }
            else
            {
                Debug.LogError($"Could not resolve all Firebase dependencies: {dependencyStatus}");
            }
        });
    }

    public void SignUp()
    {
        if (!isFirebaseReady)
        {
            Debug.LogWarning("Firebase not ready yet. Please wait...");
            return;
        }

        var createTask = FirebaseAuth.DefaultInstance.CreateUserWithEmailAndPasswordAsync(emailInput.text, passwordInput.text);
        createTask.ContinueWithOnMainThread(task =>
        {
            if (task.IsFaulted || task.IsCanceled)
            {
                Debug.Log("Error creating User!");
                return;
            }

            if (task.IsCompleted)
            {
                Debug.Log("User created successfully! Navigating to Third Page!");
                uiManager.ShowThirdPage(); // Navigate to ThirdPage
                var uid = task.Result.User.UserId;
                Debug.Log($"Created user UID: {uid}");
            }
        });
    }

    public void LogIn()
    {
        if (!isFirebaseReady)
        {
            Debug.LogWarning("Firebase not ready yet. Please wait...");
            return;
        }

        var loginTask = FirebaseAuth.DefaultInstance.SignInWithEmailAndPasswordAsync(emailInput.text, passwordInput.text);
        loginTask.ContinueWithOnMainThread(task =>
        {
            if (task.IsFaulted || task.IsCanceled)
            {
                Debug.Log("Error logging in!");
                return;
            }

            if (task.IsCompleted)
            {
                Debug.Log("User logged in successfully! Navigating to Third Page!");
                uiManager.ShowThirdPage(); // Navigate to ThirdPage
                var uid = task.Result.User.UserId;
                Debug.Log($"Logged in user UID: {uid}");
            }
        });
    }
}
