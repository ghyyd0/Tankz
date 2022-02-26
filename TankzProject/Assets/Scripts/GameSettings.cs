using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameSettings 
{
    // Start is called before the first frame update
    public  static string[] teams = { "red", "blue", "green" };
    public static string GetRandomTeam()
    {
        return teams[Random.Range(0, teams.Length)];
    }
   

    // Update is called once per frame
    
}
