using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Android;

public class Drag_And_Fusion : MonoBehaviour
{
    private Touch doigtCheck;
    private Vector2 mousePosition;

    private bool is_moving;
    //private Vector2 touchPosition;

    private float offsetX, offsetY;

    private static bool MousePressReleased = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
#if UNITY_ANDROID
        
        if (Input.touchCount > 0)
        {
            doigtCheck = Input.GetTouch(0);
            OntouchBegin(doigtCheck);
            OntouchDrag(doigtCheck);
            OntouchEnd(doigtCheck);
        }
#endif
    }

    #region(DragSouris)
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
    #endregion

    #region(fusion)
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

        if (MousePressReleased && ThisGameObjectName == "fire" && CollisionGameObjectName == "water")
        {
            Instantiate(Resources.Load("Prefab/mist_object"), transform.position, Quaternion.identity);
            MousePressReleased = false;
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }

        if (MousePressReleased && ThisGameObjectName == "fire" && CollisionGameObjectName == "wind")
        {
            Instantiate(Resources.Load("Prefab/electricity_object"), transform.position, Quaternion.identity);
            MousePressReleased = false;
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }

        if (MousePressReleased && ThisGameObjectName == "water" && CollisionGameObjectName == "ground")
        {
            Instantiate(Resources.Load("Prefab/mud_object"), transform.position, Quaternion.identity);
            MousePressReleased = false;
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }

        if (MousePressReleased && ThisGameObjectName == "water" && CollisionGameObjectName == "wind")
        {
            Instantiate(Resources.Load("Prefab/frost_object"), transform.position, Quaternion.identity);
            MousePressReleased = false;
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }

        if (MousePressReleased && ThisGameObjectName == "wind" && CollisionGameObjectName == "ground")
        {
            Instantiate(Resources.Load("Prefab/sand_object"), transform.position, Quaternion.identity);
            MousePressReleased = false;
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }


        if (MousePressReleased && ThisGameObjectName == "ice" && CollisionGameObjectName == "fire")
        {
            Instantiate(Resources.Load("Prefab/water_object"), transform.position, Quaternion.identity);
            MousePressReleased = false;
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }

        if (MousePressReleased && ThisGameObjectName == "water" && CollisionGameObjectName == "frost")
        {
            Instantiate(Resources.Load("Prefab/ice_object"), transform.position, Quaternion.identity);
            MousePressReleased = false;
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }

        if (MousePressReleased && ThisGameObjectName == "mud" && CollisionGameObjectName == "wind")
        {
            Instantiate(Resources.Load("Prefab/grass_object"), transform.position, Quaternion.identity);
            MousePressReleased = false;
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }

        if (MousePressReleased && ThisGameObjectName == "grass" && CollisionGameObjectName == "light")
        {
            Instantiate(Resources.Load("Prefab/wood_object"), transform.position, Quaternion.identity);
            MousePressReleased = false;
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }

        if (MousePressReleased && ThisGameObjectName == "lava" && CollisionGameObjectName == "water")
        {
            Instantiate(Resources.Load("Prefab/rock_object"), transform.position, Quaternion.identity);
            MousePressReleased = false;
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }

        if (MousePressReleased && ThisGameObjectName == "electricity" && CollisionGameObjectName == "fire")
        {
            Instantiate(Resources.Load("Prefab/light_object"), transform.position, Quaternion.identity);
            MousePressReleased = false;
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }

        if (MousePressReleased && ThisGameObjectName == "rock" && CollisionGameObjectName == "sand")
        {
            Instantiate(Resources.Load("Prefab/ground_object"), transform.position, Quaternion.identity);
            MousePressReleased = false;
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }

    }
    #endregion

    #region(DragTactile)
    private void OntouchBegin(Touch doigt)
    {
        

        if (doigt.phase == TouchPhase.Began)
        {
            MousePressReleased = false;
            if (Vector2.Distance(doigt.rawPosition, new Vector2(transform.position.x, transform.position.y)) < 0.5f)
            {
                is_moving = true;
                offsetX = Camera.main.ScreenToWorldPoint(doigt.position).x - transform.position.x;
                offsetY = Camera.main.ScreenToWorldPoint(doigt.position).y - transform.position.y;
            }
        }
    }

    private void OntouchDrag(Touch doigt)
    {
        if (doigt.phase == TouchPhase.Moved)
        {
            if (is_moving)
            {
                doigt.position = Camera.main.ScreenToWorldPoint(doigt.position);
                transform.position = new Vector2(doigt.position.x - offsetX, doigt.position.y - offsetY);
            }
        }
    }

    private void OntouchEnd(Touch doigt)
    {
        if (doigt.phase == TouchPhase.Ended)
        {
            MousePressReleased = true;
            is_moving = false;
        }
    }
    #endregion
}