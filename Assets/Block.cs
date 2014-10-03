using UnityEngine;
using System.Collections;

public class Block : MonoBehaviour {
    public GameObject block;
	public GameObject[] components;

	int x, y;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update() {
	
        if(Input.GetKey(KeyCode.D))
        {

        }
	}

	void move(int dx, int dy) {
		bool isOK = true;
		foreach (GameObject g in components) {
			int newX = x + dx + (int)g.transform.localPosition.x;
			int newY = y + dy + (int)g.transform.localPosition.y;
			try {
				if (Grid.grid[newX, newY] != null) {
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
			// do move
		}
		else if (dy != 0) {
			// zakończ
		}
	}
}
