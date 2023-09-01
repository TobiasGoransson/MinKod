using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Inälmning_4_väderstation
{
    public class Stad //Ny klass skapad
    {
        // deklarerar vad kalssen skall innehålla
        public string namn;
        public int temp;
       
        
        // Denna funktion kommer att skriva ut namnet på en stad och dess temperatur
        public string ToString()
        {

            return this.namn + " " + this.temp + " grader";
        }
    

        // Denna funktion är en linjär sökning som letar rätt på en viss temperatur i listan och returnerar vilket index staden har
        public static int LinSok(List<Stad> lista, int n, int key)
        {
           


            for (int i = 0; i < n; i++)
            {
                if (lista[i].temp == key)
                {              
                    return i;
                }                
            }
            
            return -1;
        }


        // DEnna funktion är en bubbel sort funktion som sorterar listan kallast först och ger tillbaka listan sorterad
        public static List<Stad> BubbelSort(List<Stad> lista)
        {
          
            int max = lista.Count - 1;

            for (int i = 0;i<max; i++)
            {
                int nrLeft = max - i;
                for (int j = 0;j < nrLeft; j++)
                {
                    if (lista[j].temp > lista[j + 1].temp)
                    {
                        Stad tempo = lista[j];
                        lista[j] = lista[j + 1];
                        lista[j + 1] = tempo;
                    }
                }
            }
            return lista;
        }

        
        // DEnna funktion är en slelection sort funktion som sorterar listan kallast först och ger tillbaka listan sorterad
        public static List<Stad> SelectionSort(List<Stad> lista)
        {
            int n = lista.Count;
            for (int i = 0; i < n - 1; i++)
            {
                int minIndex = i;
                for (int j = i + 1; j < n; j++)
                {
                    if (lista[j].temp.CompareTo(lista[minIndex].temp) < 0)
                    {
                        minIndex = j;
                    }
                }
                if (minIndex != i)
                {
                    Stad temp = lista[i];
                    lista[i] = lista[minIndex];
                    lista[minIndex] = temp;
                }
            }
            return lista;
        }


        // Denna funktionen är en binär sökning efter en speciell temperatur funktionen kommer ge tillbaka den sökta temperaturens index
        public static int BinSök(List<Stad> lista, int n, int key)
        {           
            {
                int first = 0;
                int last = n - 1;

                while (first <= last)
                {
                    int mid = (first + last) / 2;

                    if (key.CompareTo(lista[mid].temp) > 0)
                    {
                        first = mid + 1;
                    }
                    else if (key.CompareTo(lista[mid].temp) < 0)
                    {
                        last = mid - 1;
                    }
                    else
                    {
                        return mid;
                    }                    
                }
                return -1;
            }            
        }



        // Denna funktionen sotrerar listan först och ger tillbaka staden med högst index vilket blir den stad som är varmast
         public static string  HögstaTemp(List<Stad> lista)
        {
            lista = Stad.SelectionSort(lista);
            int n = lista.Count-1;
            string lastElement = lista[n].namn;

            return lastElement;
        }


        // Denna funktionen sotrerar listan först och ger tillbaka staden med lägst index vilket blir den stad som är kallast
        public static string LägstaTemp(List<Stad> lista)
        {
            lista = Stad.SelectionSort(lista);            
            string firstElement = lista[0].namn;
            
            return firstElement;

        }
        }
        
    }



