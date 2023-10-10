using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OtherExampleManager : MonoBehaviour
{
    private void Start()
    {
        ServiceLocator.Instance.GetService<ExampleManager>().ExampleMethod();
    }
}
