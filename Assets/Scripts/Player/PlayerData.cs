using System.Text;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public int shotsFired;
    public int targetsHit;
    public List<float> timeBetweenShots = new();
    public List<float> timeBetweenHits = new();

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();

        sb.AppendLine($"Shots Fired: {shotsFired}");
        sb.AppendLine($"Targets Hit: {targetsHit}");

        sb.Append("Time Between Shots: ");
        sb.AppendLine(timeBetweenShots.Count > 0 ? string.Join(", ", timeBetweenShots) : "None");

        sb.Append("Time Between Hits: ");
        sb.AppendLine(timeBetweenHits.Count > 0 ? string.Join(", ", timeBetweenHits) : "None");

        return sb.ToString();
    }
}
