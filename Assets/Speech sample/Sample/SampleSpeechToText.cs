using UnityEngine;
using UnityEngine.UI;
using TextSpeech;

public class SampleSpeechToText : MonoBehaviour
{
    public InputField inputText;
    public float pitch;
    public float rate;

    private GameManager _gameManager;

    private void Start()
    {
        _gameManager = FindObjectOfType<GameManager>();
        Setting("ru-RU");
        SpeechToText.instance.onResultCallback = OnResultSpeech;
    }

    public static void StartRecording()
    {
#if UNITY_EDITOR
#else
        SpeechToText.instance.StartRecording("Speak any");
#endif
    }

    public void StopRecording()
    {
#if UNITY_EDITOR
        OnResultSpeech("Not support in editor.");
#else
        SpeechToText.instance.StopRecording();
#endif
    }

    private void OnResultSpeech(string data)
    {
        inputText.text = data;
        _gameManager.MovePlayer(data);
    }
    
    public void OnClickSpeak()
    {
        string textToSpeech = _gameManager.GetFreeDirections();
        TextToSpeech.instance.StartSpeak(textToSpeech);
    }
    
    public void  OnClickStopSpeak() => 
        TextToSpeech.instance.StopSpeak();

    public void Setting(string code)
    {
        TextToSpeech.instance.Setting(code, pitch, rate);
        SpeechToText.instance.Setting(code);
    }
}
