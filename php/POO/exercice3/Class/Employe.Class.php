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
    private Agence $_agence;
    public static $_nbEmployer;
    private $_enfant;

    /***Accesseur***/
    #region 
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

    public function setAgence(Agence $agence)
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

    public function getEnfant()
    {
        return $this->_enfant;
    }

    public function setEnfant($enfant)
    {
        $this->_enfant = $enfant;
    }

    #endregion
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
        $dateDujour = new DateTime();
        $dateEmbauche = new DateTimeImmutable($this->getEmbauche());

        $interval = $dateEmbauche->diff($dateDujour);

        return $interval->format('%y') * 1;
    }
    /**
     * prime de 5% sur le salaire
     *
     * @return int
     */
    public function primeSalaireAnnuel()
    {
        return $this->getSalaire() * 0.05;
    }

    /**
     * prime de 2% par année d'ancienneté
     *
     * @return int
     */
    public function primeAnciennete()
    {
        return $this->getSalaire() * 0.02 * $this->anneeDansEntreprise();
    }

    /**
     * Calcul la prime annuel(5% du brut par an et 2% du brut par année) et le verse le 30/11 de chaque année
     *
     * @return int
     */
    public function primeAnnuel()
    {
        return $this->primeAnciennete() + $this->primeSalaireAnnuel();
    }

    /**
     * compare les nom -> prenom
     *
     * @param object $employe1
     * @param object $employe2
     * @return bool
     */
    public static function compareToNomPrenom($employe1, $employe2)
    {
        if (strcmp($employe1->getNom(), $employe2->getNom()) ==  0) {
            return strcmp($employe1->getPrenom(), $employe2->getPrenom());
        }
        return strcmp($employe1->getNom(), $employe2->getNom());
    }

    /**
     * compare les service -> nom -> prenom
     *
     * @param object $employe1
     * @param object $employe2
     * @return bool
     */
    public static function compareToServiceNomPrenom($employe1, $employe2)
    {
        if ($employe1->getService() < $employe2->getService()) {
            return -1;
        } elseif ($employe1->getService() > $employe2->getService()) {
            return 1;
        } else {
            return self::compareToNomPrenom($employe1, $employe2);
        }
    }

    /**
     * Calcule la masse salariale
     *
     * @return int
     */
    public function masseSalarial()
    {
        return $this->getSalaire() + $this->primeAnnuel();
    }

    /**
     * permet de définir si l'employer peut avoir des chèques vacances
     *
     * @return bool false si l'employer ne peut pas avoir de chèque
     */
    public function estChequeVacance()
    {
        if ($this->anneeDansEntreprise() > 1) {
            return true;
        } else {
            return false;
        }
    }

    /**
     * Permet de dire si le l'employer a des enfants 
     *
     * @return boolean true si enfant
     */
    public function aDesEnfants()
    {
        if (count($this->getEnfant()) > 0) {
            return true;
        } else {
            return false;
        }
    }

    /**
     * indique le nombre de cheque noel par enfant et d'emplayer
     *
     * @return void
     */
    public function chequeNoel()
    {
        foreach ($this->getEnfant() as $enfant) {
            return $enfant;
        }
    }

    public function __toString()
    {
        return  "Nom : " . $this->getNom() . " - Prénom : " . $this->getPrenom() . " - Embauche : " . $this->getEmbauche() . " - Fonction : " . $this->getPoste() . " - Salaire : " . $this->getSalaire() . " - Service : " . $this->getService();
    }
}
