using UnityEngine;

public class Tab
{
    private Window _window;

    public Tab(Window window)
    {
        _window = window;
    }

    public void Click()
    {
        _window.Open();
    }
}
