using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Bridge : MonoBehaviour
{
    [SerializeField] private GameObject brokenBridge;
    [SerializeField] private GameObject fixedBridge;
    [SerializeField] private GameObject text;
    [SerializeField] private TextMeshProUGUI Text;
    [SerializeField] private TextMeshProUGUI note;
    [SerializeField] private AudioSource AudioSource;
    public Inventory Inv;
    private int sticks;
    private int ropes;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            text.SetActive(true);
            note.text = "Repair the bridge";
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player" && Input.GetKey(KeyCode.E))
        {
            if (Inv.Stick >= 15 && Inv.Rope >= 4)
            {
                brokenBridge.SetActive(false);
                fixedBridge.SetActive(true);
                Inv.Stick = Inv.Stick - 15;
                Inv.StickCount();
                Inv.Rope = Inv.Rope - 4;
                Inv.RopeCount();
                AudioSource.Play();
                note.text = "ESCAPE!";

            }
            else if (Inv.Stick < 15 || Inv.Rope < 4)
            {
                if (Inv.Stick < 15)
                {
                    sticks = 15 - Inv.Stick;
                    if (Inv.Rope < 4)
                    {
                        ropes = 4 - Inv.Rope;
                    }
                    Text.text = "Still need " + sticks + " sticks and " + ropes + " ropes";
                }
                else if (Inv.Rope < 4)
                {
                    ropes = 4 - Inv.Rope;
                    Text.text = "Still need " + ropes + " more ropes";
                }
            }
        }
        else if (other.gameObject.tag == "Player" && !Input.GetKey(KeyCode.E))
        {
            Text.text = "If I repair this bridge, I can escape.\n15 Sticks and 4 Ropes should do it";
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            text.SetActive(false);
        }
    }
}
