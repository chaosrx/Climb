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

public class Scene : FSMBase
{
    public Transform player;
    public Vector3 camBasePos;

    protected override void Awake()
    {
        base.Awake();
        game.SetScene(this);
    }

    private void Start()
    {
        state = SceneState.Loading;
    }

    #region Loading

    private IEnumerator LoadingEnterState()
    {
        yield return null;
        state = SceneState.Play;
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
    private void PlayUpdate()
    {

    }

    #endregion

    #region GameOver

    private IEnumerator GameOverEnterState()
    {
        yield break;
    }

    #endregion
}
