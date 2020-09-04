﻿using System;

public class Point
{
    protected double x; // x coordiate of Point
    protected double y; // y coordinate of Point

    public void setPoint (double xCoor, double yCoor) {
        x = xCoor;
        y = yCoor;
    }

    public double dist(Point p)  // compute the distance of point p to the current point
    {
        double distance;
        distance = Math.Sqrt((x - p.x) * (x - p.x) + (y - p.y) * (y - p.y));
        return distance;
    }
    public double dist(double x2, double y2)  // compute the distance of point p to the current point
    {
        double distance;
        distance = Math.Sqrt((x - x2) * (x - x2) + (y - y2) * (y - y2));
        return distance;
    }
    public void print()
    {
        Console.Write("Point: ({0}, {1})", x, y);
    }
}
