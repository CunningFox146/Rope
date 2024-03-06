using System.Collections;
using UnityEngine;

namespace Rope.Infrastructure.CoroutineRunner
{
    public interface ICoroutineRunner
    {
        Coroutine StartCoroutine(IEnumerator coroutine);
    }
}