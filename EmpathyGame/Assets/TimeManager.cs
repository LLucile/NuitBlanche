using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour {
    float cTime = 0;

    Text text;
	// Use this for initialization
	void Start () {
        text = GetComponent<Text>();
        cTime = Time.realtimeSinceStartup;	
	}
	
	// Update is called once per frame
	void Update () {
        cTime = Time.realtimeSinceStartup;
        int min = (int)Time.time / 60;
        int sec = (int)Time.time % 60;
        text.text = "TIME : " + min + " \'\'" + sec;
	}
}
