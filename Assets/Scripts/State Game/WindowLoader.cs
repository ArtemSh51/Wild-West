using UnityEngine;
using UnityEngine.SceneManagement;

public class WindowLoader : State
{
    private int _indexScene;

    public WindowLoader(Game game, int indexScene)
    {
        _indexScene = indexScene;
    }

    public override void Enter()
    {
        Cursor.visible = true;

        SceneManager.LoadScene(_indexScene);
    }
}
