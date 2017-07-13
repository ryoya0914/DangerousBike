using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleControllerRed : MonoBehaviour
{
    [SerializeField]GameObject ExposionEfect;
    [SerializeField]
    Transform[] LanePosition;
    [SerializeField]
    GameObject Obstacle;
    [SerializeField]
    GameController gamecontroller;



    void Start()
    {
        ChangeHeight();
    }

    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.gameObject.CompareTag("player"))
        {
            gamecontroller.GameOver();
        }
        if(collision.gameObject.name == "truckBlue")
        {
            var exp = PoolManager.SpawnObject(ExposionEfect);
            exp.transform.position = transform.position;
            collision.gameObject.GetComponent<SpriteRenderer>().enabled = false;
            collision.gameObject.GetComponent<BoxCollider2D>().enabled = false;
        }
    }

    public void ChangeHeight()
    {
        int Index = Random.Range(0, 4);
        Obstacle.transform.localPosition = new Vector3(Obstacle.transform.localPosition.x, LanePosition[Index].position.y + 0.2f, 1);

        float baseScale = 1.2f + (float)Index / 10.0f;
        Obstacle.tag = "TruckRed" + (Index + 1).ToString();
        Obstacle.transform.localScale = new Vector3(baseScale, baseScale, 1);
    }
}
