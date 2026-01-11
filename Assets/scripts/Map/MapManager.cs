using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    public List<GameObject> AllTilesList;

    private void Start()
    {
        if (AllTilesList.Count == 0)
        {
            Debug.Log("empty tile list");
        }
        else
        {
            foreach (GameObject tile in AllTilesList)
            {
                if (tile.GetComponent<MapTile>().sideTiles.Count == 0)
                {
                    Debug.Log("empty sideTileList int:" + tile.name);
                }
            }
        }
    }
}
