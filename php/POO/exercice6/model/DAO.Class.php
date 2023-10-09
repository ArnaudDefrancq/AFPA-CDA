<?php
class DAO
{

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
    static  public function select(string $table, ?array $colonnes = null, ?array $conditions = null, ?array $orderBy = null, ?string $limit = null, ?bool $debug = false)
    {

        $verif = $table . json_encode($colonnes) . json_encode($conditions) . json_encode($orderBy) . $limit; // encode la requête 

        if (!strpos($verif, ";")) { // on vérifie qu'il n'y a pas de ";" dans la requête
            $classe = ucfirst($table);
            $liste = [];
            $db = DbConnect::getDb();
            $requete = "SELECT ";
            $requete .= self::setColonnes($colonnes, $table);
            $requete .= " FROM " . $table;
            $requete .= self::setConditions($conditions);
            $requete .= self::setOrderBy($orderBy, $requete);
            $requete .= $limit != null ? " LIMIT " . $limit : "";
            if ($debug) {
                var_dump($requete);
            }

            $req = $db->prepare($requete);
            $req->execute();
            while ($donnees = $req->fetch(PDO::FETCH_ASSOC)) {
                $liste[] = new $classe($donnees);
            }
            $req->closeCursor();
            return count($liste) > 0 ? $liste : false;
        }
        return false;
    }

    /**
     * Permet de transformer le tableau en string et sépare les elements avec une ","
     *
     * @param array|null $colonnes Nom des colonnes présents dans la base de donnée
     * @return string
     */
    static private function setColonnes(?array $colonnes = null, string $classe)
    {
        if ($colonnes != null) {
            return implode(', ', $colonnes);
        }

        return implode(", ", self::getProperties($classe));
    }

    /**
     * Permet de définir les conditions du SELECT
     *
     * @param array|null $conditions Conditions dans un array associatif. 
     *  - ">" ou "<" pour des comparaisons
     *  - "!" pour inégalité
     *  - "->" pour BETWEN
     *  - "" pour IS NULL
     *  - [array] pour IN
     *  - "%" pour LIKE
     *  - Si rien de spéciale pour comparaison 
     * @return string
     */
    static private function setConditions(?array $conditions = null)
    {
        $requete = "";
        if ($conditions != null) {
            $requete = " WHERE ";
            foreach ($conditions as $key => $value) {
                if (is_array($value)) {
                    $requete .= $key . " IN ('" . implode("','", $value) . "')";
                } elseif ($value == "") {
                    $requete .= $key . " IS NULL";
                } elseif (strpos($value, "->")) {
                    $value = str_replace("->", ' AND ', $value);
                    $requete .= $key . " BETWEEN " . $value;
                } elseif (strpos($value, "<") !== false || strpos($value, ">") !== false) {
                    $requete .= $key . $value;
                } elseif (strpos($value, "!") !== false) {
                    $requete .= $key . "!=" . substr($value, 1);
                } elseif (strpos($value, "%") !== false) {
                    $requete .= $key . " LIKE '" . $value . "'";
                } else {
                    $requete .= $key . " = '" . $value . "'";
                }

                $requete .= " AND ";
            }
            $requete = substr($requete, 0, -4);
        }
        return $requete;
    }

    /**
     * Permet de définir le ORDER BY du SELECT
     *
     * @param array|null $orderBy array associatif [nom_colonne => true (ASC) / false (DESC)]
     * @return string
     */
    static private function setOrderBy(?array $orderBy = null)
    {
        $retour = '';
        if ($orderBy != null) {
            $retour = ' ORDER BY ';
            foreach ($orderBy as $key => $value) {
                $retour .= $key . ' ' . ($value ? "" : ' DESC ') . ', ';
            }
            $retour = substr($retour, 0, -2);
        }
        return $retour;
    }

    /**
     * Permet de récupérer les attributs d'une classe dynamiquement
     *
     * @param string $classe
     * @return array Tablau avec les attributs
     */
    private static function getProperties(string $classe)
    {
        // Instanciatin de la classe
        $obj = new $classe();

        // récupération des propriétés de la classe
        $properties = (new ReflectionClass($obj))->getProperties();

        $propertiesListe = [];
        // création de la liste des propriétés
        foreach ($properties as $property) {
            $propertiesListe[] = substr($property->getName(), 1);
        }

        return $propertiesListe;
    }


    /**
     * Permet d'ajouter un élément dans la base de donnée avec l'ID de la ligne
     *
     * @param string $table Table où l'on veut ajouter des choses
     * @param object $newData objet a ajouter à la base de donnée
     * @return void
     */
    static public function create(string $table, object $newData)
    {
        $db = DbConnect::getDb();

        $allAttributs = Personne::$attributs;

        try {
            $query = $db->prepare("INSERT INTO $table (" . implode(", ", $allAttributs) . ") VALUES (:" . implode(", :", $allAttributs) . ")");

            foreach ($allAttributs as $attributs) {
                $query->bindValue(':' . $attributs, $newData->{'get' . ucfirst($attributs)}());
            }
            $query->execute();
        } catch (Exception $e) {
            return "error =>" . $e->getMessage();
        }
    }

    /**
     * Permet de modifier des données dans une BDD
     *
     * @param string $table nom de la table 
     * @param object $newData objet modifier
     * @return void
     */
    static public function update(string $table, object $newData)
    {
        $db = DbConnect::getDb();

        $allAttributs = Personne::$attributs;

        $req = '';
        foreach ($allAttributs as $attributs) {
            $req .= $attributs . " = :" . $attributs . ", ";
        }
        try {
            $query = $db->prepare("UPDATE " . $table . " SET " . substr($req, 0, -2) . " WHERE " . $allAttributs[0] . " = :" . $allAttributs[0]);
            foreach ($allAttributs as $attributs) {
                $query->bindValue(':' . $attributs, $newData->{'get' . ucfirst($attributs)}());
            }
            $query->execute();
        } catch (Exception $e) {
            return "error =>" . $e->getMessage();
        }
    }

    /**
     * Permet de supprimer une ligne dans la base de donnée avec l'ID de la ligne
     *
     * @param string $table
     * @param object $newData
     * @return void
     */
    static public function delete(string $table, object $newData)
    {
        $db = DbConnect::getDb();

        $allAttributs = Personne::$attributs;

        try {

            $query = $db->prepare("DELETE FROM " . $table . " WHERE " . $allAttributs[0] . " = :" . $allAttributs[0]);
            $query->bindValue(':' . $allAttributs[0], $newData->{'get' . ucfirst($allAttributs[0])}());
            $query->execute();
        } catch (Exception $e) {
            return "error =>" . $e->getMessage();
        }
    }
}
