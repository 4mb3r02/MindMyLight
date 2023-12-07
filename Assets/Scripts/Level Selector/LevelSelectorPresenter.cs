using Assets.Scripts.General;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.UIElements;

namespace Assets.Scripts.LevelSelector
{
    public class LevelSelectorPresenter : MonoBehaviour
    {
        [Header("----------- General ---------")]
        public int LevelCount = 2;

        [Header("----------- Audio -----------")]
        public AudioClip PlayLevelButtonSoundEffect;
        public AudioClip HomeButtonSoundEffect;


        private const int PageCount = 3;

        private PlayLevelButton[] playLevelButtons;


        // Start is called before the first frame update
        private void Start()
        {
            VisualElement root = GetComponent<UIDocument>().rootVisualElement;
            root.Q<Button>("HomeButton").clicked += OnHomeClicked;

            // Construct level buttons
            playLevelButtons = new PlayLevelButton[PageCount];
            for (int i = 0; i < PageCount; i++)
            {
                playLevelButtons[i] = new PlayLevelButton(root.Q<TemplateContainer>($"PlayButton{i + 1}"))
                {
                    PlayLevelSoundEffect = PlayLevelButtonSoundEffect
                };
            }
            
            // Initialize level buttons
            SetLevelPage(1);

            // todo Add functionality for navigation buttons
            root.Q<VisualElement>("PreviousPageButton").visible = false;
            root.Q<VisualElement>("NextPageButton").visible = false;
        }

        public void OnHomeClicked()
        {
            AudioManager.instance.playSFX(HomeButtonSoundEffect);
            SceneLoader.LoadMainMenu();
        }

        private void SetLevelPage(int page)
        {
            int x = (page - 1) * PageCount;
            for (int i = 0; i < PageCount; i++)
            {
                //todo
                int currentLevel = ++x;
                bool visible = currentLevel <= LevelCount;

                playLevelButtons[i].SetLevel(currentLevel, visible);
            }
        }

        // Update is called once per frame
        private void Update()
        {

        }
    }
}
