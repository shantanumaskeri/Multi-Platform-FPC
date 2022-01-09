using System.Runtime.CompilerServices;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class ControlsManager : MonoBehaviour
{

    #region PUBLIC VARIABLES

    [Header("Controls")]
    public FixedJoystick MoveJoystick;
    public FixedButton JumpButton;
    public FixedTouchField TouchField;

    [Header("Control Transforms")]
    public RectTransform MoveJoystickRT;
    public RectTransform JumpButtonRT;
    public RectTransform TouchFieldRT;

    [Header("Player")]
    public RigidbodyFirstPersonController PlayerFP;

    #endregion

    #region MONOBEHAVIOR CALLBACKS

    private void Start()
    {
        if (Application.platform == RuntimePlatform.WindowsPlayer || Application.platform == RuntimePlatform.OSXPlayer)
            SetControlsPosition();
    }

    private void Update()
	{
        if (Application.platform == RuntimePlatform.Android || Application.platform == RuntimePlatform.IPhonePlayer)
            UpdateControls();
    }

    #endregion

    #region CUSTOM METHODS

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private void SetControlsPosition()
    {
        MoveJoystickRT.position = new Vector3(-256.0f, 256.0f, 0.0f);
        JumpButtonRT.position = new Vector3(2048.0f, 256.0f, 0.0f);
        TouchFieldRT.offsetMin = new Vector2(1960.0f, 0.0f);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private void UpdateControls()
    {
        PlayerFP.RunAxis = MoveJoystick.Direction;
        PlayerFP.JumpAxis = JumpButton.Pressed;
        PlayerFP.mouseLook.LookAxis = TouchField.TouchDist;
    }

    #endregion

}
