using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UI;

public class RewardPopupController : MonoBehaviour
{
    private Image background;
    [SerializeField]
    private RectTransform popup;
    [SerializeField]
    private GameObject rewardPlaceHolder;
    [SerializeField]
    private TimelineController timelineController;

    private Color backgroundColorCache;
    private Vector3 popupScaleCache;

    void Awake()
    {
        background = GetComponent<Image>();
        backgroundColorCache = background.color;
        popupScaleCache = popup.localScale;
    }

    void OnEnable()
    {
        background.DOFade(0, 1f).From();
        popup.DOScale(new Vector3(.01f, .01f, 1), 1.5f)
            .From()
            .SetEase(Ease.OutBack);

        rewardPlaceHolder.SetActive(true);
        timelineController.Play(0, DirectorWrapMode.Loop);
        rewardPlaceHolder.transform.DOScale(new Vector3(.01f, .01f, 1), 1.5f).From();
    }

    public void ClaimReward()
    {
        timelineController.Play(1, DirectorWrapMode.Hold);
    }

    public void FadePopup()
    {
        popup.DOScale(new Vector3(.01f, .01f, 1), 1f);
        background.DOFade(0, 1f)
            .OnComplete(() => gameObject.SetActive(false));
    }

    void OnDisable()
    {
        background.color = backgroundColorCache;
        popup.localScale = popupScaleCache;
    }

}
