using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankSettings : MonoBehaviour
{
    [SerializeField] float health;
    [SerializeField] public float gunPower;
    public virtual void  GiveDamage(GameObject enemyTank)
    {
        enemyTank.GetComponent<TankSettings>().TakeDamage(gunPower);
    }
    public void TakeDamage(float value)
    {
        health -= value;
        CheckHealth();
    }

    private void CheckHealth()
    {
        if (health < 0) Destroy(gameObject);
    }
}
