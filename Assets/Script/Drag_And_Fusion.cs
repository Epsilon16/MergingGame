using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Android;
using UnityEngine.UI;

public class Drag_And_Fusion : MonoBehaviour
{
    #region(variable)
    private Touch doigtCheck;
    private Vector2 mousePosition;

    private bool is_moving;
    //private Vector2 touchPosition;

    private float offsetX, offsetY;

    private static bool MousePressReleased = true;

    //public bool[] is_good_fusion;
    public string[] FusionName;
    public Image [] image_Fusion;
    #endregion
    // Start is called before the first frame update
    void Start()
    {
        for (int i =0; i < FusionName.Length; i++)
        {
            Debug.Log("Find");
            image_Fusion[i] = GameObject.Find(FusionName[i]).GetComponent<Image>();
        }
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
            image_Fusion[0].color = Color.white;
        }

        if (MousePressReleased && ThisGameObjectName == "fire" && CollisionGameObjectName == "water")
        {
            Instantiate(Resources.Load("Prefab/mist_object"), transform.position, Quaternion.identity);
            MousePressReleased = false;
            Destroy(collision.gameObject);
            Destroy(gameObject);
            image_Fusion[1].color = Color.white;


        }

        if (MousePressReleased && ThisGameObjectName == "fire" && CollisionGameObjectName == "wind")
        {
            Instantiate(Resources.Load("Prefab/electricity_object"), transform.position, Quaternion.identity);
            MousePressReleased = false;
            Destroy(collision.gameObject);
            Destroy(gameObject);
            image_Fusion[2].color = Color.white;
        }

        if (MousePressReleased && ThisGameObjectName == "water" && CollisionGameObjectName == "ground")
        {
            Instantiate(Resources.Load("Prefab/mud_object"), transform.position, Quaternion.identity);
            MousePressReleased = false;
            Destroy(collision.gameObject);
            Destroy(gameObject);
            image_Fusion[3].color = Color.white;
        }

        if (MousePressReleased && ThisGameObjectName == "water" && CollisionGameObjectName == "wind")
        {
            Instantiate(Resources.Load("Prefab/frost_object"), transform.position, Quaternion.identity);
            MousePressReleased = false;
            Destroy(collision.gameObject);
            Destroy(gameObject);
            image_Fusion[5].color = Color.white;
        }

        if (MousePressReleased && ThisGameObjectName == "wind" && CollisionGameObjectName == "ground")
        {
            Instantiate(Resources.Load("Prefab/sand_object"), transform.position, Quaternion.identity);
            MousePressReleased = false;
            Destroy(collision.gameObject);
            Destroy(gameObject);
            image_Fusion[4].color = Color.white;
        }


        if (MousePressReleased && ThisGameObjectName == "ice" && CollisionGameObjectName == "fire")
        {
            Instantiate(Resources.Load("Prefab/water_object"), transform.position, Quaternion.identity);
            MousePressReleased = false;
            Destroy(collision.gameObject);
            Destroy(gameObject);
            image_Fusion[7].color = Color.white;
        }

        if (MousePressReleased && ThisGameObjectName == "water" && CollisionGameObjectName == "frost")
        {
            Instantiate(Resources.Load("Prefab/ice_object"), transform.position, Quaternion.identity);
            MousePressReleased = false;
            Destroy(collision.gameObject);
            Destroy(gameObject);
            image_Fusion[6].color = Color.white;
        }

        if (MousePressReleased && ThisGameObjectName == "mud" && CollisionGameObjectName == "wind")
        {
            Instantiate(Resources.Load("Prefab/grass_object"), transform.position, Quaternion.identity);
            MousePressReleased = false;
            Destroy(collision.gameObject);
            Destroy(gameObject);
            image_Fusion[8].color = Color.white;
        }

        if (MousePressReleased && ThisGameObjectName == "grass" && CollisionGameObjectName == "light")
        {
            Instantiate(Resources.Load("Prefab/wood_object"), transform.position, Quaternion.identity);
            MousePressReleased = false;
            Destroy(collision.gameObject);
            Destroy(gameObject);
            image_Fusion[9].color = Color.white;
        }

        if (MousePressReleased && ThisGameObjectName == "lava" && CollisionGameObjectName == "water")
        {
            Instantiate(Resources.Load("Prefab/rock_object"), transform.position, Quaternion.identity);
            MousePressReleased = false;
            Destroy(collision.gameObject);
            Destroy(gameObject);
            image_Fusion[10].color = Color.white;
        }

