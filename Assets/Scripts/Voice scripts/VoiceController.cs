using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class VoiceController : MonoBehaviour
{
  [SerializeField] private SampleSpeechToText sample;
  public int RecordingTime = 5;

  public UnityAction OnStartRecording;
  public UnityAction OnStopRecording;

  private GameManager _gameManager;

  private void Awake()
  {
    _gameManager = FindObjectOfType<GameManager>();
  }

  private void Start()
  {
    if (PlayerPrefs.GetString("mode") == "player")
      StartCoroutine(StartRecording(RecordingTime));
    else
      StartCoroutine(StartPlaying(RecordingTime));
  }

  private IEnumerator StartRecording(int sec)
  {
    yield return new WaitForSeconds(.5f);

    while (true)
    {
      yield return new WaitForSeconds(1f);
      StartRecording();
      yield return new WaitForSeconds(sec);
      StartCoroutine(StopRecordingPlayer());
      yield return new WaitForSeconds(sec);
    }
  }

  private IEnumerator StartPlaying(int sec)
  {
    yield return new WaitForSeconds(.5f);
    
    while (true)
    {
      yield return new WaitForSeconds(1f);
      StartCoroutine(StopRecordingOperator());
      yield return new WaitForSeconds(sec);
      StartRecording();
      yield return new WaitForSeconds(sec);
    }
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
  
  public IEnumerator StopRecordingPlayer()
  {
    OnStopRecording?.Invoke();

    //yield return new WaitForSeconds(1.5f);
    sample.StopRecording();
    yield return new WaitForSeconds(1f);

    if (_gameManager.LastMoveWasSucceed)
      Answer("Да");
    else
      Answer("Нет");
  }
  
  public IEnumerator StopRecordingOperator()
  {
    OnStopRecording?.Invoke();

    //yield return new WaitForSeconds(1.5f);
    sample.StopRecording();
    yield return new WaitForSeconds(1f);

    Answer(_gameManager.GetFreeDirections());
  }

  private void Answer(string answer)
  {
    sample.Speak(answer);
  }
}