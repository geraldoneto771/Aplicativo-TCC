using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

public class Currency : MonoBehaviour
{

    [JsonProperty(PropertyName = "name")]

    public string Name { get; set; }

    [JsonProperty(PropertyName = "buy")]
    public decimal Buy { get; set; }
}
