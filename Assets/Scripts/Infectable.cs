using UnityEngine;
using System.Collections;

public class Infectable : MonoBehaviour {

	public bool infected;
	public float chanceToBeInfected = 1.0f; 
	// %chance of infection = (method rate of infection)(chance to be infected)(infection rate mdifiers)100

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	if (infected) {
			transform.Find ("Infection Indicator").GetComponent<ParticleSystem>().Emit(1);
		}
	}
}
