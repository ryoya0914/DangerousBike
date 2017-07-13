using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HitJudgment : MonoBehaviour
{
    [SerializeField] GameObject Next;
    [SerializeField] GameObject BuyBike;
    [SerializeField] Text CoinLable;
    int coin;

    void Start ()
    {
        coin = PlayerPrefs.GetInt("Coin", 0);
        CoinLable.text = coin.ToString();

        Next.GetComponent<Button>().interactable = false;
        BuyBike.GetComponent<Button>().interactable = false;
    }
	
	void Update ()
    {
		
	}

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.gameObject.CompareTag("BikeRed"))
        {
            Next.GetComponent<Button>().interactable = true;
        }

        if (collision.transform.gameObject.CompareTag("BikeBlue"))
        {
            if(coin >= 1)
            {
                BuyBike.GetComponent<Button>().interactable = true;
            }
            else
            {
                BuyBike.GetComponent<Button>().interactable = false;
            }

        }

        if (collision.transform.gameObject.CompareTag("BikeShark"))
        {
            if (coin >= 10)
            {
                BuyBike.GetComponent<Button>().interactable = true;
            }
            else
            {
                BuyBike.GetComponent<Button>().interactable = false;
            }
        }
    }
}
