using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] int goldReward = 25;
    [SerializeField] int goldPenalty = 25;
    [SerializeField] int livePentalty = 1;
    [SerializeField] Vector2 minMaxEnergy;
    [SerializeField] Transform coinPlaceHolder;
    [SerializeField] GameObject coins;
    [SerializeField] GameObject soulEmit;
    [SerializeField] GameObject ParticleUI;
    Energy energy;
    Camera cameraUI;
    ObjectPool objectPool;
    Canvas canvas;
    Eco eco;
    Currency currency;
    Live live;

    private void Awake()
    {
        currency = FindObjectOfType<Currency>();
        if (currency != null)
        {
            live = currency.GetComponent<Live>();
            energy = currency.GetComponent<Energy>();
            eco = currency.GetComponent<Eco>();
        }
        else
        {
            Debug.LogWarning("Your currency system not found");
        }
        coinPlaceHolder = GameObject.FindGameObjectWithTag("CoinPlaceHolder").transform;
        cameraUI = GameObject.FindGameObjectWithTag("CameraUI").GetComponent<Camera>();



    }
    public void RewardGold()
    {   
        GiveEnergy();
        if (eco == null)
        {
            Debug.Log("Can't find Eco ");
            return;
        }
        eco.Deposit(goldReward);

    }
    public void GoldPenalty()
    {
        if (eco == null)
        {
            Debug.Log("Can't find Eco class");
            return;
        }
        eco.Withdraw(goldPenalty);
    }

    public void GiveEnergy()
    {
        if (energy != null)
        {  
            energy.CreateSoulEmitter(transform.position);
        }
    }

    public void LivePentalty()
    {
        if (live == null)
        {
            Debug.Log("Can't find live class ");
            return;
        }
        live.LoseLive(livePentalty);
    }

    public void ReachedEnd()
    {
        GoldPenalty();
        LivePentalty();
        gameObject.SetActive(false);
        objectPool = FindAnyObjectByType<ObjectPool>();
        objectPool.GetKilled();
    }

    // void CreateCoins()
    // {
    //     Camera mainCamera = Camera.main;
    //     GameObject coins_ = Instantiate(coins);
    //     coins_.transform.SetParent(coinPlaceHolder, false);
    //     canvas = coins_.GetComponentInParent<Canvas>();
    //     // RectTransform CanvasRect = canvas.GetComponent<RectTransform>();
    //     // Vector3 ViewportPosition = mainCamera.WorldToViewportPoint(transform.position);
    //     Vector3 screenPosition = mainCamera.WorldToScreenPoint(transform.position);
    //     // Vector2 WorldObject_ScreenPosition = new Vector2(
    //     //  (ViewportPosition.x * CanvasRect.sizeDelta.x) - (CanvasRect.sizeDelta.x * 0.5f),
    //     // (ViewportPosition.y * CanvasRect.sizeDelta.y) - (CanvasRect.sizeDelta.y * 0.5f));

    //     RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas.transform as RectTransform, screenPosition, cameraUI, out Vector2 localPoint);
    //     coins_.transform.localPosition = localPoint;
    // }


}
