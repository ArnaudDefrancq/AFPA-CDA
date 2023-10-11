<?php
// Objectif :
// On donne un tableau asso à la Class et on resort un Form en HTML
// Le tableau asso est créé grace à la table dans la BDD
// Le tableau asso : 
// Défini le nombre d'input et le type et défini le nom du label

class GenerateForm
{
    /**
     * Permet de démarrer la Class
     *
     * @param string $tableName Nom de la table
     * @return string
     */
    static private function generateStartFormClass(string $tableName)
    {
        $aff = "<?php \n";
        $aff .= "class " . $tableName . "Form \n";
        $aff .= "{ \n \n";

        return $aff;
    }

    /**
     * Permet de générer les Attributs
     *
     * @return string
     */
    static private function generateAttributsFormClass()
    {
    }

    /**
     * Permet de générer les Getter
     *
     * @return string
     */
    static private function generateGetterFormClass()
    {
    }

    /**
     * Permet de générer les Setter
     *
     * @return string
     */
    static private function generateSetterFormClass()
    {
    }

    /**
     * Permet de générer les Accesseurs
     *
     * @return string
     */
    static private function generateAccesseurFormClass()
    {
    }

    /**
     * Peremt de générer le Construct
     *
     * @return string
     */
    static private function generateConstructFormClass()
    {
    }

    /**
     * Permet de géénrer la fonction hydrate
     *
     * @return string
     */
    static private function generateHydrateFormClass()
    {
    }

    /**
     * Permet de générer le ToString
     *
     * @return string
     */
    static private function generateToStringFormClass()
    {
    }


    /**
     * Permet de générer le FormClass
     *
     * @param $array Array asso avec le nom de la Table et les colonnes asso
     * exemple : 
     * $array = [    
     * "ville" => [
     *   "idVille" => 'integer',
     *  "nom" => 'varchar'
     *  ]
     *]
     * @return string
     */
    static public function generateFromClass(array $array)
    {
        $aff = '';
        foreach ($array as $key => $value) {
            // var_dump($key, $value);
            $aff .= self::generateStartFormClass($key);
        }

        return $aff;
    }
}
