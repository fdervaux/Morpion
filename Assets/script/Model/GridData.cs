using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BoxState
{
    empty,
    cross,
    circle
}


public class GridData : MonoBehaviour
{
    public ViewController _viewController;

    private BoxState[,] _grid = new BoxState[3, 3];

    private int _nbBoxEmpty = 0;

    private bool _isPLayable = true;

    private Player _winner = null;

    private bool _isDraw = false;


    public Player getWinner()
    {
        return _winner;
    }

    public void setWinner(Player player)
    {
        _winner = player;
    }

    public void setDraw()
    {
        _isDraw = true;
    }

    public bool isDraw()
    {
        return _isDraw;
    }


    public void reset()
    {
        for (int i = 0; i < _grid.GetLength(0); ++i)
        {
            for (int j = 0; j < _grid.GetLength(1); ++j)
            {
                _grid[i, j] = BoxState.empty;
            }
        }

        _nbBoxEmpty = _grid.GetLength(0) * _grid.GetLength(1);

        _isPLayable = true;

        _winner = null;
        _isDraw = false;

        _viewController.updateView();
    }

    // Start is called before the first frame update
    void Start()
    {
        reset();
    }

    public int getNbBoxEmpty()
    {
        return _nbBoxEmpty;
    }

    public BoxState getBoxState(int i, int j)
    {
        return _grid[i, j];
    }

    public Vector2Int getBounds()
    {
        return new Vector2Int(_grid.GetLength(0), _grid.GetLength(1));
    }

    public bool getIsPlayable()
    {
        return _isPLayable;
    }

    public void setIsPlayable(bool isPlayable)
    {
        _isPLayable = isPlayable;
        _viewController.updateView();
    }



    public void setBoxState(BoxState boxState, int i, int j)
    {
        _grid[i, j] = boxState;

        if (boxState == BoxState.empty)
        {
            _nbBoxEmpty++;
        }
        else
        {
            _nbBoxEmpty--;
        }

        _viewController.updateView();
    }

    public bool isUsed(int i, int j)
    {
        return _grid[i, j] != BoxState.empty;
    }

}
