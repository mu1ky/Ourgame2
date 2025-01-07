using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPbarKey_hero : MonoBehaviour
{
    public static HPbarKey_hero Instance { get; private set; }

    public bool isFindKey = false;
    public byte count_Key = 0;
    public float HP = 100f;
    public Player play;
    public Image bar;
    public Text count_keys;
    public bool IsFindKey_()
    {
        return isFindKey;
    }
    private void Awake()
    {
        play = GetComponent<Player>();
    }
    private void Start()
    {
        isFindKey = false;
        count_keys.text = (count_Key).ToString();
        play.TakeHP += LowerHP;
        Debug.Log(HP);
    }
    private void LowerHP(object sender, System.EventArgs e)
    {
        HP -= 10f;
        float def = HP / 100;
        bar.fillAmount = def;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Key")
        {
            isFindKey = true;
            count_Key = +1;
            Destroy(collision.gameObject, 0.5f);
            count_keys.text = (count_Key).ToString();
        }
    }
}
