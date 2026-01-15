using System.Collections.Generic;
using UnityEngine;

public class MapTile : MonoBehaviour
{
    public List<MapTile> neigbors;

    public void AddTiles(MapTile newTile)
    {
        neigbors.Add(newTile);
    }
}