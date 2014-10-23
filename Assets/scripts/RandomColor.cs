using UnityEngine;

class RC {
	public static Color RandomColor() {
		float r, g, b;
		r = Random.value;
		g = Random.value;
		b = Random.value;

		float d = Mathf.Max(r, g, b);
		if (r < g) {
			if (r < b) r = 0;
			else b = 0;
		}
		else {
			if (g < b) g = 0;
			else b = 0;
		}

		return new Color(r / d, g / d, b / d, 1);
	}
}