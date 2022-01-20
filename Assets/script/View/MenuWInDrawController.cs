using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuWInDrawController : MonoBehaviour
{
    private ViewController _viewController;

    public Image _cross;
    public Image _circle;
    public Text _text;

    public void printDraw()
    {
        _cross.enabled = true;
        _circle.enabled = true;
        _text.text = "Draw!";
    }

    public void printCrossWin()
    {
        _cross.enabled = true;
        _circle.enabled = false;
        _text.text = "Win!";
    }

    public void printCircleWin()
    {
        _cross.enabled = false;
        _circle.enabled = true;
        _text.text = "Win!";
    }

    public void onClickRestart()
    {
        _viewController.sendRestart();
    }

    private void Start() {

        _viewController = GetComponentInParent<ViewController>();
    }

}
