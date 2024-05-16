using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class AbilityButton : MonoBehaviour
{
    // Start is called before the first frame update
    AbilityManager abilityManager;

    Image image;
    [SerializeField] Color hoverColor;
    [SerializeField] Image frame;
    Color frameColor;
    Color backgroundColor;

    private void Awake()
    {
        abilityManager = FindObjectOfType<AbilityManager>();
        image = GetComponent<Image>();
        backgroundColor = image.color;
        frameColor = frame.color;

    }

    // Update is called once per frame
    public void OnClick()
    {
        abilityManager.SwitchToAbilityMode();
    }

    public void Hover()
    {
        image.color = hoverColor;
        frame.color = new Color(frameColor.r, frameColor.g, frameColor.b, 255);
    }

    public void ExitHover()
    {
        image.color = backgroundColor;
        frame.color = frameColor;
    }
}
