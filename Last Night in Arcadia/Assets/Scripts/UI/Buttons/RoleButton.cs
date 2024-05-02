using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class RoleButton : MyButton
{
    private SORole _role;


    protected SORole Role { get { return _role; } private set { } }


    /// <summary>
    /// Initializes the values of the role button.
    /// </summary>
    /// <param name="role"></param>
    public virtual void Initialize(SORole role)
    {
        _role = role;

        this.Icon.sprite = role.Icon;
        this.TextBox.text = role.Name;
    }
}
