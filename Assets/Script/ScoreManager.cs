using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;
using System.Diagnostics;
public class ScoreManager : MonoBehaviour
{
    public int score = 0;
    public int nbrDechet = 0;
    public int nbrPlastique = 0;
    public int nbrVerre = 0;
    public int nbrDechetAlimentaire = 0;

    public int reussi = 0;


    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI scoreText2;

    public TextMeshProUGUI plastiqueText;
    public TextMeshProUGUI verreText;
    public TextMeshProUGUI alimentaireText;
    public TextMeshProUGUI dechetotalscene;

    public Button quitterButton;

    public Slider ergonomieSlider;
    public Slider utiliteAidesSlider;
    public Slider confortSlider;
    public Slider chargeCognitiveSlider;



    public TextMeshProUGUI erreurText;
    public TextMeshProUGUI erreurText2;

    public TextMeshProUGUI EchecReussite;

    public Canvas TableauDeBordCanvas;

    public Canvas recapitulatif;

    public Canvas maingauche;

    public int error;

    public bool quit = false;

    void Start()
    {
        UpdateScoreText();
        //quitterButton.gameObject.SetActive(false);
        quit = false;
    }


    void Update()
    {
        MettreAJourComptageScene();

    }
    public void AjouterPoint(string typeDechet)
    {
        score++;
        reussi++;
        //nbrDechet++;

        //switch (typeDechet)
        //{
        //    case "Plastic":
        //       nbrPlastique++;
        //       break;
        ////     nbrVerre++;
        //     break;
        // case "Dechet":
        //   nbrDechetAlimentaire++;
        //   break;
        //}

        UpdateScoreText();
    }

    public int CompterObjetsAvecTag(string tag)
    {
        GameObject[] objets = GameObject.FindGameObjectsWithTag(tag);
        return objets.Length;
    }
    void MettreAJourComptageScene()
    {
        nbrPlastique = CompterObjetsAvecTag("Plastic");
        nbrVerre = CompterObjetsAvecTag("Verre");
        nbrDechetAlimentaire = CompterObjetsAvecTag("Dechet");

        nbrDechetAlimentaire = nbrDechetAlimentaire - 1;
        nbrPlastique = nbrPlastique - 1;
        nbrVerre = nbrVerre - 4;

        nbrDechet = nbrPlastique + nbrVerre + nbrDechetAlimentaire;

        UpdateScoreText();
    }

    public void AfficheEchecReussite()
    {
        if (error < 5)
        {
            EchecReussite.text = "Bravo vous avez bien réussi le test!";
            EchecReussite.color = Color.green;
        }
        else
        {
            EchecReussite.text = "Échec vous n'avez pas bien réussi le test !";
            EchecReussite.color = Color.red;
        }
    }

    public void RetirerPoint()
    {
        score--;
        error++;
        UpdateScoreText();
    }

    void UpdateScoreText()
    {
        if (scoreText != null)
            scoreText.text = $"Score : {score}";

        if (scoreText2 != null)
            scoreText2.text = $"Score : {score}";

        if (plastiqueText != null)
            plastiqueText.text = $"Plastique : {nbrPlastique}";

        if (verreText != null)
            verreText.text = $"Verre : {nbrVerre}";

        if (alimentaireText != null)
            alimentaireText.text = $"Alimentaire : {nbrDechetAlimentaire}";

        if (erreurText != null)
            erreurText.text = $"Erreurs : {error}";
        if (erreurText2 != null)
            erreurText2.text = $"Erreurs : {error}";

        if (dechetotalscene != null)
            dechetotalscene.text = $"Total Déchets : {nbrDechet}";
    }

    public void Quitter()
    {
        //Application.Quit();
        TableauDeBordCanvas.enabled = false;
        recapitulatif.gameObject.SetActive(true);

        maingauche.enabled = false;
        DetruireObjetsAvecTag("Plastic");
        DetruireObjetsAvecTag("Verre");
        DetruireObjetsAvecTag("Dechet");

    }

    void DetruireObjetsAvecTag(string tag)
    {
        GameObject[] objets = GameObject.FindGameObjectsWithTag(tag);
        foreach (GameObject obj in objets)
        {
            Destroy(obj);
        }
    }

    public void QUitterDef()
    {
        Application.Quit();
    }

    public void Recommencer()
    {
        //score = 0;
        //nbrDechet = 0;
        //nbrPlastique = 0;
        //nbrVerre = 0;
        //nbrDechetAlimentaire = 0;

        //SupprimerObjetsAvecTag("Plastic");
        //SupprimerObjetsAvecTag("Verre");
        //SupprimerObjetsAvecTag("Dechet");

        // UpdateScoreText();

        foreach (BillboardEtDistanceUI ui in Object.FindObjectsByType<BillboardEtDistanceUI>(FindObjectsSortMode.None))
        {
            BillboardEtDistanceUI.distanceMin = 3000f;
        }



        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }

    void SupprimerObjetsAvecTag(string tag)
    {
        GameObject[] objets = GameObject.FindGameObjectsWithTag(tag);
        foreach (GameObject obj in objets)
        {
            Destroy(obj);
        }
    }

    public void SauvegarderDonneesCSV()
    {
        string path = Path.Combine(Application.persistentDataPath, "TestDechet.csv");
        bool fichierExiste = File.Exists(path);


        if (!fichierExiste)
        {
            PlayerPrefs.SetInt("ParticipantID", 0);
            PlayerPrefs.Save();
        }
        int participantID = PlayerPrefs.GetInt("ParticipantID", 0);

        int ergonomie = (int)ergonomieSlider.value;
        int utilite = (int)utiliteAidesSlider.value;
        int confort = (int)confortSlider.value;
        int chargeCog = (int)chargeCognitiveSlider.value;

        float temps = ChronoBoucle.tempsEcoule;
        string premier = "N° Participant" + "," + "TempsEcoule (s)" + "," + "Reussites" + "," + "Erreurs" + "," + "Ergonomie" + "," + "Utilité des aides" + "," + "Niveau de confort" + "," + "Charge cognitive";
        string ligne = $"{participantID},{temps.ToString("F2").Replace(',', '.')},{reussi},{error},{ergonomie},{utilite},{confort},{chargeCog}";

        using (StreamWriter writer = new StreamWriter(path, true))
        {

            if (!fichierExiste)
            {
                writer.WriteLine(premier);


            }
            writer.WriteLine(ligne);
            writer.WriteLine("");

            //participantID++;
        }

        PlayerPrefs.SetInt("ParticipantID", participantID + 1);
        PlayerPrefs.Save();

        Process.Start("explorer.exe", "/root," + Path.GetDirectoryName(path));


    }

    public void activerQuitterButton()
    {
        quitterButton.gameObject.SetActive(true);
    }
    
}
