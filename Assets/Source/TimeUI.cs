using System.Collections;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;

public class TimeUI : MonoBehaviour
{
    [DllImport("__Internal")]
    private static extern void ShowMessage(string message);

    [SerializeField] private Button _button;
    [SerializeField] private TimeController _timeController;

    private void OnEnable()
    {
        _button.onClick.AddListener(OnButtonClicked);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(OnButtonClicked);
    }

    private void OnButtonClicked()
    {
        StartCoroutine(ShowMoscowTime());
    }

    private IEnumerator ShowMoscowTime()
    {
        yield return _timeController.LoadMoscowTime();

        string time = _timeController.Time.ToLongTimeString();
#if UNITY_EDITOR
        Debug.Log(time);
#else
        ShowMessage(time);
#endif
    }
}