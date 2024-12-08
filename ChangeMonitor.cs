namespace MarkDownPad;

public class ChangeMonitor
{
    public List<Listener> listeners = new();
    public void RegisterListener(Listener listener)
    {
        listeners.Add(listener);
    }

    public void UnregisterListener(Listener listener)
    {
        listeners.Remove(listener);
    }

    public void TriggerChange(Listener listener)
    {
        foreach(var l in listeners)
        {
            if (l != listener)
                l.OnChange();
        }
    }
}


public interface Listener
{
    public void OnChange();
}