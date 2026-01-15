using UnityEngine;

public class ArroundTiles : MonoBehaviour
{
    public MapTile tile;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("tiles"));
        {
            tile.AddTiles(other.gameObject.GetComponent<MapTile>());
        }
    }
}
