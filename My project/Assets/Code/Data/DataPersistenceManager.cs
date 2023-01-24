using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class DataPersistenceManager : MonoBehaviour
{
	[SerializeField] private string fileName;
	private GameData gameData;
	private List<IDataPersitence> dataPersitenceObjects;
	private FileDataHandler dataHandler;
    public static DataPersistenceManager instance { get; private set; }

	private void Awake()
	{
		if(instance != null)
		{
			Debug.LogError("More than one Persistence managers in the scene");
		}
		instance = this;
	}


	// TODO: Make another way of loading the game.
	private void Start()
	{
		this.dataHandler = new FileDataHandler(Application.persistentDataPath, fileName);
		this.dataPersitenceObjects = FindAllDataPersistenceObjects();
		LoadGame();
	}

	public void NewGame()
	{
		this.gameData = new GameData();
	}


	public void LoadGame()
	{
		this.gameData = dataHandler.Load();
		if(this.gameData == null)
		{
			Debug.Log("No data found. Starting New Game");
			NewGame();
		}

		// push the loaded data to all other scripts that need it.
		foreach(IDataPersitence dataPersitenceObj in dataPersitenceObjects)
		{
			dataPersitenceObj.LoadData(gameData);
		}
	}

	public void SaveGame()
	{
		// push the loaded data to all other scripts that need it.
		foreach (IDataPersitence dataPersitenceObj in dataPersitenceObjects)
		{
			dataPersitenceObj.SaveData(ref gameData);
		}
		dataHandler.Save(gameData);
	}

	// TODO: Make some other way of saving the game.
	private void OnApplicationQuit()
	{
		SaveGame();
	}

	private List<IDataPersitence> FindAllDataPersistenceObjects()
	{
		IEnumerable<IDataPersitence> dataPersitenceObjects = FindObjectsOfType<MonoBehaviour>().OfType<IDataPersitence>();
		return new List<IDataPersitence>(dataPersitenceObjects);
	}
}
