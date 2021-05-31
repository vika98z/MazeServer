using System.Collections;
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
  private bool isMoving;

  public void SetPlayer(IInput input, Color color)
  {
    PlayersInput = input;
    var pointLight = GetComponentInChildren<Light>();
    pointLight.color = color;
  }

  private void Awake() => 
    _controller = GetComponent<CharacterController>();

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

  public bool MoveOneCell(float offset, Vector3 direction)
  {
    var directionRay = new Ray(transform.position, direction);
    if (!Physics.Raycast(directionRay, out var hit, offset) && !isMoving)
    {
      isMoving = true;
      
      var newPos = transform.position + direction * offset;
      float targetAngle = Vector3.SignedAngle(transform.forward, direction, Vector3.up);

      transform.rotation = Quaternion.Euler(0f, transform.eulerAngles.y + targetAngle, 0f);
      StartCoroutine(MoveToOffset(newPos));
      return true;
    }

    return false;
  }

  private IEnumerator MoveToOffset(Vector3 newPosition)
  {
    while (Vector3.Distance(transform.position, newPosition) > 0.01f)
    {
      var smoothedPosition = Vector3.Lerp(transform.position, newPosition, 0.2f);
      transform.position = smoothedPosition;
      
      yield return null;
    }

    isMoving = false;
  }

  public bool IsFreeDirection(Vector3 direction, float offset)
  {
    var directionRay = new Ray(transform.position,   direction);
    return (!Physics.Raycast(directionRay, out var hit, offset) && !isMoving);
  }
}