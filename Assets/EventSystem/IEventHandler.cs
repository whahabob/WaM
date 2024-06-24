/// <summary>
/// Generic EventHandler that will help with the Events being fired from the WaMEventSystem
/// </summary>
/// <typeparam name="T"></typeparam>
public interface IEventHandler<T>
{
    void OnEvent(T args);
}