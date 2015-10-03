using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour 
{
	public enum PlayerOrientation 
	{
		North = 0,
		NorthEast = 45,
		East = 90,
		SouthEast = 135,
		South = 180,
		SouthWest = 225,
		West = 270,
		NorthWest = 315,	
	}
	
	public GameObject _bulletPrefab;
	public PlayerOrientation _orientation;
	public float _fireCooldown = 2.0f;

	private float _currentFireCooldown = 0.0f;

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (_currentFireCooldown > 0.0f) 
		{
			_currentFireCooldown -=  Time.deltaTime;
		}

		if (Input.GetAxis ("Vertical") > 0) 
		{
			GoForward();
		}
		else if (Input.GetAxis ("Vertical") < 0) 
		{
			GoBackward();
		}		
	
		if (Input.GetKeyUp (KeyCode.LeftArrow)) 
		{
			TurnLeft();
		}

		if (Input.GetKeyUp (KeyCode.RightArrow)) 
		{
			TurnRight();
		}
		
		if (Input.GetKeyUp (KeyCode.Return)) 
		{
			Fire();
		}
	}

	private void Fire()
	{
		if (_currentFireCooldown <= 0.0f) {
			UnityEngine.Debug.Log ("Fire!");
			_currentFireCooldown = _fireCooldown;
			/*
			GameObject.Instantiate(_bulletPrefab, transform.position + transform.forward,
			            Quaternion.LookRotation(trans));
			            */
		} else 
		{
			UnityEngine.Debug.Log ("OnCoolDown!");
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
		switch (_orientation) 
		{
			case PlayerOrientation.North:
				_orientation = PlayerOrientation.NorthEast;
				break;

			case PlayerOrientation.NorthEast:
				_orientation = PlayerOrientation.East;
				break;

			case PlayerOrientation.East:
				_orientation = PlayerOrientation.SouthEast;
				break;

			case PlayerOrientation.SouthEast:
				_orientation = PlayerOrientation.South;
				break;

			case PlayerOrientation.South:
				_orientation = PlayerOrientation.SouthWest;
				break;

			case PlayerOrientation.SouthWest:
				_orientation = PlayerOrientation.West;
				break;

			case PlayerOrientation.West:
				_orientation = PlayerOrientation.NorthWest;
				break;

			case PlayerOrientation.NorthWest:
				_orientation = PlayerOrientation.North;
				break;
		}
		this.transform.eulerAngles = new Vector3(0, (int)_orientation,0);
	}

	private void TurnLeft() 
	{
		switch (_orientation) 
		{
			case PlayerOrientation.North:
				_orientation = PlayerOrientation.NorthWest;
				break;
				
			case PlayerOrientation.NorthWest:
				_orientation = PlayerOrientation.West;
				break;
				
			case PlayerOrientation.West:
				_orientation = PlayerOrientation.SouthWest;
				break;
				
			case PlayerOrientation.SouthWest:
				_orientation = PlayerOrientation.South;
				break;
				
			case PlayerOrientation.South:
				_orientation = PlayerOrientation.SouthEast;
				break;
				
			case PlayerOrientation.SouthEast:
				_orientation = PlayerOrientation.East;
				break;
				
			case PlayerOrientation.East:
				_orientation = PlayerOrientation.NorthEast;
				break;
				
			case PlayerOrientation.NorthEast:
				_orientation = PlayerOrientation.North;
				break;
		}
		this.transform.eulerAngles = new Vector3(0, (int)_orientation,0);
	}

}
