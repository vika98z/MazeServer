using UnityEngine;

public class Player : MonoBehaviour
{
  public IInput PlayersInput { get; set; }
  
  private const float GravityValue = -9.81f;

  [SerializeField] public float speed;
  [SerializeField] private float turnSmoothTime = 0.1f;
  
  private CharacterController _controller;
  private Vector3 _playerVelocity;
  private float _turnSmoothVelocity;
  private Vector3 _moveDir;
  
  private void Awake()
  {
    _controller = GetComponent<CharacterController>();
    PlayersInput = new KeyboardInput();
  }

  private void Update() =>
    Move();

  private void Move()
  {
    float vertical = PlayersInput.VerticalMove;
    float horizontal = PlayersInput.HorizontalMove;
    
    Vector3 direction = new Vector3(horizontal, 0, vertical);

    if (direction.magnitude >= .1f)
    {
      float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
      float angle =
        Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref _turnSmoothVelocity, turnSmoothTime);
      transform.rotation = Quaternion.Euler(0f, angle, 0f);

      _moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
    }
    else
      _moveDir=Vector3.zero;

    _playerVelocity.y += GravityValue * Time.deltaTime;
    _controller.Move(_moveDir.normalized * Time.deltaTime * speed + _playerVelocity * Time.deltaTime);
  }
}