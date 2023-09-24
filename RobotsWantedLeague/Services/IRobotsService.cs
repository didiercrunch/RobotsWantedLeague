namespace RobotsWantedLeague.Services;
using RobotsWantedLeague.Models;

public interface IRobotsService{
    public List<Robot> Robots { get; }

    public Robot CreateRobot(string name,
                          int weight,
                          int height,
                          string country);

    public Robot? GetRobotById(string id);

    public bool DeleteRobotById(string id);
}