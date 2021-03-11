using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankData : MonoBehaviour
{

    [SerializeField] float health;
    [SerializeField] float damage;

    public void TakeDamage(float value)
    {
        health -= value;
        HealthCheck();
    }

    public void GiveDamage(GameObject enemy)
    {
        enemy.GetComponent<TankData>().TakeDamage(damage);
    }

    public void HealthCheck()
    {
        if (health < 0)
            Destroy(gameObject);
    }

    public enum SettingType
    {
        A,B,C,D,E
    }
    [SerializeField] SettingType currentSetting;

    public void SetCurrentSetting(SettingType type)
    {
        currentSetting = type;
        switch(currentSetting)
        {
            case SettingType.A:
                health = 100;
                damage = 1;
            break;
            default:
                health = 10;
                damage = 0.01f;
            break;
        }
    }
}
