using LemonForest;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIBook : MonoBehaviour
{
    /*quests
    map
    customization
    crafting
    inventory
    pictures */

    private PageEnum currentPage = PageEnum.Quests;
    private PageEnum targetPage = PageEnum.Quests;

    [SerializeField]
    public IPage[] pages;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    /*if targetpage <> current, flip till target == current */
    // Update is called once per frame
    void Update()
    {
        
    }
}
