using System;
using DialogueEditor;
using Scripts.Interfaces;
using UnityEngine;
using UnityEngine.Events;

public class SampleUse : MonoBehaviour, IDetectableObject
{
    [SerializeField] private GameObject _camera;
    public UnityEvent _use;
    [SerializeField] private NPCConversation _conversation;
    private bool _isConversation;
    [SerializeField] private SOBoolData _onDialog;

    private void OnEnable()
    {
        ConversationManager.OnConversationEnded += DialogExit;
    }

    public void OnRise()
    {
        if (!_isConversation)
        {
            _camera.SetActive(true);
            ConversationManager.Instance.StartConversation(_conversation);
            _isConversation = true;
            _onDialog.Value = true;
            _use?.Invoke();
        }
    }

    public void DialogExit()
    {
        _camera.SetActive(false);
       // _isConversation = false;
        _onDialog.Value = false;
    }
}