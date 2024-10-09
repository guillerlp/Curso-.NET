using Microsoft.AspNetCore.Http.HttpResults;
using webapi.Common;

public class Items : IFeatureModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/items", () => {
            Results.Ok();
        });
    }
}