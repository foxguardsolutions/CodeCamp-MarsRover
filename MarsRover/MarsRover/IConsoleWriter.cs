namespace MarsRover
{
    public interface IConsoleWriter
    {
        void WriteLine(string message, params object[] args);
    }
}
