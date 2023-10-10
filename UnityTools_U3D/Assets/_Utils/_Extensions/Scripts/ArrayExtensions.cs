using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ArrayExtensions
{
    public static T[] Append<T>(this T[] array, T item)
    {
        if (array == null)
        {
            return new T[] { item };
        }

        Array.Resize(ref array, array.Length + 1);
        array[array.Length - 1] = item;
        return array;
    }
}
