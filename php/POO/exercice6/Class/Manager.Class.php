<?php
class Manager
{
    /**
     * Permet la connexion à la base de donnée
     *
     * @return object
     */
    static public function BDD()
    {
        $connectDB = new DBConnect([
            "dbName" => "exercicebdd",
            "host" => "localhost",
            "driver" => "mysql",
            "root" => "root",
            "password" => ""
        ]);

        return $connectDB->connectDB();
    }

    /**
     * permet d'ajouter une valeur dans une table
     *
     * @param string $table
     * @param  $values
     * @return void
     */
    static public function create($table, $values)
    {
        $bdd = self::BDD();

        $addValue = "INSERT INTO" . $table . "VALUES" . $values;

        $result = $bdd->query($addValue);
        $result->closeCursor();
    }

    /**
     * permet de lire les info dans une table
     *
     * @param string $table
     * @return void
     */
    static public function read($table)
    {
    }

    /**
     * Permet d'update une table
     *
     * @return void
     */
    static public function update()
    {
    }

    /**
     * permet de delete une table
     *
     * @return void
     */
    static public function delete()
    {
    }
}
