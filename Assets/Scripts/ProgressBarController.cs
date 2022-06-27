using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class ProgressBarController : MonoBehaviour
{
    private Slider slider;
    [SerializeField]
    private TextMeshProUGUI numericRepresentation;
    [SerializeField]
    private RectTransform rewardPreview;
    public AnimationCurve easeCurve;
    [SerializeField]
    private RewardPopupController rewardPopup;

    private bool isPlayingTween = false;

    void Awake()
    {
        slider = GetComponent<Slider>();
        slider.onValueChanged.AddListener(UpdateProgressText);
        slider.onValueChanged.Invoke(slider.value);
    }

    private void UpdateProgressText(float sliderValue)
    {
        numericRepresentation.text = $"{sliderValue} / {slider.maxValue}";
        if (sliderValue == slider.maxValue)
            ShowClaimRewardPopup();
    }

    private void ShowClaimRewardPopup()
    {
        if (!isPlayingTween)
        {
            isPlayingTween = true;
            rewardPreview.DOBlendableScaleBy(new Vector3(.2f, .2f, 0), 1)
            .SetEase(easeCurve)
            .OnComplete(() => {
                rewardPopup.gameObject.SetActive(true);
                EmptyBar();
                isPlayingTween = false;
            });
        }
    }

    public void EmptyBar()
    {
        slider.value = slider.minValue;
    }
    public void FillBar()
    {
        DOTween.To(() => slider.value, value => slider.value = value, slider.maxValue, 2);
    }
    public void RandomIncrementBar()
    {
        float incrementedValue = slider.value + Random.Range((float)0.1 * slider.maxValue, slider.maxValue);
        DOTween.To(() => slider.value, value => slider.value = value, incrementedValue, 2);
    }
}
