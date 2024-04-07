using System.Collections;
using UnityEngine;

public class RandomActivator : MonoBehaviour
{
    // Array of GameObjects to randomly activate
    public GameObject[] objectsToSpawn;

    // Coroutine for spawning objects
    private Coroutine spawningCoroutine;

    /// <summary>
    /// Start is called before the first frame update
    /// </summary>
    private void Start()
    {
        // Initialize the spawning coroutine
        spawningCoroutine = StartCoroutine(SpawnObjects());
    }

    /// <summary>
    /// Spawns objects at random intervals
    /// </summary>
    /// <returns>Coroutine</returns>
    private IEnumerator SpawnObjects()
    {
        while (true)
        {
            // Calculate the spawn interval based on game time
            float spawnInterval = GetSpawnInterval();
            yield return new WaitForSeconds(spawnInterval);

            // Activate a random object
            ActivateRandomObject();
        }
    }

    /// <summary>
    /// Activates a random object from the array
    /// </summary>
    private void ActivateRandomObject()
    {
        // Get a random object from the array
        GameObject randomObject = GetRandomObject();
        if (randomObject!= null)
        {
            // Activate the object and set it to deactivate after a delay
            randomObject.SetActive(true);
            StartCoroutine(DeactivateAfterDelay(randomObject, 7f));
        }
    }

    /// <summary>
    /// Deactivates a GameObject after a specified delay
    /// </summary>
    /// <param name="obj">GameObject to deactivate</param>
    /// <param name="delay">Delay in seconds</param>
    /// <returns>Coroutine</returns>
    private IEnumerator DeactivateAfterDelay(GameObject obj, float delay)
    {
        yield return new WaitForSeconds(delay);
        obj.SetActive(false);
    }

    /// <summary>
    /// Calculates the spawn interval based on game time
    /// </summary>
    /// <returns>Spawn interval in seconds</returns>
    private float GetSpawnInterval()
    {
        // Increase spawn frequency over time
        float gameTimeInSeconds = Time.time;
        return Mathf.Max(20f - gameTimeInSeconds * 0.1f, 10f);
    }

    /// <summary>
    /// Gets a random object from the array
    /// </summary>
    /// <returns>Random GameObject</returns>
    private GameObject GetRandomObject()
    {
        return objectsToSpawn[Random.Range(0, objectsToSpawn.Length)];
    }
}