using UnityEngine;
using System.Collections;

public class Grid : MonoBehaviour {
	public static Grid instance;

    public GameObject[,] grid;

	// Use this for initialization
	void Start () {
        grid = new GameObject[10, 25];
	}
	
	// Update is called once per frame
	void Update() {

	}

	public void checkFullLines() {
		for (int i = 0; i < 20; i++) {
			bool full = true;
			for (int j = 0; j < 10; ++j) {
				full &= grid[j, i] != null;
				if (!full) break;
			}

			if (full) removeLine(i);
		}
	}

	void removeLine(int line) {
		for (int i = line; i < 20; i++) {
			for (int j = 0; j < 10; j++) {
				grid[j, i] = grid[j, i + 1];
			}
		}
	}
}
