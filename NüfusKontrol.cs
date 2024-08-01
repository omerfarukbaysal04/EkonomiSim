using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NüfusKontrol : MonoBehaviour
{ 
    public PuanKontrol puanKontrol;
    public float nüfus=85000f;
    public float vergiOran=20f;
    public float vergiGeliri;
    public float nüfusMilyon=85f;
    public float vergiBin;
    public float nüfusCarpan=100000f;
    public float  vergiLevel=1f;
    public float tlPuan=100000f;
    public float tlCarpan=100f;
    public float mutluluk=60f;
    public int güvenlikLevel=1;
    public int güvenlikMaliyet=100000;
    public int saglikLevel=1;
    public int saglikMaliyet=100000;
    public int egitimLevel=1;
    public int egitimMaliyet=100000;
    public int dinLevel=1;
    public int dinMaliyet=100000;
    public int tarimLevel=1;
    public int tarimMaliyet=100000;
    public int teknolojiLevel=1;
    public int teknolojiMaliyet=100000;
    public int genelLevel=1;
    public int genelMaliyet=100000;
    public int genelGelistirmeSayisi=0;
    public int gelistirmeAylikGider=20000;
    public int egitimGelir=10000;
    public int tarimGelir=10000;
    public int teknolojiGelir=10000;
    public int güvenlikGider=20000;
    public int saglikGider=20000;
    public int dinGider=20000;
    public int egitimGider=20000;
    public int tarimGider=20000;
    public int teknolojiGider=20000;
    public int gerekliGelistirme=4;
    public int digerGelirler;
    public int giderler;

    public Button güvenlikButonu;
    public Button saglikButonu;
    public Button dinButonu;
    public Button egitimButonu;
    public Button tarimButonu;
    public Button teknolojiButonu;
    public Button genelSeviyeButonu;
    public Button vergiArttir;
    public Button vergiAzalttir;


    public TMP_Text nüfusText;
    public TMP_Text vergiText;
    public TMP_Text tlPuanText;
    public TMP_Text mutlulukText;
    public TMP_Text güvenlikText;
    public TMP_Text güvenlikMaliyetText;
    public TMP_Text saglikText;
    public TMP_Text saglikMaliyetText;
    public TMP_Text egitimText;
    public TMP_Text egitimMaliyetText;
    public TMP_Text dinText;
    public TMP_Text dinMaliyetText;
    public TMP_Text tarimText;
    public TMP_Text tarimMaliyetText;
    public TMP_Text teknolojiText;
    public TMP_Text teknolojiMaliyetText;
    public TMP_Text  genelText;
    public TMP_Text genelMaliyetText;
    public TMP_Text genelGelistirmeText;
    public TMP_Text gerekliGelistirmeText;
    public TMP_Text mevcutTlText;
    public TMP_Text digerGelirlerText;
    public TMP_Text vergiOranText;
    public TMP_Text giderlerText;

      void Start()
    {   
        UpdateText();
        StartCoroutine(NüfusArttir());
        StartCoroutine(TLArttir());
        nüfusMilyon=nüfus/1000000f;
        vergiBin=vergiGeliri/100f;
        UpdateButtonInteractability();
    }
    void Update()
    {
        VergiHesapla();
        VergiArttırma();
        VergiAzaltma();
        UpdateButtonInteractability();
        DigerGelirHesapla();
        GiderHesaplama();
        Mutluluk();
    }
    void UpdateButtonInteractability()
    {
        güvenlikButonu.interactable = tlPuan >= güvenlikMaliyet;
        saglikButonu.interactable = tlPuan >= saglikMaliyet;
        dinButonu.interactable = tlPuan >= dinMaliyet;
        egitimButonu.interactable = tlPuan >= egitimMaliyet;
        tarimButonu.interactable = tlPuan >= tarimMaliyet;
        teknolojiButonu.interactable = tlPuan >= teknolojiMaliyet;
        genelSeviyeButonu.interactable = tlPuan >= genelMaliyet && genelGelistirmeSayisi >=4;
    }
    void Mutluluk()
    {
        if(mutluluk<0 || tlPuan<-100000)
        {
            SceneManager.LoadScene(2);
        }
        if (mutluluk>100)
        {
            mutluluk=100;
            mutlulukText.text=mutluluk.ToString();
        }
    }
    public void GenelLevel()
    {
        if(genelGelistirmeSayisi==4 && tlPuan>=genelMaliyet)
        {   genelSeviyeButonu.interactable=true;
            genelLevel+=1; //level 2 oldu
            genelMaliyet+=50000;
            tlCarpan*=5;
            gerekliGelistirme=4;
            genelGelistirmeSayisi=0;
            puanKontrol.dolarCarpan+=0.01f;
            puanKontrol.euroCarpan+=0.01f;
            puanKontrol.altinCarpan+=0.1f;
            nüfusCarpan=nüfusCarpan*nüfusCarpan/2;
            genelText.text=genelLevel.ToString();
            genelMaliyetText.text=genelMaliyet.ToString();
            genelGelistirmeText.text=genelGelistirmeSayisi+2.ToString();
            tlPuan-=genelMaliyet; //birdahaki geliştirme leveli için ihtiyaç duyulan geliştirme adedini gösterir
            UpdateButtonInteractability();
        }
       
        else güvenlikButonu.interactable = false;
    }
    public void GüvenlikLevel()
    {  
        if(tlPuan>=güvenlikMaliyet)
    {   güvenlikButonu.interactable=true;
        güvenlikLevel+=1; //2 oldu
        güvenlikMaliyet+=20000;
        güvenlikGider+=5000;
        güvenlikText.text=güvenlikLevel.ToString();
        güvenlikMaliyetText.text=güvenlikMaliyet.ToString(); 
        tlPuan-=güvenlikMaliyet;
        gerekliGelistirme-=1;
        genelGelistirmeSayisi+=1;
        if(güvenlikLevel==6)
        {
            güvenlikButonu.interactable = false;
        }
        UpdateText();
    }
    }
    public void SaglikLevel()
    {
         if(tlPuan>=saglikMaliyet)
    {   saglikButonu.interactable=true;
        saglikLevel+=1; //2 oldu
        saglikMaliyet+=20000;
        saglikGider+=5000;
        saglikText.text=saglikLevel.ToString();
        saglikMaliyetText.text=saglikMaliyet.ToString(); 
        tlPuan-=saglikMaliyet;
        gerekliGelistirme-=1;
        genelGelistirmeSayisi+=1;
        if(saglikLevel==6)
        {
            saglikButonu.interactable = false;
        }
        UpdateText();
    }
    }
    public void DinLevel()
    {
         if(tlPuan>=dinMaliyet)
    {   dinButonu.interactable=true;
        dinLevel+=1; //2 oldu
        dinMaliyet+=20000;
        dinGider+=5000;
        dinText.text=dinLevel.ToString();
        dinMaliyetText.text=dinMaliyet.ToString(); 
        tlPuan-=dinMaliyet;
        gerekliGelistirme-=1;
        genelGelistirmeSayisi+=1;
        if(dinLevel==6)
        {
            dinButonu.interactable = false;
        }
        UpdateText();
    }
    }
    public void EgitimLevel()
    {
         if(tlPuan>=egitimMaliyet)
    {   egitimButonu.interactable=true;
        egitimLevel+=1; //2 oldu
        egitimMaliyet+=20000;
        egitimGelir+=5000;
        egitimGider+=5000;
        egitimText.text=egitimLevel.ToString();
        egitimMaliyetText.text=egitimMaliyet.ToString(); 
        tlPuan-=egitimMaliyet;
        gerekliGelistirme-=1;
        genelGelistirmeSayisi+=1;
        if(egitimLevel==6)
        {
            egitimButonu.interactable = false;
        }
        UpdateText();
    }
    }
    public void TarimLevel()
    {
         if(tlPuan>=tarimMaliyet)
    {   tarimButonu.interactable=true;
        tarimLevel+=1; //2 oldu
        tarimMaliyet+=20000;
        tarimGelir+=5000;
        tarimGider+=5000;
        tarimText.text=tarimLevel.ToString();
        tarimMaliyetText.text=tarimMaliyet.ToString();
        tlPuan-=tarimMaliyet; 
        gerekliGelistirme-=1;
        genelGelistirmeSayisi+=1;
        if(tarimLevel==6)
        {
            tarimButonu.interactable = false;
        }
        UpdateText();
    }
    }
    public void TeknolojiLevel()
    {
         if(tlPuan>=teknolojiMaliyet)
    {   teknolojiButonu.interactable=true;
        teknolojiLevel+=1; //2 oldu
        teknolojiMaliyet+=20000;
        teknolojiGelir+=5000;
        teknolojiGider+=5000;
        gerekliGelistirme-=1;
        teknolojiText.text=teknolojiLevel.ToString();
        teknolojiMaliyetText.text=teknolojiMaliyet.ToString();
        tlPuan-=teknolojiMaliyet; 
        genelGelistirmeSayisi+=1;
        if(teknolojiLevel==6)
        {
            teknolojiButonu.interactable = false;
        }
        UpdateText();
    }
    }

    IEnumerator TLArttir()
    {   while(true)
        {
            yield return new WaitForSeconds(1f);
            tlPuan+=tlCarpan;
            UpdateText();
        }
    }
      IEnumerator NüfusArttir() //aylık gelir+nüfus+vergi
    {
        while(true)
        {
            yield return new WaitForSeconds(120f);
            nüfus +=100000f;
            nüfusMilyon +=0.100f;
            tlPuan+=vergiGeliri+teknolojiGelir+egitimGelir+tarimGelir+egitimGelir;
            tlPuan-=güvenlikGider+saglikGider+dinGider+tarimGider+egitimGider+teknolojiGider;
            UpdateText();
        }
    }
    public void VergiArttırma()
    {
        mutluluk -=10;
        mutlulukText.text=mutluluk.ToString("F2");
        vergiText.text=vergiBin.ToString("F1")+"B";
        vergiOran+=1;
    }
    public void VergiAzaltma()
    {
        mutluluk +=10;
        mutlulukText.text=mutluluk.ToString("F2");
        vergiText.text=vergiBin.ToString("F1")+"B";
        vergiOran-=1;
    }
    public void VergiHesapla()
    {
        vergiGeliri=nüfus*vergiOran*0.01f/100f;
        vergiBin=vergiGeliri/1000f;
        tlPuanText.text=tlPuan.ToString("F2");
        vergiText.text=vergiBin.ToString("F1")+"B";
        vergiOranText.text=vergiOran.ToString();
    }
    void DigerGelirHesapla()
    {
        digerGelirler=egitimGelir+tarimGelir+teknolojiGelir;
        UpdateText();
    }
    void GiderHesaplama()
    {
        giderler=egitimGider+tarimGider+teknolojiGider+saglikGider+dinGider+güvenlikGider;
        UpdateText();
    }

    public void UpdateText()
    {
        nüfusText.text=nüfusMilyon.ToString("F3")+"M";
        tlPuanText.text = tlPuan.ToString("F2");
        genelText.text=genelLevel.ToString();
        genelMaliyetText.text=genelMaliyet.ToString();
        genelGelistirmeText.text=genelGelistirmeSayisi.ToString();
        güvenlikText.text=güvenlikLevel.ToString();
        güvenlikMaliyetText.text=güvenlikMaliyet.ToString();
        saglikText.text = saglikLevel.ToString();
        saglikMaliyetText.text = saglikMaliyet.ToString();
        dinText.text=dinLevel.ToString();
        dinMaliyetText.text=dinMaliyet.ToString();
        egitimText.text=egitimLevel.ToString();
        egitimMaliyetText.text=egitimMaliyet.ToString();
        tarimMaliyetText.text=tarimMaliyet.ToString();
        tarimText.text = tarimLevel.ToString();
        teknolojiText.text=teknolojiLevel.ToString();
        teknolojiMaliyetText.text=teknolojiMaliyet.ToString();
        gerekliGelistirmeText.text=gerekliGelistirme.ToString();
        mevcutTlText.text=tlPuan.ToString();
        digerGelirlerText.text=digerGelirler.ToString();
        giderlerText.text = giderler.ToString();
    }
     public void Ekle(string tur)
     {  switch(tur)
     {
        case "nüfus":
            nüfus+=nüfusCarpan;
            nüfusText.text=nüfus.ToString("F2");
            break;
        case "vergi":
            vergiGeliri+=vergiGeliri;
            vergiText.text=vergiGeliri.ToString("3F");
            break ;
        case "tl":
            tlPuan+=tlCarpan+1000;
            tlPuanText.text=tlPuan.ToString("F2");
            break;
     }
     }
}
