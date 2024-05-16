using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] ParticleSystem ability;
    MouseModeManager mouseModeManager;
    void Awake()
    {
        mouseModeManager = FindObjectOfType<MouseModeManager>();
        if (mouseModeManager != null)
        {
            Debug.LogWarning("Can't find mouse System");
        }
    }

    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            // Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            // if (Physics.Raycast(ray, out RaycastHit hit))
            // {
            //     if (mouseModeManager.MouseMode == MouseMode.Ability)
            //     {
            //         if (hit.transform.position.y < 0)
            //         {
            //             Instantiate(ability, new Vector3(hit.transform.position.x, 1, hit.transform.position.z), Quaternion.identity);
            //         }
            //         else
            //         {
            //             Instantiate(ability, hit.transform.position, Quaternion.identity);
            //         }
            //     }
            // }
            if (mouseModeManager.MouseMode == MouseMode.Ability)
            {
                Vector3 mousePosition = Input.mousePosition;
                mousePosition.z = 75f;
                Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);

                Instantiate(ability, new Vector3(worldPosition.x, 0.5f, worldPosition.z), Quaternion.identity);
            }
        }
    }

    public void SwitchToAbilityMode()
    {
        mouseModeManager.MouseMode = MouseMode.Ability;
    }
}
