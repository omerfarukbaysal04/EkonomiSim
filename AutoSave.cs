using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoSave : MonoBehaviour
{
    public PuanKontrol puanKontrol;
    public NüfusKontrol nüfusKontrol;
    public Takvim takvim;
    private SaveLoadManager saveLoadManager;

    void Start()
    {
        saveLoadManager = GetComponent<SaveLoadManager>();

        if (saveLoadManager == null)
        {
            Debug.LogError("SaveLoadManager bileşeni bulunamadı!");
            return;
        }

        if (puanKontrol == null || nüfusKontrol == null || takvim == null)
        {
            Debug.LogError("PuanKontrol, NüfusKontrol veya Takvim bileşeni atanmamış!");
            return;
        }

        StartCoroutine(AutoSaveRoutine());
        LoadGame();
    }


    IEnumerator AutoSaveRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(30f);
            SaveGame();
        }
    }

    void SaveGame()
    {
        if (puanKontrol == null || nüfusKontrol == null || takvim == null)
        {
            Debug.LogError("PuanKontrol, NüfusKontrol veya Takvim bileşeni atanmamış!");
            return;
        }

        GameData data = new GameData();
        data.dolarPuan = puanKontrol.dolarPuan;
        data.euroPuan = puanKontrol.euroPuan;
        data.altinPuan = puanKontrol.altinPuan;
        data.tlPuan = nüfusKontrol.tlPuan;
        data.mutluluk = nüfusKontrol.mutluluk;
        data.hafta = takvim.hafta;
        data.ay = takvim.ay;
        data.yil = takvim.yil;
        data.eskiDolar=puanKontrol.eskiDolar;
        data.eskiEuro=puanKontrol.eskiEuro;
        data.eskiAltin=puanKontrol.eskiAltin;
        data.euroDegisim=puanKontrol.euroDegisim;
        data.altinDegisim=puanKontrol.altinDegisim;
        data.dolarDegisim=puanKontrol.dolarDegisim;
        data.vergiOran=nüfusKontrol.vergiOran;
        data.vergiGeliri=nüfusKontrol.vergiGeliri;
        data.güvenlikLevel=nüfusKontrol.güvenlikLevel;
        data.güvenlikMaliyet=nüfusKontrol.güvenlikMaliyet;
        data.saglikLevel=nüfusKontrol.saglikLevel;
        data.saglikMaliyet=nüfusKontrol.saglikMaliyet;
        data.egitimLevel=nüfusKontrol.egitimLevel;
        data.egitimMaliyet=nüfusKontrol.egitimMaliyet;
        data.dinLevel=nüfusKontrol.dinLevel;
        data.dinMaliyet=nüfusKontrol.dinMaliyet;
        data.tarimLevel=nüfusKontrol.tarimLevel;
        data.tarimMaliyet=nüfusKontrol.tarimMaliyet;
        data.teknolojiLevel=nüfusKontrol.teknolojiLevel;
        data.teknolojiMaliyet=nüfusKontrol.teknolojiMaliyet;
        data.genelLevel=nüfusKontrol.genelLevel;
        data.genelMaliyet=nüfusKontrol.genelMaliyet;
        data.genelGelistirmeSayisi=nüfusKontrol.genelGelistirmeSayisi;
        data.gelistirmeAylikGider=nüfusKontrol.gelistirmeAylikGider;
        data.egitimGelir=nüfusKontrol.egitimGelir;
        data.tarimGelir=nüfusKontrol.tarimGelir;
        data.teknolojiGelir=nüfusKontrol.teknolojiGelir;
        data.güvenlikGider=nüfusKontrol.güvenlikGider;
        data.saglikGider=nüfusKontrol.saglikGider;
        data.dinGider=nüfusKontrol.dinGider;
        data.egitimGider=nüfusKontrol.egitimGider;
        data.tarimGider=nüfusKontrol.tarimGider;
        data.teknolojiGider=nüfusKontrol.teknolojiGider;
        data.gerekliGelistirme=nüfusKontrol.gerekliGelistirme;
        data.digerGelirler=nüfusKontrol.digerGelirler;
        data.giderler=nüfusKontrol.giderler;

        saveLoadManager.SaveGame(data);
        Debug.Log("Oyun kaydedildi.");
    }

    void LoadGame()
    {
        if (puanKontrol == null || nüfusKontrol == null || takvim == null)
        {
            Debug.LogError("PuanKontrol, NüfusKontrol veya Takvim bileşeni atanmamış!");
            return;
        }

        GameData data = saveLoadManager.LoadGame();

        if (data != null)
        {
            puanKontrol.dolarPuan = data.dolarPuan;
            puanKontrol.euroPuan = data.euroPuan;
            puanKontrol.altinPuan = data.altinPuan;
            nüfusKontrol.tlPuan = data.tlPuan;
            nüfusKontrol.mutluluk = data.mutluluk;
            takvim.hafta = data.hafta;
            takvim.ay = data.ay;
            takvim.yil = data.yil;
            puanKontrol.eskiDolar = data.eskiDolar;
            puanKontrol.eskiEuro = data.eskiEuro;
            puanKontrol.eskiAltin = data.eskiAltin;
            puanKontrol.euroDegisim = data.euroDegisim;
            puanKontrol.altinDegisim = data.altinDegisim;
            puanKontrol.dolarDegisim = data.dolarDegisim;
            nüfusKontrol.vergiOran = data.vergiOran;
            nüfusKontrol.vergiGeliri = data.vergiGeliri;
            nüfusKontrol.güvenlikLevel = data.güvenlikLevel;
            nüfusKontrol.güvenlikMaliyet = data.güvenlikMaliyet;
            nüfusKontrol.saglikLevel = data.saglikLevel;
            nüfusKontrol.saglikMaliyet = data.saglikMaliyet;
            nüfusKontrol.egitimLevel = data.egitimLevel;
            nüfusKontrol.egitimMaliyet = data.egitimMaliyet;
            nüfusKontrol.dinLevel = data.dinLevel;
            nüfusKontrol.dinMaliyet = data.dinMaliyet;
            nüfusKontrol.tarimLevel = data.tarimLevel;
            nüfusKontrol.tarimMaliyet = data.tarimMaliyet;
            nüfusKontrol.teknolojiLevel = data.teknolojiLevel;
            nüfusKontrol.teknolojiMaliyet = data.teknolojiMaliyet;
            nüfusKontrol.genelLevel = data.genelLevel;
            nüfusKontrol.genelMaliyet = data.genelMaliyet;
            nüfusKontrol.genelGelistirmeSayisi = data.genelGelistirmeSayisi;
            nüfusKontrol.gelistirmeAylikGider = data.gelistirmeAylikGider;
            nüfusKontrol.egitimGelir = data.egitimGelir;
            nüfusKontrol.tarimGelir = data.tarimGelir;
            nüfusKontrol.teknolojiGelir = data.teknolojiGelir;
            nüfusKontrol.güvenlikGider = data.güvenlikGider;
            nüfusKontrol.saglikGider = data.saglikGider;
            nüfusKontrol.dinGider = data.dinGider;
            nüfusKontrol.egitimGider = data.egitimGider;
            nüfusKontrol.tarimGider = data.tarimGider;
            nüfusKontrol.teknolojiGider = data.teknolojiGider;
            nüfusKontrol.gerekliGelistirme = data.gerekliGelistirme;
            nüfusKontrol.digerGelirler = data.digerGelirler;
            nüfusKontrol.giderler = data.giderler;

            puanKontrol.UpdatePuanText();
            Debug.Log("Oyun yüklendi.");
        }
        else
        {
            Debug.LogError("Oyun yüklenemedi. Veriler null olabilir.");
        }
    }
}

