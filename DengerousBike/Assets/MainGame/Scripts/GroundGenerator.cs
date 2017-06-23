using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundGenerator : MonoBehaviour
{
    public float Speed = -1;
    public GameObject Bg01;
    public GameObject Bg02;

    void Start()
    {

    }

    void Update()
    {
        StartCoroutine(StartScene());
    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.gameObject.CompareTag("Bg1"))
        {
            Debug.Log("test");
        }
        else if(collision.transform.gameObject.CompareTag("Bg2"))
        {
            Debug.Log("test");
        }
    }


    IEnumerator StartScene()
    {
        yield return new WaitForSeconds(2);
        Bg01.transform.Translate(Speed * Time.deltaTime, 0, 0);
        Bg02.transform.Translate(Speed * Time.deltaTime, 0, 0);
    }
}
