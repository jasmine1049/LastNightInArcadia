using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InstructionScreen : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _title;
    [SerializeField] private TextMeshProUGUI _description;


    /// <summary>
    /// Sets the instruction screen's title's text.
    /// </summary>
    /// <param name="title">Title text.</param>
    public void SetTitle(string title)
    {
        _title.text = title;
    }


    /// <summary>
    /// Sets the instruction screen's description's text.
    /// </summary>
    /// <param name="description">Description text.</param>
    public void SetDescription(string description)
    {
        _description.text = description;
    }
}
