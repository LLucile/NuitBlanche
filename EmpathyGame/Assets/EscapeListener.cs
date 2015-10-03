using UnityEngine;
using System.Collections;
using XboxCtrlrInput;

public class EscapeListener : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape) || XCI.GetButton(XboxButton.Back, 1) || XCI.GetButton(XboxButton.Back, 2))
        {
            Application.Quit();
        }
	}
}
