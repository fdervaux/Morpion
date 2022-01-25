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

    public float _animationEnterDuration = 1.0f; //s

    private float _animationEnterTimeRemaining = 0.0f; //s

    private Image _currentAnimatedImage = null;

    public AnimationCurve _animationEnterCurve;

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
            _animationEnterTimeRemaining = _animationEnterDuration;
            Debug.Log("test start animation");
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

    // Update is called once per frame
    void Update()
    {
        if (_animationEnterTimeRemaining > 0)
        {
            // play animation
            float animationFactor = 1 - _animationEnterTimeRemaining / _animationEnterDuration;
            _currentAnimatedImage.fillAmount = _animationEnterCurve.Evaluate(animationFactor);
            _animationEnterTimeRemaining -= Time.deltaTime;

            Debug.Log(animationFactor);
        }
        else
        {
            if(_currentAnimatedImage != null)
            {
                _currentAnimatedImage.fillAmount = 1;
                _currentAnimatedImage = null;
            }
            
        }

    }
}
