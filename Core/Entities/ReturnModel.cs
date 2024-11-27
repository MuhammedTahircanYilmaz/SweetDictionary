namespace Core.Entities;

public class ReturnModel<TData> // The Response model returned by the back end portion of the project to the front end, for the requests coming from the front end
{
    public TData? Data { get; set; } // The portion of the Model which carries the data response returned by the back end
    public string? Message { get; set; } // The portion of the Model which carries the message of success/failure regarding the request
    public bool Success { get; set; } // The portion of the Model which indicates whether the request was successfully completed or not
    public int Status { get; set; } // The portion of the Model which carries the HttpStatusCode for a given response 


    public static ReturnModel<TData> ReturnModelOfException(Exception exception, int status) // The Exception is any exception thrown either by the program itself, or the programmer. The Status is the code for the Http Status
    {
        return new ReturnModel<TData>
        {
            Data = default,
            Message = exception.Message,
            Success = false,
            Status = status
        };
    }

    public static ReturnModel<TData> ReturnModelOfSuccess(TData data, int status, string? message = null)
    {
        return new ReturnModel<TData>
        {
            Data = data,
            Message = message,
            Status = status,
            Success = true
        };
    }
}
