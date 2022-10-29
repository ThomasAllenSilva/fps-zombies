using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthUIBarController : MonoBehaviour
{
    private Image healthBar;

    [SerializeField] private PlayerHealthManager _playerHealthManager;

    private void Awake()
    {
        healthBar = GetComponent<Image>();
        _playerHealthManager.OnTakeDamage += ChangeHealthBarValue;
    }

    private void ChangeHealthBarValue()
    {
        StartCoroutine(FillHealthBarValueTowardsNewValue( (float) _playerHealthManager.CurrentHealth / _playerHealthManager.MaxHealth));
    }

    public IEnumerator FillHealthBarValueTowardsNewValue(float newValue)
    {
        while (healthBar.fillAmount != newValue)
        {
            healthBar.fillAmount = Mathf.MoveTowards(healthBar.fillAmount, newValue, Time.deltaTime);

            yield return null;
        }
    }
}
