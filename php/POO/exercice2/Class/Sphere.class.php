<?php
require_once "Cercle.class.php";

class Sphere extends Cercle
{
    /***Attributs***/

    /***Accesseur***/

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
    private function aireSphere()
    {
        return 4 * pi() * (pow((Parent::getDiametre() / 2), 2));
    }

    private function volumeSphere()
    {
        return (4 / 3) * pi() * pow((Parent::getDiametre() / 2), 3);
    }

    public function __toString()
    {
        return "Aire : " . $this->aireSphere() . " - Volume : " . $this->volumeSphere();
    }
}
