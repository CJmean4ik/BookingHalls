using Api.Contracts;
using Api.Responces.Global;
using Api.Shared;
using Application.Requests.Hall;
using Application.Services;
using Application.Services.Hall;
using Domain.Shared;
using FastEndpoints;

namespace Api.Endpoints.Hall;

public class CreateHallEndpoints : Endpoint<CreateHallRequest, BaseResponce>
{
    private readonly CreateHall _createHall;
    private readonly IResponceFactory _responceFactory;
    public CreateHallEndpoints(CreateHall createHall, IResponceFactory responceFactory)
    {
        _createHall = createHall;
        _responceFactory = responceFactory;
    }

    public override void Configure()
    {
        Post("api/halls");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CreateHallRequest req, CancellationToken ct)
    {
        var result = await _createHall.CreateAsync(req,ct);
        
        if (result.IsFailure)
        {
            var errorResponce = _responceFactory.CreateErrorResponce(result);
            await SendAsync(errorResponce,400,cancellation: ct);
            return;
        }

        var hallResponce = Mapper.FromHallToHallResponce(result.Value);
        
        var successResult = _responceFactory.CreateSuccessResponce(result,hallResponce);
        await SendAsync(successResult,200,cancellation: ct);
    }
}