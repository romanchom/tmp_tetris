using UnityEngine;
using System.Collections;

public class Block : MonoBehaviour {
	public GameObject[] components;
    public int width = 0;
    public int height = 0;
    public Grid grid;

	int x, y;

    void Start()
    {
        x = (int)transform.position.x;
        y = (int)transform.position.y;

        foreach (GameObject comp in components)
        {
            if (comp.transform.localPosition.y > height)
                height = (int)comp.transform.localPosition.y;
        }
        height++;
    }

    public int GetWidth()
    {
        foreach (GameObject comp in components)
        {
            if (comp.transform.localPosition.x > width)
                width = (int)comp.transform.localPosition.x;
        }
        width++;

        return width;
    }

	public void move(int dx, int dy) {

        bool end = false;

        foreach (GameObject comp in components)
            grid.grid[(int)comp.transform.position.x, (int)comp.transform.position.y] = null;

		foreach(GameObject comp in components)
        {
            int x_comp = (int)comp.transform.position.x + dx;
            int y_comp = (int)comp.transform.position.y + dy;

            if(x_comp < 0 || x_comp >= grid.grid.GetLength(0) ||
                y_comp < 0 || y_comp >= grid.grid.GetLength(1) ||
                grid.grid[x_comp, y_comp] != null)
            {
                if (y_comp < 0 || grid.grid[(int)comp.transform.position.x, y_comp] != null)
                    end = true;

                dx = 0;
                dy = 0;

             
                break;
            }
        }

        transform.position = transform.position + new Vector3(dx, dy, 0);

        foreach (GameObject comp in components)
            grid.grid[(int)comp.transform.position.x, (int)comp.transform.position.y] = comp;

        if (end)
            grid.Spawn();
	}
}
