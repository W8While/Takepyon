
using System;
using UnityEngine;


public interface IInteraction
{
}

public interface IInteractionFocus : IInteraction
{
    public void StartFocus();
    public void StopFocus();
    public event Action<string> StartInteractionUI;
    public event Action StopInteractionUI;
}

public interface ITalkSetterUI : IInteraction
{
    public event Action<string> SetTalkUI;
}

public interface IClickable : IInteractionFocus
{
    public void Click();
}
public interface IClickInteraction : IInteractionFocus
{
    public void ClickInteraction(Action<Vector3, Vector3> CameraMover);
}

public interface IClickInteractionDairy : IClickInteraction
{
    public void StartInteractionDairy();
    public void StopInteractionDairy();
    public event Action<DairyBase> StartDairyReading;
    public event Action StopDairyReading;
}