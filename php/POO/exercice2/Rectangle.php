<?php
class Rectangle
{
    /***Attributs***/
    private $_longueur;
    private $_largeur;

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

    public function perimetre()
    {
        return 2 * ($this->getLongueur() + $this->getLargeur());
    }

    public function aire()
    {
        return $this->getLargeur() * $this->getLongueur();
    }

    public function estCarre()
    {
        if ($this->getLargeur() == $this->getLongueur()) {
            return "il s'agit d'un carré";
        } else {
            return "il ne s'agit pas d'un carré";
        };
    }

    public function __toString()
    {
        return "Longueur : " . $this->getLongueur() . "- Largeur : " . $this->getLargeur() . "- Périmètre : " . $this->perimetre() . " - Aire : " . $this->aire() . " - " . $this->estCarre();
    }
}
