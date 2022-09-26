namespace Transport_ly.DomainLogic.Interfaces
{
    public interface IConsolePrint
    {
        void PrintToConsole();
    }

    public interface IConsolePrintAsync
    {
        Task PrintToConsoleAsync();
    }
}
