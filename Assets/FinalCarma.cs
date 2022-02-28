using UnityEngine;
using UnityEngine.UI;

public class FinalCarma : MonoBehaviour
{
    [SerializeField] private SOIntData _carma;
    [SerializeField] private Text _label;

    private void OnEnable()
    {
        PrintLabel();
    }

    private void PrintLabel()
    {
        var finalCarma = 100 * _carma.Value / 10;
        _label.text = "Ты был человеком на " + finalCarma + "%";
    }
}