using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
  [SerializeField] private GameObject playerPrefab;
  [SerializeField] private Transform playersRoot;
  [SerializeField] private Transform[] playersSpawnPosition;

  private List<Player> _players = new List<Player>();

  private void Start()
  {
    CreatePlayers(new List<IInput> {new KeyboardInput("Player 1", "#042069")});
  }

  public void CreatePlayers(List<IInput> inputs)
  {
    for (int i = 0; i < inputs.Count; i++)
    {
      GameObject playerGameObject =
        Instantiate(playerPrefab, playersSpawnPosition[i].position, Quaternion.identity, playersRoot);
      playerGameObject.name = inputs[i].Name;
      var player = playerGameObject.GetComponent<Player>();
      player.SetPlayer(inputs[i], inputs[i].Color);

      _players.Add(player);
    }

    var camera = Camera.main;
    var followCameraScript = camera.GetComponent<CameraFollow>();
    if (followCameraScript && _players.Count > 0)
      followCameraScript.SetTarget(_players[0].transform);
  }
  
  public void MoveRight()
  {
    if (_players.Count > 0)
      _players[0].MoveOneCell(1, Vector3.right);
  }
}