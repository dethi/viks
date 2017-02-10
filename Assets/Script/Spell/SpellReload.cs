using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpellReload : MonoBehaviour {

    public float delay = 4f;
    public string spellName;

    private Image image;
    private bool _canUse = false;
    private float _delayTimer = 0f;

    // Use this for initialization
    void Start() {
        image = GetComponent<Image>();
        image.fillAmount = 0;
    }
            
	// Update is called once per frame
	void Update () {
        if (_canUse)
            return;

        _delayTimer += Time.deltaTime;
        image.fillAmount = _delayTimer / delay;

        if (_delayTimer >= delay)
            _canUse = true;
	}

    public bool canUse()
    {
        return _canUse;
    }

    public void use()
    {
        _canUse = false;
        _delayTimer = 0f;
    }
}
