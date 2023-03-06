using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnNewbase : MonoBehaviour
{
    public Vector2 ground_Spawn = new Vector2 (-3f, 2f);
    public Vector2 fire_Spawn = new Vector2(3f, 2f);
    public Vector2 water_Spawn = new Vector2(-2f, -2f);
    public Vector2 wind_Spawn = new Vector2(2f, -2f);
    //public Vector2 electricity_Spawn = new Vector2(0f, 3f);

    public GameObject Ui1;
    public GameObject Ui2;

    public int changed;

    public CanvasGroup Canvas;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (changed == 1)
        {
            Ui1.SetActive(false);
            //Ui2.SetActive(true);
            //DisplayScrollArea();
        }
        if (changed == 2)
        {
            Ui1.SetActive(true);
            //Ui2.SetActive(false);
            //DisplayScrollArea();
            changed = 0;
        }
    }

    public void New_Spawn()
    {
        Instantiate(Resources.Load("Prefab/ground_object"), ground_Spawn, Quaternion.identity);
        Instantiate(Resources.Load("Prefab/fire_object"), fire_Spawn, Quaternion.identity);
        Instantiate(Resources.Load("Prefab/water_object"), water_Spawn, Quaternion.identity);
        Instantiate(Resources.Load("Prefab/wind_object"), wind_Spawn, Quaternion.identity);
        //Instantiate(Resources.Load("Prefab/electricity_object"), electricity_Spawn, Quaternion.identity);
    }

    public void SwapMenu()
    {
        changed = changed + 1;
    }

    public void DisplayScrollArea()
    {
        
        Canvas.interactable = !Canvas.interactable;
        Canvas.blocksRaycasts = !Canvas.blocksRaycasts;
        if (Canvas.interactable)
            Canvas.alpha = 1;
        else
            Canvas.alpha = 0;
    }
}
