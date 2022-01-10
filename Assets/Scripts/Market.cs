using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

public class Market : MonoBehaviour
{

    public Market()
    {
        this.Currency = new Currency();
    }

    [JsonProperty(PropertyName = "currencies")]
    public Currency Currency { get; set; }
}
