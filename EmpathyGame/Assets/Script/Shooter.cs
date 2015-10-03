using UnityEngine;
using System.Collections;

public class Shooter : MonoBehaviour
{

    public GameObject bulletPrefab;
    private GameObject[] bullets = new GameObject[20];
    private int iNext = 0;
    public float speed = 50.0f;
    public float timer = 0; //TODO implémenter un timer pour pouvoir retirer à nouveau

    void Start()
    {
        for (int i = 0; i < bullets.Length; i++)
        {
            bullets[i] = (GameObject)Instantiate(bulletPrefab);
            bullets[i].SetActive(false);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject go = bullets[iNext++];
            if (iNext >= bullets.Length) iNext = 0;
            go.SetActive(true);
            go.GetComponent<Rigidbody>().velocity = Vector3.zero;
            go.transform.position = transform.position;
            go.transform.rotation = transform.rotation;
            go.GetComponent<Rigidbody>().AddForce(transform.forward * speed);
        }
    }
}