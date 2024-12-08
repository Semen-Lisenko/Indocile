using System.Collections.Generic;
using TMPro;
using UnityEngine;
public class APIControl : MonoBehaviour
{
    public RequestAPI RequestAPI;

    public TMP_InputField RegUserNameF;
    public TMP_InputField RegPasswordF;

    public TMP_InputField AutUserNameF;
    public TMP_InputField AutPasswordF;

    public TMP_InputField ShopNameF;
    public TMP_InputField ShopEatHF;
    public TMP_InputField ShopBuildHF;
    public TMP_InputField ShopEnergyHF;

    public TMP_InputField UpdShopNameF;
    public TMP_InputField UpdShopEatHF;
    public TMP_InputField UpdShopBuildHF;
    public TMP_InputField UpdShopEnergyHF;
    public TMP_InputField UpdShopCryptF;
    public TMP_InputField UpdShopEtherHF;
    public void CreateUser()
    {
        if (RegUserNameF.text != "" && RegPasswordF.text != "")
        {
            User user = new User();
            user.name = RegUserNameF.text;
            user.resources.eatHoney = 10;
            user.resources.buildHoney = 10;
            user.resources.energyHoney = 10;
            user.resources.money = 100;
            user.resources.crypt = 1;
            user.resources.ether = 10;
            PlayerPrefs.SetString("LastUsername", user.name);
            StartCoroutine(RequestAPI.CreatePlayerCorutine(user));
        }
        else
        {
            Debug.Log("Fill all fields");
        }
    }
    public void AuthenticationUser()
    {
        if (AutUserNameF.text != "" && AutPasswordF.text != "")
        {
            User user = new User();
            user.name = AutUserNameF.text;
            PlayerPrefs.SetString("LastUsername", user.name);
        }
        else
        {
            Debug.Log("Fill all fields");
        }
    }
    public void CreateUserShop()
    {
        if (ShopNameF.text != "")
        {
            Shop shop = new Shop();
            shop.name = ShopNameF.text;
            shop.resources.crypt = 1;
            shop.resources.ether = 10;
            shop.resources.buildHoney = int.Parse(ShopBuildHF.text) == 0 ? 0 : int.Parse(ShopBuildHF.text);
            shop.resources.eatHoney = int.Parse(ShopEatHF.text) == 0 ? 0 : int.Parse(ShopEatHF.text);
            shop.resources.energyHoney = int.Parse(ShopEnergyHF.text) == 0 ? 0 : int.Parse(ShopEnergyHF.text);
            PlayerPrefs.SetString("LastShopName", ShopNameF.text);  
            User user = new User();
            user.name = PlayerPrefs.GetString("LastUsername");
            StartCoroutine(RequestAPI.CreatePlayerShopCorutine(shop,user));
        }
        else
        {
            Debug.Log("Fill all fields");
        }
    }
}
