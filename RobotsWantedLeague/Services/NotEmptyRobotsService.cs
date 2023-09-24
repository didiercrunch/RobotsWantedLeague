using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace RobotsWantedLeague.Services;

using RobotsWantedLeague.Models;

public class NotEmptyRobotsService: IRobotsService
{
    private readonly IRobotsService underlyingRobotsService;
    public List<Robot> Robots { get => underlyingRobotsService.Robots; }

    public NotEmptyRobotsService(RobotsService underlyingRobotsService)
    {
        this.underlyingRobotsService = underlyingRobotsService;
        fillDefaultRobotsWhenUnderlyingRobotServiceIsEmpty();
    }

    private void fillDefaultRobotsWhenUnderlyingRobotServiceIsEmpty()
    {
        if (underlyingRobotsService.Robots.Count() != 0)
        {
            return;
        }
        this.underlyingRobotsService.CreateRobot("Alice", 1050, 2, "Bhutan");
        this.underlyingRobotsService.CreateRobot("Bob", 5001, 5, "Vanuatu");
        this.underlyingRobotsService.CreateRobot("Xu", 890, 1, "Taiwan");
        
    }

    public Robot CreateRobot(string name,
                          int weight,
                          int height,
                          string country)
    {
        var robot = underlyingRobotsService.CreateRobot(name, weight, height, country);
        return robot;
    }


    public Robot? GetRobotById(string id){
        return underlyingRobotsService.GetRobotById(id);
    }

    public bool DeleteRobotById(string id){
        return underlyingRobotsService.DeleteRobotById(id);
    }

}