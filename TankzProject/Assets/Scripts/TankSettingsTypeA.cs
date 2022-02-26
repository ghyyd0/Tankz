using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankSettingsTypeA : TankSettings
{
    // Start is called before the first frame update
    [SerializeField]List<GameObject> tanks = new List<GameObject>();
    private void OnTriggerEnter(Collider other)
    {
        tanks.Add(other.gameObject);
    }
    private void OnTriggerExit(Collider other)
    {
        tanks.Remove(other.gameObject);

    }
     
    public void GiveDamageForListOfTanks(GameObject enemyTank)
    {
        enemyTank.GetComponent<TankSettingsTypeA>().TakeDamage(1);
        foreach (GameObject tank in tanks)
        {
            tank.GetComponent<TankSettingsTypeA>().TakeDamage(1);
        }

    }
    public override void GiveDamage(GameObject enemyTank)
    { 
        GiveDamageForListOfTanks(enemyTank);

    } 
}
