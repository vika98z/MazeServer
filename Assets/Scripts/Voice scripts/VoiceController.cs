using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class VoiceController : MonoBehaviour
{
  [SerializeField] private SampleSpeechToText sample;
  public int RecordingTime = 5;

  public UnityAction OnStartRecording;
  public UnityAction OnStopRecording;

  private void Start()
  {
    if (PlayerPrefs.GetString("mode") == "player")
      StartCoroutine(StartRecording(RecordingTime));
    else
      StartCoroutine(StartPlaying(RecordingTime));
  }

  private IEnumerator StartRecording(int sec)
  {
    yield return new WaitForSeconds(1);
    StartRecording();
    yield return new WaitForSeconds(sec);
    StopRecording();
  }

  private IEnumerator StartPlaying(int sec)
  {
    yield return new WaitForSeconds(1);
  }

  public void StartRecording()
  {
    OnStartRecording?.Invoke();

    SampleSpeechToText.StartRecording();
  }

  public void StopRecording()
  {
    OnStopRecording?.Invoke();
    sample.StopRecording();
  }
}