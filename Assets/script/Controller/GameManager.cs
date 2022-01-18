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

        if( !_gridData.isUsed(coords.x, coords.y))
        {
            _gridData.setBoxState(_players[_currentPlayerIndex].state, coords.x, coords.y);
            FinishTurn();
        }
    }
    
    public bool checkdraw()
    {
        //to implement
        return false;
    }

    public bool checkVictory()
    {
        //to implement
        return false;
    }

    public void FinishTurn()
    {
        if(checkVictory())
        {
            //do job to print player win
            return;
        }

        if(checkdraw())
        {
            //do job to print Draw
            return;
        }
        
        changePlayer();
    }

    public void changePlayer()
    {
        _currentPlayerIndex++;
        if(_currentPlayerIndex == _players.Count)
        {
            _currentPlayerIndex = 0;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
