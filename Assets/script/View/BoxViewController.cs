using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class BoxViewController : MonoBehaviour, IPointerEnterHandler
{
    private ViewController _viewController;

    public Image crossImage;

    public Image circleImage;

    public Button _button;

    public Vector2Int _coords;

    public void OnPointerEnter(PointerEventData eventData)
    {
        _button.Select();
    }
    
    public void BlockButton()
    {
        _button.interactable = false;
    }

    public void printCross()
    {
        crossImage.enabled = true;
        circleImage.enabled = false;
        _button.interactable = false;
    }

    public void printCircle()
    {
        crossImage.enabled = false;
        circleImage.enabled = true;
        _button.interactable = false;
    }

    public void printNothing()
    {
        crossImage.enabled = false;
        circleImage.enabled = false;
        _button.interactable = true;
    }

    public void onClick()
    {
        _viewController.OnClick(_coords);
    }

    // Start is called before the first frame update
    void Start()
    {
        _button = GetComponent<Button>();
        _viewController = GetComponentInParent<ViewController>();
    }
}
