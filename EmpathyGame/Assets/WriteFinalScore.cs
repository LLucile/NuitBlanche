using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WriteFinalScore : MonoBehaviour {
    Text text;
    GameObject players;
    float ctime = 0f;
	// Use this for initialization
	void Start () {
        text = GetComponent<Text>();
        players = GameObject.Find("PlayerAlien");
	}
	
	// Update is called once per frame
	void Update () {
        if (players.GetComponent<Health>().currentHealth < 0)
        {
            ctime = Time.timeSinceLevelLoad;
            int min = (int)ctime / 60;
            int sec = (int)ctime % 60;
            text.text = "You survived " + min + " \'\'" + sec + "\n Player 1 played " + (players.GetComponent<ControllersManager>().playerOnePlayingTime / ctime) * 100 + "% of the game \n Player 2 played " + (players.GetComponent<ControllersManager>().playerTwoPlayingTime / ctime) * 100 + "% of the game";
        }
	}
}
