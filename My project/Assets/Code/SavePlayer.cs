using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavePlayer : MonoBehaviour, IDataPersitence
{
    [SerializeField] PlayerMovement sPlayerMovement;
    private float fWaitForEnable = 2f;


    public void LoadData(GameData data)
    {
        gameObject.transform.position = data.vPlayerPos;
        
        Debug.Log("Loading player transform");
        StartCoroutine(waitFor());
    }

    public void SaveData(ref GameData data)
    {
        data.vPlayerPos = gameObject.transform.position;
        
    }



    private IEnumerator waitFor()
	{
        yield return new WaitForSeconds(fWaitForEnable);
        sPlayerMovement.enabled = true;
    }

    
}
