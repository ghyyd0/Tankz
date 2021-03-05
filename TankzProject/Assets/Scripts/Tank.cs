using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.AI;

public class Tank : MonoBehaviour
{
    [SerializeField] int iD;
    public string team;
    [SerializeField] Color bodyColor;
    NavMeshAgent tankNavigation;
    public List<Tank> myTeam;
    // Start is called before the first frame update
    void Start()
    {
        tankNavigation = GetComponent<NavMeshAgent>();
        iD = GameManager.GetRandomId();
        team = GameManager.GetRandomTeam();
        myTeam = new List<Tank>();
        SetBodyColor();
        myTeam = GameObject.FindObjectsOfType<Tank>().ToList().Where(tank=>tank.team == team).ToList();
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
         for(int i=0;i<transform.childCount;i++)
         {
             for(int j=0;j<transform.GetChild(i).transform.childCount;j++)
             {
                 transform.GetChild(i).transform.GetChild(j).gameObject.GetComponent<Renderer>().material.color = bodyColor;
             }
         }
    }
    // Update is called once per frame
    void Update()
    {
        RaycastHit objectOnHitLine; 
        if(Physics.Raycast(transform.position, transform.forward, out objectOnHitLine))
        {
            Tank enemyTank = objectOnHitLine.transform.gameObject.GetComponent<Tank>();
            if(enemyTank.GetComponent<Tank>())
            {
                if(!myTeam.Contains(enemyTank))
                {
                    if(objectOnHitLine.distance>5)
                    {
                        tankNavigation.SetDestination(objectOnHitLine.transform.position);
                    }
                    else 
                    {
                        int teamscore = PlayerPrefs.GetInt(team);
                        teamscore++;
                        PlayerPrefs.SetInt(team,teamscore);
                        Destroy(enemyTank.gameObject);
                    }
                    
                }
                
            }
        }
        else
        {
            transform.Rotate(0,5,0);
        }
    }
}
