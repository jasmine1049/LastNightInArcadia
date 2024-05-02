using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FillChooseRoleMenuGrid : MonoBehaviour
{
    [SerializeField] private GameObject _chooseRoleMenuButtonPrefab;


    // Start is called before the first frame update
    void Start()
    {
        foreach (SORole role in GameManager.Instance.GetSORoles(SORole.RoleType.Allied))
        {
            GameObject obj = GameObject.Instantiate(_chooseRoleMenuButtonPrefab, this.transform);

            RoleButton button = obj.GetComponent<RoleButton>();

            button.Initialize(role);
        }
    }
}
