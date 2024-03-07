using System.Collections;
using System.Collections.Generic;
using Rope.Infrastructure.CoroutineRunner;
using UnityEngine;
using UnityEngine.Pool;

namespace Rope.Services.Sound
{
    public class SoundPlayer : ISoundPlayer
    {
        private readonly ICoroutineRunner _coroutineRunner;
        private readonly ObjectPool<AudioSource> _sources;

        public SoundPlayer(ICoroutineRunner coroutineRunner)
        {
            _coroutineRunner = coroutineRunner;
            _sources = new ObjectPool<AudioSource>(
                () => new GameObject().AddComponent<AudioSource>(),
                obj => obj.gameObject.SetActive(true),
                obj => obj.gameObject.SetActive(false)
            );
        }

        public void Play(SoundData soundData)
        {
            var source = _sources.Get();
            source.clip = soundData.Clips[Random.Range(0, soundData.Clips.Count)];
            source.loop = soundData.IsLoop;
            source.volume = soundData.Volume;
            source.outputAudioMixerGroup = soundData.AudioMixerGroup;
            source.Play();
            
            if (!soundData.IsLoop)
                _coroutineRunner.StartCoroutine(ReleaseAudioSourceCoroutine(source));
        }

        private IEnumerator ReleaseAudioSourceCoroutine(AudioSource source)
        {
            yield return new WaitForSeconds(source.clip.length);
            _sources.Release(source);
        }
    }
}