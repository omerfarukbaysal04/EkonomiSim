using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelController : MonoBehaviour
{
    public NüfusKontrol nüfusKontrol;
    public PuanKontrol puanKontrol;
    public Takvim takvim;
    private CanvasGroup canvasGroup;

    public void Start()
    {
        canvasGroup=GetComponent<CanvasGroup>();
    }

    public void Olay1SolButon()
    {
        if(nüfusKontrol.tlPuan>=100000)
        {
        nüfusKontrol.mutluluk+=25;
        nüfusKontrol.tlPuan-=100000;
        nüfusKontrol.UpdateText();
        PanelKapat();
        }
        else if (nüfusKontrol.tlPuan<100000)
        {
            Olay1SagButon();
        }
    }
    public void Olay1SagButon()
    {
        nüfusKontrol.mutluluk-=30;
        nüfusKontrol.nüfus-=100000;
        nüfusKontrol.UpdateText();
        PanelKapat();
    }
    public void Olay3SolButon()
    {
        if(nüfusKontrol.tlPuan>=50000)
        {
        nüfusKontrol.mutluluk+=20;
        nüfusKontrol.tlPuan-=50000;
        nüfusKontrol.UpdateText();
        PanelKapat();
        }
        else Olay3SagButon();
    }
    public void Olay3SagButon()
    {
        nüfusKontrol.mutluluk-=20;
        nüfusKontrol.UpdateText();
        PanelKapat();
    }

      public void Olay2SolButon()
    {
        if(nüfusKontrol.tlPuan>=70000)
        {
        nüfusKontrol.mutluluk+=20;
        nüfusKontrol.tlPuan-=70000;
        nüfusKontrol.UpdateText();
        PanelKapat();
        }
        else Olay2SagButon();
    }
    public void Olay2SagButon()
    {
        nüfusKontrol.mutluluk-=25;
        nüfusKontrol.UpdateText();
        PanelKapat();
    }

     public void Olay4SolButon()
    {
        if(nüfusKontrol.tlPuan>=35000)
        {
        nüfusKontrol.mutluluk+=15;
        nüfusKontrol.tlPuan-=35000;
        nüfusKontrol.UpdateText();
        PanelKapat();
        }
        else Olay4SagButon();
    }
    public void Olay4SagButon()
    {
        nüfusKontrol.mutluluk-=15;
        nüfusKontrol.UpdateText();
        PanelKapat();
    }

    public void Olay5SolButon()
    {
        nüfusKontrol.mutluluk+=15;
        nüfusKontrol.UpdateText();
        PanelKapat();
    }
    public void Olay5SagButon()
    {
        nüfusKontrol.mutluluk-=25;
        nüfusKontrol.nüfus+=100000;
        nüfusKontrol.UpdateText();
        PanelKapat();
    }

      public void Olay6SolButon()
    {
        if(nüfusKontrol.tlPuan>=45000)
        {
        nüfusKontrol.mutluluk+=15;
        nüfusKontrol.tlPuan-=45000;
        nüfusKontrol.UpdateText();
        PanelKapat();
        }
        else Olay6SagButon();
    }
    public void Olay6SagButon()
    {
        nüfusKontrol.mutluluk-=15;
        nüfusKontrol.UpdateText();
        PanelKapat();
    }
      public void Olay7SolButon()
    {
        if(nüfusKontrol.tlPuan>=40000)
        {
        nüfusKontrol.mutluluk+=15;
        nüfusKontrol.tlPuan-=40000;
        nüfusKontrol.UpdateText();
        PanelKapat();
        }
        else Olay7SagButon();
    }
    public void Olay7SagButon()
    {
        nüfusKontrol.mutluluk-=25;
        nüfusKontrol.UpdateText();
        PanelKapat();
    }

      public void Olay8SolButon()
    {
        nüfusKontrol.mutluluk-=15;
        nüfusKontrol.nüfus+=250000;
        nüfusKontrol.tlPuan+=150000;
        nüfusKontrol.UpdateText();
        PanelKapat();
    }
    public void Olay8SagButon()
    {
        nüfusKontrol.mutluluk+=15;
        puanKontrol.euroPuan+=1.5f;
        puanKontrol.dolarPuan+=1.5f;
        puanKontrol.UpdatePuanText();
        nüfusKontrol.UpdateText();
        PanelKapat();
    }

       public void Olay9SolButon()
    {   if(nüfusKontrol.tlPuan>=250000)
        {
        nüfusKontrol.mutluluk+=20;
        nüfusKontrol.tlPuan-=250000;
        nüfusKontrol.UpdateText();
        PanelKapat();
        }
        else Olay9SagButon();
    }
    public void Olay9SagButon()
    {
        nüfusKontrol.mutluluk-=15;
        nüfusKontrol.nüfus-=250000;
        nüfusKontrol.UpdateText();
        PanelKapat();
    }

      public void Olay10SolButon()
    {
        puanKontrol.euroPuan+=1.5f;
        puanKontrol.dolarPuan-=2.5f;
        puanKontrol.UpdatePuanText();
        nüfusKontrol.UpdateText();
        PanelKapat();
    }
    public void Olay10SagButon()
    {
        puanKontrol.euroPuan-=1.5f;
        puanKontrol.dolarPuan+=2.5f;
        puanKontrol.UpdatePuanText();
        nüfusKontrol.UpdateText();
        PanelKapat();
    }

      public void Olay11SolButon()
    {   if(nüfusKontrol.tlPuan>=25000)
        {
        nüfusKontrol.mutluluk+=15;
        nüfusKontrol.tlPuan-=25000;
        nüfusKontrol.UpdateText();
        PanelKapat();
        }
        else Olay11SagButon();
    }
    public void Olay11SagButon()
    {
        nüfusKontrol.mutluluk-=15;
        nüfusKontrol.UpdateText();
        PanelKapat();
    }
     public void Olay12SolButon()
    {
        puanKontrol.euroPuan-=2.5f;
        puanKontrol.dolarPuan+=1.5f;
        puanKontrol.UpdatePuanText();
        nüfusKontrol.UpdateText();
        PanelKapat();
    }
    public void Olay12SagButon()
    {
        puanKontrol.euroPuan+=2.5f;
        puanKontrol.dolarPuan-=1.5f;
        puanKontrol.UpdatePuanText();
        nüfusKontrol.UpdateText();
        PanelKapat();
    }

    void PanelKapat()
    {   
        gameObject.SetActive(false);
        canvasGroup.blocksRaycasts=false;
        Time.timeScale=1f;
        takvim.paneller[takvim.gosterilenPanelIndex].SetActive(false);
    }
    public void PanelAc()
    {
        gameObject.SetActive(true);
        Time.timeScale = 0f;
        canvasGroup.blocksRaycasts = true;
    }
}
