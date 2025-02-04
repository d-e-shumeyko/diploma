using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;


public class dataHandler 
{
    private string dataDirPath = "";

    private string dataFileName = "";
    private bool useEncription = false;
    private readonly string encryptionCodeWord = "hotsauce";

    public dataHandler(string dataDirPath, string dataFileName, bool useEncryption) 
    {
        this.dataDirPath = dataDirPath;
        this.dataFileName = dataFileName;
        this.useEncription = useEncryption;
    }

    public gameData load()
    {
        string fullPath = Path.Combine(dataDirPath, dataFileName);
        gameData loadedData = null;
        if (File.Exists(fullPath))
        {
            try
            {
                string dataToLoad = "";
                using (FileStream stream = new FileStream(fullPath, FileMode.Open))
                {
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        dataToLoad = reader.ReadToEnd();
                    }
                }

                if (useEncription)
                {
                    dataToLoad = EncryptData(dataToLoad);
                }
                loadedData = JsonUtility.FromJson<gameData>(dataToLoad);
            }
            catch (Exception e) 
            {
                Debug.LogError("Error while loading data from file: " + fullPath + "\n" + e);
            }
        }
        return loadedData;
    }

    public void save(gameData data)
    {
        string fullPath = Path.Combine(dataDirPath, dataFileName);
        try
        {
            Directory.CreateDirectory(Path.GetDirectoryName(fullPath));

            string dataToStore = JsonUtility.ToJson(data, true);
            if (useEncription)
            {
                dataToStore = EncryptData(dataToStore);
            }

            using(FileStream stream = new FileStream(fullPath, FileMode.Create))
            {
                using (StreamWriter writer = new StreamWriter(stream))
                {
                    writer.WriteLine(dataToStore);
                }
            }
        }
        catch (Exception e)
        {
            Debug.LogError("Error while saving data to file: " + fullPath + "\n" + e);
        }


    }
    private string EncryptData(string data)
    {
        string modifiedData = "";
        for (int i = 0; i < data.Length; i++) 
        {
            modifiedData += (char)(data[i] ^ encryptionCodeWord[i % encryptionCodeWord.Length]);
        }
        return modifiedData;
    }

}
