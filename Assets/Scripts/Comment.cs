using UnityEngine;
using System;


[System.Serializable]
public class Comment 
{
    public string text;
    public string userId;

    public Comment(string text, string userId)
    {
        this.text = text;
        this.userId = userId;
    }
    


}
