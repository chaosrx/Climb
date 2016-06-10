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
    public Player player { private set; get; }

    protected override void Awake()
    {
        base.Awake();
        game.SetScene(this);
    }

    private void Start()
    {
        state = SceneState.Loading;
    }

    public void SetPlayer(Player player)
    {
        this.player = player;
    }

    #region Loading

    private IEnumerator LoadingEnterState()
    {
        yield return null;
        game.jumperCam.state = SceneState.Play;
        state = SceneState.Play;
        yield break;
    }

    #endregion

    #region Title

    private IEnumerator TitleEnterState()
    {
        game.jumperCam.state = SceneState.Title;
        yield break;
    }

    #endregion

    #region Main

    private IEnumerator MainEnterState()
    {
        game.jumperCam.state = SceneState.Main;
        yield break;
    }

    #endregion

    #region Play

    private IEnumerator PlayEnterState()
    {
        game.jumperCam.state = SceneState.Play;
        yield break;
    }
    private void PlayUpdate()
    {
        input.ManualUpdate();
        player.ManualUpdate();
    }

    #endregion

    #region GameOver

    private IEnumerator GameOverEnterState()
    {
        game.jumperCam.state = SceneState.GameOver;
        yield break;
    }

    #endregion
}
