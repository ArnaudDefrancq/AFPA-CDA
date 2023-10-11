<?php

/**
 * Permet d'ouvrir la balise PHP et la Class
 *
 * @param string $className Nom de la table
 * @return string
 */
function startClassManager(string $className)
{
    $aff = "<?php \n";
    $aff .= "class " . ucfirst($className) . "Manager \n";
    $aff .= "{ \n \n";

    return $aff;
}

/**
 * Permet de créer le CREATE
 *
 * @param string $className Nom de la table
 * @return string
 */
function createAdd(string $className)
{
    $aff = "static public function create(" . ucfirst($className) . " \$object) \n";
    $aff .= "{ \n";
    $aff .= "   return DAO::create(\$object); \n";
    $aff .= "} \n \n";

    return $aff;
}

/**
 * Permet de créer le UPDATE
 *
 * @param string $className Nom de la Table
 * @return string
 */
function createUpdate(string $className)
{
    $aff = "static public function update(" . ucfirst($className) . "  \$object) \n";
    $aff .= "{ \n";
    $aff .= "   return DAO::update(\$object); \n";
    $aff .= "} \n \n";

    return $aff;
}

/**
 * Permet de créer le DELETE
 *
 * @param string $className Nom de la classe
 * @return string
 */
function createDelete(string $className)
{
    $aff = "static public function delete(" . ucfirst($className) . "  \$object) \n";
    $aff .= "{ \n";
    $aff .= "   return DAO::delete(\$object); \n";
    $aff .= "} \n \n";

    return $aff;
}

/**
 * Permet de créer le FindById
 *
 * @param string $className Nom de la classe
 * @return string
 */
function createFindById(string $className)
{
    $aff = "static public function findById(\$id) \n";
    $aff .= "{ \n";
    $aff .= '   return DAO::select("' . ucfirst($className) . '",' . ucfirst($className) . '::getAttributs(),["id' . ucfirst($className) . '"=> $id])[0];' . "\n";
    $aff .= "} \n \n";

    return $aff;
}

/**
 * Permet de créer le GetList
 *
 * @param string $className nom de table
 * @return string
 */
function createGetList(string $className)
{
    $aff = "static public function getList(array \$nomColonnes=null,  array \$conditions = null, string \$orderBy = null, string \$limit = null, bool \$api = false, bool \$debug = false) \n";
    $aff .= "{ \n";
    $aff .= "   \$nomColonnes = (\$nomColonnes == null) ?" . ucfirst($className) . "::getAttributs() : \$nomColonnes;" . " \n";
    $aff .= '   return DAO::select("' . ucfirst($className) . '"' . ", \$nomColonnes, \$conditions, \$orderBy, \$limit, \$api, \$debug);" . "\n";
    $aff .= "} \n \n";

    return $aff;
}

/**
 * Permet de fermer la Class
 *
 * @return string
 */
function endClassManager()
{
    $aff = "}";
    return $aff;
}

/**
 * Permet de tous écrire
 *
 * @param string $className
 * @return string
 */
function createManager(string $className)
{
    $aff = '';
    $aff .= startClassManager($className);
    $aff .= createAdd($className);
    $aff .= createUpdate($className);
    $aff .= createDelete($className);
    $aff .= createFindById($className);
    $aff .= createGetList($className);
    $aff .= endClassManager();

    return $aff;
}
