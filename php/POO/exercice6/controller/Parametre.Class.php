<?php
class Parametre
{
    /***Attributs***/
    static private $_host;
    static private $_port;
    static private $_dbName;
    static private $_username;
    static private $_password;
    static private $_bdd;

    /***Accesseur***/
    #region
    public function getBdd()
    {
        return self::$_bdd;
    }

    public function setBdd($bdd)
    {
        self::$_bdd = $bdd;
    }

    public function getPassword()
    {
        return self::$_password;
    }

    public function setPassword($password)
    {
        self::$_password = $password;
    }

    public function getUsername()
    {
        return self::$_username;
    }

    public function setUsername($username)
    {
        self::$_username = $username;
    }

    public function getDbName()
    {
        return self::$_dbName;
    }

    public function setDbName($dbName)
    {
        self::$_dbName = $dbName;
    }

    public function getPort()
    {
        return self::$_port;
    }

    public function setPort($port)
    {
        self::$_port = $port;
    }

    public function getHost()
    {
        return self::$_host;
    }

    public function setHost($host)
    {
        self::$_host = $host;
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

    static public function getConfig()
    {
        $fichier = file_get_contents("config.json");
        $jsonData = json_decode($fichier, true);

        foreach ($jsonData as $key => $value) {
            switch ($key) {
                case "host":
                    self::setHost($value);
                case "port":
                    self::setPort($value);
                case "dbname":
                    self::setDbName($value);
                case "username":
                    self::setUsername($value);
                case "password":
                    self::setPassword($value);
                case "bdd":
                    self::setBdd($value);
            }
        }
    }
}
