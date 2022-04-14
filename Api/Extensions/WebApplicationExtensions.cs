using Api.Commands;
using Api.Models;
using Api.Queries;
using Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Extensions;

public static class WebApplicationExtensions
{
    public static WebApplication AddEndpoints(this WebApplication app)
    {
        const string planetsTag = "Planets";
        const string robotsTag = "Robots";

        app.MapGet("/planets", async ([FromServices] IMediator mediator) => Results.Ok(await mediator.Send(new GetAllPlanets())))
            .Produces<IEnumerable<PlanetDto>>()
            .WithTags(planetsTag);

        app.MapGet("/planets/{planetId:int}", async (int planetId, [FromServices] IMediator mediator) =>
                await mediator.Send(new GetPlanetById(planetId))
                    is { } planet
                    ? Results.Ok(planet)
                    : Results.NotFound()
            )
            .Produces<PlanetDto>()
            .Produces(StatusCodes.Status404NotFound)
            .ProducesValidationProblem()
            .WithTags(planetsTag);

        app.MapPost("/planets", async ([FromBody] string name, [FromServices] IMediator mediator) =>
            {
                var newPlanet = await mediator.Send(new CreatePlanet(name));
                return Results.Created($"planets/{newPlanet.Id}", newPlanet);
            })
            .Produces<PlanetDto>(StatusCodes.Status201Created)
            .ProducesValidationProblem()
            .WithTags(planetsTag);

        app.MapPut("/planets/{planetId}/areas/{areaId}/assign-robot",
                async (int planetId, int areaId, int robotId, [FromServices] IMediator mediator) => Results.Ok(await mediator.Send(new AssignRobotToPlanet(planetId, areaId, robotId))))
            .Produces<PlanetDto>()
            .WithTags(planetsTag);

        app.MapGet("/robots", async ([FromServices] IMediator mediator) => Results.Ok(await mediator.Send(new GetAllRobots())))
            .Produces<IEnumerable<RobotDto>>()
            .WithTags(robotsTag);

        app.MapGet("/robots/{robotId:int}", async (int robotId, [FromServices] IMediator mediator) =>
                await mediator.Send(new GetRobotById(robotId))
                    is { } robot
                    ? Results.Ok(robot)
                    : Results.NotFound()
            )
            .Produces<RobotDto>()
            .Produces(StatusCodes.Status404NotFound)
            .ProducesValidationProblem()
            .WithTags(robotsTag);

        app.MapPost("/robots", async ([FromBody] string name, [FromServices] IMediator mediator) =>
            {
                var newRobot = await mediator.Send(new CreateRobot(name));
                return Results.Created($"robots/{newRobot.Id}", newRobot);
            })
            .Produces<RobotDto>(StatusCodes.Status201Created)
            .ProducesValidationProblem()
            .WithTags("Robots");

        app.MapPost("/robots/{robotId:int}/move", async (int robotId, [FromServices] IMediator mediator) =>
                await mediator.Send(new RobotMoveForward(robotId))
                    is { } robot
                    ? Results.Ok(robot)
                    : Results.NotFound()
            )
            .Produces<RobotDto>()
            .Produces(StatusCodes.Status404NotFound)
            .ProducesValidationProblem()
            .WithTags(robotsTag);

        app.MapPost("/robots/{robotId:int}/turn-left", async (int robotId, [FromServices] IMediator mediator) =>
                await mediator.Send(new RobotTurnLeft(robotId))
                    is { } robot
                    ? Results.Ok(robot)
                    : Results.NotFound()
            )
            .Produces<RobotDto>()
            .Produces(StatusCodes.Status404NotFound)
            .ProducesValidationProblem()
            .WithTags(robotsTag);

        app.MapPost("/robots/{robotId:int}/turn-right", async (int robotId, [FromServices] IMediator mediator) =>
                await mediator.Send(new RobotTurnRight(robotId))
                    is { } robot
                    ? Results.Ok(robot)
                    : Results.NotFound()
            )
            .Produces<RobotDto>()
            .Produces(StatusCodes.Status404NotFound)
            .ProducesValidationProblem()
            .WithTags(robotsTag);

        return app;
    }
}