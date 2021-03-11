using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TankFactory : MonoBehaviour
{
    [SerializeField] GameObject tankToSpawn;
    [SerializeField] List<Tank> tanksOnScene;
    [SerializeField, Range(1, 600)] float maxTanksOnScene;
    [SerializeField, Range(0, 500)] float sizeOfSpawnField;
    [SerializeField, Range(-50, 50)] float rotationAngle;


    private void Awake()
    {
        tanksOnScene = new List<Tank>();
        maxTanksOnScene = 150;
        sizeOfSpawnField = 250;
        rotationAngle = 5;
    }
    private void Start()
    {
        tankToSpawn = Resources.Load<GameObject>("Tank");
    }

    private void Update()
    {
        GameSettings.rotationAngle = rotationAngle;
        Vector3 positionForNewTank = GetRandomPosition(); 
        SpawnTank(positionForNewTank);
    }
    Vector3 GetRandomPosition()
    {
        float randomX = Random.Range(0, sizeOfSpawnField);
        float randomY = 0; 
        float randomZ = Random.Range(0, sizeOfSpawnField); 
        return new Vector3(randomX, randomY, randomZ);
    }

    void RefreshListOfTanks()
    {
        tanksOnScene = GameObject.FindObjectsOfType<Tank>().ToList();
    }
    void SpawnTank(Vector3 spawnPoint)
    {
        if (CanSpawn())
        { 
            GameObject newTank = Instantiate(tankToSpawn, spawnPoint, Quaternion.identity);
            newTank.GetComponent<Tank>().team = GameSettings.GetRandomTeam();
             
        }
   
    }
    bool CanSpawn()
    {
        RefreshListOfTanks();
        if(tanksOnScene.Count< maxTanksOnScene)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
