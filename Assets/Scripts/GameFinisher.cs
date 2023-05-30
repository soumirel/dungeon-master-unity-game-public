using DefaultNamespace;
using Enemies;
using UnityEngine;

public class GameFinisher : MonoBehaviour
{
    [SerializeField] private Clock _clock;
    [SerializeField] private DefeatPanel _defeatPanel;
    
    private bool _finished;
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.GetComponent<Enemy>() && !_finished)
        {        
            Finish();
        }
    }

    private void Finish()
    {
        _finished = true;
        
        _defeatPanel.gameObject.SetActive(true);
        
        var score = new Score(_clock.Minutes, _clock.Seconds);
        
        ScoreSaver.TryUpdateBestScore(score);
        _defeatPanel.UpdateScoreText(score);
    }
}
