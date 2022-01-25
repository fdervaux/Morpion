using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayAnimation : MonoBehaviour
{

    public float _animationDuration = 1;
    private float _animationTimeRemaining = 0;

    public AnimationCurve _animationCurve;

    public UnityEvent _startAnimation;
    public UnityEvent _endAnimation;
    public UnityEvent<float> _updateAnimation;

    private bool _isPlaying = false;


    public void Play()
    {
        _animationTimeRemaining = _animationDuration;
        _isPlaying = true;
        Debug.Log("start Animation");
        _startAnimation.Invoke();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if(_isPlaying && _animationTimeRemaining > 0)
        {

            float animationFactor = 1 - _animationTimeRemaining / _animationDuration;
            animationFactor = _animationCurve.Evaluate(animationFactor);

            //Debug.Log(animationFactor);
            _updateAnimation.Invoke(animationFactor);

            _animationTimeRemaining -= Time.deltaTime;
        }
        else if (_isPlaying)
        {
            _endAnimation.Invoke();
            _isPlaying = false;
        }
    }
}
