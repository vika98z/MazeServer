using TextSpeech;
using UnityEngine;
using UnityEngine.UI;

public class SpeechToTextController : MonoBehaviour
{
  public InputField inputLocale;
  public InputField inputText;
  public float pitch = 1;
  public float rate = 1;

  private GameManager _gameManager;

  private void Start()
  {
    _gameManager = GetComponent<GameManager>();
    
    Setting("ru-RU");
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
  }

  private void OnResultSpeech(string _data)
  {
    inputText.text = _data;
    _gameManager.MovePlayer(_data);
  }

  public void OnClickSpeak()
  {
    TextToSpeech.instance.StartSpeak(inputText.text);
  }

  public void OnClickStopSpeak()
  {
    TextToSpeech.instance.StopSpeak();
  }

  public void Setting(string code)
  {
    TextToSpeech.instance.Setting(code, pitch, rate);
    SpeechToText.instance.Setting(code);
  }

  public void OnClickApply()
  {
    Setting(inputLocale.text);
  }
}