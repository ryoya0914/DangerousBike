using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Realtime : MonoBehaviour
{
    [SerializeField]
    Text text;
    [SerializeField] string  url = "http://ntp-a1.nict.go.jp/cgi-bin/json";


    IEnumerator Start ()
    {
        WWW www = new WWW(url);
        yield return www;

        var json = www.text;
        text.text = json;

        NictTime time = JsonUtility.FromJson<NictTime>(json);

        var now = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).AddSeconds(Convert.ToDouble(time.st)).ToLocalTime();
        string[] Time = now.TimeOfDay.ToString().Split(':');
        text.text = Time[0] + ":" + Time[1];
        //Debug.Log(time.st);

    }
	
	void Update ()
    {
    }


    [Serializable] public class NictTime
    {
        public string id;
        public decimal it;
        public double st;
        public int leap;
        public decimal next;
        public int step;
    }
}
