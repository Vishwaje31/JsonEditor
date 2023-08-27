using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleJSON;

public static class JsonLoader
{
    public static void GetJsonObject(string str, Transform _trp = null)
    {
        if (string.IsNullOrEmpty(str)) return;

        JSONObject complete = JSON.Parse(str) as JSONObject;

        JSONArray response = complete["Response"] as JSONArray;

        Debug.Log(complete.ToString());

        for (int i = 0; i < response.Count; i++)
        {
            //Debug.Log(i.ToString() + response[i]["name"]);
            GameObject obj = new GameObject(response[i]["name"]);

            Transform temp = obj.transform;

            temp.SetParent(_trp);

            Vector3 posVector = new Vector3(response[i]["position"][0], response[i]["position"][1], response[i]["position"][2]);
            Quaternion rotVector = Quaternion.Euler(response[i]["rotation"][0], response[i]["rotation"][1], response[i]["rotation"][2]);
            Vector3 scaleVector = new Vector3(response[i]["scale"][0], response[i]["scale"][1], response[i]["scale"][2]);

            temp.SetPositionAndRotation(posVector, rotVector);
            temp.localScale = scaleVector;

            //check if properties is present.
            if (response[i].HasKey("properties"))
            {
                JSONObject properties = response[i]["properties"] as JSONObject;
                //Debug.Log("Prop ----- " + properties.ToString());

                //if therer is some elements
                if (!properties.IsNull)
                {
                    foreach (var item in properties.Keys)
                    {
                        Debug.Log("Pro Item : --- " + item);
                        var type = IdentifyType.GetComponentType(item);
                        obj.AddComponent(type);


                    }

                }

            }

        }

    }


}
