using UnityEngine;

public class FlashlightSwitch : MonoBehaviour
{
    [SerializeField] private GameObject flashlightObject;
    [SerializeField] private FlashlightCooldown cooldown;

    private bool isFlashlightOn;

    // Start is called before the first frame update
    void Start()
    {
        isFlashlightOn = false;
        flashlightObject.SetActive(false); // Ensure flashlight is initially off
        cooldown.Initialize();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (!isFlashlightOn && !cooldown.IsCoolingDown())
            {
                TurnOnFlashlight();
            }
            else if (isFlashlightOn)
            {
                TurnOffFlashlight();
            }
        }
    }

    private void TurnOnFlashlight()
    {
        isFlashlightOn = true;
        flashlightObject.SetActive(true);
    }

    private void TurnOffFlashlight()
    {
        isFlashlightOn = false;
        flashlightObject.SetActive(false);
    }
}
