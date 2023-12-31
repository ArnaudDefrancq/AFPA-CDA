<?php

class Pyramide extends Triangle
{
    /***Attributs***/
    private $_hauteur;

    /***Accesseur***/
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
    private function perimetrePyramide()
    {
        return number_format((2 * Parent::perimetre()) + (3 * $this->getHauteur()), 2);
    }

    private function airePyramide()
    {
        return number_format((2 * Parent::aire()) + (Parent::perimetre() * $this->getHauteur()), 2);
    }

    private function volume()
    {
        return Parent::aire() * $this->getHauteur();
    }

    public function __toString()
    {
        return "Périmètre : " . $this->perimetrePyramide() . " - Aire : " . $this->airePyramide() . " - Volume : " . $this->volume();
    }
}
