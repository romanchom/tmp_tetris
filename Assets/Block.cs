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

    //void Update()
    //{
    //    MoveSmoothSide(side);
    //}

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

    public void MoveSide(int dx)
    {
        if (side != 0 || way != 0)
            return;

        side = dx;
        way = 1;
    }

    public void MoveSmoothSide(int dx)
    {
        if (side == 0 || way == 0)
            return;

        foreach (GameObject comp in components)
            grid.grid[Mathf.RoundToInt(comp.transform.position.x), Mathf.RoundToInt(comp.transform.position.y)] = null;

        Vector3 direct = new Vector3(dx, 0, 0) * Time.deltaTime * grid.tileUpdate;

        foreach (GameObject comp in components)
        {
            Vector3 newPos = comp.transform.position + direct;

            if (Mathf.Ceil(newPos.x) < 0 || Mathf.Ceil(newPos.x) >= grid.grid.GetLength(0) ||
                Mathf.Ceil(newPos.y) < 0 || Mathf.Ceil(newPos.y) >= grid.grid.GetLength(1) ||
                grid.grid[(int)newPos.x, (int)newPos.y] != null)
            {
                direct = Vector3.zero;

                break;
            }
        }

        transform.position = transform.position + direct;
        way -= Mathf.Abs(direct.x);

        if(way <= 0)
        {
            way = 0;
            side = 0;

            transform.position = new Vector3(Mathf.RoundToInt(transform.position.x), transform.position.y);
        }

        foreach (GameObject comp in components)
            grid.grid[Mathf.RoundToInt(comp.transform.position.x), Mathf.RoundToInt(comp.transform.position.y)] = comp;
    }

    public void MoveSmooth(int dx, int dy)
    {
        bool end = false;

        foreach (GameObject comp in components)
            grid.grid[Mathf.RoundToInt(comp.transform.position.x), Mathf.RoundToInt(comp.transform.position.y)] = null;

        Vector3 direct = new Vector3(dx, dy, 0) * Time.deltaTime * grid.tileUpdate;

        foreach (GameObject comp in components)
        {
            Vector3 newPos = comp.transform.position + direct;

            if (newPos.x < 0 || newPos.x >= grid.grid.GetLength(0) ||
                newPos.y < 0 || newPos.y >= grid.grid.GetLength(1) ||
                grid.grid[(int)newPos.x, (int)newPos.y] != null)
            {
                if (newPos.y < 0 || grid.grid[Mathf.RoundToInt(comp.transform.position.x), (int)newPos.y] != null)
                    end = true;

                direct = Vector3.zero;

                break;
            }
        }

        transform.position = transform.position + direct;

        foreach (GameObject comp in components)
            grid.grid[Mathf.RoundToInt(comp.transform.position.x), Mathf.RoundToInt(comp.transform.position.y)] = comp;

        if (end)
            grid.Spawn();
    }

	public void move(int dx, int dy) {

        bool end = false;

        foreach (GameObject comp in components)
            grid.grid[Mathf.RoundToInt(comp.transform.position.x), Mathf.RoundToInt(comp.transform.position.y)] = null;

		foreach(GameObject comp in components)
        {
            int x_comp = Mathf.RoundToInt(comp.transform.position.x) + dx;
            int y_comp = Mathf.RoundToInt(comp.transform.position.y) + dy;

            if(x_comp < 0 || x_comp >= grid.grid.GetLength(0) ||
                y_comp < 0 || y_comp >= grid.grid.GetLength(1) ||
                grid.grid[x_comp, y_comp] != null)
            {
                if (y_comp < 0 || grid.grid[Mathf.RoundToInt(comp.transform.position.x), y_comp] != null)
                    end = true;

                dx = 0;
                dy = 0;

                break;
            }
        }

        transform.position = transform.position + new Vector3(dx, dy, 0);

        foreach (GameObject comp in components)
            grid.grid[Mathf.RoundToInt(comp.transform.position.x), Mathf.RoundToInt(comp.transform.position.y)] = comp;

        if (end)
            grid.Spawn();
	}

    public void Rotate()
    {
        foreach (GameObject comp in components)
            grid.grid[Mathf.RoundToInt(comp.transform.position.x), Mathf.RoundToInt(comp.transform.position.y)] = null;

        transform.RotateAround(transform.position + transform.TransformVector(new Vector3(Mathf.Round(width / 2), Mathf.Round(height / 2))), new Vector3(0, 0, 1), 90);

        foreach(GameObject comp in components)
        {
            int x_comp = (int)comp.transform.position.x;
            int y_comp = (int)comp.transform.position.y;

            if(x_comp < 0 || x_comp >= grid.grid.GetLength(0) ||
                y_comp < 0 || y_comp >= grid.grid.GetLength(1) ||
                grid.grid[x_comp, y_comp] != null)
            {
                transform.RotateAround(transform.position + transform.TransformVector(new Vector3(Mathf.Round(width / 2), Mathf.Round(height / 2))), new Vector3(0, 0, 1), -90);
                break;
            }
        }

        foreach(GameObject comp in components)
            comp.transform.rotation = Quaternion.identity;

        foreach (GameObject comp in components)
            grid.grid[Mathf.RoundToInt(comp.transform.position.x), Mathf.RoundToInt(comp.transform.position.y)] = comp;
    }
}
