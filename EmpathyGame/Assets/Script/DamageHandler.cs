using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DamageHandler : MonoBehaviour {
    public float flashSpeed = 50f;
    public Color flashColour = new Color(1f, 0f, 0f, 0.1f);
    public Image damageImage;
    public Slider healthSlider;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if(GetComponent<Health>().damaged){
            damageImage.color = flashColour;
            healthSlider.value = GetComponent<Health>().currentHealth;
        }
        else
        {
            damageImage.color = Color.Lerp(damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
        }
        GetComponent<Health>().damaged = false;
	
	}
}
