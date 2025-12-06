using Firebase.Auth;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections;

public class Authentication : MonoBehaviour
{
    public TMP_InputField EmailInput;
    public TMP_InputField PasswordInput;
    public Image ErrorImage;
    public float ErrorDisplayTime = 2f;
    public Button LoginButton;
    public Button SignUpButton;
    public UIManager uiManager;

    private Coroutine currentErrorCoroutine;

    void Start()
    {
        if (ErrorImage != null)
            ErrorImage.gameObject.SetActive(false);
    }

    public void SignUp()
    {
        StartCoroutine(HandleSignUp());
    }

    public void LogIn()
    {
        StartCoroutine(HandleLogIn());
    }

    private IEnumerator HandleSignUp()
    {
        SetButtonsInteractable(false);

        if (string.IsNullOrEmpty(EmailInput.text) || string.IsNullOrEmpty(PasswordInput.text))
        {
            yield return ShowErrorTemporarily("Email or Password cannot be empty!");
            SetButtonsInteractable(true);
            yield break;
        }

        var task = FirebaseAuth.DefaultInstance.CreateUserWithEmailAndPasswordAsync(EmailInput.text, PasswordInput.text);
        yield return new WaitUntil(() => task.IsCompleted);

        if (task.IsCanceled)
        {
            yield return ShowErrorTemporarily("Sign Up Canceled");
        }
        else if (task.IsFaulted)
        {
            string error = task.Exception.Flatten().InnerExceptions[0].Message;
            yield return ShowErrorTemporarily("Sign Up Failed: " + error);
        }
        else
        {
            Debug.Log("Sign Up Success!");
            uiManager.ShowThirdPage(); // Only switch page on success
        }

        SetButtonsInteractable(true);
    }

    private IEnumerator HandleLogIn()
    {
        SetButtonsInteractable(false);

        if (string.IsNullOrEmpty(EmailInput.text) || string.IsNullOrEmpty(PasswordInput.text))
        {
            yield return ShowErrorTemporarily("Email or Password cannot be empty!");
            SetButtonsInteractable(true);
            yield break;
        }

        var task = FirebaseAuth.DefaultInstance.SignInWithEmailAndPasswordAsync(EmailInput.text, PasswordInput.text);
        yield return new WaitUntil(() => task.IsCompleted);

        if (task.IsCanceled)
        {
            yield return ShowErrorTemporarily("Login Canceled");
        }
        else if (task.IsFaulted)
        {
            string error = task.Exception.Flatten().InnerExceptions[0].Message;
            yield return ShowErrorTemporarily("Login Failed: " + error);
        }
        else
        {
            Debug.Log("Login Success!");
            uiManager.ShowThirdPage(); // Only switch page on success
        }

        SetButtonsInteractable(true);
    }

    private IEnumerator ShowErrorTemporarily(string message)
    {
        Debug.LogError(message);

        // Cancel previous coroutine if running
        if (currentErrorCoroutine != null)
            StopCoroutine(currentErrorCoroutine);

        if (ErrorImage != null)
            ErrorImage.gameObject.SetActive(true);

        currentErrorCoroutine = StartCoroutine(HideErrorAfterDelay(ErrorDisplayTime));
        yield return currentErrorCoroutine;
    }

    private IEnumerator HideErrorAfterDelay(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        if (ErrorImage != null)
            ErrorImage.gameObject.SetActive(false);
    }

    private void SetButtonsInteractable(bool state)
    {
        if (LoginButton != null) LoginButton.interactable = state;
        if (SignUpButton != null) SignUpButton.interactable = state;
    }
}
