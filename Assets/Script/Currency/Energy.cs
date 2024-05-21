using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Coffee.UIExtensions;

public class Energy : MonoBehaviour
{
    [SerializeField] int maxEnergy = 10;
    [SerializeField] int currentEnergy;
    [SerializeField] ParticleSystem soulEmit;
    [SerializeField] GameObject UIParticle;
    [SerializeField] Canvas canvas;
    [SerializeField] Camera cameraUI;
    [SerializeField] TextMeshProUGUI textMesh;
    [SerializeField] Image energyBar;

    public int CurrentEnergy { get { return currentEnergy; } }

    public int MaxEnergy { get { return maxEnergy; } }
    void Start()
    {
        currentEnergy = 0;
        if (textMesh != null)
        {
            textMesh.text = currentEnergy + "/" + maxEnergy;
        }
        if (energyBar != null)
        {
            energyBar.fillAmount = currentEnergy / maxEnergy;
        }
    }

    public void GainEnergy()
    {
        if (currentEnergy < maxEnergy)
        {
            currentEnergy++;
            if (textMesh != null)
            {
                textMesh.text = currentEnergy + "/" + maxEnergy;
            }
            if (energyBar != null)
            {

                energyBar.fillAmount = (float)currentEnergy / maxEnergy;
            }
        }
    }

    public void DepletedEnergy()
    {
        currentEnergy = 0;
        if (textMesh != null)
        {
            textMesh.text = currentEnergy + "/" + maxEnergy;
        }
        if (energyBar != null)
        {
            energyBar.fillAmount = (float)currentEnergy / maxEnergy;
        }
    }
    public void CreateSoulEmitter(Vector3 positionOnScreen)
    {

        Camera mainCamera = Camera.main;
        // GameObject soul = Instantiate(soulEmit);
        // soul.transform.SetParent(particlePlaceHolder.transform,false);
        Vector3 screenPosition = mainCamera.WorldToScreenPoint(positionOnScreen);
        RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas.transform as RectTransform, screenPosition, cameraUI, out Vector2 localPoint);
        UIParticle.transform.localPosition = localPoint;
        soulEmit.Play();

    }

}
