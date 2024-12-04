using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class ShopAPI : MonoBehaviour
{
    public const string URL = "https://2025.nti-gamedev.ru/api/games/feffc349-5ba4-42a7-8504-fd0aa3f6deb8/";
    public const string Users = "players/";
    public const string Shops = "shops/";
    public const string Logs = "logs/";
    public IEnumerator CreatePlayerCorutine(User user)
    {
        UnityWebRequest request = UnityWebRequest.Post(URL + Users, JsonUtility.ToJson(user), "application/json");
        yield return request.SendWebRequest();
        if (request.result == UnityWebRequest.Result.Success)
        {
            UserLogs logs = new UserLogs();
            logs.comment = "Create Player Account";
            logs.player_name = user.name;
            logs.resources.money = "+" + (user.resources.money).ToString();
            logs.resources.crypt = "+" + (user.resources.crypt).ToString();
            logs.resources.ether = "+" + (user.resources.ether).ToString();
            logs.resources.energyHoney = "+" + (user.resources.energyHoney).ToString();
            logs.resources.eatHoney = "+" + (user.resources.eatHoney).ToString();
            logs.resources.buildHoney = "+" + (user.resources.buildHoney).ToString();
            StartCoroutine(PostLogsCorutine(logs));
        }
    }
    public IEnumerator GetPlayerResourcesCorutine(User user)
    {
        UnityWebRequest request = UnityWebRequest.Get(URL + Users + user.name + "/");
        yield return request.SendWebRequest();
    }
    public IEnumerator PostLogsCorutine(UserLogs logs)
    {
        UnityWebRequest request = UnityWebRequest.Post(URL + Logs, JsonUtility.ToJson(logs),"application/json");
        yield return request.SendWebRequest();
    }
    public IEnumerator PutPlayerResourcesCorutine(User user)
    {
        UnityWebRequest request = UnityWebRequest.Get(URL + Users + user.name + "/");
        yield return request.SendWebRequest();
        User userData = JsonUtility.FromJson<User>(request.downloadHandler.text);

        request = UnityWebRequest.Put(URL + Users + user.name + "/", JsonUtility.ToJson(user));
        yield return request.SendWebRequest();
        if (request.result == UnityWebRequest.Result.Success)
        {
            UserLogs logs = new UserLogs();
            logs.comment = "Change Resources";
            logs.player_name = user.name;
            logs.resources.money = (userData.resources.money - user.resources.money).ToString();
            logs.resources.crypt = (userData.resources.crypt - user.resources.crypt).ToString();
            logs.resources.ether = (userData.resources.ether - user.resources.ether).ToString();
            logs.resources.energyHoney = (userData.resources.energyHoney - user.resources.energyHoney).ToString();
            logs.resources.eatHoney = (userData.resources.eatHoney - user.resources.eatHoney).ToString();
            logs.resources.buildHoney = (userData.resources.buildHoney - user.resources.buildHoney).ToString();
            StartCoroutine(PostLogsCorutine(logs));
        }

    }
    public IEnumerator DeletePlayerCorutine(User user)
    {
        UnityWebRequest request = UnityWebRequest.Delete(URL + Users + user + "/");
        yield return request.SendWebRequest();
    }
    public IEnumerator CreatePlayerShopCorutine(Shop shop, User user)
    {
        UnityWebRequest request = UnityWebRequest.Post(URL + Users + user.name + "/" + Shops, JsonUtility.ToJson(shop), "application/json");
        yield return request.SendWebRequest();
    }
    public IEnumerator GetPlayerShopCorutine(Shop shop, User user)
    {
        UnityWebRequest request = UnityWebRequest.Get(URL + Users + user.name + "/" + Shops + shop.name + "/");
        yield return request.SendWebRequest();
    }
    public IEnumerator GetPlayerShopsCorutine(User user)
    {
        UnityWebRequest request = UnityWebRequest.Get(URL + Users + user.name + "/" + Shops);
        yield return request.SendWebRequest();
    }
    public IEnumerator DeletePlayerShopCorutine(Shop shop, User user)
    {
        UnityWebRequest request = UnityWebRequest.Get(URL + Users + user.name + "/" + Shops + shop.name + "/");
        yield return request.SendWebRequest();
    }
}
