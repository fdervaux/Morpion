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

    private Image _currentAnimatedImage = null;

    public PlayAnimation _buttonEnterAnimation;


    public void OnPointerEnter(PointerEventData eventData)
    {
        _button.Select();
    }
    public void BlockButton()
    {
        _button.interactable = false;
    }


    public void startAnimationEnter()
    {
        if (_currentAnimatedImage != null)
        {
            _buttonEnterAnimation.Play();
        }
    }

    public void printCross()
    {
        crossImage.enabled = true;
        circleImage.enabled = false;
        _button.interactable = false;
        _currentAnimatedImage = crossImage;
    }

    public void printCircle()
    {
        crossImage.enabled = false;
        circleImage.enabled = true;
        _button.interactable = false;
        _currentAnimatedImage = circleImage;
    }

    public void printNothing()
    {
        crossImage.enabled = false;
        circleImage.enabled = false;
        _button.interactable = true;
        _currentAnimatedImage = null;
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


    public void updateButtonEnterAnimation(float factor)
    {
        _currentAnimatedImage.fillAmount = factor;
    }

    public void endButtonEnterAnimation()
    {
        _currentAnimatedImage.fillAmount = 1;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
