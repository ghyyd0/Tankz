using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TankFactory : MonoBehaviour
{
    [SerializeField] GameObject tankToSpawn;
    [SerializeField] List<Tank> tanksOnScene;
    [SerializeField, Range(1, 100)] float maxTanksOnScene;
    [SerializeField, Range(0, 500)] float sizeOfSpawnField;
     

    private void Awake()
    {
        tanksOnScene = new List<Tank>();
        maxTanksOnScene = 5;
        sizeOfSpawnField = 500;
    }
    private void Start()
    {
        tankToSpawn = Resources.Load<GameObject>("Tank");
    }

    private void Update()
    {
        GameSettings.rotation = someShit;
        Vector3 positionForNewTank = GetRandomPosition(); 
        SpawnTank(positionForNewTank);
    }
    [SerializeField, Range(-50, 50)] float someShit = 5;
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
            newTank.GetComponent<TankData>().SetCurrentSetting(TankData.SettingType.A);
             
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
