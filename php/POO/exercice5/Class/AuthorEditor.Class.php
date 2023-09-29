<?php
class AuthorEditor  extends User implements Author, Editor
{
    /***Attributs***/
    private array  $_authorPrivileges;
    private array $_editorPrivileges;

    /***Accesseur***/
    #region
    public function setEditorPrivileges(array $array)
    {
        $this->_editorPrivileges = $array;
    }
    public function getEditorPrivileges()
    {
        return $this->_editorPrivileges;
    }
    public function setAuthorPrivileges(array $array)
    {
        $this->_authorPrivileges = $array;
    }
    public function getAuthorPrivileges()
    {
        return $this->_authorPrivileges;
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
        return Parent::__toString() . " has the following privileges: " . $this->author() . " " . $this->editor();
    }

    public function author()
    {
        foreach ($this->getAuthorPrivileges() as $author) {
            return $author;
        }
    }
    public function editor()
    {
        foreach ($this->getEditorPrivileges() as $editor) {
            return $editor;
        }
    }
}
