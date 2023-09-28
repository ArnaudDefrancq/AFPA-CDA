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
        if (self::$pv == 0) {
            return false;
        } else {
            return true;
        }
    }

    /**
     * Permet au joueur d'attaquer un monstre
     *
     */
    public function attaque($monstre)
    {
        if ($monstre->lancerDe() < $this->lancerDe()) {
            return true;
        } else {
            return false;
        }
    }

    /**
     * Retire des points de vie si le joueur est touché
     *
     * @return int
     */
    public static function subitDegats($degatSubit)
    {
    }

    /**
     * Lance le dé pour le joueur
     *
     * @return int
     */
    public function lancerDe()
    {
        $de = new De();

        return $de->lanceLeDe();
    }

    // Bouclier bool
}
