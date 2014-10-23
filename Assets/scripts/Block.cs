using UnityEngine;
using System.Collections;

public class Block : MonoBehaviour {
	public GameObject[] components;
    public int width = 0;
    public int height = 0;
    public Grid grid;

	int x, y;
    private int side;
    private float way;
	
	public void Init() {
		x = (int)transform.position.x;
		y = (int)transform.position.y;

		foreach (GameObject comp in components) {
			height = Mathf.Max((int)comp.transform.localPosition.y, height);
			width = Mathf.Max((int)comp.transform.localPosition.x, width);
		}
		height++;
		width++;
	}

	public void Move(int dx, int dy) {
        bool end = false;

		foreach(GameObject comp in components)
        {
            int x_comp = Mathf.RoundToInt(comp.transform.position.x) + dx;
            int y_comp = Mathf.RoundToInt(comp.transform.position.y) + dy;


            if(x_comp < 0 || x_comp >= grid.grid.GetLength(0) ||
                y_comp < 0 || y_comp >= grid.grid.GetLength(1) ||
                grid.grid[x_comp, y_comp] != null)
            {
				if (y_comp < 0 || grid.grid[Mathf.RoundToInt(comp.transform.position.x), y_comp] != null) {
					if (y_comp >= 19) {
						grid.Lose();
						return;
					}
					end = true;
				}

                dx = 0;
                dy = 0;

                break;
            }
        }

        transform.position = transform.position + new Vector3(dx, dy, 0);

        if (end)
            grid.Spawn();
	}

    public void Rotate()
    {
        transform.RotateAround(transform.position + transform.TransformVector(new Vector3(Mathf.Round(width / 2), Mathf.Round(height / 2))), new Vector3(0, 0, 1), -90);

        foreach(GameObject comp in components)
        {
            int x_comp = (int)comp.transform.position.x;
            int y_comp = (int)comp.transform.position.y;

            if(x_comp < 0 || x_comp >= grid.grid.GetLength(0) ||
                y_comp < 0 || y_comp >= grid.grid.GetLength(1) ||
                grid.grid[x_comp, y_comp] != null)
            {
                transform.RotateAround(transform.position + transform.TransformVector(new Vector3(Mathf.Round(width / 2), Mathf.Round(height / 2))), new Vector3(0, 0, 1), +90);
                break;
            }
        }

        foreach(GameObject comp in components)
            comp.transform.rotation = Quaternion.identity;
    }
}
