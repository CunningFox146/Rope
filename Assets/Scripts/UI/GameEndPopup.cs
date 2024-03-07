using System;
using Rope.Services;
using Rope.Services.Sound;
using UnityEngine;

namespace Rope.UI
{
    public class GameEndPopup : Popup
    {
        [SerializeField] private SoundData _openSound;
        private ISoundPlayer _sound;

        private void Awake()
        {
            _sound = AllServices.Container.Single<ISoundPlayer>();
        }

        public void OnClick()
        {
            Debug.Log("Player clicked popup");
        }

        public override void Show()
        {
            base.Show();
            _sound.Play(_openSound);
        }
    }
}