using Api.Contracts;
using Api.Responces.Global;
using Domain.Shared.Utils;
using Domain.Shared.Utils.TypesResults.ErrorsResults;

namespace Api.Shared;

public class ResponceFactory : IResponceFactory
{
    
    public BaseResponce CreateErrorResponce(Result? result = null, Exception? ex = null)
    {
        if (result is not null)
        {
            return CreateResponceFromResult(result);
        }
      
        var errorResponce = new ErrorResponce()
        {
            Code = "500",
            Message = $"{ex!.Message}: {ex.StackTrace}",
            Title = ex.Source
        };
        return errorResponce;
    }
    public SuccessResponce<T> CreateSuccessResponce<T>(Result result, params T[] data)
    {
        var successResponce = new SuccessResponce<T>
        {
            Code = StatusCodes.Status200OK.ToString(),
            Title = "The operation was successful",
            Message = result.Success!.Message!,
        };
        successResponce.Datas.AddRange(data);
        return successResponce;
    }
    private BaseResponce CreateResponceFromResult(Result result)
    {
        if (result.Error is OperationError operationError)
        {
            var errorResponce = new ErrorResponce()
            {
                Code = operationError.ErrorType.ToString(),
                Message = operationError.Message,
                Title = operationError.Operation
            };
            return errorResponce;
        }

        if (result.Error is ValidationError validationError)
        {
            var errorResponce = new ValidationErrorResponce()
            {
                Code = validationError.ErrorType.ToString(),
                Message = validationError.Message,
                Title = "Validation failure"
            };
            errorResponce.ErrorModels.Add(validationError);
            return errorResponce;
        }

        return null;
    }

    private void AddErrorReasons(ErrorResponce responce, Result result)
    {
        var operationErrors = result.ErrorReasons.All(w => w.GetType() == typeof(OperationError));
        if (operationErrors)
        {
            
        }
    }
    
}