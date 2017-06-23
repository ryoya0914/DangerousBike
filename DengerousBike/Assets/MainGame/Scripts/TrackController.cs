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
            collision.transform.gameObject.SetActive(false);
            GameObject.Find("Canvas/up").GetComponent<Button>().enabled = false;
            GameObject.Find("Canvas/down").GetComponent<Button>().enabled = false;
            GameObject.Find("GameOver").GetComponent<Canvas>().enabled = true;
        }
    }
}
