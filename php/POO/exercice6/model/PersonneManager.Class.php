<?php
class PersonneManager
{
    /**
     * Ajout d'une personne en base de donnée
     *
     * @param Personne $p
     * @return void
     */
    static public function create(string $table, object $object)
    {
        DAO::create($table, $object);
    }

    /**
     * Update d'une personne en base de donnée
     *
     * @param Personne $p
     * @return void
     */
    static public function update(string $table, object $object)
    {
        DAO::update($table, $object);
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

    #region
    /**
     * Sélectionne une personne en base de donnée
     *
     * @param int $id
     * @return void
     */
    // static public function selectById($id)
    // {
    //     $db = DbConnect::getDb();

    //     $id = $id;

    //     $query = $db->query("SELECT idPersonne, nom, prenom, adresse, ville FROM personne WHERE idPersonne=" . $id);
    //     $donnes = $query->fetch(PDO::FETCH_ASSOC);

    //     return new Personne($donnes);
    // }

    // /**
    //  * Permet de sélectionner les colonnes de recherche pour le SELECT
    //  *
    //  * @param array|null $colonnes
    //  * @return string
    //  */
    // static public function getColonne(?array $colonnes = null)
    // {
    //     if ($colonnes) {
    //         return implode(",", $colonnes);
    //     } else {
    //         return "*";
    //     }
    // }

    // /**
    //  * Permet Les condition pour le SELECT
    //  *
    //  * @param array|null $conditions
    //  * @return string
    //  */
    // static public function getConditions(?array $conditions = null)
    // {
    //     $affCondition = "";
    //     if ($conditions) {
    //         foreach ($conditions as $key => $value) {
    //             if (!is_array($value) && strpos($value, "%")) $affCondition = $affCondition . $key . " LIKE " . $value;
    //             if ($value == " ") $affCondition = $affCondition . $key . " IS NULL ";
    //             if ($value[0] == "!") $affCondition = $affCondition . $key . " != " . substr($value, 1);
    //             if ($value[0] == "<" || $value[0] == ">") $affCondition = $affCondition . $key . $value;
    //             if (!is_array($value) && strpos($value, "->")) $affCondition = $affCondition . $key . " BETWEN " . str_replace("->", " AND ", $value);
    //             if (is_array($value)) $affCondition = $affCondition . $key . " IN (" . implode(',', $value) . ")";

    //             $affCondition = $affCondition . " AND ";
    //         }
    //     }

    //     return substr($affCondition, 0, -4);
    // }

    // /**
    //  * Permtet d'ajouter un trie sur le SELECT
    //  *
    //  * @param array|null $orderBy
    //  * @return void
    //  */
    // static public function getOrderBy(?array $orderBy = null)
    // {
    //     $order = "";
    //     if ($orderBy) {
    //         foreach ($orderBy as $keys => $values) {
    //             if ($values == false) {
    //                 $order = $order . $keys . " DESC ";
    //             } else {
    //                 $order = $order . $keys . " ASC ";
    //             }
    //         }
    //     }

    //     return $order;
    // }

    // /**
    //  * Permet d'ajouter LIMIT et OFFSET sur le SELECT
    //  *
    //  *  @param string|null $limit
    //  * @return void
    //  */
    // static public function getLimit(?string $limit = null)
    // {
    // }

    // static public function getListe($table, ?array $colonnes = null, ?array $conditions = null, ?array $orderBy = null, ?string $limit = null, ?bool $debug = false)
    // {
    //     $db = DbConnect::getDb();

    //     if ($debug) echo 'debug';

    //     $perso = [];

    //     // Tester les variables



    //     $query = $db->query('SELECT ' . $colonnes  . ' FROM ' . $table . ' WHERE ' . $conditions . ' ORDER BY ' . $orderBy . ' LIMIT ' . $limit);

    //     while ($donnes = $query->fetch(PDO::FETCH_ASSOC)) {
    //         $perso[] = new Personne($donnes);
    //     }

    //     return $perso;
    // }*
    #endregion

    /**
     * Permet de sélectionner un objet grace à son ID
     *
     * @param int $id
     * @return object
     */
    static public function findById($id)
    {
        DAO::select("Personne", null, ["idPersonne" => $id]);
    }

    /**
     * Permet d'obtenir une liste d'objet issu de la base de donnée. On peut définir les colonnes, les conditions, l'orderBy, la limit/offset. Si la requête n'aboutie pas return false
     *
     * @param array|null $colonnes Nom des colonnes présents dans la base de donnée
     * @param array|null $conditions Conditions dans un array associatif. 
     *  - ">" ou "<" pour des comparaisons
     *  - "!" pour inégalité
     *  - "->" pour BETWEN
     *  - "" pour IS NULL
     *  - [array] pour IN
     *  - "%" pour LIKE
     *  - Si rien de spéciale pour comparaison  
     * @param array|null $orderBy array associatif [nom_colonne => true (ASC) / false (DESC)]
     * @param string|null $limit Définit la limit ex: "2,10"
     * @param boolean|null $debug si true on affiche la requête formulée
     * @return array(object)
     */
    static public function getList(?array $colonnes = null, ?array $conditions = null, ?array $orderBy = null, ?string $limit = null, ?bool $debug = false)
    {
        DAO::select("Personne", $colonnes, $conditions, $orderBy, $limit, $debug);
    }
}
