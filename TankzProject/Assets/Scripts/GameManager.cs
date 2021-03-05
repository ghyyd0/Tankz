using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class  GameManager  
{ 
         public static List<string> teams = new List<string>
         {
             "red", 
             "blue", 
             "green"
         };


         public static string  GetRandomTeam()
         {
             return teams[Random.Range(0,teams.Count)];
         }

         public static string  GetTeam(string team)
         {
            if(teams.Contains(team))
                return team;
            else 
                return "noteam";
         }

         public static int  GetRandomId()
         {
             return Random.Range(1000,9999);
         }
}
