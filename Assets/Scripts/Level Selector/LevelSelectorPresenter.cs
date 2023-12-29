using System.IO;
using Assets.Scripts.General;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

namespace Assets.Scripts.LevelSelector
{
    public class LevelSelectorPresenter : MonoBehaviour
    {
        [field: SerializeField]
        public int LevelCount { get; set; } = 2;

        private const int PageCount = 3;

        private PlayLevelButton[] playLevelButtons;

        private AssetBundle imageLevelsBundle;
        // Start is called before the first frame update
        private void Start()
        {
            VisualElement root = GetComponent<UIDocument>().rootVisualElement;
            root.Q<Button>("HomeButton").clicked += OnHomeClicked;


            imageLevelsBundle = AssetBundle.LoadFromFile(Path.Combine(Application.streamingAssetsPath, "images/levels"));

            // Construct level buttons
            playLevelButtons = new PlayLevelButton[PageCount];
            for (int i = 0; i < PageCount; i++)
            {
                playLevelButtons[i] = new PlayLevelButton(root.Q<TemplateContainer>($"PlayButton{i + 1}"), imageLevelsBundle);
            }

            // Initialize level buttons
            SetLevelPage(1);

            // todo Add functionality for navigation buttons
            root.Q<VisualElement>("PreviousPageButton").visible = false;
            root.Q<VisualElement>("NextPageButton").visible = false;
        }

        private void OnDestroy()
        {
            imageLevelsBundle.Unload(true);
        }

        private void OnHomeClicked()
        {
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
