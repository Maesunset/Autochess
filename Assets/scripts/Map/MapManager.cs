using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    public List<MapTile> AllTilesList;

    private void Start()
    {
        if (AllTilesList == null || AllTilesList.Count == 0)
        {
            Debug.Log("No tiles found");
            return;
        }
        else
        {
            Debug.Log(AllTilesList.Count);
        }
        List<MapTile> tempList = AStar(AllTilesList[Random.Range(0, AllTilesList.Count)], AllTilesList[Random.Range(0, AllTilesList.Count)]);
        {
            foreach (var tile in tempList)
            {
                Debug.Log(tile.gameObject.name);
            }
        }
    }

    public List<MapTile> AStar(MapTile startTile, MapTile goalTile)
    {
        var openList = new List<MapTile> { startTile };
        var closedList = new HashSet<MapTile>();
        var cameFrom = new Dictionary<MapTile, MapTile>();

        var gScore = new Dictionary<MapTile, float>();
        var fScore = new Dictionary<MapTile, float>();

        foreach (var tile in AllTilesList)
        {
            gScore[tile] = Mathf.Infinity;
            fScore[tile] = Mathf.Infinity;
        }

        gScore[startTile] = 0;
        fScore[startTile] = Heuristic(startTile, goalTile);

        while (openList.Count > 0)
        {
            MapTile current = openList[0];
            foreach (var node in openList)
            {
                if (fScore[node] < fScore[current])
                    current = node;
            }
            if (current == goalTile)
            {
                return ReconstructPath(cameFrom, current);
            }
            openList.Remove(current);
            closedList.Add(current);

            foreach (var neighbor in current.sideTiles)
            {
                if (closedList.Contains(neighbor)) continue;
                float tentativeG = gScore[current] + Distance(current, neighbor);
                if (!openList.Contains(neighbor))
                    openList.Add(neighbor);
                else if (tentativeG >= gScore[neighbor])
                    continue;
                cameFrom[neighbor] = current;
                gScore[neighbor] = tentativeG;
                fScore[neighbor] = gScore[neighbor] + Heuristic(neighbor, goalTile);
            }
        }
        Debug.LogWarning("No path found!");
        return null;
    }

    private float Heuristic(MapTile a, MapTile b)
    {
        return Vector3.Distance(a.transform.position, b.transform.position);
    }
    private float Distance(MapTile a, MapTile b)
    {
        return Vector3.Distance(a.transform.position, b.transform.position);
    }
    private List<MapTile> ReconstructPath(Dictionary<MapTile, MapTile> cameFrom, MapTile current)
    {
        List<MapTile> totalPath = new List<MapTile> { current };
        while (cameFrom.ContainsKey(current))
        {
            current = cameFrom[current];
            totalPath.Insert(0, current);
        }
        Debug.Log("Path found: " + string.Join(" -> ", totalPath));
        return totalPath;
    }
}