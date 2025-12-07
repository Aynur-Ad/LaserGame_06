using UnityEngine;

public class Bonus_sc : MonoBehaviour
{ 
    [SerializeField]
    private float speed = 3;

    [SerializeField]
    int bonusId;

    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(Vector3.down * speed * Time.deltaTime);

        if (this.transform.position.y < -5.8f)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            // uclu atis bonusunu aktiflestir
            Player_sc player_sc = other.transform.GetComponent<Player_sc>();
            if(player_sc != null)
            {
                switch (bonusId)
                {
                    // uclu atis
                    case 0:
                        player_sc.TripleShotActive();
                        break;
                    // hýz
                    case 1:
                        player_sc.SpeedBonusActive();
                        break;
                    // kalkan
                    case 2:
                        player_sc.ShieldBonusActive();
                        break;
                    // tanimlanan durumlar disi
                    default:
                        Debug.Log("Hata Durumu");
                        break;
                }
            }
            // bonus nesnesini yok et
            Destroy(this.gameObject);
        }
    }
}
