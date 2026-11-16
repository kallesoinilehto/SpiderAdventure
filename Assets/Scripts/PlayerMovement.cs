using UnityEngine; // Ottaa kayttoon Unityn perustoiminnot, kuten MonoBehaviour, Transform ja Debug.
using UnityEngine.InputSystem; // Ottaa kayttoon Unityn uuden Input Systemin luokat, kuten InputAction.

// Maaritellaan julkinen (public) luokka nimelta PlayerController.
// Luokka perii (:) MonoBehaviour-luokan, jolloin se voidaan liittaa GameObjectiin komponentiksi
public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // Julkinen liukulukumuuttuja. Sen alkuarvo on 5.
    // Arvo nakyy Inspectorissa ja sita voidaan muuttaa myos muiden luokkien kautta.
    // Muuttuja kuvaa hahmon liikkumisnopeutta.

    // Yksityinen muuttuja, joka on tyyppia InputAction. Koska yksityinen, sita voidaan kayttaa vain taman luokan sisalla.
    private InputAction moveAction; // Tallentaa liikkumiseen liittyvan syotteen.
    
    // Paluutyyppi void tarkoittaa, ettei metodi palauta mitaan.
    void Start() // Suoritetaan kerran, kun objekti aktivoituu pelin alkaessa.
    {
        // Haetaan Input Systemista toiminto nimelta "Move" ja tallennetaan se muuttujaan moveAction.
        moveAction = InputSystem.actions.FindAction("Move"); // Nimi taytyy kirjoittaa tasmalleen samalla tavalla kuin Input Actions -asetuksissa.
    }

    // Update()-funktiota kaytetaan jatkuvasti paivittyvaan logiikkaan, kuten pelaajan liikkeen kasittelyyn.
    void Update() // Suoritetaan kerran jokaisella ruudunpaivityksella (framella).
    {
        // Luetaan liikesyote toimintoon sidotuilta nappaimilta (esim. WASD).
        /* ReadValue<Vector2>() palauttaa kaksi arvoa: x = vaaka-akseli (A/D tai vasen/oikea)
        ja y = pystyakseli (W/S tai ylos/alas). Tulos tallennetaan moveInput muuttujaan.*/
        Vector2 moveInput = moveAction.ReadValue<Vector2>();
        
        /* Luodaan uusi kolmiulotteinen vektori (Vector3). moveInput.x maaraa liikkeen X-suunnassa.
        Keskimmainen arvo on 0, joten hahmo ei liiku Y-suunnassa. moveInput.y maaraa liikkeen Z-suunnassa.
        transform.Translate() siirtaa GameObjectia annetun vektorin verran. Time.deltaTime tekee liikkeesta
        tasaisen riippumatta ruudunpaivitysnopeudesta. moveSpeed on liikkumisnopeus.*/
        transform.Translate(new Vector3(moveInput.x, 0, moveInput.y) * Time.deltaTime * moveSpeed);
    }
}