using System;
using UnityEngine;

public enum GameState
{
    game,pause,gameover
}
public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject _playerPref;
    [SerializeField] private Transform _spawnPositionPlayer;

    private void Start()
    {
        CreatePlayer(_playerPref);
    }

    public void CreatePlayer(GameObject _player)
    {
        var transformPlayer = _spawnPositionPlayer.transform;
        var clonPlayer = Instantiate(_playerPref, transformPlayer.position, transformPlayer.rotation);
    }
}