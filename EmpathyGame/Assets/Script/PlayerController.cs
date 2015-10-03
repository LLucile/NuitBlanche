using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour 
{
	// Use this for initialization
	void Start () 
	{
        Physics.IgnoreLayerCollision(LayerMask.NameToLayer("Default"), LayerMask.NameToLayer("Dead"), true);	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetAxis ("Vertical") > 0) 
		{
			GoForward();
		}
		else if (Input.GetAxis ("Vertical") < 0) 
		{
			GoBackward();
		}		
		
		if (Input.GetAxis ("Horizontal") > 0) 
		{
			TurnLeft();
		}
		else if (Input.GetAxis ("Horizontal") < 0) 
		{
			TurnRight();
		}	
	}
	
	private void GoForward() 
	{
		this.transform.Translate(Vector3.forward *2* Time.deltaTime);
	}
	
	private void GoBackward() 
	{
		this.transform.Translate(-Vector3.forward *2* Time.deltaTime);
	}

	private void TurnRight() 
	{
		this.transform.Rotate (0, -Time.deltaTime * 360, 0);
		//this.transform.eulerAngles = new Vector3(0, (int)_orientation,0);
	}

	private void TurnLeft() 
	{
		this.transform.Rotate (0, Time.deltaTime * 360, 0);
		//this.transform.eulerAngles = new Vector3(0, (int)_orientation,0);
	}

}
