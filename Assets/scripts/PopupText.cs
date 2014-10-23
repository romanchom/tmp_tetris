using UnityEngine;
using System.Collections;

public class PopupText : MonoBehaviour {
	float rot;
	float rotSpeed;
	float time = 0;
	void Start () {
		GetComponent<TextMesh>().color = RC.RandomColor();
		rot = Random.Range(-180.0f, 180.0f);
		rotSpeed = Random.Range(-180.0f, 180.0f);

		transform.position = new Vector3(5, 10, 0) + (Vector3) (Random.insideUnitCircle * 3);

		renderer.sortingLayerID = 2;
	}
	
	// Update is called once per frame
	void Update () {
		time += Time.deltaTime;
		if (time > PopupFactory.lifeTime) {
			Destroy(gameObject);
			return;
		}
		transform.localRotation = Quaternion.AngleAxis(rot + rotSpeed * time, Vector3.forward);
		float scale = PopupFactory.scaleOverTime.Evaluate(time / PopupFactory.lifeTime);
		transform.localScale = new Vector3(scale, scale, scale);
	}
}
