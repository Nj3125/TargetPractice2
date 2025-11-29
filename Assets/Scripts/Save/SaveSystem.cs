using UnityEngine;
using System.IO;
using System.Linq;

public static class SaveSystem
{
    private static string baseName = "game2test";
    private static string extension = ".json";
    public static void Save(PlayerData data)
    {
        string folder = Application.persistentDataPath;
        string[] files = Directory.GetFiles(folder, baseName + "_*" + extension);

        int nextIndex = 1;
        if (files.Length > 0)
        {
            nextIndex = files
                .Select(f => Path.GetFileNameWithoutExtension(f))
                .Select(name =>
                {
                    string numberPart = name.Substring(baseName.Length + 1);
                    int.TryParse(numberPart, out int n);
                    return n;
                })
                .DefaultIfEmpty(0)
                .Max() + 1;
        }

        string fileName = $"{baseName}_{nextIndex}{extension}";
        string fullPath = Path.Combine(folder, fileName);

        string json = JsonUtility.ToJson(data, true);

        File.WriteAllText(fullPath, json);
        Debug.Log($"Saved to: {fullPath}");
    }
}
