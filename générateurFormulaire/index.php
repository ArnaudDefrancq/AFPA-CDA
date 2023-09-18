<?php
require 'formulaire.php';

?>
<!DOCTYPE html>
<html lang="en">

<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Document</title>
    <link rel="stylesheet" href="style.css">
    <script src="verifFrom.js" defer></script>
</head>

<body>
    <form action="#" method="post" class="form">
        <?php
        $form->createForm();
        ?>
    </form>
</body>

</html>