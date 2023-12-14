using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.General;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

namespace Assets.Scripts.LevelSelector
{

    public class PlayLevelButton
    {
        private readonly Button _playLevelButton;
        private const string ImagePath = "Assets/Images/Level Selector";

        public TemplateContainer Reference { get; }
        public bool Visible { get; private set; }
        public int Level { get; private set; }

        public PlayLevelButton(TemplateContainer reference)
        {
            this.Reference = reference;

            _playLevelButton = reference.Q<Button>();
            _playLevelButton.clicked += OnPlayClicked;
        }

        public PlayLevelButton(TemplateContainer reference, int level, bool visible = true) : this(reference)
        {
            this.Level = level;
            this.Visible = visible;
        }

        public void SetLevel(int level, bool visible = true)
        {
            this.Level = level;
            this.Visible = visible;

            Initialize();
        }

        public void Initialize()
        {
            Reference.Q<Label>("PlayButtonLabel").text = $"Chapter {Level}";

            Reference.Q<VisualElement>("PlayButtonImage").style.backgroundImage =
                new StyleBackground(AssetDatabase.LoadAssetAtPath<Sprite>($"{ImagePath}/Levels/Level_{Level}.jpg"));
            SetVisibility(this.Visible);
        }

        public void SetVisibility(bool visible)
        {
            Reference.Q<VisualElement>("PlayButtonImage").style.display = visible ? DisplayStyle.Flex : DisplayStyle.None;
            Reference.Q<VisualElement>("PlayButtonHiddenImage").style.display = !visible ? DisplayStyle.Flex : DisplayStyle.None;
        }

        private void OnPlayClicked()
        {
            if (Visible)
                SceneLoader.LoadLevel(Level);
        }
    }

}