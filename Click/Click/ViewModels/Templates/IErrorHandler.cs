namespace Click.ViewModels
{
    public interface IErrorHandler
    {
        void HandleError<Exception>(Exception _ex);
    }
}