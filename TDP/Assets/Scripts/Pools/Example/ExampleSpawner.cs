using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Game.Framework.Pool;

public class ExampleSpawner : MonoBehaviour
{
    [SerializeField] private ExamplePool pool;

    private void OnEnable() {
        pool.Return(pool.Request());
    }
}
