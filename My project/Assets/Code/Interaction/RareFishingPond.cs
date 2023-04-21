using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class RareFishingPond : MonoBehaviour
{

    [Header("QuickTime ui")]
    [SerializeField] private GameObject QuickTimeCanvas;


   

    private FishingProjectile fishingBob;
    public List<Item> Fishes;

    public FishingBond normalFishingBond;

    private bool Caught = false;
    private bool isIn = false;

    private int Randomindex;


    // Start is called before the first frame update
    void Start()
    {
        normalFishingBond = FindObjectOfType<FishingBond>();

    }


    

    // Update is called once per frame
    

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag.Equals("Fishing"))
		{
            normalFishingBond.NormalFish = false;
            fishingBob = FindObjectOfType<FishingProjectile>();
            isIn = true;
            if(isIn == true)
			{
                StartCoroutine(WaitFor());
                Debug.Log("Rare fish");
			}
        }
	}

    IEnumerator WaitFor()
    {
        int WaitFor = 0;
        WaitFor = Random.Range(1, 6);
        yield return new WaitForSeconds(WaitFor);
        Caught = true;
        Randomindex = Random.Range(0, Fishes.Count);
        fishingBob.fish = Fishes[Randomindex];
        normalFishingBond.NormalFish = true;
        QuickTimeCanvas.SetActive(true);
        StartCoroutine(DeActivateUI());
    }

    IEnumerator DeActivateUI()
    {
        yield return new WaitForSeconds(1f);
        QuickTimeCanvas.SetActive(false);
    }
}
