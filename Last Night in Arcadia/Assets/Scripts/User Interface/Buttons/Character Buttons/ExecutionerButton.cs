using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExecutionerButton : CharacterButton
{
    public override Character Character { get { return GameManager.Instance.Executioner; } }


    public override void Initialize(Character character, GameObject objectToDeactivateOnClick, GameObject objectToActivateOnClick)
    {
        return;
    }


    public override void OnClick()
    {
        return;
    }


    public override void UpdateUI()
    {
        return;
    }
}
