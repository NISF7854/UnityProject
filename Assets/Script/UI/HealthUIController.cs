using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using UnityEngine.UI;


public class HealthUIController : MonoBehaviour
{
    private Entity entity;
    public Slider slider;
    public EntityStatistic statistic;
    RectTransform rectTransform;


    public Image fillImage;
    public RectTransform fillArea;

    public GameObject healthFlashPrefab;

    [Header("Enemy Auto Hide")]
    [SerializeField] private float visibleDuration = 3f;

    private CanvasGroup canvasGroup;
    private bool isEnemyBar;
    private Coroutine hideRoutine;

    bool a = false;
    private void Start()
    {

        slider.maxValue = statistic.maxHealth.GetValue();
        slider.value = slider.maxValue;

        // 敌人血条默认隐藏，受伤后再显示
        if (isEnemyBar)
        {
            SetVisible(false);
        }
    }

    void Awake()
    {
        entity = GetComponentInParent<Entity>();
        slider = GetComponentInChildren<Slider>();
        statistic = GetComponentInParent<EntityStatistic>();
        rectTransform = GetComponent<RectTransform>();

        isEnemyBar = GetComponentInParent<Enemy>() != null;
        canvasGroup = GetComponent<CanvasGroup>();
        if (canvasGroup == null)
        {
            canvasGroup = gameObject.AddComponent<CanvasGroup>();
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void UpdateHealthBar(float _value)
    {
        if(_value > 0)//受到伤害
        {
            if (isEnemyBar)
            {
                ShowTemporarily();
            }

            slider.maxValue = statistic.maxHealth.GetValue();
            slider.value = statistic.currentHealth;
            BeHitFX(_value);
        }
        else //受到治疗
        {
            //TODO
        }
 
        

    }

    private void ShowTemporarily()
    {
        SetVisible(true);

        if (hideRoutine != null)
        {
            StopCoroutine(hideRoutine);
        }
        hideRoutine = StartCoroutine(HideAfterDelay());
    }

    private IEnumerator HideAfterDelay()
    {
        yield return new WaitForSeconds(visibleDuration);
        SetVisible(false);
        hideRoutine = null;
    }

    private void SetVisible(bool visible)
    {
        canvasGroup.alpha = visible ? 1f : 0f;
        canvasGroup.blocksRaycasts = visible;
        canvasGroup.interactable = visible;
    }
    public void DestroyThis()
    {
        if(gameObject != null )
        {
            Destroy(gameObject);
        }
        
    }

    public void BeHitFX(float _damege)
    {
        StartCoroutine(Shake(0.25f));
        float healthPrecent = (statistic.currentHealth / statistic.maxHealth.GetValue());
        float losePrecent = _damege / statistic.maxHealth.GetValue();

        GameObject newFlash = Instantiate(healthFlashPrefab, new Vector3(0, 0, 0), Quaternion.identity, slider.GetComponent<RectTransform>());

        newFlash.GetComponent<RectTransform>().SetSiblingIndex(slider.GetComponent<RectTransform>().childCount - 1);
        newFlash.GetComponent<UI_HealthFlash>().SetUp(healthPrecent, losePrecent);

    }


    IEnumerator Shake(float _value)
    {
        Vector3 oriScale = rectTransform.localScale;

        float shakePower = Random.Range(5f, 10f);

        rectTransform.rotation = Quaternion.Euler(0, 0, shakePower);

        rectTransform.localScale = new Vector3(oriScale.x * 1.3f, oriScale.y * 1.3f, oriScale.z);

        yield return new WaitForSeconds(0.05f);
        rectTransform.localScale = oriScale;

   
        yield return new WaitForSeconds(0.03f);
        rectTransform.rotation = Quaternion.Euler(0, 0, shakePower * 0.7f);

        yield return new WaitForSeconds(0.04f);

        rectTransform.rotation = Quaternion.Euler(0, 0, 0);
    }
    IEnumerator Flash(float _damege)
    {
        //flashImage.rectTransform.anchoredPosition = new Vector3(statistic.currentHealth / statistic.maxHealth.GetValue() * 310f, flashImage.rectTransform.position.y, 0);
       // flashImage.rectTransform.sizeDelta = new Vector3(_damege / statistic.maxHealth.GetValue() * 310f, 44f, 0);
        a = true;

        yield return new WaitForSeconds(1f);

        a = false;
    }
}
