using System.Text.Json.Serialization;
using System.Text.Json.Serialization.Metadata;
using Api.Contracts;
using Api.Middlewares;
using Api.Shared;
using Application;
using DataAccess;
using FastEndpoints;
using FluentValidation.AspNetCore;
using Infrastructure;

namespace Api;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddFastEndpoints();
        builder.Services.AddFluentValidationAutoValidation();
       
        builder.Services.AddDataAccessLayer(builder.Configuration);
        builder.Services.AddInfrastructureLayer();
        builder.Services.AddApplicationLayer();

        builder.Services.AddSingleton<IResponceFactory, ResponceFactory>();
        
        var app = builder.Build();

        app.MapFastEndpoints();
        app.UseMiddleware<ExceptionsHandlerMiddleware>();
        app.Run();
    }
}
