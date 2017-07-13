using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BikeController : MonoBehaviour
{

    [SerializeField] Renderer render;
    [SerializeField] GameObject bike;

    private bool PushLeft = false;
    private bool PushRight = false;
    private bool Moving = false;
    private float speed = 0;

    float movePower = 0.2f;
    Rigidbody2D rb2d;

    const int MinLane = -1;
    const int MaxLane = 2;
    const float LaneWidth = 1.0f;
    int targetLane;
    [SerializeField] GameObject wall;


	void Start ()
    {
        rb2d = GetComponent<Rigidbody2D>();


        
    }

    void Update()
    {
        if (PushLeft == true)
        {
            bike.transform.Rotate(0, 0, -2);
        }

        if (PushRight == true)
        {
            bike.transform.Rotate(0, 0, 2);
        }

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

        if(targetLane == 2)
        {
            bike.transform.localScale = new Vector3(0.7f, 0.7f, 1);
        }
        if(targetLane == 1)
        {
            bike.transform.localScale = new Vector3(0.8f, 0.8f, 1);
        }
        if (targetLane == 0)
        {
            bike.transform.localScale = new Vector3(0.9f, 0.9f, 1);
        }
        if (targetLane == -1)
        {
            bike.transform.localScale = new Vector3(1f, 1f, 1);
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


    IEnumerator Invincible()
    {
        gameObject.tag = "InvincibleBike";
        int count = 40;
        while (count > 0)
        {
            //透明にする
            render.material.color = new Color(1, 1, 1, 0);
            //0.05秒待つ
            yield return new WaitForSeconds(0.05f);
            //元に戻す
            render.material.color = new Color(1, 1, 1, 1);
            //0.05秒待つ
            yield return new WaitForSeconds(0.05f);
            //透明にする
            render.material.color = new Color(1, 1, 1, 0);
            //0.05秒待つ
            yield return new WaitForSeconds(0.05f);
            //元に戻す
            render.material.color = new Color(1, 1, 1, 1);
            //0.05秒待つ
            count--;
        }
        gameObject.tag = "player";
    }

    public void ChangeInvincible()
    {
        StartCoroutine(Invincible());
    }
}
