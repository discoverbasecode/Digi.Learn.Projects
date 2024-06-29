namespace Framework.Core.Application.OperationResultHelpers;

public class OperationResultData<TData>
{
    public const string SuccessMessage = "عملیات با موفقیت انجام شد";
    public const string ErrorMessage = "عملیات با شکست مواجه شد";

    public string Message { get; set; }
    public string Title { get; set; } = null;
    public OperationResultStatus Status { get; set; }
    public TData Data { get; set; }
    public static OperationResult<TData> Success(TData data)
    {
        return new OperationResult<TData>()
        {
            Status = OperationResultStatus.Success,
            Message = SuccessMessage,
            Data = data,
        };
    }
    public static OperationResult<TData> NotFound()
    {
        return new OperationResult<TData>()
        {
            Status = OperationResultStatus.NotFound,
            Title = "NotFound",
            Data = default(TData),
        };
    }
    public static OperationResult<TData> Error(string message = ErrorMessage)
    {
        return new OperationResult<TData>()
        {
            Status = OperationResultStatus.Error,
            Title = "مشکلی در عملیات رخ داده",
            Data = default(TData),
            Message = message
        };
    }
}