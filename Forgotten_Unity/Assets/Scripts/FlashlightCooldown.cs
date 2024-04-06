using UnityEngine;

public class FlashlightCooldown : MonoBehaviour
{
    [SerializeField] private float onTime;
    [SerializeField] private float cooldownTime;
    private float currentOnTime;
    private float nextOnTime;
    private bool isCountingDown;
    private bool isOnCooldown;

    public bool IsFlashlightOn { get; private set; }

    public void Initialize()
    {
        currentOnTime = onTime;
        nextOnTime = Time.time + onTime;
        isCountingDown = true;
        IsFlashlightOn = true;
    }

    private void Update()
    {
        if (isCountingDown && IsFlashlightOn)
        {
            currentOnTime = nextOnTime - Time.time;
            if (currentOnTime <= 0)
            {
                currentOnTime = 0;
                ToggleFlashlight();
            }
        }
    }

    public void ToggleFlashlight()
    {
        IsFlashlightOn = !IsFlashlightOn;
        if (!IsFlashlightOn)
        {
            isCountingDown = false;
            StartCooldown();
        }
    }

    private void StartCooldown()
    {
        isOnCooldown = true;
        StartCoroutine(CooldownRoutine());
    }

    private System.Collections.IEnumerator CooldownRoutine()
    {
        yield return new WaitForSeconds(cooldownTime);
        ResetFlashlight();
    }

    private void ResetFlashlight()
    {
        currentOnTime = onTime;
        nextOnTime = Time.time + onTime;
        isCountingDown = true;
        isOnCooldown = false;
    }

    public bool IsCoolingDown()
    {
        return isOnCooldown;
    }
}
