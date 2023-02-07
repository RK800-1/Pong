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
    [SerializeField] private GameObject mainMenuPanel, statisticsPanel, settingsPanel, aboutPanel, returnPanel, gameScene, pausePanel;

	[SerializeField] private GameObject[] panels;

	private Dictionary<string, IEnumerable<Transform>> panelListDict = new Dictionary<string, IEnumerable<Transform>>();

    private StatsVars statsVars;
    private Settings settingsScript;

    private void Start()
    {
        statsVars = FindObjectOfType<StatsVars>();
        settingsScript = FindObjectOfType<Settings>();


		this.initComponents();
		this.switchPanels(mainMenuPanel);

		if (!PlayerPrefs.HasKey(SaveDataNames.SettingsAreChanged())) //Check if the game has no saved data
		{
			settingsScript.ResetProgress();
		}
	}

	/// <summary>
	/// This method creates a dictionary to manage panels in future
	/// </summary>
	protected void initComponents()
	{
		
		foreach(GameObject _panel in panels)
		{
			panelListDict.Add(_panel.name, _panel.GetComponentsInChildren<Transform>().Skip(1));
		}
	}

	/// <summary>
	/// We parse a dictionary and enable/disable useful/useless panels
	/// I found no more solution to switch between panels
	/// </summary>
	/// <param name="_panel">
	/// The panel we want to switch to
	/// </param>
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

	protected void switchFromMenu(GameObject _panel)
	{
		this.switchPanels(_panel);
		this.enableRetButton();
	}

	public void Play()
	{
		this.switchPanels(gameScene);
		StatsVars.MatchCount();
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
	protected void enableRetButton()
	{
		this.switchPanelItems(panelListDict[returnPanel.name], true);
	}

	public void pauseButton()
	{
		this.switchPanelItems(panelListDict[pausePanel.name], true);
		Time.timeScale = 0;
	}

	public void resume()
	{
		this.switchPanelItems(panelListDict[pausePanel.name], false);
	}
}
