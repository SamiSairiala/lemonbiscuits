using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Shop : MonoBehaviour
{
    [System.Serializable] class ShopItem
    {
        public Sprite Image;
        public int Price;
        public Item item;

    }

    [SerializeField] List<ShopItem> ShopItemsList = new List<ShopItem>();
    GameObject ItemTemplate;
    GameObject g;
    [SerializeField]Transform ShopScrollView;
    Button buyButton;
    Button SellButton;
    public Item Coin;
    [SerializeField] private GameObject ShopCanvas;
    

    private void Start()
    {
        ItemTemplate = ShopScrollView.GetChild(0).gameObject;

        int len = ShopItemsList.Count;
        for (int i = 0; i < len; i++)
        {
            g = Instantiate(ItemTemplate, ShopScrollView);
            g.transform.GetChild(0).GetComponent<Image>().sprite = ShopItemsList[i].Image;
            g.transform.GetChild(1).GetChild(0).GetComponent<TextMeshProUGUI>().text = ShopItemsList[i].Price.ToString();
            buyButton = g.transform.GetChild(2).GetComponent<Button>();
            buyButton.AddEventListener(i, OnShopItemButtonClicked);
            g.transform.GetChild(4).GetChild(0).GetComponent<TextMeshProUGUI>().text = ShopItemsList[i].item.value.ToString();
            SellButton = g.transform.GetChild(3).GetComponent<Button>();
            SellButton.AddEventListener(i, SellButtonClicked);
        }
        Destroy(ItemTemplate);
    }



    void SellButtonClicked(int itemIndex)
	{
        Debug.Log("Selling");
		if (InventoryManager.Instance.Items.Contains(ShopItemsList[itemIndex].item))
		{
            InventoryManager.Instance.Remove(ShopItemsList[itemIndex].item);
            int value = ShopItemsList[itemIndex].item.value;
            Debug.Log("Had needed item removing it now");
            for(int i = 0; i == value; i++)
			{
                Debug.Log("Adding coin");
                InventoryManager.Instance.Add(Coin);
            }
            
		}
		else
		{
            Debug.Log("Dont have that item");
		}
	}

    void OnShopItemButtonClicked(int itemIndex)
    {
        Debug.Log(itemIndex);
        int PlayerCoins = 0;
        int price = ShopItemsList[itemIndex].Price;
        for(int i = 0; i < price; i++)
        {
            if (InventoryManager.Instance.Items.Contains(Coin))
            {
                if(Coin.Amount >= price)
                {
                    Debug.Log("Player had coin");
                    PlayerCoins++;

                }


            }
           
        }
        if (PlayerCoins == price)
        {
            Debug.Log("Purhaced " + ShopItemsList[itemIndex].item);
            InventoryManager.Instance.Add(ShopItemsList[itemIndex].item);
            for(int i = 0; i < PlayerCoins; i++)
            {
                InventoryManager.Instance.Remove(Coin);
            }
        }

    }

    public void CloseShop()
    {
        ShopCanvas.SetActive(false);
    }
}
