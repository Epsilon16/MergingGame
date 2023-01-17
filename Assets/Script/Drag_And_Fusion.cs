using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drag_And_Fusion : MonoBehaviour
{
    private Vector2 mousePosition;

    private float offsetX, offsetY;

    private static bool MousePressReleased = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        
        MousePressReleased = false;
        offsetX = Camera.main.ScreenToWorldPoint(Input.mousePosition).x - transform.position.x;
        offsetY = Camera.main.ScreenToWorldPoint(Input.mousePosition).y - transform.position.y;

    }

    private void OnMouseDrag()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector2(mousePosition.x - offsetX, mousePosition.y - offsetY);
    }

    private void OnMouseUp()
    {
        MousePressReleased = true;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        string ThisGameObjectName = gameObject.name.Substring(0, name.IndexOf("_"));
        string CollisionGameObjectName = collision.gameObject.name.Substring(0, collision.gameObject.name.IndexOf("_"));
        

        if (MousePressReleased && ThisGameObjectName == "fire" && CollisionGameObjectName == "ground")
        {
            Instantiate(Resources.Load("Prefab/lava_object"), transform.position, Quaternion.identity);
            MousePressReleased = false;
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
