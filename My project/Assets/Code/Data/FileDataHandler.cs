using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public class FileDataHandler
{
    private string dataDirPath = "";
    private string dataFileName = "";

    public FileDataHandler(string dataDirPath, string dataFileName)
	{
        this.dataDirPath = dataDirPath;
        this.dataFileName = dataFileName;
	}

    public GameData Load()
	{
		string fullPath = Path.Combine(dataDirPath, dataFileName);
		GameData loadedData = null;
		if (File.Exists(fullPath))
		{
			try
			{
				// using "using" statements if forget to open or close a file this ensures they will be closes etc.
				string dataToLoad = "";
				using(FileStream stream = new FileStream(fullPath, FileMode.Open))
				{
					using (StreamReader reader = new StreamReader(stream))
					{
						dataToLoad = reader.ReadToEnd();
					}
				}
				
				loadedData = JsonUtility.FromJson<GameData>(dataToLoad);
			}
			// Log error if cannot find data in fullpath.
			catch (Exception e)
			{
				Debug.LogError("Error when trying to load data from file: " + fullPath + "\n" + e);
			}
		}
		return loadedData;
	}

    public void Save(GameData data)
	{
        string fullPath = Path.Combine(dataDirPath, dataFileName);
		try
		{
			// Create path if it dosen't already exist.
			Directory.CreateDirectory(Path.GetDirectoryName(fullPath));

			// Serialize the game data to JSON.
			string dataToStore = JsonUtility.ToJson(data, true);

			using(FileStream stream = new FileStream(fullPath, FileMode.Create))
			{
				using (StreamWriter writer = new StreamWriter(stream))
				{
					writer.Write(dataToStore);
				}
			}
		}
		// Log error if cannot find data in fullpath.
		catch (Exception e)
		{
			Debug.LogError("Error when trying to save data to file: " + fullPath + "\n" + e);
		}
	}
}
