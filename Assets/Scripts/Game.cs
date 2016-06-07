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

    public Game()
    {
        audio = new Audio();
    }

    public void SetScene(Scene scene)
    {
        this.scene = scene;
    }
}
