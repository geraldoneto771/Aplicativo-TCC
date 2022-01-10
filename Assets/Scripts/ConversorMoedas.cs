using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Data;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Drawing;
using System.ComponentModel;
using System.Globalization;
using System;
using System.Net.Http;
using Newtonsoft.Json;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Events;

public class ConversorMoedas : MonoBehaviour
{

    string cotacaoDolar;
    float dolar;
    private double valor, resultado;
    public InputField inputMoney;
    public GameObject textTotalCofre;

    public void ConveterMoedaDolar()
    {

        
        
            string strURL = "https://api.hgbrasil.com/finance?array_limit=1&fields=only_results,USD&key=c1eae02f";

            using (HttpClient client = new HttpClient())
            {

                try
                {
                    var response = client.GetAsync(strURL).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        var result = response.Content.ReadAsStringAsync().Result;

                        Market market = JsonConvert.DeserializeObject<Market>(result);

                        //cotacaoDolar = (market.Currency.Buy);
                        //cotacaoDolar = string.Format(CultureInfo.GetCultureInfo("pt-BR"), "{0:C}", market.Currency.Buy);
                        print(market.Currency.Buy);

                        dolar = (float)market.Currency.Buy;


                        try
                        {
                            if ((double.Parse(inputMoney.text)) <= 0)
                            {
                                Debug.Log("Entre com um valor maior que zero!");
                            }
                            else if ((double.Parse(inputMoney.text)) > 0)
                            {
                                valor = double.Parse(inputMoney.text);


                                resultado = valor / dolar;
                                textTotalCofre.GetComponent<Text>().text = string.Format(CultureInfo.GetCultureInfo("en-US"), "{0:C}", resultado);


                            }
                        }
                        catch (Exception e)
                        {
                            Debug.Log("Entre com um valor!");
                        }



                    }
                    else
                    {
                        cotacaoDolar = "-";
                        print(cotacaoDolar);
                    }
                }
                catch (Exception ex)
                {
                    cotacaoDolar = "erro";

                    Debug.Log(ex);
                    print(cotacaoDolar);
                }
            }
        
                
                
        
    }



    public void ConveterMoedaEuro()
    {



        string strURL = "https://api.hgbrasil.com/finance?array_limit=1&fields=only_results,EUR&key=c1eae02f";

        using (HttpClient client = new HttpClient())
        {

            try
            {
                var response = client.GetAsync(strURL).Result;
                if (response.IsSuccessStatusCode)
                {
                    var result = response.Content.ReadAsStringAsync().Result;

                    Market market = JsonConvert.DeserializeObject<Market>(result);

                    //cotacaoDolar = (market.Currency.Buy);
                    //cotacaoDolar = string.Format(CultureInfo.GetCultureInfo("pt-BR"), "{0:C}", market.Currency.Buy);
                    print(market.Currency.Buy);

                    dolar = (float)market.Currency.Buy;


                    try
                    {
                        if ((double.Parse(inputMoney.text)) <= 0)
                        {
                            Debug.Log("Entre com um valor maior que zero!");
                        }
                        else if ((double.Parse(inputMoney.text)) > 0)
                        {
                            valor = double.Parse(inputMoney.text);


                            resultado = valor / dolar;
                            textTotalCofre.GetComponent<Text>().text = string.Format(CultureInfo.GetCultureInfo("fr-FR"), "{0:C}", resultado);


                        }
                    }
                    catch (Exception e)
                    {
                        Debug.Log("Entre com um valor!");
                    }



                }
                else
                {
                    cotacaoDolar = "-";
                    print(cotacaoDolar);
                }
            }
            catch (Exception ex)
            {
                cotacaoDolar = "erro";

                Debug.Log(ex);
                print(cotacaoDolar);
            }
        }




    }




}
