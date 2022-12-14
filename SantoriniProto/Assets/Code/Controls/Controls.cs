//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.4.2
//     from Assets/Code/Controls/Controls.inputactions
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

public partial class @Controls : IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @Controls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Controls"",
    ""maps"": [
        {
            ""name"": ""Gameplay"",
            ""id"": ""841fde56-2837-4d40-ab94-e0ac55b9ac7b"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""9d1d974d-80d4-4f4d-bb67-00cc2ab1ebef"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Cam Move"",
                    ""type"": ""Value"",
                    ""id"": ""c5a5a9bb-52b8-4a14-96f3-26e1d237ab6d"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""PassThrough"",
                    ""id"": ""899678ab-66b6-4200-91a0-91ea18b421ca"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Tap(duration=0.1)"",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""HighJump"",
                    ""type"": ""PassThrough"",
                    ""id"": ""f48e37c8-e5f1-435a-9e74-e95741c94e3a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Hold(duration=0.11)"",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Punch"",
                    ""type"": ""Button"",
                    ""id"": ""dfdba6d3-8a36-420c-8971-97cc4ef96464"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Kick"",
                    ""type"": ""Button"",
                    ""id"": ""f91e8051-4d69-472e-8e79-9a2a675e9b3c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Use powerup"",
                    ""type"": ""Button"",
                    ""id"": ""301fb81c-19e3-43ef-818f-80ef50def1ff"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""e4fba10f-c17e-4b73-acc7-e21dab3526b7"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""8f9564df-f285-4854-8927-21e81ea21701"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""57df44d2-b5e8-4c9a-83fa-9ee2976eac82"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""073aa5c4-7f26-42f8-9855-0f4f6c6e34e6"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""f8a8932e-f41b-4b8d-af42-b18e79fc6641"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""0709d6fb-e269-4ef5-b098-50e5c3280588"",
                    ""path"": ""<Pointer>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Cam Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ad767730-5ec3-4d2b-a204-9000f32a80d1"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1c5265ba-8ad4-488d-ad64-db4e7f80ded2"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""HighJump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a0fad01b-0c57-468a-9d14-b30dc5527982"",
                    ""path"": ""<Keyboard>/leftCtrl"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Punch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e14d6b27-3fe6-4cb4-b720-093f1a4645fa"",
                    ""path"": ""<Keyboard>/leftShift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Kick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""999c2ae2-04f5-40b5-bf71-046a4bdfd692"",
                    ""path"": ""<Keyboard>/f"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Use powerup"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Gameplay
        m_Gameplay = asset.FindActionMap("Gameplay", throwIfNotFound: true);
        m_Gameplay_Move = m_Gameplay.FindAction("Move", throwIfNotFound: true);
        m_Gameplay_CamMove = m_Gameplay.FindAction("Cam Move", throwIfNotFound: true);
        m_Gameplay_Jump = m_Gameplay.FindAction("Jump", throwIfNotFound: true);
        m_Gameplay_HighJump = m_Gameplay.FindAction("HighJump", throwIfNotFound: true);
        m_Gameplay_Punch = m_Gameplay.FindAction("Punch", throwIfNotFound: true);
        m_Gameplay_Kick = m_Gameplay.FindAction("Kick", throwIfNotFound: true);
        m_Gameplay_Usepowerup = m_Gameplay.FindAction("Use powerup", throwIfNotFound: true);
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

    // Gameplay
    private readonly InputActionMap m_Gameplay;
    private IGameplayActions m_GameplayActionsCallbackInterface;
    private readonly InputAction m_Gameplay_Move;
    private readonly InputAction m_Gameplay_CamMove;
    private readonly InputAction m_Gameplay_Jump;
    private readonly InputAction m_Gameplay_HighJump;
    private readonly InputAction m_Gameplay_Punch;
    private readonly InputAction m_Gameplay_Kick;
    private readonly InputAction m_Gameplay_Usepowerup;
    public struct GameplayActions
    {
        private @Controls m_Wrapper;
        public GameplayActions(@Controls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_Gameplay_Move;
        public InputAction @CamMove => m_Wrapper.m_Gameplay_CamMove;
        public InputAction @Jump => m_Wrapper.m_Gameplay_Jump;
        public InputAction @HighJump => m_Wrapper.m_Gameplay_HighJump;
        public InputAction @Punch => m_Wrapper.m_Gameplay_Punch;
        public InputAction @Kick => m_Wrapper.m_Gameplay_Kick;
        public InputAction @Usepowerup => m_Wrapper.m_Gameplay_Usepowerup;
        public InputActionMap Get() { return m_Wrapper.m_Gameplay; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GameplayActions set) { return set.Get(); }
        public void SetCallbacks(IGameplayActions instance)
        {
            if (m_Wrapper.m_GameplayActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMove;
                @CamMove.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnCamMove;
                @CamMove.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnCamMove;
                @CamMove.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnCamMove;
                @Jump.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnJump;
                @HighJump.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnHighJump;
                @HighJump.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnHighJump;
                @HighJump.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnHighJump;
                @Punch.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnPunch;
                @Punch.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnPunch;
                @Punch.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnPunch;
                @Kick.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnKick;
                @Kick.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnKick;
                @Kick.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnKick;
                @Usepowerup.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnUsepowerup;
                @Usepowerup.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnUsepowerup;
                @Usepowerup.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnUsepowerup;
            }
            m_Wrapper.m_GameplayActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @CamMove.started += instance.OnCamMove;
                @CamMove.performed += instance.OnCamMove;
                @CamMove.canceled += instance.OnCamMove;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @HighJump.started += instance.OnHighJump;
                @HighJump.performed += instance.OnHighJump;
                @HighJump.canceled += instance.OnHighJump;
                @Punch.started += instance.OnPunch;
                @Punch.performed += instance.OnPunch;
                @Punch.canceled += instance.OnPunch;
                @Kick.started += instance.OnKick;
                @Kick.performed += instance.OnKick;
                @Kick.canceled += instance.OnKick;
                @Usepowerup.started += instance.OnUsepowerup;
                @Usepowerup.performed += instance.OnUsepowerup;
                @Usepowerup.canceled += instance.OnUsepowerup;
            }
        }
    }
    public GameplayActions @Gameplay => new GameplayActions(this);
    public interface IGameplayActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnCamMove(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnHighJump(InputAction.CallbackContext context);
        void OnPunch(InputAction.CallbackContext context);
        void OnKick(InputAction.CallbackContext context);
        void OnUsepowerup(InputAction.CallbackContext context);
    }
}
