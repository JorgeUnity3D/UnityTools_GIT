using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ExampleKeyStore : KeyStore
{
    #region EXAMPLE

    [SerializeField]
    public string apiUrl = "https://fakeExampleUrl.com/";

    [SerializeField]
    public string apiKey = "fakeExampleApiKey";

    #endregion
}
