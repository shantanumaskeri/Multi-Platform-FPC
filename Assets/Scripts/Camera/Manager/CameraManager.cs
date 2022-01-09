using UnityEngine;
using System.Runtime.CompilerServices;

public class CameraManager : MonoBehaviour
{

    #region PUBLIC FIELDS

    public GyroCamera gyroCamera;

	#endregion

	#region MONOBEHAVIOUR CALLBACKS

	private void Start()
    {
        if (Application.platform == RuntimePlatform.Android || Application.platform == RuntimePlatform.IPhonePlayer)
            ActivateCameraOnMobilePlatform();
    }

    #endregion

    #region CUSTOM METHODS

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private void ActivateCameraOnMobilePlatform()
	{
        gyroCamera.enabled = true;
    }

	#endregion

}
