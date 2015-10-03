using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour 
{
	public int damage = 3;

	// Use this for initialization
	void Start () 
	{	
	}
	
	// Update is called once per frame
	void Update () 
	{	
	}

	void OnCollisionEnter(Collision collision) 
	{
		GameObject go = collision.gameObject;
		Health health = go.GetComponent<Health>();
		Debug.Log ("Hit!");
		
		if (health != null) 
		{
			health.TakeDamage(damage, collision.contacts[0].normal);
			gameObject.SetActive(false);
		}
	}
}
