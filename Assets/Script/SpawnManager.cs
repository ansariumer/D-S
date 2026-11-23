using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject healthPoint;
    //public Transform Blasto;

    [Range(0f, 100f)] // changed to ff
    public float healthChance = 50f;

    public void healthSpawn(Vector3 spawnPosition)
    {
        float randomValue = Random.Range(0f, 100f);

        if (randomValue <= healthChance)
        {
            Instantiate(healthPoint, spawnPosition, Quaternion.identity);
            Debug.Log("Spawned Health");
        }
    }
}
