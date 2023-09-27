<?php
class Employe
{
    /***Attributs***/
    private $_nom;
    private $_prenom;
    private $_embauche;
    private $_poste;
    private $_salaire;
    private $_service;
    private $_agence;
    public static $_nbEmployer;

    /***Accesseur***/
    public function getNom()
    {
        return $this->_nom;
    }

    public function setNom($nom)
    {
        $this->_nom = $nom;
    }

    public function getPrenom()
    {
        return $this->_prenom;
    }

    public function setPrenom($prenom)
    {
        $this->_prenom = $prenom;
    }

    public function getEmbauche()
    {
        return $this->_embauche;
    }

    public function setEmbauche($embauche)
    {
        $this->_embauche = $embauche;
    }

    public function getPoste()
    {
        return $this->_poste;
    }

    public function setPoste($poste)
    {
        $this->_poste = $poste;
    }

    public function getSalaire()
    {
        return $this->_salaire;
    }

    public function setSalaire($salaire)
    {
        $this->_salaire = $salaire;
    }

    public function getService()
    {
        return $this->_service;
    }

    public function setService($service)
    {
        $this->_service = $service;
    }

    public function getAgence()
    {
        return $this->_agence;
    }

    public function setAgence($agence)
    {
        $this->_agence = $agence;
    }

    public function getNbEmployer()
    {
        return $this->_nbEmployer;
    }

    public function setNbEmployer($nbEmployer)
    {
        $this->_nbEmployer = $nbEmployer;
    }

    /***Construct***/
    public function __construct(array $options = [])
    {
        if (!empty($options)) // empty : renvoi vrai si le tableau est vide
        {
            $this->hydrate($options);
            self::$_nbEmployer++;
        }
    }
    public function hydrate($data)
    {
        foreach ($data as $key => $value) {
            $methode = 'set' . ucfirst($key); //ucfirst met la 1ere lettre en majuscule
            if (is_callable([$this, $methode])) // is_callable verifie que la methode existe
            {
                $this->$methode($value);
            }
        }
    }

    /***Methodes***/
    /**
     * Calcul depuis combien de temps l'employer a ete employer
     *
     * @return string return la différence
     */
    public function anneeDansEntreprise()
    {
        $dateDujour = new DateTimeImmutable();
        $dateEmbauche = new DateTimeImmutable($this->getEmbauche());

        $interval = $dateEmbauche->diff($dateDujour);

        return $interval->format('%y');
    }

    /**
     * Indique si le salaire est verser
     * 
     * @return boolean true si la prime peut être versée
     */
    public function estVerser()
    {
        $dateDujour = new DateTime();
        $dateVersement = "30-11";

        $dateDujour->format("d-m");

        ($dateDujour == $dateVersement) ? true : false;
    }

    /**
     * Calcul la prime annuel(5% du brut par an et 2% du brut par année) et le verse le 30/11 de chaque année
     *
     * @return void
     */
    public function primeAnnuel()
    {
        return ($this->getSalaire() * 0.05) + (($this->getSalaire() * 0.02) * $this->anneeDansEntreprise());
    }

    /**
     * compare les nom -> prenom
     *
     * @param object $employe1
     * @param object $employe2
     * @return void
     */
    public static function compareToNomPrenom($employe1, $employe2)
    {
        if ($employe1->getNom() == $employe2->getNom()) {
            return $employe1->getPrenom() > $employe2->getPrenom();
        }
        return $employe1->getNom() > $employe2->getNom();
    }

    /**
     * compare les service -> nom -> prenom
     *
     * @param object $employe1
     * @param object $employe2
     * @return void
     */
    public static function compareToServiceNomPrenom($employe1, $employe2)
    {
        if ($employe1->getService() == $employe2->getService()) {
            if ($employe1->getNom() == $employe2->getNom()) {
                return $employe1->getPrenom() > $employe2->getPrenom();
            }
            return $employe1->getNom() > $employe2->getNom();
        }
        return $employe1->getService() > $employe2->getService();
    }

    public function __toString()
    {
        return  "Nom : " . $this->getNom() . " - Prénom : " . $this->getPrenom() . " - Embauche : " . $this->getEmbauche() . " - Fonction : " . $this->getPoste() . " - Salaire : " . $this->getSalaire() . " - Service : " . $this->getService();
    }
}
