<?php
class Joueur
{
    /***Attributs***/
    public static $pv;

    /***Accesseur***/
    #region
    public function getPv()
    {
        return $this->pv;
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

    /**
     * Permet de dire si le joueur est toujour viviant
     * true si viviant
     *
     * @return bool
     */
    public static function estVivant()
    {
    }

    /**
     * Permet au joueur d'attaquer un monstre
     *
     * @return void
     */
    public function attaque($montre)
    {
    }

    /**
     * Retire des points de vie si le joueur est touché
     *
     * @return int
     */
    public function subitDegats($degatSubit)
    {
    }
}
