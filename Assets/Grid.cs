using UnityEngine;
using System.Collections;

public class Grid : MonoBehaviour {
	public static Grid instance;

    public int score;

    public GameObject[,] grid;
    public GameObject[] blocks; 

	// Use this for initialization
	void Start () {
        grid = new GameObject[10, 25];

	}
	
	// Update is called once per frame

    public void Spawn()
    {
        int blocksCount = blocks.Length;
        int block = Random.Range(0, blocksCount);

        int x = Random.Range(0, 10);
        int y = 21;

        GameObject.Instantiate(blocks[block], new Vector2(x, y), blocks[block].transform.rotation);
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
