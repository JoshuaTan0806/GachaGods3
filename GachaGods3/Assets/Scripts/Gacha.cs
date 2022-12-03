using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gacha : MonoBehaviour
{
    [SerializeField] List<GachaCard> cards;
    [SerializeField] Button confirmButton;
    List<GachaCard> selectedCards = new();

    private void Awake()
    {
        confirmButton.onClick.AddListener(() => ConfirmCards());
        confirmButton.interactable = false;

        RandomiseCharacters();
    }

    private void OnEnable()
    {
        foreach (var card in cards)
        {
            card.OnCardClicked += OnCardClicked;
        }
    }

    private void OnDisable()
    {
        foreach (var card in cards)
        {
            card.OnCardClicked -= OnCardClicked;
        }
    }

    void OnCardClicked(GachaCard card)
    {
        if (!selectedCards.Contains(card))
            SelectCard(card);
        else
            DeselectCard(card);

        bool canClickConfirm = selectedCards.Count == 3;
        confirmButton.interactable = canClickConfirm;

        if (canClickConfirm)
            DOTween.Sequence().Append(confirmButton.transform.DOScale(new Vector2(1.05f, 1.05f), 0.3f));
        else
            DOTween.Sequence().Append(confirmButton.transform.DOScale(new Vector2(1f, 1f), 0.3f));
    }


    void SelectCard(GachaCard card)
    {
        if (selectedCards.Count == 3)
            return;

        selectedCards.Add(card);
        DOTween.Sequence().Append(card.transform.DOScale(new Vector2(1.05f, 1.05f), 0.3f));
    }

    void DeselectCard(GachaCard card)
    {
        selectedCards.Remove(card);
        DOTween.Sequence().Append(card.transform.DOScale(new Vector2(1f, 1f), 0.3f));
    }

    public void RandomiseCharacters()
    {
        List<Character> pulls = CharacterManager.TenPull();

        for (int i = 0; i < pulls.Count; i++)
        {
            cards[i].Initialise(pulls[i]);
        }
    }

    void ConfirmCards()
    {
        foreach (var card in selectedCards)
        {
            Debug.Log(card.Character);
            CharacterManager.AddCharacter(card.Character);
        }

        selectedCards.Clear();
    }
}
