namespace BusinessIn.Application.Exceptions.Common;

public class BnException : Exception {
    public string Title { protected set; get; } = "UnhandledException";
    public string Details { protected set; get; } = "Exception happened while processing your request";
    public int StatusCode { protected set; get; } = 500;

    protected void SetTitle(string title) => Title = title;
    protected void SetDetails(string details) => Details = details;
    protected void SetStatusCode(int statusCode) => StatusCode = statusCode;
}