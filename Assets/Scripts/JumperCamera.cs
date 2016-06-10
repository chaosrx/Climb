using UnityEngine;
using System.Collections;

public class JumperCamera : FSMBase 
{
    private void FollowPlayer()
    {
        transform.position = game.scene.player.transform.position + Vector3.up;
    }

    #region Loading

    private IEnumerator LoadingEnterState()
    {
        yield return null;
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
        FollowPlayer();
    }

    #endregion

    #region GameOver

    private IEnumerator GameOverEnterState()
    {
        yield break;
    }

    #endregion
}
