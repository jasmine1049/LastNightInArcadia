using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoraleSystem : MonoBehaviour
{
    [SerializeField] private int _initialMorale;

    private int _currentMorale;

    public int CurrentMorale { get { return _currentMorale; } private set { } }


    // Start is called before the first frame update
    void Start()
    {
        _currentMorale = _initialMorale;
    }


    public void IncreaseMorale(int value)
    {
        _currentMorale += value;
    }


    public void DecreaseMorale(int value)
    {
        _currentMorale -= value;
    }
}
