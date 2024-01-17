using System.Collections.Generic;
using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Environments;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Ships;
using Itmo.ObjectOrientedProgramming.Lab1.Models;
using Itmo.ObjectOrientedProgramming.Lab1.Services;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab1.Tests;

public class Journey
{
    public static IEnumerable<object[]> FirstTestData =>
        new List<object[]>
        {
            new object[] { new PleasureShuttle(1000) },
            new object[] { new Avgur(1000, false) },
        };

    public static IEnumerable<object[]> SecondTestData =>
        new List<object[]>
        {
            new object[] { new Vaklas(10000, true), new JourneyResult(true, 0, 0, false, false, false) },
            new object[] { new Vaklas(10000, false), new JourneyResult(true, 0, 0, false, false, false) },
        };

    public static IEnumerable<object[]> ThirdTestData =>
        new List<object[]>
        {
            new object[] { new Vaklas(1000, true) },
            new object[] { new Avgur(1000, true) },
            new object[] { new Meredian(1000, true) },
        };

    [Theory]
    [MemberData(nameof(FirstTestData))]
    public void ImposibleComplete(Spaceship ship)
    {
        var journeyFirst = new Services.Journey(ship);
        var obstacles = new Collection<Stones> { new Asteroid() };
        journeyFirst.AddRout(new Space(obstacles, 10000));
        Assert.True(!journeyFirst.JourneyCalculate().DoneJourney);
    }

    [Theory]
    [MemberData(nameof(SecondTestData))]
    public void PhotonDeflectors(Spaceship ship, JourneyResult result)
    {
        var journey = new Services.Journey(ship);
        var obstacles = new Collection<AntimatterFlares> { new AntimatterFlares() };
        journey.AddRout(new NitrineNebula(obstacles, 10));
        Assert.True(journey.JourneyCalculate().Equals(result));
    }

    [Theory]
    [MemberData(nameof(ThirdTestData))]
    public void DestroyingShips(Spaceship ship)
    {
        var obstacles = new Collection<AntimatterFlares> { new AntimatterFlares() };
        var journey = new Services.Journey(ship);
        journey.AddRout(new NitrineNebula(obstacles, 100));
        Assert.True(journey.JourneyCalculate().DoneJourney);
    }

    [Fact]
    public void OptimalShip()
    {
        var firstShip = new Vaklas(100, false);
        var secondShip = new PleasureShuttle(100);

        var journey = new Services.Journey(firstShip);
        var obstacles = new Collection<Stones>();
        journey.AddRout(new Space(obstacles, 100));
        Assert.Equal(journey.OptimapShip(firstShip, secondShip), secondShip);
    }

    [Fact]
    public void OptimalShip2()
    {
        var firstShip = new Avgur(100, false);
        var secondShip = new Stella(100, false);

        var journey = new Services.Journey(firstShip);
        var obstacles = new Collection<SpaceWhales>();
        journey.AddRout(new Nebula(obstacles, 100));
        Assert.Equal(journey.OptimapShip(firstShip, secondShip), secondShip);
    }

    [Fact]
    public void OptimalShip3()
    {
        var firstShip = new Vaklas(1000, false);
        var secondShip = new PleasureShuttle(1000);

        var journey = new Services.Journey(firstShip);
        var obstacles = new Collection<AntimatterFlares>();
        journey.AddRout(new NitrineNebula(obstacles, 100));
        Assert.Equal(journey.OptimapShip(firstShip, secondShip), firstShip);
    }

    [Fact]
    public void MoreRoutes()
    {
        var firstShip = new Avgur(10000, true);

        var journey = new Services.Journey(firstShip);
        var obstaclesFirst = new Collection<Stones> { new Asteroid(), new Meteorite() };
        var obstaclesSecond = new Collection<AntimatterFlares> { new AntimatterFlares() };
        var obstaclesThird = new Collection<SpaceWhales> { new SpaceWhales() };
        journey.AddRout(new Space(obstaclesFirst, 100));
        journey.AddRout(new NitrineNebula(obstaclesSecond, 100));
        journey.AddRout(new Nebula(obstaclesThird, 100));
        Assert.True(journey.JourneyCalculate().DoneJourney);
    }
}