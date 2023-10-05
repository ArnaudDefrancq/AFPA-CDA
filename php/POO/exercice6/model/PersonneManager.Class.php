<?php
class PersonneManager
{
    /**
     * Ajout d'une personne en base de donnée
     *
     * @param Personne $p
     * @return void
     */
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

    /**
     * Update d'une personne en base de donnée
     *
     * @param Personne $p
     * @return void
     */
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

    /**
     * Supprime une personne en base de donnée
     *
     * @param Personne $p
     * @return void
     */
    static public function delete(Personne $p)
    {
        $db = DbConnect::getDb();
        $query = $db->prepare("DELETE FROM personne WHERE idPersonne=:idPersonne");
        $query->bindValue(":idPersonne", $p->getIdPersonne());
        $query->execute();
    }

    /**
     * Sélectionne une personne en base de donnée
     *
     * @param int $id
     * @return void
     */
    static public function selectById($id)
    {
        $db = DbConnect::getDb();

        $id = $id;

        $query = $db->query("SELECT idPersonne, nom, prenom, adresse, ville FROM personne WHERE idPersonne=" . $id);
        $donnes = $query->fetch(PDO::FETCH_ASSOC);

        return new Personne($donnes);
    }

    /**
     * Permet de sélectionner les colonnes de recherche pour le SELECT
     *
     * @param array|null $colonnes
     * @return string
     */
    static public function getColonne(?array $colonnes = null)
    {
        if ($colonnes) {
            return implode(",", $colonnes);
        } else {
            return "*";
        }
    }

    /**
     * Permet Les condition pour le SELECT
     *
     * @param array|null $conditions
     * @return string
     */
    static public function getConditions(?array $conditions = null)
    {
        if ($conditions) {
        }
    }

    /**
     * Permtet d'ajouter un trie sur le SELECT
     *
     * @param array|null $orderBy
     * @return void
     */
    static public function getOrderBy(?array $orderBy = null)
    {
        $order = "";
        if ($orderBy) {
            foreach ($orderBy as $keys => $values) {
                if ($values == false) {
                    $order = $order . $keys . " DESC ";
                } else {
                    $order = $order . $keys . " ASC ";
                }
            }
        }

        return $order;
    }

    /**
     * Permet d'ajouter LIMIT et OFFSET sur le SELECT
     *
     *  @param string|null $limit
     * @return void
     */
    static public function getLimit(?string $limit = null)
    {
    }

    static public function getListe($table, ?array $colonnes = null, ?array $conditions = null, ?array $orderBy = null, ?string $limit = null, ?bool $debug = false)
    {
        $db = DbConnect::getDb();

        if ($debug) echo 'debug';

        $perso = [];

        // Tester les variables



        $query = $db->query('SELECT ' . $colonnes  . ' FROM ' . $table . ' WHERE ' . $conditions . ' ORDER BY ' . $orderBy . ' LIMIT ' . $limit);

        while ($donnes = $query->fetch(PDO::FETCH_ASSOC)) {
            $perso[] = new Personne($donnes);
        }

        return $perso;
    }
}
