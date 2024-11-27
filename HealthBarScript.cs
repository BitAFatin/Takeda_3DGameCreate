using System.Net.NetworkInformation;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// ����HP�o�[�̎�����ɁuDamageable�v�X�N���v�g���A�T�C�����A
/// Inspector�ł���HP�o�[�̎������Damageable�́uHealthBar�v�̔���
/// ���̃X�N���v�g��n��
/// HUD�ɓK��
/// </summary>
public class HealthBarScript : MonoBehaviour
{
    [SerializeField]
    Player_Status_Controller plasta;

    [SerializeField]
    Slider slider;

    [SerializeField]
    TextMeshProUGUI hpText;

    [SerializeField]
    TextMeshProUGUI lveText;

    [SerializeField]
    Gradient gradient;

    [SerializeField]
    Image fill;

    /// <summary>
    /// �X���C�_�[�̒l�������̒l�ɕύX���郁�\�b�h
    /// </summary>
    /// <param name="health"></param>
    public void SetHealth(int health) { 
    
        slider.value = health;

        hpText.text = "<u>HP:" + plasta.PlayerHP + "/" + plasta.LivePlayerHP;

        lveText.text = "<u><scale=0.8>Lv."+ "</scale>" + plasta.PlayerLevel;

        hpText.color = gradient.Evaluate(slider.normalizedValue);

        lveText.color = gradient.Evaluate(slider.normalizedValue);

        fill.color = gradient.Evaluate(slider.normalizedValue);

    }
    /// <summary>
    /// �X���C�_�[�̍ő�l�ƌ��݂̒l���ő�HP�ɐݒ肷�郁�\�b�h
    /// </summary>
    /// <param name="maxHealth"></param>
    public void SetMaxHealth(int maxHealth) { 
    
        slider.maxValue = maxHealth;
        slider.value = maxHealth;

        hpText.color = gradient.Evaluate(1f);

        fill.color = gradient.Evaluate(1f);
    }

    public void HealthDeath()
    { 
    fill.enabled = false;
    }
}
