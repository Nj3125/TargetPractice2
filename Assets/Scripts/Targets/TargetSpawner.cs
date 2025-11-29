using System.Collections.Generic;
using UnityEngine;

public class TargetSpawner : MonoBehaviour
{
    public GameObject targetPrefab;
    public float spawnRadius = 10f;
    public float minDistance = 1.5f;
    public int maxTargets = 5;

    private Dictionary<GameObject, Vector3> targetPositions = new Dictionary<GameObject, Vector3>();
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
        // Remove destroyed (null) targets
        foreach (var key in new List<GameObject>(targetPositions.Keys))
        {
            if (key == null)
                targetPositions.Remove(key);
        }

        activeTargets.RemoveAll(t => t == null);

        while (activeTargets.Count < maxTargets)
            SpawnTarget();
    }
    void SpawnTarget()
    {
        Vector3 spawnPos;

        do
        {
            spawnPos = transform.position + new Vector3(
                Random.Range(-spawnRadius, spawnRadius),
                Random.Range(0.5f, 3f),
                0
            );
        } 
        while (!isPositionValid(spawnPos));

        GameObject newTarget = Instantiate(targetPrefab, spawnPos, targetPrefab.transform.rotation);

        activeTargets.Add(newTarget);
        targetPositions.Add(newTarget, spawnPos);
    }

    bool isPositionValid(Vector3 pos)
    {
        foreach (Vector3 existing in targetPositions.Values)
        {
            if (Vector3.Distance(pos, existing) < minDistance)
                return false;
        }
        return true;
    }
}
