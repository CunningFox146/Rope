using System;
using Rope.Infrastructure;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Rope.Services
{
    public class AllServices
    {
        private static AllServices _instance;
        public static AllServices Container => _instance ??= new AllServices();

        public void RegisterSingle<TService>(TService implementation) where TService : IService
        {
            Implementation<TService>.ServiceInstance = implementation;
        }

        public TService Single<TService>() where TService : IService
        {
            return Implementation<TService>.ServiceInstance;
        }
        
        public void RegisterSingleFromHierarchy<TService>() where TService : Object, IService
        {
            var implementation = Object.FindAnyObjectByType<TService>();
            if (implementation is null)
                throw new Exception($"Failed to find {typeof(TService).Name} in scene hierarchy");
            Implementation<TService>.ServiceInstance = implementation;
        }
        
        public void RegisterSingleFromNewPrefab<TService>(GameObject prefab) where TService : Object, IService
        {
            var obj = Object.Instantiate(prefab);
            Implementation<TService>.ServiceInstance = obj.GetComponent<TService>();
        }

        private class Implementation<TService> where TService : IService
        {
            public static TService ServiceInstance;
        }
    }
}