using Cinemachine;
using UnityEngine;

public class CinemachineCameraController : CinemachineExtension
{
    [SerializeField] private PlayerInputsManager _playerInputsManager;

    [Range(10f, 80f)] [SerializeField] private float _cameraRotationYAngleMaxValue = 45f;

    [Range(0.1f, 5f)] [SerializeField] private float _cameraHorizontalSensitivity = 0.3f;

    [Range(0.1f, 5f)] [SerializeField] private float _cameraVerticalSensitivity = 0.3f;

    private Vector3 _cameraDesiredRotation;

    protected override void Awake()
    {
        base.Awake();

        _cameraDesiredRotation = _playerInputsManager.transform.rotation.eulerAngles;
    }

    protected override void PostPipelineStageCallback(CinemachineVirtualCameraBase vcam, CinemachineCore.Stage stage, ref CameraState state, float deltaTime)
    {
        Vector2 playerMouseDeltaInput = _playerInputsManager.PlayerMouseDeltaValue();

        _cameraDesiredRotation.x += playerMouseDeltaInput.x * _cameraHorizontalSensitivity * Time.deltaTime;
        _cameraDesiredRotation.y = Mathf.Clamp(_cameraDesiredRotation.y += playerMouseDeltaInput.y * _cameraVerticalSensitivity * Time.deltaTime, -_cameraRotationYAngleMaxValue, _cameraRotationYAngleMaxValue);
        
        state.RawOrientation = Quaternion.Euler(-_cameraDesiredRotation.y, _cameraDesiredRotation.x, 0f);
    }
}
