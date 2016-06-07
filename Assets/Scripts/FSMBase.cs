using UnityEngine;
using System.Collections;
using System.Reflection;
using System;

public class FSMBase : ClimbBehavior 
{
    private Action DoUpdate = DoNothing;
    private Action DoManualUpdate = DoNothing;
    private Func<IEnumerator> ExitState = DoNothingCoroutine;
    private Action<Collider> DoOnTriggerEnter = DoNothingTrigger;

    private Enum currentState;

    public Enum state
    {
        set
        {
            currentState = value;
            ConfigureCurrentState();
        }
        get
        {
            return currentState;
        }
    }

    private static void DoNothingTrigger(Collider coll) { }
    private static void DoNothing() { }
    private static IEnumerator DoNothingCoroutine() { yield break; }

    private void ConfigureCurrentState()
    {
        if (ExitState != null)
        {
            StartCoroutine(ExitState());
        }
        DoUpdate = ConfigureDelegate<Action>("Update", DoNothing);
        DoManualUpdate = ConfigureDelegate<Action>("ManualUpdate", DoNothing);
        DoOnTriggerEnter = ConfigureDelegate<Action<Collider>>("OnTriggerEnter", DoNothingTrigger);
        ExitState = ConfigureDelegate<Func<IEnumerator>>("ExitState", DoNothingCoroutine);
        Func<IEnumerator> enterState = ConfigureDelegate<Func<IEnumerator>>("EnterState", DoNothingCoroutine);

        StartCoroutine(enterState());
    }
    private T ConfigureDelegate<T>(string methodName, T Default) where T : class
    {
        var method = GetType().GetMethod(currentState.ToString() + methodName, BindingFlags.Instance | BindingFlags.InvokeMethod | BindingFlags.Public | BindingFlags.NonPublic);
        if (method == null)
            return Default;

        return Delegate.CreateDelegate(typeof(T), this, method) as T;
    }

    private void Update()
    {
        DoUpdate();
    }
    protected override void ManualUpdate()
    {
        base.ManualUpdate();
        DoManualUpdate();
    }
}
