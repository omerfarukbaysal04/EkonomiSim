using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Button gelistirmelerButon;
    public Button ekonomiButon;
    public Button menuButton;
    public GameObject gelistirmelerPanel;
    public GameObject ekonomiPanel;
    public GameObject menuPanel;

    private CanvasGroup gelistirmelerCanvasGroup;
    private CanvasGroup ekonomiCanvasGroup;
    private CanvasGroup menuCanvasGroup;

    void Start()
    {
        gelistirmelerButon.onClick.AddListener(OpenGelistirmelerPanel);
        ekonomiButon.onClick.AddListener(OpenEkonomiPanel);
        menuButton.onClick.AddListener(OpenMenuPanel);

        gelistirmelerPanel.SetActive(false);
        ekonomiPanel.SetActive(false);
        menuPanel.SetActive(false);

        gelistirmelerCanvasGroup = gelistirmelerPanel.GetComponent<CanvasGroup>();
        ekonomiCanvasGroup = ekonomiPanel.GetComponent<CanvasGroup>();
        menuCanvasGroup = menuPanel.GetComponent<CanvasGroup>();
    }

    void OpenGelistirmelerPanel()
    {
        gelistirmelerPanel.SetActive(true);
        gelistirmelerCanvasGroup.blocksRaycasts = true;
        gelistirmelerCanvasGroup.interactable = true;
        Time.timeScale = 1f;
    }

    public void CloseGelistirmelerPanel()
    {
        gelistirmelerPanel.SetActive(false);
        gelistirmelerCanvasGroup.blocksRaycasts = false;
        gelistirmelerCanvasGroup.interactable = false;
        Time.timeScale = 1f;
    }

    public void OpenEkonomiPanel()
    {
        ekonomiPanel.SetActive(true);
        ekonomiCanvasGroup.blocksRaycasts = true;
        ekonomiCanvasGroup.interactable = true;
        Time.timeScale = 1f;
    }

    public void CloseEkonomiPanel()
    {
        ekonomiPanel.SetActive(false);
        ekonomiCanvasGroup.blocksRaycasts = false;
        ekonomiCanvasGroup.interactable = false;
        Time.timeScale = 1f;
    }

    public void OpenMenuPanel()
    {
        menuPanel.SetActive(true);
        menuCanvasGroup.blocksRaycasts = true;
        menuCanvasGroup.interactable = true;
        Time.timeScale = 1f;
    }

    public void CloseMenuPanel()
    {
        menuPanel.SetActive(false);
        menuCanvasGroup.blocksRaycasts = false;
        menuCanvasGroup.interactable = false;
        Time.timeScale = 1f;
    }

    public void AnaMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void DevamEt()
    {
        menuPanel.SetActive(false);
        menuCanvasGroup.blocksRaycasts = false;
        menuCanvasGroup.interactable = false;
        Time.timeScale = 1f;
    }
}

