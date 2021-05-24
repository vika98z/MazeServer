using UnityEngine;
using UnityEngine.UI;
using TextSpeech;

public class SampleSpeechToText : MonoBehaviour
{
    public GameObject loading;
    public InputField inputLocale;
    public InputField inputText;
    public float pitch;
    public float rate;

    public Text txtLocale;
    public Text txtPitch;
    public Text txtRate;

    private GameManager _gameManager;
    
    void Start()
    {
        _gameManager = FindObjectOfType<GameManager>();
        
        Setting("ru-RU");
        loading.SetActive(false);
        SpeechToText.instance.onResultCallback = OnResultSpeech;
    }
    

    public void StartRecording()
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
#if UNITY_IOS
        loading.SetActive(true);
#endif
    }
    void OnResultSpeech(string _data)
    {
        inputText.text = _data;

        _gameManager.MovePlayer(_data);

    }
    public void OnClickSpeak()
    {
        var textToSpeech = _gameManager.GetFreeDirections();
        TextToSpeech.instance.StartSpeak(textToSpeech);
    }
    
    public void  OnClickStopSpeak()
    {
        TextToSpeech.instance.StopSpeak();
    }
    public void Setting(string code)
    {
        TextToSpeech.instance.Setting(code, pitch, rate);
        SpeechToText.instance.Setting(code);
        txtLocale.text = "Locale: " + code;
        txtPitch.text = "Pitch: " + pitch;
        txtRate.text = "Rate: " + rate;
    }
    public void OnClickApply()
    {
        Setting(inputLocale.text);
    }
}
