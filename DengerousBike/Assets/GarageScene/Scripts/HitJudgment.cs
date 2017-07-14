using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HitJudgment : MonoBehaviour
{
    [SerializeField] GameObject Next;
    [SerializeField] GameObject BuyBike;

    void Start ()
    {
        Next.GetComponent<Button>().interactable = false;
        BuyBike.GetComponent<Button>().interactable = false;
    }
	
	void Update ()
    {
		
	}

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.gameObject.CompareTag("Unlocked"))
        {
            Next.GetComponent<Button>().interactable = true;
            BuyBike.GetComponent<Button>().interactable = false;

        }

        if(collision.transform.gameObject.CompareTag("Purchasable"))
        {
            BuyBike.GetComponent<Button>().interactable = true;
            Next.GetComponent<Button>().interactable = false;
        }
    }
}
