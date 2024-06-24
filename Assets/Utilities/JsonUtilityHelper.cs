using UnityEngine;

public static class JsonUtilityHelper
{
    public static string ToJson<T>(T obj)
    {
        return JsonUtility.ToJson(obj);
    }

    public static T FromJson<T>(string json)
    {
        return JsonUtility.FromJson<T>(json);
    }
}