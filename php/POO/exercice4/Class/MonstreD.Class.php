<?php
class MonstreD extends MonstreF
{
    /***Attributs***/
    // nb monstre tuer static 
    //degat sort constante xx__x

    /***Accesseur***/
    #region

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

    /**
     * Permet d'attaquer le joueur (herite de la methode attaque de MonstreF)
     *
     */
    public function attaque()
    {
    }

    // subit degat
    // sort magic
}
