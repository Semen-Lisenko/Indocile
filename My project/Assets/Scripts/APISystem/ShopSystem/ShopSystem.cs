using System.Collections.Generic;
using UnityEngine;

public class ShopSystem : MonoBehaviour
{
    public static List<int> ShopCart = new List<int>(0);

    public static float money;
    public static float totalSum;
    private void Start()
    {
        for (int i = 0; i < ShopCart.Count; i++)
        {
            ShopCart[i] = 0;
        }
    }
    public void GetShops()
    {

    }
    public static void AddToTotalSum(float cost)
    {
        totalSum += cost;
    }
    public void BuyCart()
    {
        if (totalSum > money)
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
