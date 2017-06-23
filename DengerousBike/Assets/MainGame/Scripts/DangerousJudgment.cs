using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DangerousJudgment : MonoBehaviour
{
    public GameObject Icon1;
    public GameObject Icon2;
    public GameObject Icon3;
    public GameObject Icon4;
    void Start ()
    {
		
	}
	
	void Update ()
    {
		
	}

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.gameObject.CompareTag("Track1"))
        {
            Icon1.SetActive(true);
        }
        else
        {
            Icon1.SetActive(false);
        }

        if (collision.transform.gameObject.CompareTag("Track2"))
        {
            Icon2.SetActive(true);
        }
        else
        {
            Icon2.SetActive(false);
        }

        if (collision.transform.gameObject.CompareTag("Track3"))
        {
            Icon3.SetActive(true);
        }
        else
        {
            Icon3.SetActive(false);
        }

        if (collision.transform.gameObject.CompareTag("Track4"))
        {
            Icon4.SetActive(true);
        }
        else
        {
            Icon4.SetActive(false);
        }
    }

}
