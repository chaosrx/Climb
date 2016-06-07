using UnityEngine;
using System.Collections;

public enum SceneState
{
    Loading,
    Title,
    Main,
    Play,
    GameOver
}

public class Scene : ClimbBehavior
{
    protected override void Awake()
    {
        base.Awake();
        game.SetScene(this);
    }

    #region Loading

    private IEnumerator LoadingEnterState()
    {
        yield break;
    }

    #endregion

    #region Title

    private IEnumerator TitleEnterState()
    {
        yield break;
    }

    #endregion

    #region Main

    private IEnumerator MainEnterState()
    {
        yield break;
    }

    #endregion

    #region Play

    private IEnumerator PlayEnterState()
    {
        yield break;
    }

    #endregion

    #region GameOver

    private IEnumerator GameOverEnterState()
    {
        yield break;
    }

    #endregion
}
