using UnityEngine;

public class CameraFollow : MonoBehaviour
{
  [SerializeField] private Transform target;
  [SerializeField] private float smoothSpeed = 0.125f;
  [SerializeField] private Vector3 offset;

  private void FixedUpdate()
  {
    var desiredPosition = target.position + offset;
    var smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
    transform.position = smoothedPosition;
  }
}