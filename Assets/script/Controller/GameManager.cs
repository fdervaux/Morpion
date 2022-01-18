using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public GridData _gridData;
    private int _currentPlayerIndex = 0;

    [SerializeField] private List<Player> _players = new List<Player>();



    public void onClick(Vector2Int coords)
    {

        if (!_gridData.isUsed(coords.x, coords.y))
        {
            _gridData.setBoxState(_players[_currentPlayerIndex].state, coords.x, coords.y);
            FinishTurn();
        }
    }

    public bool checkdraw()
    {

        /* old version basic
        for(int i = 0; i < _gridData.getBounds().x; ++i)
        {
            for (int j = 0; j < _gridData.getBounds().y; ++j)
            {
                if(_gridData.getBoxState(i,j) == BoxState.empty)
                {
                    return false;
                } 
            }
        }*/

        return _gridData.getNbBoxEmpty() == 0;
    }

    public void restart()
    {
        _currentPlayerIndex = 0;
        _gridData.reset();
    }


    public bool checkLinesVictory()
    {
        for (int j = 0; j < _gridData.getBounds().y; j++)
        {
            if (_gridData.getBoxState(0, j) != BoxState.empty)
            {
                if (_gridData.getBoxState(0, j) == _gridData.getBoxState(1, j) && _gridData.getBoxState(1, j) == _gridData.getBoxState(2, j))
                {
                    return true;
                }
            }
        }
        return false;
    }

    public bool checkColumnsVictory()
    {
        for (int i = 0; i < _gridData.getBounds().x; i++)
        {
            if (_gridData.getBoxState(i, 0) != BoxState.empty)
            {
                if (_gridData.getBoxState(i, 0) == _gridData.getBoxState(i, 1) && _gridData.getBoxState(i, 1) == _gridData.getBoxState(i, 2))
                {
                    return true;
                }
            }
        }
        return false;
    }

    public bool checkDiagonalesVictory()
    {
        if (_gridData.getBoxState(1, 1) != BoxState.empty)
        {
            if (_gridData.getBoxState(0, 0) == _gridData.getBoxState(1, 1) && _gridData.getBoxState(1, 1) == _gridData.getBoxState(2, 2))
            {
                return true;
            }

            if (_gridData.getBoxState(2, 0) == _gridData.getBoxState(1, 1) && _gridData.getBoxState(1, 1) == _gridData.getBoxState(0, 2))
            {
                return true;
            }
        }
        return false;
    }

    public bool checkVictory()
    {
        return checkColumnsVictory() ||
                checkLinesVictory() ||
                checkDiagonalesVictory();
    }

    public void FinishTurn()
    {
        if (checkVictory())
        {
            _gridData.setWinner(_players[_currentPlayerIndex]);
            _gridData.setIsPlayable(false);
            return;
        }

        if (checkdraw())
        {
            _gridData.setDraw();
            _gridData.setIsPlayable(false);
            return;
        }

        changePlayer();
    }

    public void changePlayer()
    {
        _currentPlayerIndex++;
        if (_currentPlayerIndex == _players.Count)
        {
            _currentPlayerIndex = 0;
        }
    }
}
