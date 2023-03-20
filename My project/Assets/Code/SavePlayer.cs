using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavePlayer : MonoBehaviour, IDataPersitence
{
    [SerializeField] PlayerMovement sPlayerMovement;
    private float fWaitForEnable = 2f;
    private InventoryManager inventoryManager;

    public void LoadData(GameData data)
    {
        inventoryManager = FindObjectOfType<InventoryManager>();
        gameObject.transform.position = data.vPlayerPos;
        inventoryManager.Items = data.items;
        inventoryManager.InventoryItems = data.Inventoryitems;
        Debug.Log("Loading player transform" + data.vPlayerPos);
        StartCoroutine(waitFor());
    }

    public void SaveData(ref GameData data)
    {
        inventoryManager = FindObjectOfType<InventoryManager>();
        data.vPlayerPos = gameObject.transform.position;
        data.items = inventoryManager.Items;
        data.Inventoryitems = inventoryManager.InventoryItems;
    }



    private IEnumerator waitFor()
	{
        yield return new WaitForSeconds(fWaitForEnable);
        sPlayerMovement.enabled = true;
    }

    
}
