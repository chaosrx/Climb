using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIActionManager : JumperBehavior
{
    public Text rig;
    public Text tracking;

    public GameObject titleWindow;

    public GameObject mainWindow;

    public GameObject stageSelectWindow;

    public GameObject playWindow;

    public GameObject gameOverWindow;

    protected override void Awake()
    {
        base.Awake();
        game.SetUI(this);
    }
    
    public void ActiveTitleWindow()
    {

    }
    public void ActiveMainWindow()
    {

    }
    public void ActiveStageSelectWindow()
    {

    }
    public void ActivePlayWindow()
    {

    }
    public void ActiveGameOverWindow()
    {

    }

    public void OnTitleClick()
    {

    }
    public void OnStageSelectClick()
    {

    }
    public void OnTestMapClick()
    {

    }
}
