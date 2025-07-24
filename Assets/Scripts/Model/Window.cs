using Unity.VisualScripting;
using UnityEngine;

public class Window : IInitializable
{
    public void Initialize()
    {
        Debug.Log("Window initialized");
    }

    public void Open()
    {
        Debug.Log("Window opened");
    }

    public void Close()
    {
        Debug.Log("Window closed");
    }
}
