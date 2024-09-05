namespace Explorer.API.Middleware.ExceptionModel;

public class ExceptionResponse
{
    public string Type { get; set; }
    public int Status { get; set; }
    public string Title { get; set; }

    public ExceptionResponse(Exception ex)
    {
        Type = ex.GetType().Name;
        Title = ex.Message;
        Status = (int)ex.ExceptionToStatus();
    }


}
