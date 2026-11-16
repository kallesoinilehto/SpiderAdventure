using UnityEngine; // Ottaa kayttoon Unityn perustoiminnot, kuten MonoBehaviour, Transform ja Debug.
using UnityEngine.InputSystem; // Ottaa kayttoon Unityn uuden Input Systemin luokat, kuten InputAction.

// Maaritellaan julkinen (public) luokka nimelta PlayerController.
// Luokka perii (:) MonoBehaviour-luokan, jolloin se voidaan liittaa GameObjectiin komponentiksi
public class PlayerJump : MonoBehaviour
{
    public float jumpSpeed = 5f; // Julkinen liukulukumuuttuja. Sen alkuarvo on 5.
    // Arvo nakyy Inspectorissa ja sita voidaan muuttaa myos muiden luokkien kautta.
    // Muuttuja kuvaa hahmon liikkumisnopeutta.

    // Yksityinen muuttuja, joka on tyyppia InputAction. Koska yksityinen, sita voidaan kayttaa vain taman luokan sisalla.
    private InputAction jumpAction; // Tallentaa hyppaamiseen liittyvan syotteen.
    
    // Paluutyyppi void tarkoittaa, ettei metodi palauta mitaan.
    void Start() // Suoritetaan kerran, kun objekti aktivoituu pelin alkaessa.
    {
        // Haetaan Input Systemista toiminto nimelta "Jump" ja tallennetaan se muuttujaan jumpAction.
        jumpAction = InputSystem.actions.FindAction("Jump"); // Nimi taytyy kirjoittaa tasmalleen samalla tavalla kuin Input Actions -asetuksissa.
    }

    // Update()-funktiota kaytetaan jatkuvasti paivittyvaan logiikkaan, kuten pelaajan liikkeen kasittelyyn.
    void Update() // Suoritetaan kerran jokaisella ruudunpaivityksella (framella).
    {
        // Tarkistetaan painettiinko hyppynappainta juuri taman framen aikana.
        if (jumpAction.WasPressedThisFrame()) // Ehto on tosi vain yhden kerran yhta painallusta kohden.
        {
            Debug.Log("Jumped!"); // Jos hyppynappainta painettiin, Unity Consoleen tulostetaan teksti "Jumped!".
        }
    }
}