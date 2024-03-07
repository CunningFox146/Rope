using System;
using Rope.Infrastructure;
using Rope.Services;
using Rope.Services.Inputs;
using Rope.Services.Interactions;
using Rope.Services.Spawner;
using UnityEngine;

namespace Rope.UI
{
    public class UserInterfaceSystem : MonoBehaviour, IService
    {
        [SerializeField] private GameObject _guide;
        [SerializeField] private Popup _endGamePopup;
        private IInputService _input;
        private CharacterSpawner _spawner;

        private void Awake()
        {
            _input = AllServices.Container.Single<IInputService>();
            _spawner = AllServices.Container.Single<CharacterSpawner>();
        }

        private void Start()
        {
            _input.Click += OnClick;
            _spawner.NoCharacters += OnNoCharactersLeft;
        }

        private void OnNoCharactersLeft()
        {
            _endGamePopup.Show();
        }

        private void OnClick(Vector2 obj)
        {
            _input.Click -= OnClick;
            _guide.gameObject.SetActive(false);
        }
    }
}