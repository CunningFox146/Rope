using System;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Rope.Infrastructure
{
    public class AllServices
    {
        private static AllServices _instance;
        public static AllServices Container => _instance ??= new AllServices();

        public void RegisterSingle<TService>(TService implementation) where TService : IService
        {
            Debug.Log($"RegisterSingle {typeof(TService).Name}");
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

        private class Implementation<TService> where TService : IService
        {
            public static TService ServiceInstance;
        }
    }
}