using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum InputType
{
    X = 0,
    Y,
    A,
    B,
    LT,
    LB,
    RT,
    RB,
    Max
}

public class InputManager : ClimbBehavior
{
    private static InputManager instance = null;

    public static InputManager Instance
    {
        get
        {
            if (instance == null)
                instance = FindObjectOfType(typeof(InputManager)) as InputManager;

            return instance;
        }
    }

    private Dictionary<InputType , bool> input = new Dictionary<InputType,bool>();

    protected override void Awake()
    {
        base.Awake();

        for (int i = 0; i < (int)InputType.Max; i++)
        {
            InputType type = (InputType)i;
            if (input.ContainsKey(type))
                continue;
            input.Add(type, false);
        }
    }

    public bool IsKeyDown(InputType type)
    {
        bool tmp;
        if (input.TryGetValue(type, out tmp))
            return tmp;

        Debug.LogError("Not Initializing : Input Manager");
        return false;
    }
    public void KeyDown(InputType type)
    {
        bool tmp;
        if (input.TryGetValue(type, out tmp))
            tmp = true;
    }
    public void KeyUp(InputType type)
    {
        bool tmp;
        if (input.TryGetValue(type, out tmp))
            tmp = false;
    }
}
