using System;
using System.Collections;
using Rope.Infrastructure;

namespace Rope.Services.SceneLoading
{
    public interface ISceneLoader : IService
    {
        void Load(string name, Action onLoaded = null);
        void Load(SceneNames name, Action onLoaded = null);
        IEnumerator LoadScene(string nextScene, Action onLoaded = null);
    }
}