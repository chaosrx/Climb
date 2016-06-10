using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum InputType
{
    A = 0,
    B,
    Max
}

public class InputManager : JumperBehavior
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

    public Vector2 joyStickDirection { private set; get; }

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

    public override void ManualUpdate()
    {
        base.ManualUpdate();
        joyStickDirection = new Vector2(Input.GetAxis("Horizontal") ,Input.GetAxis("Vertical"));

        if (Input.GetButtonDown("Fire1") && !IsKeyDown(InputType.A))
            KeyDown(InputType.A);
        if (Input.GetButtonUp("Fire1") && IsKeyDown(InputType.A))
            KeyUp(InputType.A);
        if (Input.GetButtonDown("Fire2") && !IsKeyDown(InputType.B))
            KeyDown(InputType.B);
        if (Input.GetButtonUp("Fire2") && IsKeyDown(InputType.B))
            KeyUp(InputType.B);
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
        input[type] = true;
    }
    public void KeyUp(InputType type)
    {
        input[type] = false;
    }
}
