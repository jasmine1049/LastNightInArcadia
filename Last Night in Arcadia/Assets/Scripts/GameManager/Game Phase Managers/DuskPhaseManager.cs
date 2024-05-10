using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DuskPhaseManager : MonoBehaviour
{
    [SerializeField] private RoleButton _executionButton;

    private RoleButton _roleButton;
    private CharacterButton _characterButton;


    // Start is called before the first frame update
    void Start()
    {
        _executionButton.Initialize(GameManager.Instance.Executioner);
    }


    private void OnEnable()
    {
        Actions.OnRoleButtonClicked += SetRoleButton;
        Actions.OnCharacterButtonClicked += SetTarget;
    }


    private void OnDisable()
    {
        Actions.OnRoleButtonClicked -= SetRoleButton;
        Actions.OnCharacterButtonClicked -= SetTarget;
    }


    private void SetRoleButton(RoleButton roleButton)
    {
        _roleButton = roleButton;
    }


    private void SetTarget(CharacterButton characterButton)
    {
        // this is very ugly but it works and I'll make it better later B) - Diego
        GameManager.Instance.Executioner.SetTarget(GameManager.Instance.GetCharacter(characterButton.Index));
        GameManager.Instance.GetCharacter(characterButton.Index).SetTargeter(GameManager.Instance.Executioner);

        characterButton.UpdateUI();

        _characterButton = characterButton;
    }


    public void UnselectTarget()
    {
        GameManager.Instance.Executioner.ClearTarget();
        GameManager.Instance.GetCharacter(_characterButton.Index).ClearTarget();

        _characterButton.UpdateUI();
    }
}
