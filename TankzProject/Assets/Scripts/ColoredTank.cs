using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColoredTank : Tank
{
    [SerializeField] Color bodyColor;
    private void LateUpdate()
    {
        SetBodyColor();
    }
    public void SetBodyColor()
    {
        switch (team)
        {
            case "red":
                bodyColor = Color.red;
                break;
            case "green":
                bodyColor = Color.green;
                break;
            case "blue":
                bodyColor = Color.blue;
                break;
            default:
                bodyColor = Color.white;
                break;
        }
        PaintBody();
    }
    public void PaintBody()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            for (int j = 0; j < transform.GetChild(i).transform.childCount; j++)
            {
                transform.GetChild(i).transform.GetChild(j).gameObject.GetComponent<Renderer>().material.color = bodyColor;
            }
        }
    }
}
