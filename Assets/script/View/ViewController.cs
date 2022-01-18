using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewController : MonoBehaviour
{
    public GameManager _gameManager;
    public GridData _gridData;

    public GameObject _boxesOwner;

    private List<BoxViewController> _boxes = new List<BoxViewController>();

    public Vector2Int getCoordsWithIndex(int index)
    {
        Vector2Int bounds = _gridData.getBounds();
        return new Vector2Int(index % bounds.x, index / bounds.y);
    }

    public void updateView()
    {
        Debug.Log(_boxes.Count);
        for (int i = 0; i < _boxes.Count; i++)
        {
            Vector2Int coords = getCoordsWithIndex(i);
            BoxState state = _gridData.getBoxState(coords.x, coords.y);

            if (state == BoxState.none)
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

    // Update is called once per frame
    void Update()
    {

    }
}
