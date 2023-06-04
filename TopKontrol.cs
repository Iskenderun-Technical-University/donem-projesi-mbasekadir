using UnityEngine;

public class TopKontrol : MonoBehaviour
{
    public UnityEngine.UI.Text zaman, can,durum;
    private Rigidbody rg;
    public float hiz = 1.5f;
    float zamansayaci = 20;
    int cansayaci = 6;
    bool oyundevam = true;
    bool oyuntamam = false;
    // Start is called before the first frame update
    void Start()
    {
        rg = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (oyundevam && !oyuntamam)
        {
            zamansayaci -= Time.deltaTime;
            zaman.text = (int)zamansayaci + "";
        }
        else if(!oyuntamam)
        {
            durum.text = "OYUN TAMAMLANAMADI";
        }
       
        
        if (zamansayaci < 0)
        {
            oyundevam = false;
        }
        
    }
    void FixedUpdate()
    { 
        if (oyundevam && !oyuntamam) 
        { 
        float yatay = Input.GetAxis("Horizontal");
        float dikey = Input.GetAxis("Vertical");
        Vector3 kuvvet = new Vector3(-dikey, 0, yatay);

        rg.AddForce(kuvvet*hiz);

        }
        else
        {
            rg.velocity = Vector3.zero;
            rg.angularVelocity = Vector3.zero;
        }

    }
    void OnCollisionEnter(Collision cls)
    {
        string objisim = cls.gameObject.name;
        if (objisim.Equals("Bitis")) {
            // print("Oyun Tamamlandý..");
            oyuntamam = true;
            durum.text = "TEBRÝKLER BAÞARDIN.";
          
            

        }
        else if (!objisim.Equals("labirentzemin") && !objisim.Equals("zemin"))
        {
            cansayaci -= 1;
            can.text = cansayaci + "";
            if (cansayaci == 0)
            {
                oyundevam = false;
            }
        }
    }
}