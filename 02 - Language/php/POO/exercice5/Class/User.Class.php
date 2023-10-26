<?php
class User
{
    /***Attributs***/
    protected $_username;

    /***Accesseur***/
    #region
    public function getUsername()
    {
        return $this->_username;
    }

    public function setUsername($username)
    {
        $this->_username = $username;
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

    public function __toString()
    {
        $aff = $this->isReading() ? $this->getUsername() . " is reading" : $this->getUsername() . " isn't reading";

        return $aff;
    }

    /**
     * return random true or false
     *
     * @return boolean
     */
    public function isReading()
    {
        if (rand(0, 1) == 1) {
            return true;
        } else {
            return false;
        }
    }
}
