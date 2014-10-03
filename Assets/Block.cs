using UnityEngine;
using System.Collections;

public class Block : MonoBehaviour {
	public GameObject[] components;

	int x, y;

	void move(int dx, int dy) {
		bool isOK = true;
		foreach (GameObject g in components) {
			int newX = x + dx + (int)g.transform.localPosition.x;
			int newY = y + dy + (int)g.transform.localPosition.y;
			try {
				if (Grid.instance.grid[newX, newY] != null) {
					isOK = false;
					break;
				}
			}
			catch {
				isOK = false;
				break;
			}
		}

		if (isOK) {
			
		}
		else if (dy != 0) {
			foreach (GameObject g in components) {
				int newX = x + dx + (int)g.transform.localPosition.x;
				int newY = y + dy + (int)g.transform.localPosition.y;

				Grid.instance.grid[newX, newY] = g;
			}
			Destroy(gameObject);
		}
	}
}
