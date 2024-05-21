using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] ParticleSystem ability;
    [SerializeField] GameObject readyBorder;
    Energy energy;
    void Awake()
    {
       
        energy = FindObjectOfType<Energy>();
        if (MouseModeManager.instance != null)
        {
            Debug.LogWarning("Can't find mouse System");
        }
    }

    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {


            if (MouseModeManager.instance.MouseMode == MouseMode.Ability && energy.CurrentEnergy == energy.MaxEnergy)
            {
                if (MouseModeManager.instance.MouseState == MouseState.Ready)
                {
                    // Vector3 mousePosition = Input.mousePosition;
                    // mousePosition.z = 75f;
                    // Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);
                    // Instantiate(ability, new Vector3(worldPosition.x, 0.5f, worldPosition.z), Quaternion.identity);
                    // energy.DepletedEnergy();

                    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                    RaycastHit hit;

                    if (Physics.Raycast(ray, out hit))
                    {
                         Vector3 hitPosition = hit.point;
                        Instantiate(ability, new Vector3(hitPosition.x, 0.5f, hitPosition.z), Quaternion.identity);
                        energy.DepletedEnergy();
                    }
                }

            }
        }

        if (energy.CurrentEnergy == energy.MaxEnergy)
        {
            readyBorder.SetActive(true);
        }
        else
        {
            readyBorder.SetActive(false);
        }
    }

    public void SwitchToAbilityMode()
    {
        MouseModeManager.instance.MouseMode = MouseMode.Ability;
    }
}
