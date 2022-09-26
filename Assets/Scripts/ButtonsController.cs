using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonsController : CharacterFactory
{
    private Button _generateBtn;
    private Button _playBtn;
    private Button _backBtn;
    
    public void Begin()
    {
        finderTextures = new FinderTextures();
        Debug.Log("Begin");
        
        SceneManager.activeSceneChanged += FindBtn;
        var currentScene = SceneManager.GetActiveScene();
        finderTextures.CreateImages();
    }
    private void FindBtn(Scene current, Scene next)
    {
        _generateBtn = GameObject.FindGameObjectWithTag("generateBtn")?.GetComponent<Button>();
        _playBtn = GameObject.FindGameObjectWithTag("playBtn")?.GetComponent<Button>();
        _backBtn = GameObject.FindGameObjectWithTag("backBtn")?.GetComponent<Button>();
        SetBtn();
    }
    private void SetBtn()
    {
        _generateBtn?.onClick.AddListener(LoadCharacters);
        _generateBtn?.onClick.AddListener(ShowCharacter);
        _generateBtn?.onClick.AddListener(delegate{finderTextures.HighliahtChar(randIntChar);});
        _playBtn?.onClick.AddListener(ShowCharacter);
        _playBtn?.onClick.AddListener(LoadScene);
        _backBtn?.onClick.AddListener(LoadScene);
    }
    private void LoadScene()
    {
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            SceneManager.LoadScene(1);
        }
        else
        {
            SceneManager.activeSceneChanged -= FindBtn;
            SceneManager.LoadScene(0);
        }
    }

}
