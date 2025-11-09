using UnityEngine;

public class PelletSpawner : MonoBehaviour
{
    public GameObject pelletPrefab;
    public GameObject powerBulletPrefab;
    public LayerMask obstacleLayer;
    public LayerMask noSpawnZoneLayer;
    public Vector2 boxSize = new Vector2(0.5f, 0.5f);
    void GeneratePellet()
    {
        for (int y = 0; y < 29; y++)
        {
            for (int x = 0; x < 26; x++)
            {
                GameObject prefab = ((y == 6 || y == 26) && (x == 0 || x == 25)) ? powerBulletPrefab : pelletPrefab;
                Vector3 position = new Vector3(transform.position.x + x * 0.5F, transform.position.y + y * 0.5F, -1);
                bool canSpawn = !Physics2D.OverlapBox(position, boxSize, 0f, noSpawnZoneLayer);
                bool notOverlapingObstacles = !Physics2D.OverlapBox(position, boxSize, 0f, obstacleLayer);
                if (notOverlapingObstacles && canSpawn)
                    Instantiate(prefab, position, Quaternion.identity, transform);
            }
        }
    }
    void Start()
    {
        obstacleLayer = LayerMask.GetMask("Obstacles");
        noSpawnZoneLayer = LayerMask.GetMask("NoSpawnZone");
        GeneratePellet();
    }
}
