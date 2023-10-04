<?php
class PersonneManager
{
    static public function create(Personne $p)
    {
        $db = DbConnect::getDb();
        $query = $db->prepare("INSERT INTO personne (nom,prenom,adresse,ville) VALUES (:nom,:prenom,:adresse,:ville)");
        $query->bindValue(":nom", $p->getNom());
        $query->bindValue(":prenom", $p->getPrenom());
        $query->bindValue(":adresse", $p->getAdresse());
        $query->bindValue(":ville", $p->getVille());
        $query->execute();
    }

    static public function update(Personne $p)
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

    static public function delete(Personne $p)
    {
        $db = DbConnect::getDb();
        $query = $db->prepare("DELETE FROM personne WHERE idPersonne=:idPersonne");
        $query->bindValue(":idPersonne", $p->getIdPersonne());
        $query->execute();
    }

    static public function selectById($id)
    {
        $db = DbConnect::getDb();

        $id = $id;

        $query = $db->query("SELECT idPersonne, nom, prenom, adresse, ville FROM personne WHERE idPersonne=" . $id);
        $donnes = $query->fetch(PDO::FETCH_ASSOC);

        return new Personne($donnes);
    }

    static public function getListe()
    {
        $db = DbConnect::getDb();

        $perso = [];

        $query = $db->query('SELECT id, nom, prenom FROM personne ORDER BY nom');

        while ($donnes = $query->fetch(PDO::FETCH_ASSOC)) {
            $perso[] = new Personne($donnes);
        }

        return $perso;
    }
}
