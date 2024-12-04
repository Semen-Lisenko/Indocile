using System.Collections.Generic;
using TMPro;
using UnityEngine;
public class ShopControl : MonoBehaviour
{
    public static List<int> ShopCart = new List<int>(0);
    
    public static float money;
    public static float totalSum;

    public ShopAPI ShopAPI;

    public TMP_InputField RegUserNameF;
    public TMP_InputField RegEnergyHF;
    public TMP_InputField RegBuildHF;
    public TMP_InputField RegEatHF;
    public TMP_InputField RegPasswordF;

    public TMP_InputField AutUserNameF;
    public TMP_InputField AutPasswordF;

    public TMP_InputField ShopNameF;
    public TMP_InputField ShopEatHF;
    public TMP_InputField ShopBuildHF;
    public TMP_InputField ShopEnergyHF;

    public TMP_InputField UpdUserNameF;
    public TMP_InputField UpdUserEatHF;
    public TMP_InputField UpdUserBuildHF;
    public TMP_InputField UpdUserEnergyHF;

    public TMP_InputField UpdShopNameF;
    public TMP_InputField UpdShopEatHF;
    public TMP_InputField UpdShopBuildHF;
    public TMP_InputField UpdShopEnergyHF;
    public void CreateUser()
    {
        if (RegUserNameF.text != "" && RegPasswordF.text != "")
        {
            User user = new User();
            user.name = RegUserNameF.text;
            user.resources.money = 100;
            user.resources.crypt = 1;
            user.resources.ether = 10;
            user.resources.buildHoney = int.Parse(RegBuildHF.text) == 0 ? 0 : int.Parse(RegBuildHF.text);
            user.resources.eatHoney = int.Parse(RegEatHF.text) == 0 ? 0 : int.Parse(RegEatHF.text);
            user.resources.energyHoney = int.Parse(RegEnergyHF.text) == 0 ? 0 : int.Parse(RegEnergyHF.text);
            user.password = RegPasswordF.text;
            PlayerPrefs.SetString("LastUsername", user.name);
            PlayerPrefs.SetString("LastPassword", user.password);
            StartCoroutine(ShopAPI.CreatePlayerCorutine(user));
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
            user.password = AutPasswordF.text;
            PlayerPrefs.SetString("LastUsername", user.name);
            PlayerPrefs.SetString("LastPassword", user.password);
        }
        else
        {
            Debug.Log("Fill all fields");
        }
    }
    private void Start()
    {
        for(int i = 0; i < ShopCart.Count; i++)
        {
            ShopCart[i] = 0;
        }
    }
    public static void AddToTotalSum(float cost)
    {
        totalSum += cost;
    }
    public void BuyCart()
    {
        if(totalSum > money)
        {
            return;
        }
        else
        {
            int[] PlayerProducts = new int[ShopCart.Count];
            money -= totalSum;
            for (int i = 0; i < ShopCart.Count; i++)
            {
                PlayerProducts[i] += ShopCart[i];
                ShopCart[i] = 0;
            }

        }
    }
}
