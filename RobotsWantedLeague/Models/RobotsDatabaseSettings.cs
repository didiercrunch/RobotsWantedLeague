namespace RobotsWantedLeague.Models;

public class RobotsDatabaseSettings
{
    
    public string ConnectionString { get; set; } = null!;

    public string DatabaseName { get; set; } = null!;

    public string RobotsCollectionName { get; set; } = null!;
}