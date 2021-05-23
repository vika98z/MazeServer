using UnityEngine;

public class CameraFollow : MonoBehaviour
{
  [SerializeField] private Transform target;
  [SerializeField] private float smoothSpeed = 0.125f;
  [SerializeField] private Vector3 offset;

  public void SetTarget(Transform newTarget) => 
    target = newTarget;

  private void FixedUpdate()
  {
    if (target == null)
      return;

    var desiredPosition = target.position + offset;
    var smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
    transform.position = smoothedPosition;
  }
}