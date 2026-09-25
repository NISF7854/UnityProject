using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Data;

public class FileDataHandler
{
    private string dataDirPath = "";
    private string dataFileName = "";

    public FileDataHandler(string dataDirPath, string dataFileName)
    {
        this.dataDirPath = dataDirPath;
        this.dataFileName = dataFileName;
    }

    public void Save(GameData _gameData)
    {
        string fullPath = Path.Combine(dataDirPath, dataFileName);

        try
        {
            Directory.CreateDirectory(Path.GetDirectoryName(fullPath));

            string dataToStore = JsonUtility.ToJson(_gameData, true);

            using (FileStream strem = new FileStream(fullPath, FileMode.Create))
            {
                using(StreamWriter writer = new StreamWriter(strem))
                {
                    writer.Write(dataToStore);
                }
            }

        }
        catch (Exception ex)
        {
            Debug.LogError("´´½¨Ê§°Ü" + fullPath + "\n" + ex);
        }
    }

    public GameData Load()
    {
        string fullPath = Path.Combine(dataDirPath , dataFileName);
        GameData loadData = null;

        if(File.Exists(fullPath))
        {
            try
            {
                string dataToLoad = "";
                using (FileStream stream = new FileStream(fullPath,FileMode.Open))
                {
                    using(StreamReader  reader = new StreamReader(stream))
                    {
                        dataToLoad = reader.ReadToEnd();
                    }
                }

                loadData = JsonUtility.FromJson<GameData>(dataToLoad);
            }
            catch { }
            
        }
        return loadData;
    }

    public void Delete()
    {
        string fullPath = Path.Combine(dataDirPath, dataFileName);
        if(File.Exists(fullPath))
        {
            File.Delete(fullPath);
        }
    }
}
