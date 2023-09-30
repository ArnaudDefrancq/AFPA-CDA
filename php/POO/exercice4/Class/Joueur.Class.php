<?php
class Joueur
{
    /***Attributs***/
    public static $pv;

    /***Accesseur***/
    #region

    public function getPv()
    {
        return self::$pv;
    }

    public function setPv($pv)
    {
        self::$pv = $pv;
    }
    #endregion

    /***Construct***/
    public function __construct(array $options = [])
    {
        if (!empty($options)) // empty : renvoi vrai si le tableau est vide
        {
            $this->hydrate($options);
        }
        self::setPv(self::getPv() + 50);
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
     * Permet de dire si le joueur est toujour viviant
     * true si viviant
     *
     * @return bool
     */
    public static function estVivant()
    {
        return (self::$pv < 0) ? true : false;
    }

    /**
     * Permet au joueur d'attaquer un monstre
     *
     */
    public function attaque($monstre, $debug)
    {

        $deJoueur = $this->lancerDe();
        $deMonstre = $monstre->lancerDe();

        if ($deJoueur >= $deMonstre) {
            if ($debug) echo "le joueur fait " . $deJoueur . " et le monstre fait " . $deMonstre . " : Le joueur gagne !";
            return  $monstre->subitDegats();
        } else {
            if ($debug) echo "joueur rate, tour du monstre";
        }
    }

    /**
     * Retire des points de vie si le joueur est touché
     *
     */
    public function subitDegats($degatSubit, $debug)
    {

        if (!$this->bouclier($debug)) {
            if ($debug) echo "\n" . "le joueur perd " . $degatSubit . " pv";
            return self::setPv(self::getPv() - $degatSubit);
        } else {
            if ($debug) echo "\n" . "le joueur se protege";
        }
    }

    /**
     * Lance le dé pour le joueur
     *
     * @return int
     */
    public function lancerDe()
    {
        return De::lanceLeDe();
    }

    /**
     * Permet de dire si le bouclier est levé si <= 2 bouclier lever
     *
     * @return bool
     */
    public function bouclier($debug)
    {
        $bouclier = $this->lancerDe();

        if ($bouclier <= 2) {
            if ($debug) echo "\n" . "le bouclier fait : " . $bouclier;
            return true;
        } else {
            if ($debug) echo "\n" . "le bouclier fait : " . $bouclier;
            return false;
        }
    }
}
