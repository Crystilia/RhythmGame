using UnityEngine;

public class ChargeTest : MonoBehaviour
{
    float Dmg = 0;
    float multi = 1;
    bool canCharge = false;

    void ChargeATK()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            canCharge = true;
        }
        if (canCharge == true)
        {
            Dmg = (Dmg + (multi * Time.deltaTime));
            Debug.Log(Dmg);
        }
        if (Input.GetKeyUp(KeyCode.B))
        {
            //put ur hit the target stuff here
            Dmg = 0;
            canCharge = false;
        }
    }
    void Update ()
    {
        ChargeATK();
    }
}
