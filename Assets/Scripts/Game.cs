﻿using UnityEngine;
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
    public OVRCameraRig camRig { private set; get; }

    public Game()
    {
        audio = new Audio();
        camRig = GameObject.FindObjectOfType(typeof(OVRCameraRig)) as OVRCameraRig;
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
