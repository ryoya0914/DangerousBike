using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrackController : MonoBehaviour
{

	void Start ()
    {
		
	}
	
	void Update ()
    {
		
	}

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.gameObject.CompareTag("player"))
        {
            collision.gameObject.GetComponent<BikeController>().StopBike();
            GameObject.Find("Canvas/up").GetComponent<Button>().enabled = false;
            GameObject.Find("Canvas/down").GetComponent<Button>().enabled = false;
            GameObject.Find("GameOver").GetComponent<Canvas>().enabled = true;
            var foreground = GameObject.Find("ForeGroundGenerator");
            foreground.GetComponent<ForeGroundGenerator>().enabled = false;
            foreground.GetComponent<ForeGroundGenerator>().StopAllCoroutines();
            var background = GameObject.Find("BackGroundGenerator");
            background.GetComponent<BackGroundGenerator>().enabled = false;
            background.GetComponent<BackGroundGenerator>().StopAllCoroutines();
        }
    }
}
