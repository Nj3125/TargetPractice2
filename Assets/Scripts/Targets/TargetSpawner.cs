using System.Collections.Generic;
using UnityEngine;

public class TargetSpawner : MonoBehaviour
{
    public GameObject targetPrefab;
    public float spawnRadius = 10f;
    public float minDistance = 1.5f;
    public int maxTargets = 5;

    private List<Vector3> spawnedPositions = new List<Vector3>();
    private List<GameObject> activeTargets = new List<GameObject>();

    void Start()
    {
        // Spawn targets up to the designated max targets:
        for (int i = 0; i < maxTargets; i++)
        {
            SpawnTarget();
        }
    }

    void Update()
    {
        activeTargets.RemoveAll(item => item == null);
        if (activeTargets.Count == 0)
        {
            spawnedPositions.Clear(); // reset so they don’t overlap with old positions
            for (int i = 0; i < maxTargets; i++)
            {
                SpawnTarget();
            }
        }
    }
    void SpawnTarget()
    {
        Vector3 spawnPos;
        // Spawn a single target that does not overlap with other targets:
        do
        {
            // Calculate random spawn position (z is 0):
            spawnPos = transform.position + new Vector3(Random.Range(-spawnRadius, spawnRadius), Random.Range(0.5f, 3.0f), 0);
            // Keep doing this until position is valid (no overlap):
        } while (!isPositionValid(spawnPos));

        // Record the spawned position:
        spawnedPositions.Add(spawnPos);

        // Spawn the target:
        GameObject newTarget = Instantiate(targetPrefab, spawnPos, targetPrefab.transform.rotation);
        activeTargets.Add(newTarget);
    }

    bool isPositionValid(Vector3 pos)
    {
        // Iterate over each catalogued position.
        foreach (Vector3 existingPos in spawnedPositions)
        {
            // If within the min distance, it is overlapping and is not a valid position:
            if (Vector3.Distance(pos, existingPos) < minDistance)
            {
                return false;
            }
        }
        // Else, it is a valid position:
        return true;
    }
}
