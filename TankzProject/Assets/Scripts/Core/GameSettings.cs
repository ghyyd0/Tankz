using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameSettings  
{
    public static string [] teams =   { "red", "blue", "green" };

    public static float rotationAngle;

    public static string GetRandomTeam()
    {
        return teams[Random.Range(0, teams.Length)];
    }
}


