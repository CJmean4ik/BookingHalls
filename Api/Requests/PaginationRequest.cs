using Microsoft.AspNetCore.Mvc;

namespace Api.Requests;

public class PaginationRequest
{
    [FromQuery] public int Page { get; set; } = 1;
    [FromQuery] public int Limit { get; set; } = 10;
}