using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankSettings : MonoBehaviour

{
    // Start is called before the first frame update
    [SerializeField] float health = 100;
    [SerializeField] public float gunPower = 1;
    
    public  virtual void GiveDamage(GameObject enemyTank)
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

    void Start()
    {
        health = 100;
        gunPower = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
