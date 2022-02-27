using System;
using Scripts.SO;
using UnityEngine;

public enum GameState
{
    game,
    pause,
    gameover
}

public class GameManager : MonoBehaviour
{
    [SerializeField] private SOEventGameObject _playerObject;
    [SerializeField] private GameObject _playerPref;
    [SerializeField] private Transform _spawnPositionPlayer;


    private void Start()
    {
        CreatePlayer(_playerPref);
    }

    public void CreatePlayer(GameObject _player)
    {
        var transformPlayer = _spawnPositionPlayer.transform;
        var clonPlayer = Instantiate(_player, transformPlayer.position, transformPlayer.rotation);
        _playerObject.Value = clonPlayer;
    }

    public void ChangeTransform(Transform _newTransform)
    {
        _playerObject.Value.transform.position = _newTransform.position;
        _playerObject.Value.transform.rotation = _newTransform.rotation;
    }
}