<?php
class Voiture
{
    /***Attributs***/
    private string $_couleur = "";
    private string $_marque = "";
    private string $_model = "";
    private int $_nbKilometre = 0;
    private string $_motorisation = "";

    /***Accesseur***/
    public function getMotorisation()
    {
        return $this->_motorisation;
    }

    public function setMotorisation($motorisation)
    {
        $this->_motorisation = $motorisation;
    }

    public function getNbKilometre()
    {
        return $this->_nbKilometre;
    }

    public function setNbKilometre($nbKilometre)
    {
        $this->_nbKilometre = $nbKilometre;
    }

    public function getModel()
    {
        return $this->_model;
    }

    public function setModel($model)
    {
        $this->_model = $model;
    }

    public function getMarque()
    {
        return $this->_marque;
    }

    public function setMarque($marque)
    {
        $this->_marque = $marque;
    }

    public function getCouleur()
    {
        return $this->_couleur;
    }

    public function setCouleur($couleur)
    {
        $this->_couleur = $couleur;
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
    public function __toString()
    {
        echo "Cette voiture est une ";
        echo $this->getModel() ? $this->getModel() . " de la marque " : " voiture de la marque ";
        echo $this->getMarque();
        echo $this->getCouleur() ? " de couleur " . $this->getCouleur() : " ";
        echo $this->getMotorisation() ? " de motorisation " . $this->getMotorisation() : " ";
        echo $this->getNbKilometre() ?  " avec " . $this->getNbKilometre() . " kilometres" : "";
    }

    public function rouler($kilometreFait)
    {
        $ajoutKilometre = $this->getNbKilometre() + $kilometreFait;

        $this->setNbKilometre($ajoutKilometre);
    }
}
