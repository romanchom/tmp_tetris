using UnityEngine;
using System.Collections;

public class Grid : MonoBehaviour {

    public int score;

    public static GameObject[,] grid;

    public GameObject[] blocks; 

	// Use this for initialization
	void Start () {
        grid = new GameObject[10, 20];

	}
	
	// Update is called once per frame
	void Update () {
	}

    public void Spawn()
    {
        int blocksCount = blocks.Length;
        int block = Random.Range(0, blocksCount);

        int x = Random.Range(0, 10);
        int y = 21;

        GameObject.Instantiate(blocks[block], new Vector2(x, y), blocks[block].transform.rotation);
    }
}
