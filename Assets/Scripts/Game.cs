using UnityEngine;
using System.Collections;

public class Game
{
    private static Game instance = null;

    public static Game Instance
    {
        get
        {
            if (instance == null)
                instance = new Game();
            return instance;
        }
    }

    public Scene scene { private set; get; }
    public Audio audio { private set; get; }
    public UIActionManager ui { private set; get; }
    public OVRCameraRig ovrCamRig { private set; get; }
    public OVRManager ovrMgr { private set; get; }
    public JumperCamera jumperCam { private set; get; }

    public Game()
    {
        audio = new Audio();
        ovrCamRig = GameObject.FindObjectOfType(typeof(OVRCameraRig)) as OVRCameraRig;
        ovrMgr = GameObject.FindObjectOfType(typeof(OVRManager)) as OVRManager;
        jumperCam = GameObject.FindObjectOfType(typeof(JumperCamera)) as JumperCamera;
    }

    public void SetScene(Scene scene)
    {
        this.scene = scene;
    }
    public void SetUI(UIActionManager ui)
    {
        this.ui = ui;
    }
}
