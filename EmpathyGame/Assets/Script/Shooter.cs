using UnityEngine;
using System.Collections;
using XboxCtrlrInput;

public class Shooter : MonoBehaviour
{

    public GameObject bulletPrefab;
    public float speed = 50.0f;
	public float fireCooldown = 0.5f;	
    public int damagePerHit = 10;
	public float range = 100f;
	public AudioClip[] shootClip;

	private AudioSource audioSource;
	private float currentFireCooldown = 0.0f;
	private GameObject[] bullets = new GameObject[20];
	private int iNext = 0;

    int shootableMask;


    void Awake()
    {
		audioSource = GetComponentInParent<AudioSource> ();
        shootableMask = LayerMask.GetMask("Shootable");
        for (int i = 0; i < bullets.Length; i++)
        {
            bullets[i] = (GameObject)Instantiate(bulletPrefab);
            bullets[i].SetActive(false);
        }
    }

    void Update()
	{
        if ( !GetComponentInParent<ControllersManager>().frozen )
        {
            if (currentFireCooldown > 0.0f)
            {
                currentFireCooldown -= Time.deltaTime;
            }
            else if (Input.GetKeyDown(KeyCode.Space) || XCI.GetButton(XboxButton.A, 1) || XCI.GetButton(XboxButton.B, 1) || XCI.GetButton(XboxButton.Y, 1) || XCI.GetButton(XboxButton.X, 1) || XCI.GetButton(XboxButton.Start, 1) || XCI.GetButton(XboxButton.LeftStick, 1) || XCI.GetButton(XboxButton.RightStick, 1) || XCI.GetButton(XboxButton.LeftBumper, 1) || XCI.GetButton(XboxButton.RightBumper, 1) ||
                XCI.GetDPad(XboxDPad.Left, 1) || (bool)XCI.GetDPad(XboxDPad.Right, 1) || (bool)XCI.GetDPad(XboxDPad.Up, 1) || XCI.GetDPad(XboxDPad.Down, 1) || XCI.GetAxis(XboxAxis.LeftTrigger) != 0 || XCI.GetAxis(XboxAxis.RightTrigger, 1) != 0 || Input.GetKeyDown(KeyCode.Enter) || XCI.GetButton(XboxButton.A, 2) || XCI.GetButton(XboxButton.B, 2) || XCI.GetButton(XboxButton.Y, 2) || XCI.GetButton(XboxButton.X, 2) || XCI.GetButton(XboxButton.Start, 2) || XCI.GetButton(XboxButton.LeftStick, 2) || XCI.GetButton(XboxButton.RightStick, 2) || XCI.GetButton(XboxButton.LeftBumper, 2) || XCI.GetButton(XboxButton.RightBumper, 2) ||
                XCI.GetDPad(XboxDPad.Left, 2) || (bool)XCI.GetDPad(XboxDPad.Right, 2) || (bool)XCI.GetDPad(XboxDPad.Up, 2) || XCI.GetDPad(XboxDPad.Down, 2) ||
                XCI.GetAxis(XboxAxis.LeftTrigger) != 0 || XCI.GetAxis(XboxAxis.RightTrigger, 2) != 0)
            {
                Shoot();
            }
        }
        else
        {
            Debug.Log("FROZEN !!!");
        }
    }

    void Shoot()
    {
        GameObject bullet_fired = bullets[iNext++];
        if (iNext >= bullets.Length) iNext = 0;
		Debug.Log ("fire : " + iNext);
        if (bullet_fired != null)
        {
            bullet_fired.SetActive(true);
            bullet_fired.GetComponent<Rigidbody>().velocity = Vector3.zero;
            bullet_fired.transform.position = transform.position;
            bullet_fired.transform.rotation = transform.rotation;
			bullet_fired.GetComponent<Rigidbody>().AddForce(transform.forward * speed);
			bullet_fired.GetComponent<Bullet>().ResetTimer();
        }
		if ((shootClip != null) && (shootClip.Length > 0)) 
		{
			audioSource.PlayOneShot(shootClip[UnityEngine.Random.Range(0, shootClip.Length)]);
		}
    }
}