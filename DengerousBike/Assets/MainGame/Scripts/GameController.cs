using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject bike;
    public GameObject Up;
    public GameObject Down;
    public GameObject GameOver;
    public GameObject ForeGroundGenerator;
    public GameObject BackGroundGenerator;
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
        bike.GetComponent<BikeController>().RunBike();
        Up.GetComponent<Button>().enabled = true;
        Down.GetComponent<Button>().enabled = true;
        GameOver.GetComponent<Canvas>().enabled = false;
        ForeGroundGenerator.GetComponent<GroundGenerator>().enabled = true;
        BackGroundGenerator.GetComponent<GroundGenerator>().enabled = true;
    }

}
