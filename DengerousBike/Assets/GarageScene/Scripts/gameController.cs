using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using UnityEngine.UI;

public class gameController : MonoBehaviour
{
    private Vector2 m_touchStartPosition;
    [SerializeField] float m_minSwipeDistance = 10.0f;
    [SerializeField] Animator m_transitionAnim;
    [SerializeField] AudioSource ClickSound;
    [SerializeField] AudioSource MoveSceneSound;
    [SerializeField] AudioSource Maincamera;
    [SerializeField] GameObject[] Bikes;
    [SerializeField] Text CoinLable;

    public GameObject bikeType;
    private float Scroll;

    int coin;

    int[] bikePrices = new int[4];

    void Start ()
    {
        coin = PlayerPrefs.GetInt("Coin", 0);
        CoinLable.text = coin.ToString();

        bikePrices[0] = 0;
        bikePrices[1] = 100; //BikeBlue
        bikePrices[2] = 200; //BikeShark
        bikePrices[3] = 300; //BikeBlack

        UpdateBikes();
    }

    void UpdateBikes()
    {
        bool firstBike = false;
        foreach (var bike in Bikes)
        {
            if (firstBike)
                continue;

            CoinLable.text = coin.ToString();

            bool unlocked = PlayerPrefs.GetInt("Unlocked" + bike.name, 0) == 0 ? false : true;

            if (unlocked)
            {
                bike.GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
                bike.tag = "Unlocked";
            }
        }
    }
	
	void Update ()
    {
        BikeScroll();
	}

    void BikeScroll()
    {
#if !UNITY_EDITOR && !UNITY_STANDALONE
        if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began) 
		{
			m_touchStartPosition = Input.GetTouch(0).position;
		}
        if (Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            Vector2 swipeDelta = (Input.GetTouch(0).position - m_touchStartPosition);
            if (swipeDelta.magnitude < m_minSwipeDistance)
            {
                return;
            }
            swipeDelta.Normalize();

            //right
            if (swipeDelta.x > 0.0f && swipeDelta.y > -0.5f && swipeDelta.y < 0.5f)
            {
                if (Scroll < 0)
                {
                    Scroll += 6f;
                    StartCoroutine(MoveOverSeconds(bikeType, new Vector3(Scroll, -1.5f, 0), 0.5f));
                }
            }
            //left
            else if (swipeDelta.x < 0.0f && swipeDelta.y > -0.5f && swipeDelta.y < 0.5f)
            {
                if(Scroll > (Bikes.Length - 1) * -6)
                {
                    Scroll -= 6f;
                    StartCoroutine(MoveOverSeconds(bikeType, new Vector3(Scroll, -1.5f, 0), 0.5f));
                }
            }
        }
#endif
    }

    public void Button()
    {
        if (Scroll < 0)
        {
            Scroll += 6;
            StartCoroutine(MoveOverSeconds(bikeType, new Vector3(Scroll, -1.5f, 0), 0.5f));
        }
    }

    public void Button2()
    {
        if (Scroll > (Bikes.Length - 1) * -6)
        {
            Scroll -= 6;
            StartCoroutine(MoveOverSeconds(bikeType, new Vector3(Scroll, -1.5f, 0), 0.5f));
        }
    }

    public void OnStartButtonClicked()
    {
        int bikeNum = (int)Scroll / 6;
        bikeNum *= -1;

        Debug.Log(bikeNum);
        if(Bikes[bikeNum].tag == "Unlocked")
        {
            ClickSound.Play();
            PlayerPrefs.SetInt("SelectedBike", bikeNum);
            m_transitionAnim.SetBool("start", true);
            MoveScene();
            Invoke("MainSceneChange", 2.5f);
        }        
    }
    public void BuyButtonClicked()
    {
        ClickSound.Play();
        int bikeNum = (int)Scroll / 6;
        bikeNum *= -1;
        Debug.Log(bikeNum);
        if (coin >= bikePrices[bikeNum])
        {
            coin -= bikePrices[bikeNum];
            Bikes[bikeNum].GetComponent<BoxCollider2D>().enabled = false;
            Bikes[bikeNum].tag = "Unlocked";
            SaveBikeStates();
            UpdateBikes();
            Bikes[bikeNum].GetComponent<BoxCollider2D>().enabled = true;
        }
    }

    void SaveBikeStates()
    {
        foreach(var bike in Bikes)
        {
            if(bike.tag == "Unlocked")
            {
                PlayerPrefs.SetInt("Unlocked" + bike.name, 1);
            }
        }

        PlayerPrefs.SetInt("Coin", coin);
        PlayerPrefs.Save();
    }

    void MainSceneChange()
    {
        SceneManager.LoadScene("main");
    }

    void MoveScene()
    {
        Maincamera.GetComponent<AudioSource>().Stop();
        MoveSceneSound.time = 2;
        MoveSceneSound.Play();
    }

    public void OptionSceneChange()
    {
        ClickSound.Play();
        SceneManager.LoadScene("Option");
    }
    
    IEnumerator MoveOverSpeed(GameObject objectToMove,Vector3 end,float speed)
    {
        while(objectToMove.transform.position != end)
        {
            objectToMove.transform.position = Vector3.MoveTowards(objectToMove.transform.position, end, speed * Time.deltaTime);
            yield return new WaitForEndOfFrame();
        }
    }
    public IEnumerator MoveOverSeconds(GameObject objectToMove,Vector3 end,float seconds)
    {
        float elapsedTime = 0;
        Vector3 startingPos = objectToMove.transform.position;
        while(elapsedTime <seconds)
        {
            bikeType.transform.position = Vector3.Lerp(startingPos, end, (elapsedTime / seconds));
            elapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        transform.position = end;
    }
}
