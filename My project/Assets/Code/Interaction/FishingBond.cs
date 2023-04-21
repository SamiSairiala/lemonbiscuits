using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class FishingBond : MonoBehaviour
{

	public List<Item> Fishes;

	private FishingProjectile fishingBob;

    [Header("QuickTime ui")]
    [SerializeField] private GameObject QuicktimeCanvas;
    [SerializeField] private GameObject QuickTimeText;
    [SerializeField] private GameObject QuickTimeMouse;

    [SerializeField] private InputActionReference Reel;

    private int Randomindex;

    private bool Caught = false;
    private bool isIn = false;

    public bool NormalFish = true;

    public GameObject fishingRod;

    private void OnEnable()
    {
        Reel.action.Enable();
    }

    private void OnDisable()
    {
        Reel.action.Disable();
    }
    
    private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag.Equals("Fishing") && NormalFish == true)
		{
            //int i = 0;
            //i = Random.Range(1, 11);
            fishingBob = FindObjectOfType<FishingProjectile>();
            isIn = true;
            if (isIn == true)
            {
                int i = 0;
                i = Random.Range(1, 11);
                
                fishingBob = FindObjectOfType<FishingProjectile>();
                if (i <= 2)
                {
                    Debug.Log("<= 2");
                    StartCoroutine(WaitFor());
                    StartCoroutine(ResetFishing());
                }
                else if(i >= 7)
                {
                    Debug.Log(">= 7");
                    StartCoroutine(WaitForReel());
                    StartCoroutine(ResetFishing());
                }
                else
                {
                    Debug.Log("no fish");
                    StartCoroutine(ResetFishing());
                }
            }
            //if (i <= 5)
            //{
            //    Caught = true;
            //    Randomindex = Random.Range(0, Fishes.Count);
            //    fishingBob.fish = Fishes[Randomindex];
            //    QuickTimeMouse.SetActive(true);
            //    QuickTimeText.SetActive(true);
            //    Debug.Log("Caught fish");
            //}
            //else
            //{
            //    Debug.Log("didint Caught fish");
            //    Caught = false;
            //}
            //StartCoroutine(QuickTime(other));
        }
	}

    private void Update()
    {
        




        
            if (Reel.action.WasPerformedThisFrame() && fishingRod.activeInHierarchy)
            {
                
                fishingBob.MoveBackToPlayer();
                
                
                QuicktimeCanvas.SetActive(false);
            }
        
    }

    IEnumerator DeActivateUI()
    {
        yield return new WaitForSeconds(2f);
        QuicktimeCanvas.SetActive(false);
    }

    IEnumerator ResetFishing()
    {
        NormalFish = true;
        yield return new WaitForSeconds(10);
    }

    IEnumerator WaitFor()
	{
        int WaitFor = 0;
        WaitFor = Random.Range(1, 6);
        yield return new WaitForSeconds(WaitFor);
        Caught = true;
        Randomindex = Random.Range(0, Fishes.Count);
        fishingBob.fish = Fishes[Randomindex];
        QuicktimeCanvas.SetActive(true);
        StartCoroutine(DeActivateUI());
        Debug.Log("Caught fish");
    }

    IEnumerator WaitForReel()
	{
        int WaitFor = 0;
        WaitFor = Random.Range(4, 9);
        yield return new WaitForSeconds(WaitFor);
        Caught = true;
        Randomindex = Random.Range(0, Fishes.Count);
        fishingBob.fish = Fishes[Randomindex];
        QuicktimeCanvas.SetActive(true);
        StartCoroutine(DeActivateUI());
        Debug.Log("Caught fish");

    }

    //IEnumerator QuickTime(Collider other)
    //{
    //    yield return new WaitForSeconds(3f);
    //    int i = 0;
    //    i = Random.Range(1, 11);
    //    if (i <= 5 && other.gameObject.activeInHierarchy)
    //    {
    //        Debug.Log("Fish caught");
    //        Randomindex = Random.Range(0, Fishes.Count);
    //        fishingBob.fish = Fishes[Randomindex];
    //        QuickTimeMouse.SetActive(true);
    //        QuickTimeText.SetActive(true);
    //        Caught = true;
    //    }
    //    else if(i > 5 && other.gameObject.activeInHierarchy)
    //    {
    //        Debug.Log("Fish not caught");
    //        fishingBob.MoveBackToPlayer();
    //        QuickTimeMouse.SetActive(false);
    //        QuickTimeText.SetActive(false);
    //    }
    //    if (!other.gameObject.activeInHierarchy)
    //    {
    //        StopCoroutine(QuickTime(null));
    //    }
    //}
}
