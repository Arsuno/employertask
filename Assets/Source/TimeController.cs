using System;
using System.Collections;
using System.Globalization;
using UnityEngine;
using UnityEngine.Networking;

public class Date
{
    public string datetime;
}

public class TimeController : MonoBehaviour
{
    private const string URL = "http://worldtimeapi.org/api/timezone/Europe/Moscow";
    public DateTime Time { get; private set; }

    public IEnumerator LoadMoscowTime()
    {
        UnityWebRequest request = UnityWebRequest.Get(URL);
        yield return request.SendWebRequest();

        Date date = JsonUtility.FromJson<Date>(request.downloadHandler.text);

        DateTimeOffset dateTimeOffset = DateTimeOffset.Parse(date.datetime);
        Time = dateTimeOffset.DateTime;
    }
}
