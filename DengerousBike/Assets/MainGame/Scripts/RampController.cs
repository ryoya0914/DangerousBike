using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RampController : MonoBehaviour
{
    public bool Jump = false;
    public float flap = 1000f;
    Rigidbody2D rb2d;

    void Start ()
    {
        rb2d = GetComponent<Rigidbody2D>();
	}
	
	void Update ()
    {
		
	}

    void OnCollisionEnter2D(Collision2D collision)
    {

    }
}
