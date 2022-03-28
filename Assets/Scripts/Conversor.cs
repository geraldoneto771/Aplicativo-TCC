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

public class Conversor : MonoBehaviour
{

    
    int verificador;
    // Start is called before the first frame update

    string cotacaoDolar;
    float dolar;
    private double valor, resultado;
    public InputField inputMoney;
    public GameObject textTotalCofre;

    public void HandleInputData(int val)
    {
        if (val == 0)
        {
           
            verificador = 0;
            print(verificador);
        }
        if (val == 1)
        {
           
            verificador = 1;
            print(verificador);
        }
        if (val == 2)
        {
            
            verificador = 2;
            print(verificador);
        }
        if (val == 3)
        {

            verificador = 3;
            print(verificador);
        }
        if (val == 4)
        {

            verificador = 4;
            print(verificador);
        }
        if (val == 5)
        {

            verificador = 5;
            print(verificador);
        }
    }


    public void ConverterMoeda()
    {
        print(verificador);

        if(verificador == 0)
        {
            print("Selecione uma moeda");
        }

        if(verificador == 1)
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
                            Debug.Log("Entre com um valor!" + e);
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

        if (verificador == 2)
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
                            Debug.Log("Entre com um valor!" +  e);
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

        if (verificador == 3)
        {

            string strURL = "https://api.hgbrasil.com/finance?array_limit=1&fields=only_results,GBP&key=c1eae02f";

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
                                textTotalCofre.GetComponent<Text>().text = string.Format(CultureInfo.GetCultureInfo("en-GB"), "{0:C}", resultado);


                            }
                        }
                        catch (Exception e)
                        {
                            Debug.Log("Entre com um valor!" + e);
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

        if (verificador == 4)
        {

            string strURL = "https://api.hgbrasil.com/finance?array_limit=1&fields=only_results,JPY&key=c1eae02f";

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
                                textTotalCofre.GetComponent<Text>().text = string.Format(CultureInfo.GetCultureInfo("ja-JP"), "{0:C}", resultado);


                            }
                        }
                        catch (Exception e)
                        {
                            Debug.Log("Entre com um valor!" + e);
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

        if (verificador == 5)
        {

            string strURL = "https://api.hgbrasil.com/finance?array_limit=1&fields=only_results,ARS&key=c1eae02f";

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
                                textTotalCofre.GetComponent<Text>().text = string.Format(CultureInfo.GetCultureInfo("es-AR"), "{0:C}", resultado);


                            }
                        }
                        catch (Exception e)
                        {
                            Debug.Log("Entre com um valor!" + e);
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
    
}
