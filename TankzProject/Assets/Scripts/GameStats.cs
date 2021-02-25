using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class GameStats : MonoBehaviour
{

    GameObject tank;
    List<GameObject> tanks;
    [SerializeField,Range(10,100)] int  maxTankScene = 10;
    // Start is called before the first frame update
    void Start()
    {
        tank  = Resources.Load<GameObject>("Tank");
        PlayerPrefs.DeleteAll();
    }

    // Update is called once per frame
    void Update()
    {
        tanks = GameObject.FindObjectsOfType<GameObject>().Where(t=>t.GetComponent<Tank>()).ToList();
        if(tanks.Count<maxTankScene)
        {
            Vector3 randomPostion =  transform.position + new Vector3(Random.Range(-300,300),0,Random.Range(-300,300));
            Instantiate(tank, randomPostion, Quaternion.identity);
        }
    }
}
