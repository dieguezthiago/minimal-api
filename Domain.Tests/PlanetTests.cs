using System;
using Domain.Models;
using FluentAssertions;
using Xunit;

namespace Domain.Tests;

public class PlanetTests
{
    [Fact]
    public void Ctor_WhenNameIsProvided_ThenCreatePlanetWithEmptyAreas()
    {
        //Arrange
        const string name = "Jupiter";

        //Act
        var planet = new Planet(name);

        //Assert
        planet.Name.Should().Be(name);
        planet.Areas.Should().BeEmpty();
    }

    [Fact]
    public void Ctor_WhenNameIsNotProvided_ThenThrowArgumentNullException()
    {
        //Arrange
        const string name = "";

        //Act
        Action act = () => new Planet(name);

        //Assert
        act.Should().ThrowExactly<ArgumentNullException>();
    }
}