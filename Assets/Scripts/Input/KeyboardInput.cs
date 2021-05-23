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

  public KeyboardInput(string name, string color)
  {
    _hMove = "Horizontal";
    _vMove = "Vertical";

    Color parsedColor;

    if (ColorUtility.TryParseHtmlString(color, out parsedColor))
      Color = parsedColor;
    else Color = Color.white;
    
    Name = name;
  }

  public float HorizontalMove => Input.GetAxis(_hMove);
  public float VerticalMove => Input.GetAxis(_vMove);
  public string Name { get; }
  public Color Color { get; }
}