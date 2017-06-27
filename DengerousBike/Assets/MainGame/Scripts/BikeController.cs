using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BikeController : MonoBehaviour
{
    Animator animator;

    private Renderer renderer;
    public GameObject bike;

    public bool PushLeft = false;
    public bool PushRight = false;
    public bool Jump = false;
    public bool Moving = false;
    public float speed = 0;

    float movePower = 0.2f;
    Rigidbody2D rb2d;

    const int MinLane = -1;
    const int MaxLane = 2;
    const float LaneWidth = 1.0f;
    int targetLane;
    public GameObject wall;
    private bool stopped = false;


	void Start ()
    {
        rb2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        
    }

    void Update()
    {
        if (stopped)
            return;

        StartCoroutine(StartScene());

        if (PushLeft == true)
        {
            bike.transform.Rotate(0, 0, -2);
        }

        if (PushRight == true)
        {
            bike.transform.Rotate(0, 0, 2);
        }
        //rb2d.angularVelocity = new Vector3(2,rb2d.angularVelocity.z);

        /*else if (0 < speed)        //*Time.deltaTime;
        //{
           // speed -= 0.5f;
            //rb2d.velocity = new Vector3(speed, rb2d.velocity.y);
        }*/

    }



    public void Down()
    {
        if (targetLane > MinLane && !Moving)
        {
            Moving = true;
            ChangeLane(false);
        }
    }

    public void Up()
    {
        if (targetLane < MaxLane && !Moving)
        {
            Moving = true;
            ChangeLane(true);
        }
    }
    void ChangeLane(bool up)
    {
        var inc = up ? 1 : -1;
        targetLane += inc;
        var To = wall.transform.position;
        To.y += inc * 0.8f;
        StartCoroutine(MoveFormTo(wall.transform, wall.transform.position, To, 5.0f));
    }

    IEnumerator MoveFormTo(Transform ToMove,Vector3 Form,Vector3 To,float speed)
    {
        float step = (speed / (Form - To).magnitude) * Time.fixedDeltaTime;
        float t = 0;
        while (t <= 1.0f)
        {
            t += step;
            var newpos = Vector3.Lerp(Form, To, t);
            var currpos = ToMove.localPosition;
            currpos.y = newpos.y;
            currpos.x = 0;
            ToMove.localPosition = currpos;
            yield return new WaitForFixedUpdate();
        }

        var pos1 = Vector3.Lerp(Form, To, t);
        var pos2 = ToMove.localPosition;
        pos1.y = pos2.y;
        pos1.x = 0;
        ToMove.localPosition = pos1;
        Moving = false;
    }

    IEnumerator StartScene()
    {
        yield return new WaitForSeconds(2);
        if (5 > speed && !stopped)
        {
            speed += 0.5f;
            rb2d.velocity = new Vector3(speed, rb2d.velocity.y);
        }
    }

    public void LeftUp()
    {
        PushLeft = true;
    }
    public void LeftDown()
    {
        PushLeft = false;
    }

    public void RightUp()
    {
        PushRight = true;
    }
    public void RightDown()
    {
        PushRight = false;
    }

    public void ReLoad()
    {
        SceneManager.LoadScene("main");
    }

    public void StopBike()
    {
        speed = 0;
        rb2d.velocity = Vector3.zero;
        stopped = true;
        StopCoroutine(StartScene());
    }

    public void RunBike()
    {
        stopped = false;
    }
}
