using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using TMPro;
using Unity.Mathematics;
using Unity.VisualScripting;

public class Takvim : MonoBehaviour
{
   public PuanKontrol puanKontrol;
   public int hafta=1;
   public int ay=07;
   public int yil=2024;

   public TMP_Text haftaText;
   public TMP_Text ayText;
   public TMP_Text yilText;

   public GameObject[] paneller;
   public int gosterilenPanelIndex=-1;

    void Start()
    {
        UpdateText();
        StartCoroutine(Ekle());
    }
    IEnumerator Ekle()
    {
        while(true)
        {
            yield return new WaitForSeconds(30f);
            hafta += 1;
            if(hafta>4)
            {
                ay++;
                hafta=1;
                if(ay>12)
                {
                    yil++;
                    ay=1;
                    hafta=1;
                }
                ShowPanel();
            }
            
            UpdateText();
            puanKontrol.UpdateWeeklyChanges();
        }
        
    }
    void ShowPanel()
    {
        if(gosterilenPanelIndex>0)
        {
            paneller[gosterilenPanelIndex].SetActive(false);
        }
        gosterilenPanelIndex=ay-1;
        paneller[gosterilenPanelIndex].SetActive(true);
        Time.timeScale=0f;
    }
    void UpdateText()
    {
        haftaText.text=hafta.ToString()+".H";
        ayText.text=ay.ToString()+".A";
        yilText.text=yil.ToString();
    }
}
