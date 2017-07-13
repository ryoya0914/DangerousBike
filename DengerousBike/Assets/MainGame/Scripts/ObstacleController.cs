using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObstacleController : MonoBehaviour
{
    [SerializeField] Transform[] LanePosition;
    [SerializeField] GameObject Obstacle;
    [SerializeField] GameController gamecontroller;
    //[SerializeField] GameObject thisObstacle;

    void Start ()
    {
        ChangeHeight();
	}
	
	void Update ()
    {

	}

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.gameObject.CompareTag("player"))
        {
            gamecontroller.GameOver();
        }
    }

    public void ChangeHeight()
    {
        int Index = Random.Range(0,4);
        Obstacle.transform.localPosition = new Vector3(Obstacle.transform.localPosition.x, LanePosition[Index].position.y+0.2f, 1);

        float baseScale = 1.2f + (float)Index / 10.0f;

        Obstacle.tag = "Track" + (Index + 1).ToString();
        Obstacle.transform.localScale = new Vector3(baseScale, baseScale, 1);
        //thisObstacle.transform.position = new Vector3(Random.Range(8f, 13f), thisObstacle.transform.position.y);
        gameObject.GetComponent<SpriteRenderer>().enabled = true;
        gameObject.GetComponent<BoxCollider2D>().enabled = true;
    }
}
