using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BoxState
{
    none,
    cross,
    circle
}


public class GridData : MonoBehaviour
{
    public ViewController _viewController;

    private BoxState[,] _grid = new BoxState[3, 3];

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < _grid.GetLength(0); ++i)
        {
            for (int j = 0; j < _grid.GetLength(1); ++j)
            {
                _grid[i, j] = BoxState.none;
            }
        }
    }


    public BoxState getBoxState(int i, int j)
    {
        return _grid[i, j];
    }

    public Vector2Int getBounds()
    {
        return new Vector2Int(_grid.GetLength(0), _grid.GetLength(1));
    }

    public void setBoxState(BoxState boxState, int i, int j)
    {
        _grid[i, j] = boxState;
        _viewController.updateView();
    }

    public bool isUsed(int i, int j)
    {
        return _grid[i, j] != BoxState.none;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
