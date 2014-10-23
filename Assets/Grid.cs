using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Grid : MonoBehaviour {
	int _score;
    public int score{
		get{ return _score; }
		set{ _score = value; textScore.text = _score.ToString(); }
	}

    public GameObject[,] grid;
    public GameObject[] blocks;
    public Text textScore;
	float scoreScale;
	public ParticleSystem particles;
    private Block current;

	float updateTime;
	float tileUpdate;
	float sessionTime = 0;

	void Start () {
        grid = new GameObject[10, 25];
        Spawn();
	}

	Color RandomColor() {
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

    void Update()
    {
		sessionTime += Time.deltaTime;
        if (current && updateTime <= 0)
        {
            current.Move(0, -1);
			tileUpdate = 1 / (1 + sessionTime * 0.01f);
			updateTime = tileUpdate;
        }
        else
            updateTime -= Time.deltaTime;

		if (Input.GetKey(KeyCode.S)) {
			updateTime -= tileUpdate * 0.2f;
			score++;
			foreach (GameObject g in current.components) {
				particles.Emit(g.transform.position + new Vector3(0.5f, 0, 0.5f), Random.insideUnitCircle * 2, 2.0f, Random.Range(0.5f, 1.5f), RandomColor());
			}
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
		int linesRemoved = 1;
		int points = 1;
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
				linesRemoved++;
				points *= linesRemoved;
            }
		}

		score += points * 32;
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
			particles.Emit(new Vector3(Random.Range(0.0f, 10.0f), line, 0), Random.insideUnitCircle * 2, 2.0f, Random.Range(0.5f, 1.5f), RandomColor());
		}
	}
}
