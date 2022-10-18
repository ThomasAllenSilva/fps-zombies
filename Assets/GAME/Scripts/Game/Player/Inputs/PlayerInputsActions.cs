//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.3.0
//     from Assets/GAME/Scripts/Game/Player/Inputs/PlayerInputsActions.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public partial class @PlayerInputsActions : IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerInputsActions()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerInputsActions"",
    ""maps"": [
        {
            ""name"": ""PlayerMovementController"",
            ""id"": ""bcb93404-b78e-4d20-9651-983bebb66be8"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""Value"",
                    ""id"": ""fb915e7c-c171-4cc7-8dd8-846786b05024"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""RunButton"",
                    ""type"": ""Button"",
                    ""id"": ""049bcbdc-ac6e-444e-aa87-ce9973094817"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""WASD Vector"",
                    ""id"": ""2997a9f0-8c82-4cee-a35e-8c105e37224d"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""0c566c42-bfc5-4385-b081-fdffaa5e8bb2"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""558e3978-ab19-4de9-a514-5ff6b13ea43c"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""e017388f-adae-45ed-b31e-84bf6f4a26b1"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""ce136a65-7398-4a1b-b709-73f16cf4e7c6"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""302230f9-24da-4251-bd53-e5c07de67819"",
                    ""path"": ""<Keyboard>/leftShift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RunButton"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""PlayerCameraController"",
            ""id"": ""e0a19865-5afd-4fff-a040-4edcb96d0182"",
            ""actions"": [
                {
                    ""name"": ""Mouse"",
                    ""type"": ""PassThrough"",
                    ""id"": ""b2cc0391-edec-4cd2-9abb-8a23674c492b"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""a63d5492-e150-4230-bc44-df7ce9daf614"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Mouse"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""PlayerWeaponsController"",
            ""id"": ""5d26232a-7f9e-45b6-9b22-95a3a1340a9e"",
            ""actions"": [
                {
                    ""name"": ""Shoot"",
                    ""type"": ""Button"",
                    ""id"": ""dd051269-483f-4c00-91c5-973532b0dc00"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Hold(duration=0.01,pressPoint=0.01)"",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Reload"",
                    ""type"": ""Button"",
                    ""id"": ""0961554d-48bf-404b-9945-6f527c486083"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""dc7daf4d-4ce9-4147-ab76-ed9117ee1b97"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Shoot"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""03f45359-bd68-46e4-b64e-94677015fc62"",
                    ""path"": ""<Keyboard>/r"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Reload"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // PlayerMovementController
        m_PlayerMovementController = asset.FindActionMap("PlayerMovementController", throwIfNotFound: true);
        m_PlayerMovementController_Movement = m_PlayerMovementController.FindAction("Movement", throwIfNotFound: true);
        m_PlayerMovementController_RunButton = m_PlayerMovementController.FindAction("RunButton", throwIfNotFound: true);
        // PlayerCameraController
        m_PlayerCameraController = asset.FindActionMap("PlayerCameraController", throwIfNotFound: true);
        m_PlayerCameraController_Mouse = m_PlayerCameraController.FindAction("Mouse", throwIfNotFound: true);
        // PlayerWeaponsController
        m_PlayerWeaponsController = asset.FindActionMap("PlayerWeaponsController", throwIfNotFound: true);
        m_PlayerWeaponsController_Shoot = m_PlayerWeaponsController.FindAction("Shoot", throwIfNotFound: true);
        m_PlayerWeaponsController_Reload = m_PlayerWeaponsController.FindAction("Reload", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }
    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }
    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // PlayerMovementController
    private readonly InputActionMap m_PlayerMovementController;
    private IPlayerMovementControllerActions m_PlayerMovementControllerActionsCallbackInterface;
    private readonly InputAction m_PlayerMovementController_Movement;
    private readonly InputAction m_PlayerMovementController_RunButton;
    public struct PlayerMovementControllerActions
    {
        private @PlayerInputsActions m_Wrapper;
        public PlayerMovementControllerActions(@PlayerInputsActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_PlayerMovementController_Movement;
        public InputAction @RunButton => m_Wrapper.m_PlayerMovementController_RunButton;
        public InputActionMap Get() { return m_Wrapper.m_PlayerMovementController; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerMovementControllerActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerMovementControllerActions instance)
        {
            if (m_Wrapper.m_PlayerMovementControllerActionsCallbackInterface != null)
            {
                @Movement.started -= m_Wrapper.m_PlayerMovementControllerActionsCallbackInterface.OnMovement;
                @Movement.performed -= m_Wrapper.m_PlayerMovementControllerActionsCallbackInterface.OnMovement;
                @Movement.canceled -= m_Wrapper.m_PlayerMovementControllerActionsCallbackInterface.OnMovement;
                @RunButton.started -= m_Wrapper.m_PlayerMovementControllerActionsCallbackInterface.OnRunButton;
                @RunButton.performed -= m_Wrapper.m_PlayerMovementControllerActionsCallbackInterface.OnRunButton;
                @RunButton.canceled -= m_Wrapper.m_PlayerMovementControllerActionsCallbackInterface.OnRunButton;
            }
            m_Wrapper.m_PlayerMovementControllerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Movement.started += instance.OnMovement;
                @Movement.performed += instance.OnMovement;
                @Movement.canceled += instance.OnMovement;
                @RunButton.started += instance.OnRunButton;
                @RunButton.performed += instance.OnRunButton;
                @RunButton.canceled += instance.OnRunButton;
            }
        }
    }
    public PlayerMovementControllerActions @PlayerMovementController => new PlayerMovementControllerActions(this);

    // PlayerCameraController
    private readonly InputActionMap m_PlayerCameraController;
    private IPlayerCameraControllerActions m_PlayerCameraControllerActionsCallbackInterface;
    private readonly InputAction m_PlayerCameraController_Mouse;
    public struct PlayerCameraControllerActions
    {
        private @PlayerInputsActions m_Wrapper;
        public PlayerCameraControllerActions(@PlayerInputsActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Mouse => m_Wrapper.m_PlayerCameraController_Mouse;
        public InputActionMap Get() { return m_Wrapper.m_PlayerCameraController; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerCameraControllerActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerCameraControllerActions instance)
        {
            if (m_Wrapper.m_PlayerCameraControllerActionsCallbackInterface != null)
            {
                @Mouse.started -= m_Wrapper.m_PlayerCameraControllerActionsCallbackInterface.OnMouse;
                @Mouse.performed -= m_Wrapper.m_PlayerCameraControllerActionsCallbackInterface.OnMouse;
                @Mouse.canceled -= m_Wrapper.m_PlayerCameraControllerActionsCallbackInterface.OnMouse;
            }
            m_Wrapper.m_PlayerCameraControllerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Mouse.started += instance.OnMouse;
                @Mouse.performed += instance.OnMouse;
                @Mouse.canceled += instance.OnMouse;
            }
        }
    }
    public PlayerCameraControllerActions @PlayerCameraController => new PlayerCameraControllerActions(this);

    // PlayerWeaponsController
    private readonly InputActionMap m_PlayerWeaponsController;
    private IPlayerWeaponsControllerActions m_PlayerWeaponsControllerActionsCallbackInterface;
    private readonly InputAction m_PlayerWeaponsController_Shoot;
    private readonly InputAction m_PlayerWeaponsController_Reload;
    public struct PlayerWeaponsControllerActions
    {
        private @PlayerInputsActions m_Wrapper;
        public PlayerWeaponsControllerActions(@PlayerInputsActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Shoot => m_Wrapper.m_PlayerWeaponsController_Shoot;
        public InputAction @Reload => m_Wrapper.m_PlayerWeaponsController_Reload;
        public InputActionMap Get() { return m_Wrapper.m_PlayerWeaponsController; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerWeaponsControllerActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerWeaponsControllerActions instance)
        {
            if (m_Wrapper.m_PlayerWeaponsControllerActionsCallbackInterface != null)
            {
                @Shoot.started -= m_Wrapper.m_PlayerWeaponsControllerActionsCallbackInterface.OnShoot;
                @Shoot.performed -= m_Wrapper.m_PlayerWeaponsControllerActionsCallbackInterface.OnShoot;
                @Shoot.canceled -= m_Wrapper.m_PlayerWeaponsControllerActionsCallbackInterface.OnShoot;
                @Reload.started -= m_Wrapper.m_PlayerWeaponsControllerActionsCallbackInterface.OnReload;
                @Reload.performed -= m_Wrapper.m_PlayerWeaponsControllerActionsCallbackInterface.OnReload;
                @Reload.canceled -= m_Wrapper.m_PlayerWeaponsControllerActionsCallbackInterface.OnReload;
            }
            m_Wrapper.m_PlayerWeaponsControllerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Shoot.started += instance.OnShoot;
                @Shoot.performed += instance.OnShoot;
                @Shoot.canceled += instance.OnShoot;
                @Reload.started += instance.OnReload;
                @Reload.performed += instance.OnReload;
                @Reload.canceled += instance.OnReload;
            }
        }
    }
    public PlayerWeaponsControllerActions @PlayerWeaponsController => new PlayerWeaponsControllerActions(this);
    public interface IPlayerMovementControllerActions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnRunButton(InputAction.CallbackContext context);
    }
    public interface IPlayerCameraControllerActions
    {
        void OnMouse(InputAction.CallbackContext context);
    }
    public interface IPlayerWeaponsControllerActions
    {
        void OnShoot(InputAction.CallbackContext context);
        void OnReload(InputAction.CallbackContext context);
    }
}
