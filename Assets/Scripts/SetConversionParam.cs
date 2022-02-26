using System;
using DialogueEditor;
using UnityEngine;

[Serializable]
public struct DataValueQuest
{
    public string name;
    public SOBoolData value;
}

public class SetConversionParam : MonoBehaviour
{
    [SerializeField] private DataValueQuest _dataValueQuest;


    public void SetData()
    {
        ConversationManager.Instance.SetBool(_dataValueQuest.name, _dataValueQuest.value.Value);
    }
}