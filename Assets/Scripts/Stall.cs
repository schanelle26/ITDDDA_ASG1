using UnityEngine;
using System;

[System.Serializable]
public class Stall 
{
    public string id;
    public string stallName;
    public int likes;
    
    public Stall( string id, string stallName, int likes)
    {
        this.id = id;
        this.stallName = stallName;
        this.likes = likes;
    }
}
