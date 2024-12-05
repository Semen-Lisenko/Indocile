using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class RequestAPI : MonoBehaviour
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
            StartCoroutine(PostLogsCorutine(user,user,"Create new user"));
        }
    }
    public IEnumerator GetPlayerResourcesCorutine(User user, Action<User> callback)
    {
        UnityWebRequest request = UnityWebRequest.Get(URL + Users + user.name + "/");
        yield return request.SendWebRequest();
        callback.Invoke(JsonUtility.FromJson<User>(request.downloadHandler.text));
    }
    public IEnumerator PutPlayerResourcesCorutine(User user)
    {
        UnityWebRequest request = UnityWebRequest.Get(URL + Users + user.name + "/");
        yield return request.SendWebRequest();
        User user1 = JsonUtility.FromJson<User>(request.downloadHandler.text);

        request = UnityWebRequest.Put(URL + Users + user.name + "/", JsonUtility.ToJson(user));
        yield return request.SendWebRequest();
        User user2 = JsonUtility.FromJson<User>(request.downloadHandler.text);
        StartCoroutine(PostLogsCorutine(user1,user2,"Update resources"));

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
        StartCoroutine(PostLogsCorutine(shop, shop, "Create shop"));
    }
    public IEnumerator PutPlayerShopResourcesCorutine(Shop shop, User user)
    {
        UnityWebRequest request = UnityWebRequest.Get(URL + Users + user.name + "/");
        yield return request.SendWebRequest();
        Shop data1 = JsonUtility.FromJson<Shop>(request.downloadHandler.text);

        request = UnityWebRequest.Put(URL + Users + user.name + "/" + Shops + shop.name + "/", JsonUtility.ToJson(shop));
        yield return request.SendWebRequest();
        Shop data2 = JsonUtility.FromJson<Shop>(request.downloadHandler.text);
        StartCoroutine(PostLogsCorutine(data1, data2, "Update shop resources"));
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
    public IEnumerator PostLogsCorutine(User data1, User data2,string comment)
    {
        Logs logs = new Logs();
        logs.comment = comment;
        logs.player_name = data1.name;
        logs.resources_changed.money = (data1.resources.money - data2.resources.money).ToString();
        logs.resources_changed.crypt = (data1.resources.crypt - data2.resources.crypt).ToString();
        logs.resources_changed.ether = (data1.resources.ether - data2.resources.ether).ToString();
        logs.resources_changed.energyHoney = (data1.resources.energyHoney - data2.resources.energyHoney).ToString();
        logs.resources_changed.eatHoney = (data1.resources.eatHoney - data2.resources.eatHoney).ToString();
        logs.resources_changed.buildHoney = (data1.resources.buildHoney - data2.resources.buildHoney).ToString();
        UnityWebRequest request = UnityWebRequest.Post(URL + Logs, JsonUtility.ToJson(logs), "application/json");
        yield return request.SendWebRequest();
    }
    public IEnumerator PostLogsCorutine(Shop data1, Shop data2, string comment)
    {
        Logs logs = new Logs();
        logs.comment = comment;
        logs.player_name = data2.name;
        logs.shop_name = data2.name;
        logs.resources_changed.crypt = (data1.resources.crypt - data2.resources.crypt).ToString();
        logs.resources_changed.ether = (data1.resources.ether - data2.resources.ether).ToString();
        logs.resources_changed.energyHoney = (data1.resources.energyHoney - data2.resources.energyHoney).ToString();
        logs.resources_changed.eatHoney = (data1.resources.eatHoney - data2.resources.eatHoney).ToString();
        logs.resources_changed.buildHoney = (data1.resources.buildHoney - data2.resources.buildHoney).ToString();
        UnityWebRequest request = UnityWebRequest.Post(URL + Logs, JsonUtility.ToJson(logs), "application/json");
        yield return request.SendWebRequest();
        Debug.Log(request.downloadHandler.text);
    }
}
