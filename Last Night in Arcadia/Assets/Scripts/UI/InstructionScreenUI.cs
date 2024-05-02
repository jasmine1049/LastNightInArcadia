using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InstructionScreenUI : MonoBehaviour
{
    [Header("UI Elements")]
    [SerializeField] private TextMeshProUGUI _titleText;
    [SerializeField] private TextMeshProUGUI _instructionsText;

    [SerializeField] private List<string> _titles;
    [TextArea(4, 8)]
    [SerializeField] private List<string> _instructions;


    /// <summary>
    /// Updates the instruction screen text based off the given index. It's assumed that the
    /// titles and instructions lists are equal length, correctly match, and the given index
    /// is within the bounds of the list.
    /// </summary>
    /// <param name="textIndex"></param>
    public void UpdateText(int textIndex)
    {
        _titleText.text = _titles[textIndex];
        _instructionsText.text = _instructions[textIndex];
    }
}
