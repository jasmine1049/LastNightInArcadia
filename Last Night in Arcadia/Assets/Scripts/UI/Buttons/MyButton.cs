using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public abstract class MyButton : MonoBehaviour
{
    [SerializeField] private Image _icon;
    [SerializeField] private TextMeshProUGUI _textBox;


    protected Image Icon { get { return _icon; } private set { } }
    protected TextMeshProUGUI TextBox { get { return _textBox; } private set { } }
    protected Button Button { get { return this.gameObject.GetComponentInChildren<Button>(); } private set { } }
}
