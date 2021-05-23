using UnityEngine;

public class Player : MonoBehaviour
{
  private const float GravityValue = -9.81f;

  [SerializeField] public float speed;
  [SerializeField] private float turnSmoothTime = 0.1f;
  
  private CharacterController _controller;

  private Vector3 _playerVelocity;
  private bool _groundedPlayer;
  private float _turnSmoothVelocity;
  private readonly float allowPlayerRotation = 0.1f;
  private Vector3 moveDir;
  
  private void Awake()
  {
    _controller = GetComponent<CharacterController>();
  }
  
  private void Update() =>
    Move();

  private void Move()
  {
    float vertical = Input.GetAxis("Vertical");
    float horizontal = Input.GetAxis("Horizontal");

    Vector3 direction = new Vector3(horizontal, 0, vertical);

    if (direction.magnitude >= .1f)
    {
      float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
      float angle =
        Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref _turnSmoothVelocity, turnSmoothTime);
      transform.rotation = Quaternion.Euler(0f, angle, 0f);

      moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
    }
    else
    {
      moveDir=Vector3.zero;
    }

    _playerVelocity.y += GravityValue * Time.deltaTime;
    _controller.Move(moveDir.normalized * Time.deltaTime * speed + _playerVelocity * Time.deltaTime);
  }
}