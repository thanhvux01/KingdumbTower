using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Coin_Attract : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float timeDelay;
    //off set when the object contact with destination
    [SerializeField] float offset = 10;
    [SerializeField] float speed = 20;

    Transform coinPanel;
    Vector2 destination;
     RectTransform rectTransformCoins;

    void Start()
    {
        coinPanel = GameObject.FindGameObjectWithTag("CoinPanel").transform;
        rectTransformCoins = GetComponent<RectTransform>();

    }

    void Update()
    {

        if (coinPanel != null)
        {   // lay vi tri cua vat the so voi man hinh
           
         
            Vector3 direction = (coinPanel.position - transform.position).normalized;
            rectTransformCoins.position += speed * Time.deltaTime * direction;
            
       
            if (Vector3.Distance(transform.position, coinPanel.position) <= 0 + offset) 
            {
                Destroy(gameObject);
            }
        }
    }

}
