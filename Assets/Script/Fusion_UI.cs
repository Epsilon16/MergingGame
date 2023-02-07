using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fusion_UI : MonoBehaviour
{
    public Image[] Discovered_fusion;
    public Drag_And_Fusion fusion;
    private bool[] is_good;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        //for (int i = 0; i <= fusion.is_good_fusion.Length; i++)
        //    is_good = fusion.is_good_fusion;

        if (is_good[0] == true)
        {
            Discovered_fusion[0].color = Color.white;
        }
    }
}
