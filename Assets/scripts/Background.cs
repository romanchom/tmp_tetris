using UnityEngine;
using System.Collections;

public class Background : MonoBehaviour {
	Vector3 posOffset;
	float rotOffset;

	float posScale;
	float rotScale;

	float angle;
	// Use this for initialization
	void Start () {
		posOffset = Random.insideUnitCircle;
		rotOffset = Random.value * 360;

		posScale = Random.RandomRange(0.1f, 0.2f);
		rotScale = Random.RandomRange(0.1f, 0.2f);
	}
	
	// Update is called once per frame
	void Update () {
		float t = Time.time * posScale;
		transform.localPosition = new Vector3(
			Mathf.PerlinNoise(posOffset.x, t) - 0.5f,
			0,
			Mathf.PerlinNoise(posOffset.y, t) - 0.5f
			) * 80;


		t = Time.time * rotScale;
		angle += Mathf.PerlinNoise(rotOffset, t) - 0.5f;
		transform.localRotation = Quaternion.AngleAxis(angle, Vector3.up);
	}
}
