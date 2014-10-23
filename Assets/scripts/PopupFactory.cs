using UnityEngine;
using System.Collections;

public class PopupFactory : MonoBehaviour {
	public GameObject prefab;
	public Transform canvas;
	static PopupFactory instance;

	public AnimationCurve curve;
	public static AnimationCurve scaleOverTime { get { return instance.curve; } }

	public float life;
	public static float lifeTime { get { return instance.life; } }

	void Start() {
		instance = this;
	}

	public static void CreatePopup(string text) {
		GameObject g = (GameObject)Instantiate(instance.prefab);
		g.GetComponent<TextMesh>().text = text;
		g.transform.parent = instance.canvas;
	}
}
