using UnityEngine;

public interface IInput
{
  float HorizontalMove { get; }
  float VerticalMove { get; }
  string Name { get; }
  Color Color { get; }
}