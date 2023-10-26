<?php
function chargerClasse($classe)
{
    require './Class/' . $classe . '.Class.php';
}
spl_autoload_register('chargerClasse');

$user1 = new AuthorEditor(["username" => "Baltahzar"]);
$user1->setAuthorPrivileges(["write text", "add ponctuation"]);
$user1->setEditorPrivileges(["edit text", "edit ponctuation"]);
$user1->__toString();

echo $user1;
