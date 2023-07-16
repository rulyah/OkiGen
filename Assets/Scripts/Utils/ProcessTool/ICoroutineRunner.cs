using System.Collections;
using UnityEngine;

namespace Utils.ProcessTool
{
    public interface ICoroutineRunner
    {
        public Coroutine StartCoroutine(IEnumerator routine);
        public void StopCoroutine(Coroutine coroutine);
    }
}