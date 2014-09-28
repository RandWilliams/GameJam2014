using UnityEngine;
using System.Collections;

public class CameraControl : MonoBehaviour {

	public enum Mode { global, focusEdge }
	public Mode mode = Mode.focusEdge;
	private Mode lastMode = Mode.focusEdge;

	public NodeManager gameManager = null;
	public Camera camera = null;
	public Vector3 center = new Vector3 (0f, 0f);

	public Edge focusEdge = null;
	public Node focusNode = null;

	public float restSize = 100f;
	public Vector3 restPosition = new Vector3(0f, 0f, -10f);
	public Quaternion restRotation = new Quaternion ();

	public float damper = 0.0f;

	public float focusScale = 1f;

	// privatize 
	private Quaternion camRotation = new Quaternion();
	public Vector3 tgtRotationAngles = new Vector3();



	private 
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {


		switch (mode) {
		case Mode.global: UpdateGlobal(); break;
		case Mode.focusEdge: UpdateEdge(); break;
		}

		if (Input.GetButtonDown("Fire1")) {

			Vector3 mousePosition0 = Input.mousePosition;
			mousePosition0.z = -10f;
			// bounds check regarding GUI as well..
			// bc cant capture / cancel mouse clicks, click button can potentially
			// hit an edge, etc.
			if ((mousePosition0.y < Screen.height - 50) && 
			    (mousePosition0.y > 50)) {
				Vector3 mousePosition1 = camera.ScreenToWorldPoint(mousePosition0);

			
				Ray ray = new Ray(mousePosition1, new Vector3(0f,0f,10f));
				Debug.Log (mousePosition0);
				RaycastHit[] hits = Physics.RaycastAll(ray);
			
				if(hits.Length > 0){
					bool abort = false;
					foreach ( RaycastHit h in hits) {
						Node n = h.collider.gameObject.GetComponent(typeof(Node)) as Node;
						if (n != null) { 
							focusNode = n;
							abort = true;
						} 
						if (abort) break;
					}

					if (!abort) {
						RaycastHit hit = hits[0];
						Debug.Log("Collided with: " + hit.collider.gameObject.name);
						Edge e = hit.collider.gameObject.GetComponent(typeof(Edge)) as Edge;
						if (e != null) { 
							focusEdge = e;
							mode = Mode.focusEdge;
						} 
					}
				}
			}
			//else
			//{
			//	mode = Mode.global;
			//}


			//RaycastHit2D hit = Physics2D.Raycast(camera.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
			//Debug.Log("pressed");
			//if(hit.collider != null)
			//{
			//	Edge e = hit.collider.gameObject.GetComponent(typeof(Edge)) as Edge;
			//	if (e != null) focusEdge = e;
			//	Debug.Log ("Target Position: " + hit.collider.gameObject.transform.position);
			//}
		}
	}

	void UpdateGlobal () {
		if (mode != lastMode) { 
			//camera.orthographicSize = restSize;
			//camera.transform.position = restPosition;
			//camera.transform.rotation = restRotation;
			lastMode = mode;
		}

		
			camRotation = camera.transform.rotation;
			//float tgtRotZ = focusEdge.transform.rotation.eulerAngles.z -90f ;
			//if (tgtRotZ < 0) tgtRotZ += 360.0f;
			tgtRotationAngles = restRotation.eulerAngles;
			camRotation.eulerAngles = Vector3.Lerp(camRotation.eulerAngles, tgtRotationAngles, Time.deltaTime * damper);
			camera.transform.rotation = camRotation;
			
			Vector3 camPosition = camera.transform.position;
			Vector3 tgtPosition = restPosition;
			camPosition.z = camera.transform.position.z;
			tgtPosition.z = camPosition.z;
			camPosition = Vector3.Lerp(camPosition, tgtPosition, Time.deltaTime * damper);
			camera.transform.position = camPosition;
			
			float camSize = camera.orthographicSize;
			float tgtSize = restSize;
			camSize = Mathf.Lerp(camSize, tgtSize, Time.deltaTime * damper);
			camera.orthographicSize = camSize;
	}

	void UpdateEdge () { 
		if (mode != lastMode) {
			restSize = camera.orthographicSize;
			restPosition = camera.transform.position;
			restRotation = camera.transform.rotation;
			lastMode = mode;
		}

		if (focusEdge != null) {

			camRotation = camera.transform.rotation;
			float camRotZ = camRotation.eulerAngles.z;
			float tgtRotZ = focusEdge.transform.rotation.eulerAngles.z -90f ;
			if (tgtRotZ < 0) tgtRotZ += 360.0f;

			tgtRotationAngles = new Vector3(camRotation.eulerAngles.x, camRotation.eulerAngles.y, tgtRotZ );
			camRotation.eulerAngles = Vector3.Lerp(camRotation.eulerAngles, tgtRotationAngles, Time.deltaTime * damper);
			camera.transform.rotation = camRotation;

			Vector3 camPosition = camera.transform.position;
			Vector3 tgtPosition = focusEdge.transform.position;
			camPosition.z = camera.transform.position.z;
			tgtPosition.z = camPosition.z;
			camPosition = Vector3.Lerp(camPosition, tgtPosition, Time.deltaTime * damper);
			camera.transform.position = camPosition;

			float camSize = camera.orthographicSize;
			float tgtSize = focusEdge.transform.localScale.y * focusScale;
			camSize = Mathf.Lerp(camSize, tgtSize, Time.deltaTime * damper);
			camera.orthographicSize = camSize;
		}
	}

	void SwitchToEdgeMode() { 

	}
}
