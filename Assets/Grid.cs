using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Grid : MonoBehaviour {

    public int score;

    public GameObject[,] grid;
    public GameObject[] blocks;
    public Text textScore;
	public ParticleSystem particles;
    private Block current;

    public float tileUpdate;
    private float updateTime;

	void Start () {
        grid = new GameObject[10, 25];
        Spawn();
	}
	
    void Update()
    {
        if (current && updateTime <= 0)
        {
            current.Move(0, -1);
            updateTime = tileUpdate;
        }
        else
            updateTime -= Time.deltaTime;

		if (Input.GetKey(KeyCode.S)) {
			updateTime -= Time.deltaTime * 2;
		}

        if (Input.GetKeyDown(KeyCode.D))
            current.Move(1, 0);

        if (Input.GetKeyDown(KeyCode.A))
            current.Move(-1, 0);

        if (Input.GetKeyDown(KeyCode.W))
            current.Rotate();
    }

    public void Spawn()
    {
		if (current != null) {
			foreach (GameObject comp in current.components) {
				grid[Mathf.RoundToInt(comp.transform.position.x), Mathf.RoundToInt(comp.transform.position.y)] = comp;
			}
			while (current.transform.childCount > 0) {
				current.transform.GetChild(0).parent = transform;
			}
			Destroy(current.gameObject);
		}
        int blocksCount = blocks.Length;
        int block = Random.Range(0, blocksCount);

        current = (Instantiate(blocks[block], new Vector2(0, 0), blocks[block].transform.rotation) as GameObject).GetComponent<Block>();
		current.Init();
        int x = Random.Range(0, 10 - current.width);
        int y = 21;

        current.transform.position = new Vector2(x, y);
        current.grid = this;

        checkFullLines();
    }

	public void checkFullLines() {
		for (int i = 19; i >= 0; i--) {
			bool full = true;
			for (int j = 0; j < 10; ++j) {
				if(grid[j, i] == null)
                {
                    full = false;
                    break;
                }
			}
            if (full)
            {
				removeLine(i);
            }
		}

        textScore.text = score.ToString();
	}

	Color32 white = new Color32(255, 255, 255, 255);

	void removeLine(int line) {

        score += 10;

        for (int x = 0; x < 10; x++)
        {
            GameObject obj = grid[x, line];
            grid[x, line] = null;
            Destroy(obj);
        }

		for(int y = line+1; y < 20; y++)
        {
            for(int x = 0; x < 10; x++)
            {
                GameObject obj = grid[x, y];
                if (!obj)
                    continue;
                grid[x, y - 1] = obj;
                grid[x, y] = null;
                obj.transform.position = obj.transform.position + new Vector3(0, -1, 0);
            }
        }

		for (int i = 0; i < 100; ++i) {
			particles.Emit(new Vector3(Random.Range(0.0f, 10.0f), line, 0), Random.insideUnitCircle * 2, 2.0f, Random.Range(0.5f, 1.5f), white);
		}
	}
}
