using UnityEngine;
using System.Collections;

public class GameOverManager : MonoBehaviour {


    Animator anim;
    float restartTimer;

	// Use this for initialization
	void Start () {
	    anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player.GetComponent<Health>().currentHealth <= 0)
        {
            anim.SetTrigger("GameOver");

            //TODO ADD RESTART CONDITIONS
        }
	
	}
}
