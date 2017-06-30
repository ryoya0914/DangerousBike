using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class ScrollController : MonoBehaviour
{

    private Vector2 m_touchStartPosition;
    [SerializeField]
    float m_minSwipeDistance = 10.0f;
    [SerializeField]
    Animator m_transitionAnim;
    public GameObject bikeType;
    private float Scroll;
    private int BikeRed = 0;
    private int BikeBlue = -6;
    private int BikeShark = -12;
    void Start ()
    {
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
                if(Scroll > -12)
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
        if (Scroll < BikeRed)
        {
            Scroll += 6;
            StartCoroutine(MoveOverSeconds(bikeType, new Vector3(Scroll, -1.5f, 0), 0.5f));
        }
    }

    public void Button2()
    {
        if (Scroll > BikeShark)
        {
            Scroll -= 6;
            StartCoroutine(MoveOverSeconds(bikeType, new Vector3(Scroll, -1.5f, 0), 0.5f));
        }
    }

    public void OnStartButtonClicked()
    {
        m_transitionAnim.SetBool("start", true);
        Invoke("MainSceneChange", 1.0f);
    }

    void MainSceneChange()
    {
        SceneManager.LoadScene("main");
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
