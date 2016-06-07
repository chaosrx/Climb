using UnityEngine;
using System.Collections;

public class ClimbBehavior : MonoBehaviour
{
    public Game game { private set; get; }
    public InputManager input { private set; get; }

    protected virtual void Awake()
    {
        game = Game.Instance;
        input = InputManager.Instance;
    }
    protected virtual void ManualUpdate()
    {

    }
}
