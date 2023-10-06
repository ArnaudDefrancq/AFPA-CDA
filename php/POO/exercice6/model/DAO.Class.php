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
            $requete .= self::setColonnes($colonnes);
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
    static private function setColonnes(?array $colonnes)
    {
        if ($colonnes != null) {
            return implode(', ', $colonnes);
        }

        return '*';
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
    static private function setConditions(?array $conditions)
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


    // static public function create(string $table)
    // {
    //     $db = DbConnect::getDb();
    //     $query = $db->prepare("INSERT INTO $table (nom,prenom,adresse,ville) VALUES (:nom,:prenom,:adresse,:ville)");
    //     $query->bindValue(":nom", $p->getNom());
    //     $query->bindValue(":prenom", $p->getPrenom());
    //     $query->bindValue(":adresse", $p->getAdresse());
    //     $query->bindValue(":ville", $p->getVille());
    //     $query->execute();
    // }
}
