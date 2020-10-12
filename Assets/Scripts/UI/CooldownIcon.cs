using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CooldownIcon : MonoBehaviour
{
    public enum CooldownType { Blunderbuss, HarpoonGun, HandCannon }

    [SerializeField] Slider cooldownSlider;
    [SerializeField] CooldownType weaponType;

    private static CooldownIcon m_blunderbussInstance;
    public static CooldownIcon Blunderbuss
    {
        get
        {
            if(m_blunderbussInstance == null)
            {
                Debug.LogError(typeof(CooldownIcon).ToString() + " blunderbuss instance is null!");
            }
            return m_blunderbussInstance;
        }
    }

    private static CooldownIcon m_harpoongunInstance;
    public static CooldownIcon HarpoonGun
    {
        get
        {
            if(m_harpoongunInstance == null)
            {
                Debug.LogError(typeof(CooldownIcon).ToString() + " harpoon gun instance is null!");
            }
            return m_harpoongunInstance;
        }
    }

    private static CooldownIcon m_handcannonInstance;
    public static CooldownIcon HandCannon
    {
        get
        {
            if(m_handcannonInstance == null)
            {
                Debug.LogError(typeof(CooldownIcon).ToString() + " hand cannon instance is null!");
            }
            return m_handcannonInstance;
        }
    }

    protected virtual void Awake()
    {
        //if(m_instance != null)
        //{
        //    Debug.LogError("Already have a singleton of type " + typeof(T).ToString() + ", destroying this one");
        //    Destroy(gameObject);
        //}

        //m_instance = this as T;

        switch(weaponType)
        {
            case CooldownType.Blunderbuss:
                m_blunderbussInstance = this;
                break;
            case CooldownType.HarpoonGun:
                m_harpoongunInstance = this;
                break;
            case CooldownType.HandCannon:
                m_handcannonInstance = this;
                break;
        }
    }

    public void UpdateSliderValue(float val)
    {
        cooldownSlider.value = val;
    }
}
