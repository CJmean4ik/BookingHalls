using Api.Responces.Global;
using Domain.Shared;
using Domain.Shared.Utils;

namespace Api.Contracts;

public interface IResponceFactory
{
    BaseResponce CreateErrorResponce(Result? result = null, Exception? ex = null);

    SuccessResponce<T> CreateSuccessResponce<T>(Result result, params T[] data);
}