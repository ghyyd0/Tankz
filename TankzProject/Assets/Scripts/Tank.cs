 
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI; 
public class Tank : MonoBehaviour
{
    // Start is called before the first frame update
    public string team;
    private List<Tank> myTeam;
    [SerializeField] float maxDistanceShooting = 5;
    NavMeshAgent tankNavigation;
    [SerializeField] bool isPlayer;

    [SerializeField] GameObject _child;
    private Color bodyColor;

    void Start()
    {
        tankNavigation = GetComponent<NavMeshAgent>();
        myTeam = new List<Tank>();
        myTeam = GameObject.FindObjectsOfType<Tank>().ToList().Where(Tank => Tank.team == team).ToList();

        ColorFeature();
    }

    private void SetBodyColor()
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
    }

   
    private void ColorFeature()
    {
        SetBodyColor();
        foreach (Renderer shape in GetComponentsInChildren<Renderer>())
            shape.material.color = bodyColor;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isPlayer)
            FollowEnemy();
    }
    public void SearchEnemy()
    {
        transform.Rotate(0, 5, 0);
    }
    public void DestroyEnemy(GameObject enemyTank)
    {
        int teamscore = PlayerPrefs.GetInt(team);
        teamscore++;
        PlayerPrefs.SetInt(team, teamscore);
        if (enemyTank.GetComponent<TankSettings>())
        {
            TankSettings myTankSettings = GetComponent<TankSettings>();
            myTankSettings.GiveDamage(enemyTank);
        }


    }
    public void FollowEnemy()
    {
        RaycastHit objectOnHitLine;
        if (Physics.Raycast(transform.position, transform.forward , out objectOnHitLine))
        {
            if (objectOnHitLine.transform.gameObject.GetComponent<Tank>())
            {
                Tank enemyTank = objectOnHitLine.transform.gameObject.GetComponent<Tank>();
                if (!myTeam.Contains(enemyTank))
                {
                    if (objectOnHitLine.distance > maxDistanceShooting)
                    {
                        tankNavigation.SetDestination(objectOnHitLine.transform.position);

                    }
                    else
                    {
                        DestroyEnemy(enemyTank.gameObject);
                    }

                }
            }
        }
        else
        {
            SearchEnemy();
        }   
    }

    
   
}
