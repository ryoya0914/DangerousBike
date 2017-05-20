using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movescript : MonoBehaviour
{
    float spped = 0f;
    float movePower = 0.2f;
    Rigidbody2D rb2d;

	void Start ()
    {
        rb2d = GetComponent<Rigidbody2D>();
		
	}
	
	void Update ()
    {
	}
}
