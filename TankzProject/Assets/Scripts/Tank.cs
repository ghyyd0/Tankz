 
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
    void Start()
    {
        tankNavigation = GetComponent<NavMeshAgent>();
        myTeam = new List<Tank>();
        myTeam = GameObject.FindObjectsOfType<Tank>().ToList().Where(Tank => Tank.team == team).ToList();

        RandomFeature();
    }

    private void RandomFeature()
    {
        team = Random.Range(1111, 999).ToString();
        foreach (Renderer shape in GetComponentsInChildren<Renderer>())
            shape.material.color = Random.ColorHSV();
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
        Destroy(enemyTank.gameObject,1);


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
