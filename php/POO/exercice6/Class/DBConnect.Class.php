<?php
class DBConnect
{
    /***Attributs***/
    private $_dbName;
    private $_host;
    private $_driver;
    private $_root;
    private $_password;

    /***Accesseur***/
    #region
    public function getDbName()
    {
        return $this->_dbName;
    }

    public function setDbName($dbName)
    {
        $this->_dbName = $dbName;
    }

    public function getHost()
    {
        return $this->_host;
    }

    public function setHost($host)
    {
        $this->_host = $host;
    }

    public function getDriver()
    {
        return $this->_driver;
    }

    public function setDriver($driver)
    {
        $this->_driver = $driver;
    }

    public function getRoot()
    {
        return $this->_root;
    }

    public function setRoot($root)
    {
        $this->_root = $root;
    }

    public function getPassword()
    {
        return $this->_password;
    }

    public function setPassword($password)
    {
        $this->_password = $password;
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
     * Permet de nous connecter a une base de donnée
     *
     */
    public function connectDB()
    {
        try {
            $db = new PDO($this->getDriver() . ":host" . $this->getHost() . ";charset=utf8;dbname=" . $this->getDbName(), $this->getRoot(), $this->getPassword());

            $db->setAttribute(PDO::ATTR_ERRMODE, PDO::ERRMODE_EXCEPTION);
        } catch (Exception $e) {
            echo 'Erreur : ' . $e->getMessage() . '<br />';
            echo 'numéro : ' . $e->getCode();
            die('Fin du script');
        }
    }
}
