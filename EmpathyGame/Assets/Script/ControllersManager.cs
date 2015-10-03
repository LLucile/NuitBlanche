using UnityEngine;
using System.Collections;
using XboxCtrlrInput;

public class ControllersManager : MonoBehaviour {
    public bool frozen = false;
    public float frozenTime = 3.0f;
    public float playerOnePlayingTime = 0f;
    public float playerTwoPlayingTime = 0f;
    private int playerTurn = 0;
    float timer;
	// Use this for initialization
	void Start () {
        timer = frozenTime;
	}
	
	// Update is called once per frame
	void Update () {
        if (
            (XCI.GetButton(XboxButton.A, 1) || XCI.GetButton(XboxButton.B, 1) || XCI.GetButton(XboxButton.Y, 1) || XCI.GetButton(XboxButton.X, 1) || XCI.GetButton(XboxButton.Start, 1) || XCI.GetButton(XboxButton.LeftStick, 1) || XCI.GetButton(XboxButton.RightStick, 1) || XCI.GetButton(XboxButton.LeftBumper, 1) || XCI.GetButton(XboxButton.RightBumper, 1) ||
            XCI.GetDPad(XboxDPad.Left, 1) || (bool) XCI.GetDPad(XboxDPad.Right, 1) || (bool) XCI.GetDPad(XboxDPad.Up, 1) || XCI.GetDPad(XboxDPad.Down, 1) ||
            XCI.GetAxis(XboxAxis.LeftTrigger) != 0 || XCI.GetAxis(XboxAxis.RightTrigger, 1) != 0 || XCI.GetAxis(XboxAxis.LeftStickY, 1) !=0 || XCI.GetAxis(XboxAxis.LeftStickX, 1) !=0 || XCI.GetAxis(XboxAxis.RightStickY, 1) !=0 || XCI.GetAxis(XboxAxis.RightStickX, 1) !=0 ||
            Input.GetKeyDown(KeyCode.RightShift) || Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow)) 
            &&
            (XCI.GetButton(XboxButton.A, 2) || XCI.GetButton(XboxButton.B, 2) || XCI.GetButton(XboxButton.Y, 2) || XCI.GetButton(XboxButton.X, 2) || XCI.GetButton(XboxButton.Start, 2) || XCI.GetButton(XboxButton.LeftStick, 2) || XCI.GetButton(XboxButton.RightStick, 2) || XCI.GetButton(XboxButton.LeftBumper, 2) || XCI.GetButton(XboxButton.RightBumper, 2) ||
            XCI.GetDPad(XboxDPad.Left, 2) || (bool)XCI.GetDPad(XboxDPad.Right, 2) || (bool)XCI.GetDPad(XboxDPad.Up, 2) || XCI.GetDPad(XboxDPad.Down, 2) ||
            XCI.GetAxis(XboxAxis.LeftTrigger) != 0 || XCI.GetAxis(XboxAxis.RightTrigger, 2) != 0 || XCI.GetAxis(XboxAxis.LeftStickY, 2) != 0 || XCI.GetAxis(XboxAxis.LeftStickX, 2) != 0 || XCI.GetAxis(XboxAxis.RightStickY, 2) != 0 || XCI.GetAxis(XboxAxis.RightStickX, 2) != 0 ||
            Input.GetKeyDown(KeyCode.Q) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.Space)) 
            )
        {
            frozen = true;
        }
        if (frozen == true)
        {
            timer -= Time.deltaTime;
        }
        if (timer <= 0)
        {
            timer = frozenTime;
            frozen = false;
        }
        if (
            (XCI.GetButton(XboxButton.A, 1) || XCI.GetButton(XboxButton.B, 1) || XCI.GetButton(XboxButton.Y, 1) || XCI.GetButton(XboxButton.X, 1) || XCI.GetButton(XboxButton.Start, 1) || XCI.GetButton(XboxButton.LeftStick, 1) || XCI.GetButton(XboxButton.RightStick, 1) || XCI.GetButton(XboxButton.LeftBumper, 1) || XCI.GetButton(XboxButton.RightBumper, 1) ||
            XCI.GetDPad(XboxDPad.Left, 1) || (bool) XCI.GetDPad(XboxDPad.Right, 1) || (bool) XCI.GetDPad(XboxDPad.Up, 1) || XCI.GetDPad(XboxDPad.Down, 1) ||
            XCI.GetAxis(XboxAxis.LeftTrigger, 1) != 0 || XCI.GetAxis(XboxAxis.RightTrigger, 1) != 0 || XCI.GetAxis(XboxAxis.LeftStickY, 1) !=0 || XCI.GetAxis(XboxAxis.LeftStickX, 1) !=0 || XCI.GetAxis(XboxAxis.RightStickY, 1) !=0 || XCI.GetAxis(XboxAxis.RightStickX, 1) !=0 ||
            Input.GetKeyDown(KeyCode.RightShift) || Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow))
            )
        {
            playerTurn = 1;
        }
        else if((XCI.GetButton(XboxButton.A, 2) || XCI.GetButton(XboxButton.B, 2) || XCI.GetButton(XboxButton.Y, 2) || XCI.GetButton(XboxButton.X, 2) || XCI.GetButton(XboxButton.Start, 2) || XCI.GetButton(XboxButton.LeftStick, 2) || XCI.GetButton(XboxButton.RightStick, 2) || XCI.GetButton(XboxButton.LeftBumper, 2) || XCI.GetButton(XboxButton.RightBumper, 2) ||
            XCI.GetDPad(XboxDPad.Left, 2) || (bool)XCI.GetDPad(XboxDPad.Right, 2) || (bool)XCI.GetDPad(XboxDPad.Up, 2) || XCI.GetDPad(XboxDPad.Down, 2) ||
            XCI.GetAxis(XboxAxis.LeftTrigger, 2) != 0 || XCI.GetAxis(XboxAxis.RightTrigger, 2) != 0 || XCI.GetAxis(XboxAxis.LeftStickY, 2) != 0 || XCI.GetAxis(XboxAxis.LeftStickX, 2) != 0 || XCI.GetAxis(XboxAxis.RightStickY, 2) != 0 || XCI.GetAxis(XboxAxis.RightStickX, 2) != 0 ||
            Input.GetKeyDown(KeyCode.Q) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.Space))
             )
        {
            playerTurn = 2;
        }
        if (playerTurn == 1)
        {
            playerOnePlayingTime += Time.deltaTime;
        }
        else if (playerTurn == 2)
        {
            playerTwoPlayingTime += Time.deltaTime;
        }
	}
}
