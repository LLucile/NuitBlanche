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
        cTime = Time.timeSinceLevelLoad;
        int min = (int)cTime / 60;
        int sec = (int)cTime % 60;
        text.text = "TIME : " + min + " \'\'" + sec;
	}
}
