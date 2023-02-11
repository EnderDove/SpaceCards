//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.4.4
//     from Assets/Scripts/Player/PlayerInput.inputactions
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

namespace Game
{
    public partial class @PlayerInput : IInputActionCollection2, IDisposable
    {
        public InputActionAsset asset { get; }
        public @PlayerInput()
        {
            asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerInput"",
    ""maps"": [
        {
            ""name"": ""Movement"",
            ""id"": ""70edcb2a-c34d-4b84-ab0c-381772fff734"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""PassThrough"",
                    ""id"": ""905c71b7-4f4c-4a6d-a9e2-a8d0b7620037"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Crosshair"",
                    ""type"": ""PassThrough"",
                    ""id"": ""d1cb6ece-5c76-4d5c-9280-54f9091f6e73"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""WASD"",
                    ""id"": ""76745c8b-d020-4653-8e98-946c9f9dfced"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": ""NormalizeVector2"",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""480ce86f-c38d-460d-a889-84d36546ddb3"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardMouse"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""100ad9e0-c05b-4f68-ad32-a52762c18b48"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardMouse"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""71fea85b-5b52-4d4f-8bd4-8bc243472a8d"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardMouse"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""f52835d2-8a39-426f-b0d6-054b17c80c3f"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardMouse"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""ff8727f2-e192-4667-ab8f-aca4e495fc94"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""93c98ff6-f000-4be8-8a57-83c0b6af0169"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardMouse"",
                    ""action"": ""Crosshair"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""fca280ab-d30a-411d-9702-c6d2afbc3a1f"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Crosshair"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Actions"",
            ""id"": ""61056e55-6986-4e75-92fa-a5ef82885306"",
            ""actions"": [
                {
                    ""name"": ""RightMB"",
                    ""type"": ""Button"",
                    ""id"": ""ed056ede-46d2-471b-b0db-3e6e5898d0f9"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""LeftMb"",
                    ""type"": ""Button"",
                    ""id"": ""61fa44ec-e1d9-45a6-8925-0085c7c7cd69"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Dash"",
                    ""type"": ""Button"",
                    ""id"": ""c102057f-8c20-495b-8d7e-e62d558b2bbb"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""f15aa79c-168f-4a5b-9e32-946821717baa"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RightMB"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""376ddc75-227f-40c8-b8bb-e8f226f6547e"",
                    ""path"": ""<Gamepad>/leftTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""RightMB"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0f04f961-6c5f-479f-8359-2904019c5a57"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LeftMb"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3cdd1a4e-07a2-4312-bbb8-b71ba482f53c"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""LeftMb"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0eb065f5-e027-4c89-a24d-4c823d664937"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Dash"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""55fb49e4-dc32-45ad-885e-165db99a734a"",
                    ""path"": ""<Gamepad>/dpad/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Dash"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""KeyboardMouse"",
            ""bindingGroup"": ""KeyboardMouse"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<Mouse>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""Gamepad"",
            ""bindingGroup"": ""Gamepad"",
            ""devices"": [
                {
                    ""devicePath"": ""<Gamepad>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
            // Movement
            m_Movement = asset.FindActionMap("Movement", throwIfNotFound: true);
            m_Movement_Movement = m_Movement.FindAction("Movement", throwIfNotFound: true);
            m_Movement_Crosshair = m_Movement.FindAction("Crosshair", throwIfNotFound: true);
            // Actions
            m_Actions = asset.FindActionMap("Actions", throwIfNotFound: true);
            m_Actions_RightMB = m_Actions.FindAction("RightMB", throwIfNotFound: true);
            m_Actions_LeftMb = m_Actions.FindAction("LeftMb", throwIfNotFound: true);
            m_Actions_Dash = m_Actions.FindAction("Dash", throwIfNotFound: true);
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

        // Movement
        private readonly InputActionMap m_Movement;
        private IMovementActions m_MovementActionsCallbackInterface;
        private readonly InputAction m_Movement_Movement;
        private readonly InputAction m_Movement_Crosshair;
        public struct MovementActions
        {
            private @PlayerInput m_Wrapper;
            public MovementActions(@PlayerInput wrapper) { m_Wrapper = wrapper; }
            public InputAction @Movement => m_Wrapper.m_Movement_Movement;
            public InputAction @Crosshair => m_Wrapper.m_Movement_Crosshair;
            public InputActionMap Get() { return m_Wrapper.m_Movement; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(MovementActions set) { return set.Get(); }
            public void SetCallbacks(IMovementActions instance)
            {
                if (m_Wrapper.m_MovementActionsCallbackInterface != null)
                {
                    @Movement.started -= m_Wrapper.m_MovementActionsCallbackInterface.OnMovement;
                    @Movement.performed -= m_Wrapper.m_MovementActionsCallbackInterface.OnMovement;
                    @Movement.canceled -= m_Wrapper.m_MovementActionsCallbackInterface.OnMovement;
                    @Crosshair.started -= m_Wrapper.m_MovementActionsCallbackInterface.OnCrosshair;
                    @Crosshair.performed -= m_Wrapper.m_MovementActionsCallbackInterface.OnCrosshair;
                    @Crosshair.canceled -= m_Wrapper.m_MovementActionsCallbackInterface.OnCrosshair;
                }
                m_Wrapper.m_MovementActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @Movement.started += instance.OnMovement;
                    @Movement.performed += instance.OnMovement;
                    @Movement.canceled += instance.OnMovement;
                    @Crosshair.started += instance.OnCrosshair;
                    @Crosshair.performed += instance.OnCrosshair;
                    @Crosshair.canceled += instance.OnCrosshair;
                }
            }
        }
        public MovementActions @Movement => new MovementActions(this);

        // Actions
        private readonly InputActionMap m_Actions;
        private IActionsActions m_ActionsActionsCallbackInterface;
        private readonly InputAction m_Actions_RightMB;
        private readonly InputAction m_Actions_LeftMb;
        private readonly InputAction m_Actions_Dash;
        public struct ActionsActions
        {
            private @PlayerInput m_Wrapper;
            public ActionsActions(@PlayerInput wrapper) { m_Wrapper = wrapper; }
            public InputAction @RightMB => m_Wrapper.m_Actions_RightMB;
            public InputAction @LeftMb => m_Wrapper.m_Actions_LeftMb;
            public InputAction @Dash => m_Wrapper.m_Actions_Dash;
            public InputActionMap Get() { return m_Wrapper.m_Actions; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(ActionsActions set) { return set.Get(); }
            public void SetCallbacks(IActionsActions instance)
            {
                if (m_Wrapper.m_ActionsActionsCallbackInterface != null)
                {
                    @RightMB.started -= m_Wrapper.m_ActionsActionsCallbackInterface.OnRightMB;
                    @RightMB.performed -= m_Wrapper.m_ActionsActionsCallbackInterface.OnRightMB;
                    @RightMB.canceled -= m_Wrapper.m_ActionsActionsCallbackInterface.OnRightMB;
                    @LeftMb.started -= m_Wrapper.m_ActionsActionsCallbackInterface.OnLeftMb;
                    @LeftMb.performed -= m_Wrapper.m_ActionsActionsCallbackInterface.OnLeftMb;
                    @LeftMb.canceled -= m_Wrapper.m_ActionsActionsCallbackInterface.OnLeftMb;
                    @Dash.started -= m_Wrapper.m_ActionsActionsCallbackInterface.OnDash;
                    @Dash.performed -= m_Wrapper.m_ActionsActionsCallbackInterface.OnDash;
                    @Dash.canceled -= m_Wrapper.m_ActionsActionsCallbackInterface.OnDash;
                }
                m_Wrapper.m_ActionsActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @RightMB.started += instance.OnRightMB;
                    @RightMB.performed += instance.OnRightMB;
                    @RightMB.canceled += instance.OnRightMB;
                    @LeftMb.started += instance.OnLeftMb;
                    @LeftMb.performed += instance.OnLeftMb;
                    @LeftMb.canceled += instance.OnLeftMb;
                    @Dash.started += instance.OnDash;
                    @Dash.performed += instance.OnDash;
                    @Dash.canceled += instance.OnDash;
                }
            }
        }
        public ActionsActions @Actions => new ActionsActions(this);
        private int m_KeyboardMouseSchemeIndex = -1;
        public InputControlScheme KeyboardMouseScheme
        {
            get
            {
                if (m_KeyboardMouseSchemeIndex == -1) m_KeyboardMouseSchemeIndex = asset.FindControlSchemeIndex("KeyboardMouse");
                return asset.controlSchemes[m_KeyboardMouseSchemeIndex];
            }
        }
        private int m_GamepadSchemeIndex = -1;
        public InputControlScheme GamepadScheme
        {
            get
            {
                if (m_GamepadSchemeIndex == -1) m_GamepadSchemeIndex = asset.FindControlSchemeIndex("Gamepad");
                return asset.controlSchemes[m_GamepadSchemeIndex];
            }
        }
        public interface IMovementActions
        {
            void OnMovement(InputAction.CallbackContext context);
            void OnCrosshair(InputAction.CallbackContext context);
        }
        public interface IActionsActions
        {
            void OnRightMB(InputAction.CallbackContext context);
            void OnLeftMb(InputAction.CallbackContext context);
            void OnDash(InputAction.CallbackContext context);
        }
    }
}
