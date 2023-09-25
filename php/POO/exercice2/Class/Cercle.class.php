<?php
class Cercle
{
    /***Attributs***/
    protected $_diametre;

    /***Accesseur***/
    protected function getDiametre()
    {
        return $this->_diametre;
    }

    protected function setDiametre($diametre)
    {
        $this->_diametre = $diametre;
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
    private function perimetre()
    {
        return number_format(2 * pi() * ($this->getDiametre() / 2), 2);
    }

    private function aire()
    {
        return number_format(pi() * pow(($this->getDiametre() / 2), 2), 2);
    }

    public function __toString()
    {
        return "Diamètre : " . $this->getDiametre() . " - Périmètre : " . $this->perimetre() . " - Aire : " . $this->aire();
    }
}
