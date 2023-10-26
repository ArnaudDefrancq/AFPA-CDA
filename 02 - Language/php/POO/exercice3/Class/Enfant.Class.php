<?php
class Enfant
{
    /***Attributs***/
    private $_age;

    /***Accesseur***/
    #region
    public function getAge()
    {
        return $this->_age;
    }

    public function setAge($age)
    {
        $this->_age = $age;
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
}
