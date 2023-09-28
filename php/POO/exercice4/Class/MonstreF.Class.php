<?php
class MonstreF
{
    /***Attributs***/
    private $_vivant = true;
    public static $nbMonstreTue;
    public const DEGAT = 10;

    /***Accesseur***/
    #region
    public function getVivant()
    {
        return $this->_vivant;
    }

    public function setVivant(bool $vivant)
    {
        $this->_vivant = $vivant;
    }

    public function getNbMonstreTue()
    {
        return self::$nbMonstreTue;
    }

    public function setNbMonstreTue($nbMonstreTue)
    {
        self::$nbMonstreTue = $nbMonstreTue;
    }

    #endregion

    /***Construct***/
    public function __construct(array $options = [])
    {
        if (!empty($options)) // empty : renvoi vrai si le tableau est vide
        {
            $this->hydrate($options);
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

    public function __toString()
    {
    }

    /**
     * Permet au monstre d'attaquer
     *
     */
    public function attaque($joueur, $debug)
    {
        $deMonstre = $this->lancerDe();
        $deJoueur = $joueur->lancerDe();

        if ($deMonstre <= $deJoueur) {
            if ($debug) echo "le joueur fait " . $deJoueur . " et le monstre fait " . $deMonstre . " : Le joueur gagne !";
            self::setNbMonstreTue(self::getNbMonstreTue() + 1);
        } else {
            if ($debug) echo "le joueur fait " . $deJoueur . " et le monstre fait " . $deMonstre . " : Le monstre gagne !";
        }
    }

    /**
     * Lance le dé pour du montre
     *
     * @return int
     */
    public function lancerDe()
    {
        $de = new De();

        return $de->lanceLeDe();
    }
}
