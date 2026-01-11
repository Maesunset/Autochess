using System.Collections.Generic;
using UnityEngine;

public class MapTile : MonoBehaviour
{
    public List<GameObject> sideTiles;

    private void Start()
    {
        foreach (GameObject child in sideTiles)
        {
            if (child == gameObject)
            {
                Debug.Log(" same GameObject");
                sideTiles.Remove(child);
                
            }
        }
    }
}
