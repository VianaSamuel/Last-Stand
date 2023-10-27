using System.Collections.Generic;
using UnityEngine;

public static class ObstacleManager
{
    public static List<Vector3> obstaclePositions = new List<Vector3>();

    public static void AddObstacle(Vector3 position)
    {
        obstaclePositions.Add(position);
    }

    public static void ClearObstacles()
    {
        obstaclePositions.Clear();
    }
}