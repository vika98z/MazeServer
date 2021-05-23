using UnityEngine;

public class KeyboardInput : IInput
{
  private readonly string _hMove;
  private readonly string _vMove;

  public KeyboardInput(int playerNum)
  {
    _hMove = "Horizontal" + playerNum.ToString();
    _vMove = "Vertical" + playerNum.ToString();
  }

  public KeyboardInput()
  {
    _hMove = "Horizontal";
    _vMove = "Vertical";
  }

  public float HorizontalMove => Input.GetAxis(_hMove);
  public float VerticalMove => Input.GetAxis(_vMove);
}