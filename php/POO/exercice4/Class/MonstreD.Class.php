<?php
class MonstreD extends MonstreF
{
    /***Attributs***/
    public static $nbMonstreTue;
    const DEGAT_SORT = 5;

    /***Accesseur***/
    #region
    public function getNbMontreTue()
    {
        return self::$nbMonstreTue;
    }

    public function setNbMontreTue($nbMonstreTue)
    {
        self::$nbMonstreTue = $nbMonstreTue;
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
     * Permet d'attaquer le joueur (herite de la methode attaque de MonstreF)
     *
     */
    public function attaque($joueur, $debug)
    {
        parent::attaque($joueur, $debug);
        $joueur->subitDegats(self::DEGAT_SORT, $debug);
    }

    public function subitDegats()
    {
        return self::setNbMontreTue(self::getNbMontreTue() + 1);
    }

    /**
     * Si le dé fait 6 le monstre fait un sort
     *
     * @return bool
     */
    public function degatSort()
    {
        $deSort = Parent::lancerDe();
        var_dump($deSort);

        if ($deSort == 6) {
            echo "le monstre fait " . $deSort . " pour jeter sont sort";
            return true;
        } else {
            echo "le monstre fait " . $deSort . " pour jeter sont sort";
            return false;
        }
    }
}
