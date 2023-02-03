using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// This class is responsible for
/// the main menu
/// </summary>
public class SceneLoader : MonoBehaviour
{
    [SerializeField] private GameObject mainMenuPanel, statisticsPanel, settingsPanel, aboutPanel, returnPanel;

	[SerializeField] private GameObject[] panels;

	private Dictionary<string, IEnumerable<Transform>> panelListDict = new Dictionary<string, IEnumerable<Transform>>();

	private TapAudio tapAudioScript;
    private StatsVars statsVars;
    private Settings settingsScript;

    private void Start()
    {
        tapAudioScript = GameObject.FindObjectOfType<TapAudio>();
        statsVars = FindObjectOfType<StatsVars>();
        settingsScript = FindObjectOfType<Settings>();


		this.initComponents();
		this.switchPanels(mainMenuPanel);
    }

    protected void PlayGame()
    {
        if (!PlayerPrefs.HasKey("MatchesPlayed")) //Check if the game has no saved data
        { 
            settingsScript.ResetProgress(); 
        }
        
        SceneManager.LoadScene(1);
        //tapAudioScript.PlayTap();
        //Time.timeScale = 1;
        //statsVars.MatchCount();
    }

	protected void initComponents()
	{
		
		foreach(GameObject _panel in panels)
		{
			panelListDict.Add(_panel.name, _panel.GetComponentsInChildren<Transform>().Skip(1));
		}
	}

	protected void switchPanels (GameObject _panel)
	{

		foreach(KeyValuePair<string, IEnumerable<Transform>> _panelItemDict in panelListDict)
		{
			if (_panelItemDict.Key == _panel.name)
			{
				this.switchPanelItems(_panelItemDict.Value, true);				
			}
			
			else 
			{
				foreach (Transform _panelItem in _panelItemDict.Value)
				{
					this.switchPanelItems(_panelItemDict.Value, false);
				}
			}
		}
	}

	protected void switchPanelItems(IEnumerable<Transform> _panelItemDictVal, bool _enable)
	{
		foreach (Transform _panelItem in _panelItemDictVal)
		{
			_panelItem.gameObject.SetActive(_enable);
		}
	}

	protected void enableRetButton()
	{
		this.switchPanelItems(panelListDict[returnPanel.name], true);
	}

	protected void switchFromMenu(GameObject _panel)
	{
		this.switchPanels(_panel);
		this.enableRetButton();
	}

	public void Statistics()
	{
		this.switchFromMenu(statisticsPanel);
	}

	public void Settings()
	{
		this.switchFromMenu(settingsPanel);
	}

	public void About()
	{
		this.switchFromMenu(aboutPanel);
	}

	public void ReturnToMenuActive()
	{
		this.switchPanels(mainMenuPanel);
	}
}
