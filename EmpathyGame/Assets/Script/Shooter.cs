using UnityEngine;
using System.Collections;

public class Shooter : MonoBehaviour
{

    public GameObject bulletPrefab;
    private GameObject[] bullets = new GameObject[20];
    private int iNext = 0;
    public float speed = 50.0f;
	public float fireCooldown = 2.0f;	
	private float currentFireCooldown = 0.0f;
    public int damagePerHit = 10;
    public float range = 100f;

    int shootableMask;


    void Awake()
    {
        shootableMask = LayerMask.GetMask("Shootable");
        for (int i = 0; i < bullets.Length; i++)
        {
            bullets[i] = (GameObject)Instantiate(bulletPrefab);
            bullets[i].SetActive(false);
        }
    }

    void Update()
	{

		if (currentFireCooldown > 0.0f) 
		{
			currentFireCooldown -=  Time.deltaTime;
		}
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        GameObject bullet_fired = bullets[iNext++];
        if (iNext >= bullets.Length) iNext = 0;
        bullet_fired.SetActive(true);
        bullet_fired.GetComponent<Rigidbody>().velocity = Vector3.zero;
        bullet_fired.transform.position = transform.position;
        bullet_fired.transform.rotation = transform.rotation;
        bullet_fired.GetComponent<Rigidbody>().AddForce(transform.forward * speed);
    }
}