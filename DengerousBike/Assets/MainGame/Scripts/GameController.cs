using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject bike;
    public Renderer renderer;

    void Start()
    {
    }

    void Update()
    {

    }



    public void RetrunTitle()
    {
        SceneManager.LoadScene("Title");
    }

    public void RestartGame()
    {

        StartCoroutine("Invincible");
        GameObject.Find("Canvas/up").GetComponent<Button>().enabled = true;
        GameObject.Find("Canvas/down").GetComponent<Button>().enabled = true;
        GameObject.Find("GameOver").GetComponent<Canvas>().enabled = false;
    }

    IEnumerator Invincible()
    {
        bike.SetActive(true);
        bike.tag = "Player";
        int count = 10;
        while (count > 0)
        {
            //透明にする
            renderer.material.color = new Color(1, 1, 1, 0);
            //0.05秒待つ
            yield return new WaitForSeconds(0.05f);
            //元に戻す
            renderer.material.color = new Color(1, 1, 1, 1);
            //0.05秒待つ
            yield return new WaitForSeconds(0.05f);
            count--;
        }
        bike.tag = "player";
    }
}
