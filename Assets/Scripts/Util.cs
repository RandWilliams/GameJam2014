using UnityEngine;
using System.Collections;

public class Util {

	public static Vector2 RandomVector2(float max) {
		float x = Random.value * max;
		float y = Random.value * max;
		return new Vector2(x, y);
	}

	public static Vector3 RandomVector3(float max) {
		float x = Random.value * max;
		float y = Random.value * max;
		float z = Random.value * max;
		return new Vector3(x, y, z);
	}
}
