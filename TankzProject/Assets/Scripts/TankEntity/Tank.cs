using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.AI;

public class Tank : MonoBehaviour
{ 
    public string team; 
    NavMeshAgent tankNavigation;
    private  List<Tank> myTeam;
    [SerializeField, Range(1, 100)] float maxDistanceOfShooting = 5;
    [SerializeField] bool isPlayer; 
    public float rotationSpeed = 2;

    // Start is called before the first frame update
    void Start()
    {
        tankNavigation = GetComponent<NavMeshAgent>();  
        myTeam = new List<Tank>(); 
        myTeam = GameObject.FindObjectsOfType<Tank>().ToList().Where(tank=>tank.team == team).ToList();
    }


     
    // Update is called once per frame
    void Update()
    {
        if(!isPlayer)
        {
            FollowEnemy();
        }
       
    }

    void FollowEnemy()
    {
        RaycastHit objectOnHitLine;
        if (Physics.Raycast(transform.position, transform.forward, out objectOnHitLine))
        {
            Tank enemyTank = null;
            if (objectOnHitLine.transform.gameObject.GetComponent<Tank>())
            { 
                enemyTank = objectOnHitLine.transform.gameObject.GetComponent<Tank>();
            }
            if (objectOnHitLine.transform.gameObject.GetComponent<ColoredTank>())
            {
                enemyTank = (Tank)objectOnHitLine.transform.gameObject.GetComponent<ColoredTank>();
            }
            if (!myTeam.Contains(enemyTank))
            {
                if (objectOnHitLine.distance > maxDistanceOfShooting)
                {
                    tankNavigation.SetDestination(objectOnHitLine.transform.position);
                }
                else
                {
                    DestroyEnemy(enemyTank.gameObject);
                }

            } 
        }
        else
        {
            SearchEnemy();
        }
    }


    void SearchEnemy()
    {
        transform.Rotate(0, rotationSpeed, 0);
    }
    void DestroyEnemy(GameObject enemyTank)
    {
        int teamscore = PlayerPrefs.GetInt(team);
        teamscore++;
        PlayerPrefs.SetInt(team, teamscore);
        Destroy(enemyTank.gameObject);
    }
}
