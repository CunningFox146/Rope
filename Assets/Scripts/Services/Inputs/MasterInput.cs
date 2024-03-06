//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.7.0
//     from Assets/Settings/Input/MasterInput.inputactions
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

namespace Rope.Services.Inputs
{
    public partial class @MasterInput: IInputActionCollection2, IDisposable
    {
        public InputActionAsset asset { get; }
        public @MasterInput()
        {
            asset = InputActionAsset.FromJson(@"{
    ""name"": ""MasterInput"",
    ""maps"": [
        {
            ""name"": ""Generic"",
            ""id"": ""2d5f904c-3ee2-4a2c-9a51-3b68f708bbd3"",
            ""actions"": [
                {
                    ""name"": ""Click"",
                    ""type"": ""Button"",
                    ""id"": ""6b2ab9f2-a5e9-457f-beea-3e17eaf1a2fc"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Hold"",
                    ""type"": ""Button"",
                    ""id"": ""c785bdea-260f-4e7e-a369-53f12c7952e2"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Hold"",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""ClickPosition"",
                    ""type"": ""PassThrough"",
                    ""id"": ""9f20e4af-4854-45b1-bcfd-e574b8059dd0"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""1df2dff1-5b54-415e-baf9-353bc402968b"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Hold"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e754101c-d3f8-4626-aa93-52521f00b698"",
                    ""path"": ""<Touchscreen>/Press"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Hold"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d7eb1dfa-4a8d-4da9-9465-c8bf08177189"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Click"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""305a986f-838f-4d6a-a40b-566f40e49295"",
                    ""path"": ""<Touchscreen>/Press"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Click"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""293a7335-988a-4c19-a716-8f0c94347d6c"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ClickPosition"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8a47c232-abb8-4e28-b053-67726c1f6e33"",
                    ""path"": ""<Touchscreen>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ClickPosition"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
            // Generic
            m_Generic = asset.FindActionMap("Generic", throwIfNotFound: true);
            m_Generic_Click = m_Generic.FindAction("Click", throwIfNotFound: true);
            m_Generic_Hold = m_Generic.FindAction("Hold", throwIfNotFound: true);
            m_Generic_ClickPosition = m_Generic.FindAction("ClickPosition", throwIfNotFound: true);
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

        // Generic
        private readonly InputActionMap m_Generic;
        private List<IGenericActions> m_GenericActionsCallbackInterfaces = new List<IGenericActions>();
        private readonly InputAction m_Generic_Click;
        private readonly InputAction m_Generic_Hold;
        private readonly InputAction m_Generic_ClickPosition;
        public struct GenericActions
        {
            private @MasterInput m_Wrapper;
            public GenericActions(@MasterInput wrapper) { m_Wrapper = wrapper; }
            public InputAction @Click => m_Wrapper.m_Generic_Click;
            public InputAction @Hold => m_Wrapper.m_Generic_Hold;
            public InputAction @ClickPosition => m_Wrapper.m_Generic_ClickPosition;
            public InputActionMap Get() { return m_Wrapper.m_Generic; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(GenericActions set) { return set.Get(); }
            public void AddCallbacks(IGenericActions instance)
            {
                if (instance == null || m_Wrapper.m_GenericActionsCallbackInterfaces.Contains(instance)) return;
                m_Wrapper.m_GenericActionsCallbackInterfaces.Add(instance);
                @Click.started += instance.OnClick;
                @Click.performed += instance.OnClick;
                @Click.canceled += instance.OnClick;
                @Hold.started += instance.OnHold;
                @Hold.performed += instance.OnHold;
                @Hold.canceled += instance.OnHold;
                @ClickPosition.started += instance.OnClickPosition;
                @ClickPosition.performed += instance.OnClickPosition;
                @ClickPosition.canceled += instance.OnClickPosition;
            }

            private void UnregisterCallbacks(IGenericActions instance)
            {
                @Click.started -= instance.OnClick;
                @Click.performed -= instance.OnClick;
                @Click.canceled -= instance.OnClick;
                @Hold.started -= instance.OnHold;
                @Hold.performed -= instance.OnHold;
                @Hold.canceled -= instance.OnHold;
                @ClickPosition.started -= instance.OnClickPosition;
                @ClickPosition.performed -= instance.OnClickPosition;
                @ClickPosition.canceled -= instance.OnClickPosition;
            }

            public void RemoveCallbacks(IGenericActions instance)
            {
                if (m_Wrapper.m_GenericActionsCallbackInterfaces.Remove(instance))
                    UnregisterCallbacks(instance);
            }

            public void SetCallbacks(IGenericActions instance)
            {
                foreach (var item in m_Wrapper.m_GenericActionsCallbackInterfaces)
                    UnregisterCallbacks(item);
                m_Wrapper.m_GenericActionsCallbackInterfaces.Clear();
                AddCallbacks(instance);
            }
        }
        public GenericActions @Generic => new GenericActions(this);
        public interface IGenericActions
        {
            void OnClick(InputAction.CallbackContext context);
            void OnHold(InputAction.CallbackContext context);
            void OnClickPosition(InputAction.CallbackContext context);
        }
    }
}