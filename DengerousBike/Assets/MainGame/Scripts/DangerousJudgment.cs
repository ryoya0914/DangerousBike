using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DangerousJudgment : MonoBehaviour
{
    public GameObject Icon1;
    public GameObject Icon2;
    public GameObject Icon3;
    public GameObject Icon4;
    public string trucktag;
    void Start ()
    {
		
	}
	
	void Update ()
    {
		
	}

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.gameObject.CompareTag(trucktag+"1"))
        {
            Icon1.SetActive(true);
        }

        if (collision.transform.gameObject.CompareTag(trucktag + "2"))
        {
            Icon2.SetActive(true);
        }

        if (collision.transform.gameObject.CompareTag(trucktag + "3"))
        {
            Icon3.SetActive(true);
        }

        if (collision.transform.gameObject.CompareTag(trucktag + "4"))
        {
            Icon4.SetActive(true);
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.gameObject.CompareTag(trucktag + "1"))
        {
            Icon1.SetActive(false);
        }

        if (collision.transform.gameObject.CompareTag(trucktag + "2"))
        {
            Icon2.SetActive(false);
        }

        if (collision.transform.gameObject.CompareTag(trucktag + "3"))
        {
            Icon3.SetActive(false);
        }

        if (collision.transform.gameObject.CompareTag(trucktag + "4"))
        {
            Icon4.SetActive(false);
        }
    }

}
