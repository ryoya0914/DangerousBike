using System.Collections;
using UnityEngine;

public class BikeController : MonoBehaviour
{
    public bool push = false;
    public float speed = 0;

    float movePower = 0.2f;
    Rigidbody2D rb2d;

    const int MinLane = -2;
    const int MaxLane = 2;
    const float LaneWidth = 1.0f;
    int targetLane;
    public GameObject wall;

	void Start ()
    {
        rb2d = GetComponent<Rigidbody2D>();

    }

    void Update()
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

    public void Accel()
    {
        push = true;

    }

    public void Brake()
    {
        push = false;

    }

    public void Left()
    {
        if (wall.isStatic && targetLane > MinLane) targetLane--;
    }

    public void Right()
    {
        if (wall.isStatic && targetLane > MinLane) targetLane++;
    }
}
