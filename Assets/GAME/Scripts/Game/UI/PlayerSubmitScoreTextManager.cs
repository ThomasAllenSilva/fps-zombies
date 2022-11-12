using UnityEngine;
using TMPro;

public class PlayerSubmitScoreTextManager : MonoBehaviour
{
    TMP_InputField _submitScoreInputField;

    private void Awake()
    {
        _submitScoreInputField = GetComponent<TMP_InputField>();
    }

    private void Start()
    {
        _submitScoreInputField.characterLimit = 8;
    }
}
