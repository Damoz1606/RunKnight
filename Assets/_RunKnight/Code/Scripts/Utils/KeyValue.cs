using System;
using UnityEngine;

[Serializable]
public struct KeyValue<K, V>
{
    public K key;
    public V value;
}