        if (MousePressReleased && ThisGameObjectName == "electricity" && CollisionGameObjectName == "fire")
        {
            Instantiate(Resources.Load("Prefab/light_object"), transform.position, Quaternion.identity);
            MousePressReleased = false;
            Destroy(collision.gameObject);
            Destroy(gameObject);
            image_Fusion[11].color = Color.white;
        }

        if (MousePressReleased && ThisGameObjectName == "rock" && CollisionGameObjectName == "sand")
        {
            Instantiate(Resources.Load("Prefab/ground_object"), transform.position, Quaternion.identity);
            MousePressReleased = false;
            Destroy(collision.gameObject);
            Destroy(gameObject);
            image_Fusion[12].color = Color.white;
        }

        if (MousePressReleased && ThisGameObjectName == "fire" && CollisionGameObjectName == "grass")
        {
            Instantiate(Resources.Load("Prefab/scorch_object"), transform.position, Quaternion.identity);
            MousePressReleased = false;
            Destroy(collision.gameObject);
            Destroy(gameObject);
            image_Fusion[13].color = Color.white;
        }

        if (MousePressReleased && ThisGameObjectName == "fire" && CollisionGameObjectName == "mist")
        {
            Instantiate(Resources.Load("Prefab/boom_object"), transform.position, Quaternion.identity);
            MousePressReleased = false;
            Destroy(collision.gameObject);
            Destroy(gameObject);
            image_Fusion[14].color = Color.white;
        }

        if (MousePressReleased && ThisGameObjectName == "fire" && CollisionGameObjectName == "wood")
        {
            Instantiate(Resources.Load("Prefab/burnt_object"), transform.position, Quaternion.identity);
            MousePressReleased = false;
            Destroy(collision.gameObject);
            Destroy(gameObject);
            image_Fusion[15].color = Color.white;
        }

        if (MousePressReleased && ThisGameObjectName == "electricity" && CollisionGameObjectName == "mist")
        {
            Instantiate(Resources.Load("Prefab/storm_object"), transform.position, Quaternion.identity);
            MousePressReleased = false;
            Destroy(collision.gameObject);
            Destroy(gameObject);
            image_Fusion[16].color = Color.white;
        }

        if (MousePressReleased && ThisGameObjectName == "fire" && CollisionGameObjectName == "rock")
        {
            Instantiate(Resources.Load("Prefab/steel_object"), transform.position, Quaternion.identity);
            MousePressReleased = false;
            Destroy(collision.gameObject);
            Destroy(gameObject);
            image_Fusion[17].color = Color.white;
        }

        if (MousePressReleased && ThisGameObjectName == "ground" && CollisionGameObjectName == "steel")
        {
            Instantiate(Resources.Load("Prefab/magnet_object"), transform.position, Quaternion.identity);
            MousePressReleased = false;
            Destroy(collision.gameObject);
            Destroy(gameObject);
            image_Fusion[18].color = Color.white;
        }

        if (MousePressReleased && ThisGameObjectName == "ground" && CollisionGameObjectName == "lava")
        {
            Instantiate(Resources.Load("Prefab/cristal_object"), transform.position, Quaternion.identity);
            MousePressReleased = false;
            Destroy(collision.gameObject);
            Destroy(gameObject);
            image_Fusion[19].color = Color.white;
        }

        if (MousePressReleased && ThisGameObjectName == "light" && CollisionGameObjectName == "electricity")
        {
            Instantiate(Resources.Load("Prefab/speed_object"), transform.position, Quaternion.identity);
            MousePressReleased = false;
            Destroy(collision.gameObject);
            Destroy(gameObject);
            image_Fusion[20].color = Color.white;
        }

        if (MousePressReleased && ThisGameObjectName == "lava" && CollisionGameObjectName == "burnt")
        {
            Instantiate(Resources.Load("Prefab/dark_object"), transform.position, Quaternion.identity);
            MousePressReleased = false;
            Destroy(collision.gameObject);
            Destroy(gameObject);
            image_Fusion[21].color = Color.white;
        }

        if (MousePressReleased && ThisGameObjectName == "light" && CollisionGameObjectName == "cristal")
        {
            Instantiate(Resources.Load("Prefab/yin_object"), transform.position, Quaternion.identity);
            MousePressReleased = false;
            Destroy(collision.gameObject);
            Destroy(gameObject);
            image_Fusion[20].color = Color.white;
        }

