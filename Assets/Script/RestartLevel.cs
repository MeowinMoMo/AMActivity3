using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RestartLevel : MonoBehaviour
{
    SceneManager scene;
    public float PlayerHp = 5;
    public Image HpBar;
  
    private void Start()
    {
    }
    private void Update()
    {
        if (PlayerHp == 0)
            SceneManager.LoadScene(0); 
    }

    public void PlayerDamage()
    {
        PlayerHp--;
        HpBar.fillAmount = PlayerHp / 5f;
    }
}
