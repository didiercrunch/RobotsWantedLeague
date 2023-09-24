﻿using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using RobotsWantedLeague.Models;
using RobotsWantedLeague.Services;

namespace RobotsWantedLeague.Controllers;

public class RobotRequest{
    public RobotRequest(){
        this.Name = "";
        this.Country = "";
        this.Height = 0;
        this.Weight = 0;
    }
    
    public string Name { get; set; }
    public int Height { get; set; }
    public int Weight { get; set; }
    
    public string Country { get; set; }
}

public class RobotsController : Controller
{
    private readonly ILogger<RobotsController> _logger;
    private readonly IRobotsService robotsService;

    public RobotsController(ILogger<RobotsController> logger,
                            IRobotsService robotsService)
    {
        _logger = logger;
        this.robotsService = robotsService;
    }

    public IActionResult Index()
    {
        return View(robotsService.Robots);
    }

    public IActionResult Robot(string id){
        Robot? robot = robotsService.GetRobotById(id);
        return View(robot);
    }

    [HttpGet]
    public IActionResult CreateRobot(){
        return View();
    }

    [HttpPost]
    public IActionResult CreateRobot([FromBody] RobotRequest robot)
    {
        Robot r = robotsService.CreateRobot(robot.Name, 
                                            robot.Weight, 
                                            robot.Height, 
                                            robot.Country);
        string htmxRedirectHeaderName = "HX-Redirect";
        string redirectURL = "/robots/robot?id=" + r.Id;
        Response.Headers.Add(htmxRedirectHeaderName, redirectURL);
        return Ok();
    }
}
