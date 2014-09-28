using UnityEngine;
using System.Collections;

public class Infectable : MonoBehaviour {

	public bool infected, tested;
	public float chanceToBeInfected = 1.0f, chanceToInfect = 1.0f; 
	// %chance of spread = (infected node's chance to infect)(method rate of infection)(clean node's chance to be infected)(infection rate modifiers)100

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
