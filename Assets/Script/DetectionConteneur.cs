using UnityEngine;

public class DetectionConteneur : MonoBehaviour
{
    private ScoreManager scoreManager;

    public ParticleSystem effetVerre;
    public ParticleSystem effetPlastic;
    public ParticleSystem effetDechet;

    public ParticleSystem effetVerreErreur;
    public ParticleSystem effetPlasticErreur;
    public ParticleSystem effetDechetErreur;
    private AudioSource audioSource;
    public AudioClip clip;
    public AudioClip echec;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        scoreManager = FindFirstObjectByType<ScoreManager>();

        
    }

    void JouerEffet(string tag)
    {
        switch (tag)
        {
            case "Verre":
                if (effetVerre != null) effetVerre.Play();
                break;
            case "Plastic":
                if (effetPlastic != null) effetPlastic.Play();
                break;
            case "Dechet":
                if (effetDechet != null) effetDechet.Play();
                break;
        }
    }

    void JouerEffetErreur(string tag)
    {
        switch (tag)
        {
            case "Verre":
                if (effetVerreErreur != null) effetVerreErreur.Play();
                break;
            case "Plastic":
                if (effetPlasticErreur != null) effetPlasticErreur.Play();
                break;
            case "Dechet":
                if (effetDechetErreur != null) effetDechetErreur.Play();
                break;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Verre") || other.CompareTag("Dechet") || other.CompareTag("Plastic"))
        {
            string tagConteneur = this.gameObject.tag;
            string tagDechet = other.tag;

            if (tagConteneur == tagDechet)
            {
               scoreManager.AjouterPoint(tagDechet);

                if (audioSource != null && clip != null)
                    audioSource.PlayOneShot(clip);
                JouerEffet(tagDechet);


            }
            else
            {
                Debug.Log(" Mauvais tri !");
                if (audioSource != null && echec != null)
                    audioSource.PlayOneShot(echec);
                JouerEffetErreur(tagConteneur);
                scoreManager.RetirerPoint();
            }

             
            Destroy(other.gameObject);
        }
    }
}
