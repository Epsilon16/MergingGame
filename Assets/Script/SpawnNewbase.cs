using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnNewbase : MonoBehaviour
{
    public Vector2 ground_Spawn = new Vector2 (-1, 1);
    public Vector2 fire_Spawn = new Vector2(1, 1);
    public Vector2 water_Spawn = new Vector2(-1, -1);
    public Vector2 wind_Spawn = new Vector2(1, -1);
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void New_Spawn()
    {
        Instantiate(Resources.Load("Prefab/ground_object"), ground_Spawn, Quaternion.identity);
        Instantiate(Resources.Load("Prefab/fire_object"), fire_Spawn, Quaternion.identity);
        Instantiate(Resources.Load("Prefab/water_object"), water_Spawn, Quaternion.identity);
        Instantiate(Resources.Load("Prefab/wind_object"), wind_Spawn, Quaternion.identity);
    }
}
