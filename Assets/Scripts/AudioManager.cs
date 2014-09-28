using UnityEngine;
using System.Collections;

public class AudioManager : MonoBehaviour {

	public AudioClip calm, stress, panic;
	public AudioSource source;
	public int healthyPercentage = 100;

	private int dangerLevel;
	// Use this for initialization
	void Start () {
		source.clip = calm;
	}
	
	// Update is called once per frame
	void Update () {
		if (healthyPercentage > 70)
						dangerLevel = 0;
		if (healthyPercentage > 30 && healthyPercentage <= 70)
						dangerLevel = 1;
		if (healthyPercentage <= 30)
						dangerLevel = 2;

		switch (dangerLevel) {
		case 0:
			source.clip = calm;
			if (!source.isPlaying){
				source.Play ();
			}
			break;
		case 1:
			source.clip = stress;
			if (!source.isPlaying){
				source.Play ();
			}
			break;
		case 2:
			source.clip = panic;
			if (!source.isPlaying){
				source.Play ();
			}
			break;
		}
	}
}
