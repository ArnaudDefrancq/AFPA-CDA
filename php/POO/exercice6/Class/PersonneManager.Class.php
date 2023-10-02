<?php
class PersonneManager
{
    public static function create(Personne $p)
    {
        $db = DbConnect::getDb();
        $query = $db->prepare("INSERT INTO personne (nom,prenom,adresse,ville) VALUES (:nom,:prenom,:adresse,:ville)");
        $query->bindValue(":nom", $p->getNom());
        $query->bindValue(":prenom", $p->getPrenom());
        $query->bindValue(":adresse", $p->getAdresse());
        $query->bindValue(":ville", $p->getVille());
        $query->execute();
    }

    public static function update(Personne $p)
    {
        $db = DbConnect::getDb();
        $query = $db->prepare("UPDATE  personne SET nom=:nom,prenom=:prenom,adresse=:adresse,ville=:ville WHERE idPersonne=:idPersonne");
        $query->bindValue(":idPersonne", $p->getIdPersonne());
        $query->bindValue(":nom", $p->getNom());
        $query->bindValue(":prenom", $p->getPrenom());
        $query->bindValue(":adresse", $p->getAdresse());
        $query->bindValue(":ville", $p->getVille());
        $query->execute();
    }

    public static function delete(Personne $p)
    {
        $db = DbConnect::getDb();
        $query = $db->prepare("DELETE FROM personne WHERE idPersonne=:idPersonne");
        $query->bindValue(":idPersonne", $p->getIdPersonne());
        $query->execute();
    }

    public static function selectById(Personne $p)
    {
        $db = DbConnect::getDb();
        $query = $db->prepare("SELECT idPersonne, nom, prenom, adresse, ville FROM personne WHERE idPersonne=:idPersonne");
    }
}
