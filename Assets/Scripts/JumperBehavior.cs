using UnityEngine;
using System.Collections;

public class JumperBehavior : MonoBehaviour
{
    public Game game { private set; get; }
    public InputManager input { private set; get; }

    protected virtual void Awake()
    {
        game = Game.Instance;
        input = InputManager.Instance;
    }

    public virtual void ManualUpdate()
    {

    }
}
