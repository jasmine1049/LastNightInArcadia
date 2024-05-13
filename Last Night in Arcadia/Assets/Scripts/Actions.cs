using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Actions
{
    public static Action<CharacterButton> OnCharacterButtonClicked;

    public static Action<ChooseRoleMenuButton> OnChooseRoleMenuButtonClicked;

    public static Action<ChooseTargetMenuButton> OnChooseTargetMenuButtonClicked;
}
