using System;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class ExitButton : MonoBehaviour
{
    private Button _exitButton;

    public event Action ButtonExitClicked;

    private void Awake()
    {
        _exitButton = GetComponent<Button>();
    }

    private void OnEnable()
    {
        _exitButton.onClick.AddListener(Exit);
    }

    private void OnDisable()
    {
        _exitButton.onClick.RemoveListener(Exit);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
