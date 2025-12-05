using Firebase;
using Firebase.Auth;
using Firebase.Extensions;  
using UnityEngine;
using TMPro;


public class Authentication : MonoBehaviour
{

    public TMP_InputField Emailinput;
    public TMP_InputField Passwordinput;


    void Start()
{
    FirebaseApp.CheckAndFixDependenciesAsync().ContinueWithOnMainThread(task =>
    {
        var dependencyStatus = task.Result;
        if (dependencyStatus == DependencyStatus.Available)
        {
            Debug.Log("Firebase initialized successfully.");
        }
        else
        {
            Debug.LogError($"Could not resolve Firebase dependencies: {dependencyStatus}");
        }
    });
}


    public void SignUp()
    {
        var createTask = FirebaseAuth.DefaultInstance.CreateUserWithEmailAndPasswordAsync(Emailinput.text, Passwordinput.text);

        createTask.ContinueWithOnMainThread(task =>
        {
            if (task.IsFaulted || task.IsCanceled)
            {
                Debug.Log("Error creating User!");
                return;

            }
            
            if (task.IsCompleted)
            {
                Debug.Log("User created successfully!, please sign in.");

                var uid = task.Result.User.UserId;
                Debug.Log($"Created user UID: {uid}");
            }

        });
        

    }
    
    public void LogIn()
    {
        var signinTask = FirebaseAuth.DefaultInstance.SignInWithEmailAndPasswordAsync(Emailinput.text, Passwordinput.text);

        signinTask.ContinueWithOnMainThread(task =>
        {
            if (task.IsFaulted || task.IsCanceled)
            {
                Debug.Log("Error signing in!");
                return;

            }
            
            if (task.IsCompleted)
            {
                Debug.Log("User signed in successfully!");

                var uid = task.Result.User.UserId;
                Debug.Log($"Signed in user UID: {uid}");

            }

        });
        
        
    }


}
