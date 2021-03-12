using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankSettingsTypeA : TankSettings
{
    List<GameObject> tanks = new List<GameObject>();
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
        enemyTank.GetComponent<TankSettings>().TakeDamage(gunPower);

        foreach (GameObject tank in tanks)
        {
            tank.GetComponent<TankSettings>().TakeDamage(gunPower);
        }
    }
     
    override public void GiveDamage(GameObject enemyTank)
    {
        GiveDamageForListOfTanks(enemyTank);
    }
}
