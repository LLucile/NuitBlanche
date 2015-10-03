using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {

	public int startingHealth = 3;
	public int currentHealth;
	public int scoreValue = 1;	
	public AudioClip hitClip;
	public AudioClip deathClip;
    public bool damaged;
	
	//Animator anim;
	AudioSource enemyAudio;
	ParticleSystem hitParticles;
	CapsuleCollider capsuleCollider;
	bool isDead;
	bool isDisappearing;
	
	// Use this for initialization
	void Awake () {
		//anim = GetComponent <Animator>();
		enemyAudio = GetComponent <AudioSource>();
		hitParticles = GetComponentInChildren<ParticleSystem>();
		capsuleCollider = GetComponent<CapsuleCollider>();
		
		currentHealth = startingHealth;
	}
	
	// Update is called once per frame
	void Update () {
		if (isDisappearing)
		{
			StartDisappear();
		}
	}
	
	void StartDisappear()
	{
        gameObject.layer = LayerMask.NameToLayer("Dead");
        GetComponent <NavMeshAgent>().enabled = false;
		GetComponent <Rigidbody>().isKinematic = true;
		enemyAudio.PlayOneShot (deathClip);
        if (hitParticles != null)
        {
            hitParticles.transform.position = gameObject.transform.position;
            hitParticles.Play();
            Debug.Log("particles triggered");
        }
		isDisappearing = true;
		Destroy(gameObject, deathClip.length);		
	}
	
	public void TakeDamage(int amount, Vector3 hitPoint)
	{
        damaged = true;
		if (isDead) return;
		enemyAudio.PlayOneShot (hitClip);
		currentHealth -= amount;
		if (currentHealth <= 0)
		{
			Death();
		}
	}
	
	void Death()
	{
		isDead = true;
		capsuleCollider.isTrigger = true;
		Debug.Log ("arg!");
        StartDisappear();
	}
}
