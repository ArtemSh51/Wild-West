using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class ButtonLoaderScene : MonoBehaviour
{
    [SerializeField] private int _indexScene;

    private Button _button;

    public event Action ButtonClicked;

    private void Awake()
    {
        _button = GetComponent<Button>();
    }

    private void OnEnable()
    {
        _button.onClick.AddListener(LoadGame);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(LoadGame);
    }

    public void LoadGame()
    {
        SceneManager.LoadScene(_indexScene);
    }
}
