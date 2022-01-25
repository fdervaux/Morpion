using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewController : MonoBehaviour
{
    public GameManager _gameManager;
    public GridData _gridData;

    public GameObject _boxesOwner;

    public MenuWInDrawController _menuWinDraw;

    private List<BoxViewController> _boxes = new List<BoxViewController>();

    public Vector2Int getCoordsWithIndex(int index)
    {
        Vector2Int bounds = _gridData.getBounds();
        return new Vector2Int(index % bounds.x, index / bounds.y);
    }


    public void updateBox(BoxState state, int i, int j)
    {
        int index = i + j * _gridData.getBounds().x;

        if (state == BoxState.empty)
        {
            _boxes[index].printNothing();
        }

        if (state == BoxState.cross)
        {
            _boxes[index].printCross();
        }

        if (state == BoxState.circle)
        {
            _boxes[index].printCircle();
        }

       _boxes[index].startAnimationEnter();
    }

    public void updateView()
    {
        if (!_gridData.getIsPlayable())
        {
            for (int i = 0; i < _boxes.Count; i++)
            {
                _boxes[i].BlockButton();
            }

            _menuWinDraw.gameObject.SetActive(true);

            if (_gridData.isDraw())
            {
                _menuWinDraw.printDraw();
            }

            if (_gridData.getWinner() != null)
            {
                if (_gridData.getWinner().state == BoxState.circle)
                {
                    _menuWinDraw.printCircleWin();
                }

                if (_gridData.getWinner().state == BoxState.cross)
                {
                    _menuWinDraw.printCrossWin();
                }
            }

            return;
        }

        _menuWinDraw.gameObject.SetActive(false);

        for (int i = 0; i < _boxes.Count; i++)
        {
            Vector2Int coords = getCoordsWithIndex(i);
            BoxState state = _gridData.getBoxState(coords.x, coords.y);

            if (state == BoxState.empty)
            {
                _boxes[i].printNothing();
            }

            if (state == BoxState.cross)
            {
                _boxes[i].printCross();
            }

            if (state == BoxState.circle)
            {
                _boxes[i].printCircle();
            }
        }
    }

    public void OnClick(Vector2Int coords)
    {
        _gameManager.onClick(coords);
    }



    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < _boxesOwner.transform.childCount; i++)
        {
            _boxes.Add(_boxesOwner.transform.GetChild(i).GetComponent<BoxViewController>());
            _boxes[i]._coords = getCoordsWithIndex(i);
        }
    }

    public void sendRestart()
    {
        _gameManager.restart();
    }

}
