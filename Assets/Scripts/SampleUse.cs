using System;
using DialogueEditor;
using Scripts.Interfaces;
using Scripts.SO;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

public class SampleUse : MonoBehaviour, IDetectableObject
{
    [SerializeField] private GameObject _camera;
    public UnityEvent _use;
    [SerializeField] private NPCConversation _thisConversation;
    private bool _isConversation;
    [SerializeField] private SOBoolData _onDialog;
    [SerializeField] private string _nameValueQuest;
    [SerializeField] private SOIntData _valueQuest;
    [SerializeField] private SOEventBool _onSpeach;
    public bool _isActive = true;

    public void SetState(bool state)
    {
        _isActive = state;
    }

    private void OnEnable()
    {
        ConversationManager.OnConversationEnded += DialogExit;
    }

    public void OnRise()
    {
        if (!_isActive) return;

        if (!_isConversation)
        {
            if (_camera != null)
            {
                _camera.SetActive(true);
            }

            ConversationManager.Instance.StartConversation(_thisConversation);
            if (_valueQuest)
            {
                ConversationManager.Instance.SetInt(_nameValueQuest, _valueQuest.Value);
            }
        }

        _isConversation = true;
        _onDialog.Value = true;
        _use?.Invoke();
        _onSpeach.Event?.Invoke(false);
    }

    public void DialogExit()
    {
        if (_camera != null)
        {
            _camera.SetActive(false);
        }

// _isConversation = false;
        _onDialog.Value = false;
        Invoke(("TimeToOffDialog"), 2f);
    }

    public void TimeToOffDialog()
    {
        _isConversation = false;
    }

    private void OnDisable()
    {
        ConversationManager.OnConversationEnded -= DialogExit;
    }
}