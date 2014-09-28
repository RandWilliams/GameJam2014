using UnityEngine;
using System.Collections;

public class GUI_LinkView : MonoBehaviour {
	
	public CameraControl c = null;
	public bool active = false;

	public enum ActionButton { Infect, Cut, Condom, Arts, Prep, Testing }
	public GUISkin InfectButtonSkin;
	public Texture InfectButtonImage;
	public GUISkin CutButtonSkin;
	public GUISkin CondomButtonSkin;
	public GUISkin ArtsButtonSkin;
	public GUISkin PrepButtonSkin;
	public GUISkin TestingButtonSkin;
	public GUISkin ZoomOutButtonSkin;


	void OnGUI()
	{
		active = (c.mode == CameraControl.Mode.focusEdge);
		if (!active) return;

		// GUI.Box (new Rect (0,0,Screen.width,50), "Top");
		GUI.Box (new Rect (Screen.width - 100,Screen.height - 50,100,50), "Bottom-right");

		// GUI.skin = InfectButtonSkin;
		//if (GUI.Button (new Rect ((Screen.width / 2f) - 50, 5, 100, 100), InfectButtonImage, GUIStyle.none)) {
		//	// do Infect
		//}

		if (GUI.Button (new Rect (0, Screen.height - 50, 100, 50), "Zoom Out")) {
			c.mode = CameraControl.Mode.global;
		}
	}
}
