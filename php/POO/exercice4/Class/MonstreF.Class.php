<?php
class MonstreF
{
    /***Attributs***/
    private $_vivant;

    /***Accesseur***/
    #region
    public function getVivant()
    {
        return $this->_vivant;
    }

    public function setVivant($vivant)
    {
        $this->_vivant = $vivant;
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

    /**
     * Permet au monstre d'attaquer
     *
     */
    public function attaque()
    {
    }
}