        if (MousePressReleased && ThisGameObjectName == "dark" && CollisionGameObjectName == "storm")
        {
            Instantiate(Resources.Load("Prefab/yang_object"), transform.position, Quaternion.identity);
            MousePressReleased = false;
            Destroy(collision.gameObject);
            Destroy(gameObject);
            image_Fusion[20].color = Color.white;
        }

        if (MousePressReleased && ThisGameObjectName == "yin" && CollisionGameObjectName == "yang")
        {
            Instantiate(Resources.Load("Prefab/yinyang_object"), transform.position, Quaternion.identity);
            MousePressReleased = false;
            Destroy(collision.gameObject);
            Destroy(gameObject);
            image_Fusion[20].color = Color.white;
        }

    }
    #endregion

    #region(effetFusion)
    private void OnTriggerEnter2D(Collider2D collision)
    {
        string ThisGameObjectName = gameObject.name.Substring(0, name.IndexOf("_"));
        string CollisionGameObjectName = collision.gameObject.name.Substring(0, collision.gameObject.name.IndexOf("_"));

        if ((ThisGameObjectName == "fire" && CollisionGameObjectName == "ground") || (ThisGameObjectName == "ground" && CollisionGameObjectName == "fire"))
        {
            StartCoroutine(FusionEffect());
        }
        if ((ThisGameObjectName == "fire" && CollisionGameObjectName == "water") || (ThisGameObjectName == "water" && CollisionGameObjectName == "fire"))
        {
            StartCoroutine(FusionEffect());
        }
        if ((ThisGameObjectName == "fire" && CollisionGameObjectName == "wind") || (ThisGameObjectName == "wind" && CollisionGameObjectName == "fire"))
        {
            StartCoroutine(FusionEffect());
        }
        if ((ThisGameObjectName == "water" && CollisionGameObjectName == "ground") || (ThisGameObjectName == "ground" && CollisionGameObjectName == "water"))
        {
            StartCoroutine(FusionEffect());
        }
        if ((ThisGameObjectName == "water" && CollisionGameObjectName == "wind") || (ThisGameObjectName == "wind" && CollisionGameObjectName == "water"))
        {
            StartCoroutine(FusionEffect());
        }
        if ((ThisGameObjectName == "wind" && CollisionGameObjectName == "ground") || (ThisGameObjectName == "ground" && CollisionGameObjectName == "wind"))
        {
            StartCoroutine(FusionEffect());
        }
        if ((ThisGameObjectName == "ice" && CollisionGameObjectName == "fire") || (ThisGameObjectName == "fire" && CollisionGameObjectName == "ice"))
        {
            StartCoroutine(FusionEffect());
        }
        if ((ThisGameObjectName == "water" && CollisionGameObjectName == "frost") || (ThisGameObjectName == "frost" && CollisionGameObjectName == "water"))
        {
            StartCoroutine(FusionEffect());
        }
        if ((ThisGameObjectName == "mud" && CollisionGameObjectName == "wind") || (ThisGameObjectName == "wind" && CollisionGameObjectName == "mud"))
        {
            StartCoroutine(FusionEffect());
        }
        if ((ThisGameObjectName == "grass" && CollisionGameObjectName == "light") || (ThisGameObjectName == "light" && CollisionGameObjectName == "grass"))
        {
            StartCoroutine(FusionEffect());
        }
        if ((ThisGameObjectName == "lava" && CollisionGameObjectName == "water") || (ThisGameObjectName == "water" && CollisionGameObjectName == "lava"))
        {
            StartCoroutine(FusionEffect());
        }
        if ((ThisGameObjectName == "electricity" && CollisionGameObjectName == "fire") || (ThisGameObjectName == "fire" && CollisionGameObjectName == "electricity"))
        {
            StartCoroutine(FusionEffect());
        }
        if ((ThisGameObjectName == "rock" && CollisionGameObjectName == "sand") || (ThisGameObjectName == "sand" && CollisionGameObjectName == "rock"))
        {
            StartCoroutine(FusionEffect());
        }
        if ((ThisGameObjectName == "fire" && CollisionGameObjectName == "grass") || (ThisGameObjectName == "grass" && CollisionGameObjectName == "fire"))
        {
            StartCoroutine(FusionEffect());
        }
        if ((ThisGameObjectName == "fire" && CollisionGameObjectName == "mist") || (ThisGameObjectName == "mist" && CollisionGameObjectName == "fire"))
        {
            StartCoroutine(FusionEffect());
        }
        if ((ThisGameObjectName == "fire" && CollisionGameObjectName == "wood") || (ThisGameObjectName == "wood" && CollisionGameObjectName == "fire"))
        {
            StartCoroutine(FusionEffect());
        }
        if ((ThisGameObjectName == "electricity" && CollisionGameObjectName == "mist") || (ThisGameObjectName == "mist" && CollisionGameObjectName == "electricity"))
        {
            StartCoroutine(FusionEffect());
        }
        if ((ThisGameObjectName == "fire" && CollisionGameObjectName == "rock") || (ThisGameObjectName == "rock" && CollisionGameObjectName == "fire"))
        {
            StartCoroutine(FusionEffect());
        }
        if ((ThisGameObjectName == "ground" && CollisionGameObjectName == "steel") || (ThisGameObjectName == "steel" && CollisionGameObjectName == "ground"))
        {
            StartCoroutine(FusionEffect());
        }
        if ((ThisGameObjectName == "ground" && CollisionGameObjectName == "lava") || (ThisGameObjectName == "lava" && CollisionGameObjectName == "ground"))
        {
            StartCoroutine(FusionEffect());
        }
        if ((ThisGameObjectName == "light" && CollisionGameObjectName == "electricity") || (ThisGameObjectName == "electricity" && CollisionGameObjectName == "light"))
        {
            StartCoroutine(FusionEffect());
        }
        if ((ThisGameObjectName == "lava" && CollisionGameObjectName == "burnt") || (ThisGameObjectName == "burnt" && CollisionGameObjectName == "lava"))
        {
            StartCoroutine(FusionEffect());
        }
        if ((ThisGameObjectName == "light" && CollisionGameObjectName == "cristal") || (ThisGameObjectName == "cristal" && CollisionGameObjectName == "light"))
        {
            StartCoroutine(FusionEffect());
        }
        if ((ThisGameObjectName == "dark" && CollisionGameObjectName == "storm") || (ThisGameObjectName == "storm" && CollisionGameObjectName == "dark"))
        {
            StartCoroutine(FusionEffect());
        }
        if ((ThisGameObjectName == "yin" && CollisionGameObjectName == "yang") || (ThisGameObjectName == "yang" && CollisionGameObjectName == "yin"))
        {
            StartCoroutine(FusionEffect());
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        string ThisGameObjectName = gameObject.name.Substring(0, name.IndexOf("_"));
        string CollisionGameObjectName = collision.gameObject.name.Substring(0, collision.gameObject.name.IndexOf("_"));

        if ((ThisGameObjectName == "fire" && CollisionGameObjectName == "ground") || (ThisGameObjectName == "ground" && CollisionGameObjectName == "fire"))
        {
            StartCoroutine(DefusionEffect());
        }
        if ((ThisGameObjectName == "fire" && CollisionGameObjectName == "water") || (ThisGameObjectName == "water" && CollisionGameObjectName == "fire"))
        {
            StartCoroutine(DefusionEffect());
        }
        if ((ThisGameObjectName == "fire" && CollisionGameObjectName == "wind") || (ThisGameObjectName == "wind" && CollisionGameObjectName == "fire"))
        {
            StartCoroutine(DefusionEffect());
        }
        if ((ThisGameObjectName == "water" && CollisionGameObjectName == "ground") || (ThisGameObjectName == "ground" && CollisionGameObjectName == "water"))
        {
            StartCoroutine(DefusionEffect());
        }
        if ((ThisGameObjectName == "water" && CollisionGameObjectName == "wind") || (ThisGameObjectName == "wind" && CollisionGameObjectName == "water"))
        {
            StartCoroutine(DefusionEffect());
        }
        if ((ThisGameObjectName == "wind" && CollisionGameObjectName == "ground") || (ThisGameObjectName == "ground" && CollisionGameObjectName == "wind"))
        {
            StartCoroutine(DefusionEffect());
        }
        if ((ThisGameObjectName == "ice" && CollisionGameObjectName == "fire") || (ThisGameObjectName == "fire" && CollisionGameObjectName == "ice"))
        {
            StartCoroutine(DefusionEffect());
        }
        if ((ThisGameObjectName == "water" && CollisionGameObjectName == "frost") || (ThisGameObjectName == "frost" && CollisionGameObjectName == "water"))
        {
            StartCoroutine(DefusionEffect());
        }
        if ((ThisGameObjectName == "mud" && CollisionGameObjectName == "wind") || (ThisGameObjectName == "wind" && CollisionGameObjectName == "mud"))
        {
            StartCoroutine(DefusionEffect());
        }
        if ((ThisGameObjectName == "grass" && CollisionGameObjectName == "light") || (ThisGameObjectName == "light" && CollisionGameObjectName == "grass"))
        {
            StartCoroutine(DefusionEffect());
        }
        if ((ThisGameObjectName == "lava" && CollisionGameObjectName == "water") || (ThisGameObjectName == "water" && CollisionGameObjectName == "lava"))
        {
            StartCoroutine(DefusionEffect());
        }
        if ((ThisGameObjectName == "electricity" && CollisionGameObjectName == "fire") || (ThisGameObjectName == "fire" && CollisionGameObjectName == "electricity"))
        {
            StartCoroutine(DefusionEffect());
        }
        if ((ThisGameObjectName == "rock" && CollisionGameObjectName == "sand") || (ThisGameObjectName == "sand" && CollisionGameObjectName == "rock"))
        {
            StartCoroutine(DefusionEffect());
        }
        if ((ThisGameObjectName == "fire" && CollisionGameObjectName == "grass") || (ThisGameObjectName == "grass" && CollisionGameObjectName == "fire"))
        {
            StartCoroutine(DefusionEffect());
        }
        if ((ThisGameObjectName == "fire" && CollisionGameObjectName == "mist") || (ThisGameObjectName == "mist" && CollisionGameObjectName == "fire"))
        {
            StartCoroutine(DefusionEffect());
        }
        if ((ThisGameObjectName == "fire" && CollisionGameObjectName == "wood") || (ThisGameObjectName == "wood" && CollisionGameObjectName == "fire"))
        {
            StartCoroutine(DefusionEffect());
        }
        if ((ThisGameObjectName == "electricity" && CollisionGameObjectName == "mist") || (ThisGameObjectName == "mist" && CollisionGameObjectName == "electricity"))
        {
            StartCoroutine(DefusionEffect());
        }
        if ((ThisGameObjectName == "fire" && CollisionGameObjectName == "rock") || (ThisGameObjectName == "rock" && CollisionGameObjectName == "fire"))
        {
            StartCoroutine(DefusionEffect());
        }
        if ((ThisGameObjectName == "ground" && CollisionGameObjectName == "steel") || (ThisGameObjectName == "steel" && CollisionGameObjectName == "ground"))
        {
            StartCoroutine(DefusionEffect());
        }
        if ((ThisGameObjectName == "ground" && CollisionGameObjectName == "lava") || (ThisGameObjectName == "lava" && CollisionGameObjectName == "ground"))
        {
            StartCoroutine(DefusionEffect());
        }
        if ((ThisGameObjectName == "light" && CollisionGameObjectName == "electricity") || (ThisGameObjectName == "electricity" && CollisionGameObjectName == "light"))
        {
            StartCoroutine(DefusionEffect());
        }
        if ((ThisGameObjectName == "lava" && CollisionGameObjectName == "burnt") || (ThisGameObjectName == "burnt" && CollisionGameObjectName == "lava"))
        {
            StartCoroutine(DefusionEffect());
        }
        if ((ThisGameObjectName == "light" && CollisionGameObjectName == "cristal") || (ThisGameObjectName == "cristal" && CollisionGameObjectName == "light"))
        {
            StartCoroutine(DefusionEffect());
        }
        if ((ThisGameObjectName == "dark" && CollisionGameObjectName == "storm") || (ThisGameObjectName == "storm" && CollisionGameObjectName == "dark"))
        {
            StartCoroutine(DefusionEffect());
        }
        if ((ThisGameObjectName == "yin" && CollisionGameObjectName == "yang") || (ThisGameObjectName == "yang" && CollisionGameObjectName == "yin"))
        {
            StartCoroutine(DefusionEffect());
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

    #region(Couroutine)
    IEnumerator FusionEffect()
    {
        float elapsedTime = 0;
        float waitTime = 0.5f;
        while (elapsedTime < waitTime)
        {
            transform.localScale = Vector2.Lerp(transform.localScale, new Vector2(3, 3), elapsedTime / waitTime);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        transform.localScale = new Vector2(3, 3);
        yield return null;
    }

    IEnumerator DefusionEffect()
    {
        float elapsedTime = 0;
        float waitTime = 0.5f;
        while (elapsedTime < waitTime)
        {
            transform.localScale = Vector2.Lerp(transform.localScale, new Vector2(2, 2), elapsedTime / waitTime);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        transform.localScale = new Vector2(2, 2);
        yield return null;
    }
    #endregion
}