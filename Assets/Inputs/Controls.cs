// GENERATED AUTOMATICALLY FROM 'Assets/Inputs/Controls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @Controls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @Controls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Controls"",
    ""maps"": [
        {
            ""name"": ""Ball"",
            ""id"": ""88931da7-03b6-42c3-bb5e-a01849d1ca0b"",
            ""actions"": [
                {
                    ""name"": ""Aim"",
                    ""type"": ""Value"",
                    ""id"": ""3dc2f945-a042-4b67-b9c1-1383415e246e"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Shoot"",
                    ""type"": ""Value"",
                    ""id"": ""47b59cb6-3fc7-46cc-85dd-19e3d5262b2b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""31e77663-5193-471e-8d91-9cb2f61ae17b"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Aim"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5a5e9d6e-add6-4cfa-8b54-c1f2c5dd67d1"",
                    ""path"": ""<Mouse>/press"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Shoot"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Ball
        m_Ball = asset.FindActionMap("Ball", throwIfNotFound: true);
        m_Ball_Aim = m_Ball.FindAction("Aim", throwIfNotFound: true);
        m_Ball_Shoot = m_Ball.FindAction("Shoot", throwIfNotFound: true);
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

    // Ball
    private readonly InputActionMap m_Ball;
    private IBallActions m_BallActionsCallbackInterface;
    private readonly InputAction m_Ball_Aim;
    private readonly InputAction m_Ball_Shoot;
    public struct BallActions
    {
        private @Controls m_Wrapper;
        public BallActions(@Controls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Aim => m_Wrapper.m_Ball_Aim;
        public InputAction @Shoot => m_Wrapper.m_Ball_Shoot;
        public InputActionMap Get() { return m_Wrapper.m_Ball; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(BallActions set) { return set.Get(); }
        public void SetCallbacks(IBallActions instance)
        {
            if (m_Wrapper.m_BallActionsCallbackInterface != null)
            {
                @Aim.started -= m_Wrapper.m_BallActionsCallbackInterface.OnAim;
                @Aim.performed -= m_Wrapper.m_BallActionsCallbackInterface.OnAim;
                @Aim.canceled -= m_Wrapper.m_BallActionsCallbackInterface.OnAim;
                @Shoot.started -= m_Wrapper.m_BallActionsCallbackInterface.OnShoot;
                @Shoot.performed -= m_Wrapper.m_BallActionsCallbackInterface.OnShoot;
                @Shoot.canceled -= m_Wrapper.m_BallActionsCallbackInterface.OnShoot;
            }
            m_Wrapper.m_BallActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Aim.started += instance.OnAim;
                @Aim.performed += instance.OnAim;
                @Aim.canceled += instance.OnAim;
                @Shoot.started += instance.OnShoot;
                @Shoot.performed += instance.OnShoot;
                @Shoot.canceled += instance.OnShoot;
            }
        }
    }
    public BallActions @Ball => new BallActions(this);
    public interface IBallActions
    {
        void OnAim(InputAction.CallbackContext context);
        void OnShoot(InputAction.CallbackContext context);
    }
}
