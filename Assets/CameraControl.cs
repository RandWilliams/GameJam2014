using UnityEngine;
using System.Collections;

public class CameraControl : MonoBehaviour {

	public NodeManager gameManager = null;
	public Camera camera = null;
	public Vector3 center = new Vector3 (0f, 0f);

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		// global mode -- center at global extent center
		if ((gameManager != null) && (camera != null)) {
			camera.rect = gameManager.Extents;
		}
	}
}
