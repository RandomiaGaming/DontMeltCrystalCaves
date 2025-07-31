using UnityEngine;
using System.Collections.Generic;
using System.IO;
public struct SaveData
{
    public ushort NormalProgress;
    public ushort HardProgress;
    public ushort ExpertProgress;
    public SaveData(ushort normalProgress, ushort hardProgress, ushort expertProgress)
    {
        NormalProgress = normalProgress;
        HardProgress = hardProgress;
        ExpertProgress = expertProgress;
    }
}
public static class SaveDataHelper
{
    public const bool SaveFilesSupported = true;

    public const string SaveDataSubPath = "SaveGame.txt";
    public static string SaveDataPath => Application.dataPath + @"\" + SaveDataSubPath;
    public static string DefaultSaveDataString => $"NormalProgress = {DefaultSaveData.NormalProgress};\nHardProgress = {DefaultSaveData.HardProgress};\nExpertProgress = {DefaultSaveData.ExpertProgress};";
    public static SaveData DefaultSaveData => new SaveData(0, 0, 0);

    public static SaveData SaveData = DefaultSaveData;

    public static void Load()
    {
        if (!SaveFilesSupported)
        {
            SaveData = DefaultSaveData;
            return;
        }

        if (!File.Exists(SaveDataPath))
        {
            SaveData = DefaultSaveData;
            Save();
            return;
        }

        string saveDataString = File.ReadAllText(SaveDataPath);

        saveDataString = saveDataString.ToLower();

        saveDataString = saveDataString.Replace(" ", "");
        saveDataString = saveDataString.Replace("\n", "");
        saveDataString = saveDataString.Replace("\r", "");
        saveDataString = saveDataString.Replace("\t", "");

        List<string> statements = new List<string>();

        int previousSplitIndex = 0;
        for (int i = 0; i < saveDataString.Length; i++)
        {
            if(saveDataString[i] == ';')
            {
                statements.Add(saveDataString.Substring(previousSplitIndex + 1, i));
            }
        }

        if(previousSplitIndex != saveDataString.Length - 1)
        {
            SaveData = DefaultSaveData;
            Save();
            return;
        }

        bool normalProgressSetAlready = false;
        bool hardProgressSetAlready = false;
        bool expertProgressSetAlready = false;

        foreach(string statement in statements)
        {
            int splitIndex = -1;
            
            for (int i = 0; i < statement.Length; i++)
            {
                if (i == statement.Length - 1)
                {
                    SaveData = DefaultSaveData;
                    Save();
                    return;
                }

                if(statement[i] == '=')
                {
                    if(splitIndex != -1)
                    {
                        SaveData = DefaultSaveData;
                        Save();
                        return;
                    }
                    splitIndex = i;
                }
            }

            string property = statement.Substring(0, splitIndex + 1);
            string value = statement.Substring(splitIndex + 1, statement.Length - splitIndex - 2);

            if(property == "normalprogress")
            {
                if (normalProgressSetAlready)
                {
                    SaveData = DefaultSaveData;
                    Save();
                    return;
                }

                ushort parsedValue = 0;
                
                if(!ushort.TryParse(value, out parsedValue))
                {
                    SaveData = DefaultSaveData;
                    Save();
                    return;
                }

                SaveData.NormalProgress = parsedValue;

                normalProgressSetAlready = true;
            }
            else if (property == "hardprogress")
            {
                if (hardProgressSetAlready)
                {
                    SaveData = DefaultSaveData;
                    Save();
                    return;
                }

                ushort parsedValue = 0;

                if (!ushort.TryParse(value, out parsedValue))
                {
                    SaveData = DefaultSaveData;
                    Save();
                    return;
                }

                SaveData.HardProgress = parsedValue;

                hardProgressSetAlready = true;
            }
            else if (property == "expertprogress")
            {
                if (expertProgressSetAlready)
                {
                    SaveData = DefaultSaveData;
                    Save();
                    return;
                }

                ushort parsedValue = 0;

                if (!ushort.TryParse(value, out parsedValue))
                {
                    SaveData = DefaultSaveData;
                    Save();
                    return;
                }

                SaveData.ExpertProgress = parsedValue;

                expertProgressSetAlready = true;
            }
            else
            {
                SaveData = DefaultSaveData;
                Save();
                return;
            }
        }
    }
    public static void Save()
    {
        if (!SaveFilesSupported)
        {
            return;
        }

        File.WriteAllText(SaveDataPath, $"NormalProgress = {SaveData.NormalProgress};\nHardProgress = {SaveData.HardProgress};\nExpertProgress = {SaveData.ExpertProgress};");
    }

    static SaveDataHelper()
    {
        Load();
    }
}
