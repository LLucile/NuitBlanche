using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour 
{
	public int damage = 3;
    public float bulletLifeTime = 1.5f;
    float timer;

	// Use this for initialization
	void Start () 
	{
        timer = 0;
	}
	
	// Update is called once per frame
	void Update () 
	{
        timer = timer + Time.deltaTime;
        if (timer > bulletLifeTime)
        {
            GameObject.Destroy(gameObject);
        }
	}

	void OnCollisionEnter(Collision collision) 
	{
		GameObject go = collision.gameObject;
		Health health = go.GetComponent<Health>();
		Debug.Log ("Hit!");
		
		if (health != null) 
		{
			health.TakeDamage(damage, collision.contacts[0].normal);
		}
        GameObject.Destroy(gameObject);
	}
}
