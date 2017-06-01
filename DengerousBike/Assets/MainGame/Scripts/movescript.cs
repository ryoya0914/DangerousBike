using System.Collections;
using UnityEngine;

public class movescript : MonoBehaviour
{

    float speed = 0f;
    float movePower = 0.2f;
    bool push = false;
    Rigidbody2D rb2d;

	void Start ()
    {
        rb2d = GetComponent<Rigidbody2D>();

    }
	
	void Update ()
    {
        if(push)
        {

        }
    }

    void Accel()
    {
        speed += 3f;
        rb2d.velocity = new Vector3(rb2d.velocity.x + speed, rb2d.velocity.y);
    }

    void DownAccel()
    {
        speed -=2;
        rb2d.velocity = new Vector3(rb2d.velocity.x + speed, rb2d.velocity.y);
        if (speed < 0)
        {
            speed = 0;
        }
    }

    void Up()
    {
        push = true;
    }

    void Down()
    {
        push = false;
    }

    /*
    void Right()
    {
        if (transform.position.y <= 5f)
        {
            Vector2 temp = new Vector2(transform.position.x + movePower, transform.position.y);
            transform.position = temp;
        }

    }

    void Left()
    {
        if (transform.position.y <= 5f)
        {
            Vector2 temp = new Vector2(transform.position.x - movePower, transform.position.y);
            transform.position = temp;
        }
    }*/
}
