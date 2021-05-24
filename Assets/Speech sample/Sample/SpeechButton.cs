using System;
using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class SpeechButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
  public GameObject effect;
  public float speedEffect = 1;
  public float scaleEffect = 1.2f;
  private float _speed;
  private float _scale = 1;

  private VoiceController _voiceController;

  private void Awake()
  {
    _voiceController = FindObjectOfType<VoiceController>();
    
    _voiceController.OnStartRecording += OnStartRecording;
    _voiceController.OnStopRecording += OnStopRecording;
  }

  private void Start()
  {
    effect.SetActive(false);
    _speed = speedEffect;
  }

  private void Update() =>
    AnimateButton();

  private void OnDisable()
  {
    _voiceController.OnStartRecording -= OnStartRecording;
    _voiceController.OnStopRecording -= OnStopRecording;
  }

  public void OnPointerDown(PointerEventData eventData) =>
    _voiceController.StartRecording();

  public void OnPointerUp(PointerEventData eventData) =>
    _voiceController.StopRecording();

  private void OnStartRecording()
  {
    print("start");
    effect.SetActive(true);
    _scale = 1;
  }

  private void OnStopRecording()
  {
    
    effect.SetActive(false);
    print("stop");

  }


  private void AnimateButton()
  {
    if (effect.activeSelf)
    {
      _scale += Time.deltaTime * _speed;
      if (_scale > scaleEffect)
        _speed = -speedEffect;

      if (_scale < scaleEffect - 0.1f)
        _speed = speedEffect;

      effect.transform.localScale = new Vector3(_scale, _scale, 1);
    }
  }
}