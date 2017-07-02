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
            GameObject.Find("GameOver").GetComponent<Canvas>().enabled = true;
            var foreground = GameObject.Find("ForeGroundGenerator");
            foreground.GetComponent<GroundGenerator>().enabled = false;
            foreground.GetComponent<GroundGenerator>().StopAllCoroutines();
            var background = GameObject.Find("BackGroundGenerator");
            background.GetComponent<GroundGenerator>().enabled = false;
            background.GetComponent<GroundGenerator>().StopAllCoroutines();
        }
    }
}
