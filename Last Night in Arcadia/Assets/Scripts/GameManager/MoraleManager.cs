using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoraleManager : MonoBehaviour
{
    [Header("Morale Values")]
    [SerializeField] private int _minMorale;
    [SerializeField] private int _maxMorale;
    [SerializeField] private int _initialMorale;

    private int _currentMorale;


    public int CurrentMorale { get { return _currentMorale; } private set { } }


    /// <summary>
    /// Initializes the current morale and breakpoints. Done in Awake to ensure data from this
    /// class is always set if another class calls data from it in its Start.
    /// </summary>
    void Awake()
    {
        _currentMorale = _initialMorale;
    }


    public void IncreaseMorale(int value)
    {
        _currentMorale = Mathf.Min(_currentMorale + value, _maxMorale);
    }


    public void DecreaseMorale(int value)
    {
        _currentMorale = Mathf.Max(_currentMorale - value, _minMorale);
    }
}
