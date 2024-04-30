using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Role : MonoBehaviour
{
    protected int _target;
    protected int _moraleLossOnDeath;
    protected bool _isHostile;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void setTarget(int target)
    {
        _target = target;
    }


    /// <summary>
    /// Method to be called in derived class, unique action per role.
    /// </summary>
    protected abstract void TakeAction();
}
