using System.Collections;
using UnityEngine;

public class BikeController : MonoBehaviour
{
    public bool push = false;
    public float speed = 0;

    float movePower = 0.2f;
    Rigidbody2D rb2d;

    const int MinLane = 0;
    const int MaxLane = 4;
    const float LaneWidth = 1.0f;
    int targetLane;

	void Start ()
    {
        rb2d = GetComponent<Rigidbody2D>();

    }

    void FixedUpdate()
    {
        //*Time.deltaTime;
        if (push == true)
        {

            if (5 > speed)
            {
                speed += 1f;
                rb2d.velocity = new Vector3(speed, rb2d.velocity.y);
            }

        }
        else if (push == false)
        {
            if (0 < speed)
            {
                speed -= 0.5f;
                rb2d.velocity = new Vector3(speed, rb2d.velocity.y);
            }
        }
    }

    void Update()
    {

    }

    public void Accel()
    {
        push = true;

    }

    public void Brake()
    {
        push = false;

    }


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
    }
}
