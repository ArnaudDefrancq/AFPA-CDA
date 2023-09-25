<?php
require_once "Rectangle.class.php";

class Parallelepipede extends Rectangle
{
    /***Attributs***/
    private $_longueur;
    private $_largeur;
    private $_hauteur;

    /***Accesseur***/
    public function getLongueur()
    {
        return $this->_longueur;
    }

    public function setLongueur($longueur)
    {
        $this->_longueur = $longueur;
    }

    public function getLargeur()
    {
        return $this->_largeur;
    }

    public function setLargeur($largeur)
    {
        $this->_largeur = $largeur;
    }
    public function getHauteur()
    {
        return $this->_hauteur;
    }

    public function setHauteur($hauteur)
    {
        $this->_hauteur = $hauteur;
    }

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
    private function perimetreParallelepipede()
    {
        return (2 * Parent::perimetre()) + (4 * $this->getHauteur());
    }

    private function aireParallelepipede()
    {
        return (2 * Parent::aire()) + (Parent::perimetre() * $this->getHauteur());
    }

    private function volume()
    {
        return Parent::aire() * $this->getHauteur();
    }

    public function __toString()
    {
        return "Périmètre : " . $this->perimetreParallelepipede() . " - Aire : " . $this->aireParallelepipede() . " - Volume : " . $this->volume();
    }
}
