namespace VeryDeli.Data.Data
{
    public enum LogicErrorCode : byte
    {
        DefaultError = 0,
        QueryHandlerNotFound,
        CommandHandlerNotFound
    }
}
