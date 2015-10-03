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
        Physics.IgnoreLayerCollision(LayerMask.NameToLayer("Default"), LayerMask.NameToLayer("Dead"), true);
	}

	public void ResetTimer()
	{
		timer = 0;
	}
	
	// Update is called once per frame
	void Update () 
	{
        timer = timer + Time.deltaTime;
        if (timer > bulletLifeTime)
		{
			gameObject.SetActive(false);
		}
	}
	
	void OnCollisionEnter(Collision collision) 
	{
        if (collision.collider.gameObject.layer == LayerMask.NameToLayer("Shootable"))
        {
            GameObject go = collision.gameObject;
            Health health = go.GetComponent<Health>();
            Debug.Log("Hit!");

            if (health != null)
            {
                health.TakeDamage(damage, collision.contacts[0].normal);
                gameObject.SetActive(false);
            }
        }
	}
}
