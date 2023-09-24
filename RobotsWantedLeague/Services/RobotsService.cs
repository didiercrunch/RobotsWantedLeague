using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace RobotsWantedLeague.Services;

using RobotsWantedLeague.Models;

public class RobotsService: IRobotsService
{
    private readonly IMongoCollection<Robot> robotsCollection;

    public List<Robot> Robots { get => robotsCollection.AsQueryable().ToList(); }

    public RobotsService(IOptions<RobotsDatabaseSettings> bookStoreDatabaseSettings)
    {
        var mongoClient = new MongoClient(
            bookStoreDatabaseSettings.Value.ConnectionString);

        var mongoDatabase = mongoClient.GetDatabase(
            bookStoreDatabaseSettings.Value.DatabaseName);

        this.robotsCollection = mongoDatabase.GetCollection<Robot>(bookStoreDatabaseSettings.Value.RobotsCollectionName);
    }

    public Robot CreateRobot(string name,
                          int weight,
                          int height,
                          string country)
    {
        var robot = new Robot(null, name, weight, height, country);
        robotsCollection.InsertOne(robot);
        return robot;
    }
    

    public Robot? GetRobotById(string id)
    {
        IQueryable<Robot> q = from robot in robotsCollection.AsQueryable()
            where robot.Id == id
            select robot;
        return q.First();
    }

    public bool DeleteRobotById(string id)
    {
        var res = robotsCollection.DeleteOne(robot => robot.Id == id);
        return res != null ;
    }

}