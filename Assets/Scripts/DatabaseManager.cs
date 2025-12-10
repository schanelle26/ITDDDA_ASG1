using System.Collections.Generic;
using Firebase.Extensions;
using UnityEngine;
using Firebase.Database;
using Firebase.Auth;
using TMPro;
using UnityEngine.UI;


public class DatabaseManager : MonoBehaviour
{
    public TMP_Text liveCount1;
    public TMP_Text liveCount2;
    public TMP_Text liveCount3;
    public Button likeBtn1;
    public Button likeBtn2;
    public Button likeBtn3;
    public TMP_Text commentsDisplay;
    public TMP_InputField commentInputField;
    private DatabaseReference db;


    void Start()
    {
        db = FirebaseDatabase.DefaultInstance.RootReference;
    }

    //Create stall data
    public void CreateStallData()
    {
        //Stall01 Tachi Chicken Rice
        Stall stall01 = new Stall("Stall01", "TianChi Chicken Rice", 0);
        string stall01Json = JsonUtility.ToJson(stall01);
        db.Child("stalls").Child(stall01.id).SetRawJsonValueAsync(stall01Json)
        .ContinueWithOnMainThread(task =>
        {
            
            if (task.IsCompleted)
            Debug.Log("Created new stall: " +stall01.stallName);
        });
        
        //Stall02 Lemak House
        Stall stall02 = new Stall("Stall02", "Lemak House", 0);
        string stall02Json = JsonUtility.ToJson(stall02);
        db.Child("stalls").Child(stall02.id).SetRawJsonValueAsync(stall02Json)
        .ContinueWithOnMainThread(task =>
        {
            
            if (task.IsCompleted)
            Debug.Log("Created new stall: " +stall02.stallName);
        });
        
        //Stall03 Prawn King
        Stall stall03 = new Stall("Stall03", "Prawn King", 0);
        string stall03Json = JsonUtility.ToJson(stall03);
        db.Child("stalls").Child(stall03.id).SetRawJsonValueAsync(stall03Json)
        .ContinueWithOnMainThread(task =>
        {
            
            if (task.IsCompleted)
            Debug.Log("Created new stall: " +stall03.stallName);
        });

        //Empty comment node before user input
        db.Child("stalls").Child("comments").SetValueAsync("");

        
    }



    //Retrieves like count from firebase to update UI    
    public void RetrieveLikes(string stallId, TMP_Text liveCountText)
    {
        db.Child("stalls").Child(stallId).Child("likes").GetValueAsync()
        .ContinueWithOnMainThread(task =>
        {
            if(task.IsCompleted && task.Result.Exists)
            {
                int likes = 0;
                int.TryParse(task.Result.Value.ToString(), out likes);
                liveCountText.text = likes.ToString();
            }

            else
            {
                liveCountText.text = "0";
            }
            

        });    
    }



    //Update firebase likes
    public void IncrementLikes(string stallId, TMP_Text liveCountText)
    {
        db.Child("stalls").Child(stallId).Child("likes").GetValueAsync()
        .ContinueWithOnMainThread(task =>
        {
            if(task.IsCompleted && task.Result.Exists)
            {
                int likes = 0;
                int.TryParse(task.Result.Value.ToString(), out likes);
                likes += 1;

                db.Child("stalls").Child(stallId).Child("likes").SetValueAsync(likes)
                .ContinueWithOnMainThread(updateTask =>
                {
                    if (updateTask.IsCompleted)
                    liveCountText.text = likes.ToString();
                });
            }
        
    });

    }

    //To link Buttons to likes
     public void LikeStall1()
    {
        IncrementLikes("Stall01", liveCount1);
    }

    public void LikeStall2()
    {
        IncrementLikes("Stall02", liveCount2);
    }

    public void LikeStall3()
    {
        IncrementLikes("Stall03", liveCount3);
    }


    //Retrieves comments 
    public void RetrieveComments()
    {
        db.Child("stalls").Child("comments").GetValueAsync()
        .ContinueWithOnMainThread(task =>
        {
            if (task.IsFaulted || task.IsCanceled)
            {
                Debug.Log("Failed to retrieve comments!");
                return;
            }

            if (!task.Result.Exists)
            {
                commentsDisplay.text = "No comments yet."; //Updates UI in game 
                return;
            }

            commentsDisplay.text = ""; //Clears input field  
            
            foreach(var child in task.Result.Children)
            {
                // comment etxt stored in frebase
                string commentText =child.Child("text").Value.ToString(); 
                //userId stored in firebase
                string userId = child.Child("userId").Value.ToString(); 

                commentsDisplay.text += $"{userId}: {commentText}\n";
            }

            Debug.Log("Comments retrieved!");



        });

    }


    //Update firebase comments node 
    public void SendComment()
    
    {
    // Get the Id of user that logged in
    string userId = FirebaseAuth.DefaultInstance.CurrentUser.UserId;

    // Get input text from unity
    string commentText = commentInputField.text;
    if (string.IsNullOrEmpty(commentText)) return;
    
    
    // create comment object and generate key
    Comment newComment = new Comment(commentText, userId); 
    string newKey = db.Child("stalls").Child("comments").Push().Key;

    // Convert comment to dictionary
    Dictionary<string, object> commentDict = new Dictionary<string, object>
    {
        { "text", newComment.text },
        { "userId", newComment.userId }
    };

    // Prepare dictionary for UpdateChildrenAsync
    Dictionary<string, object> data = new Dictionary<string, object>();
    data[newKey] = commentDict;

    // Update comments and userId on Firebase
    db.Child("stalls").Child("comments").UpdateChildrenAsync(data)
      .ContinueWithOnMainThread(task =>
      {
          if (task.IsCompleted)
          {
              commentInputField.text = ""; 
              RetrieveComments();// Refresh UI
              Debug.Log("Comment sent successfully!");
          }
          else
          {
              Debug.LogWarning("Failed to send comment.");
          }
      });
}





}

