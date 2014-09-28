using UnityEngine;
using System.Collections;

public class GUI_Full_Script : MonoBehaviour {
		
	public CameraControl c = null;
	public bool active = false;

	void OnGUI()
	{
		active = (c.mode == CameraControl.Mode.global);
		if (!active) return;

//		GUI.Box (new Rect (0, 0, 100, 50), "Top-left");
//		GUI.Box (new Rect (Screen.width - 100, 0, 100, 50), "Top-right");
//		GUI.Box (new Rect (0, Screen.height - 50, 100, 50), "Bottom-left");
//		GUI.Box (new Rect (Screen.width - 100, Screen.height - 50, 100, 50), "Bottom-right");
	}
}
		

