using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIStuff : MonoBehaviour
{
    public string team;
     
    void Update()
    {
        GetComponent<Text>().text = team + " = " + PlayerPrefs.GetInt(team);
    }
}
