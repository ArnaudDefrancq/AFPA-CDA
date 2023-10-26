<?php
class Formulaire
{
    private $values = [];

    public function addValues(string $for, string $name, string $type)
    {
        $this->values[] = [
            $type,
            $name,
            $for
        ];
    }

    public function submit()
    {
        return '<button type="submit" class="btn btn-event" id="btn">Envoyer</button>';
    }

    public function createForm()
    {
        foreach ($this->values as $value) {
            echo '<div class="labelInput">';
            echo '<label for="' . $value[2] . '" class="label">' . $value[1] . '</label>';
            if ($value[0] == 'password') echo '<div class="input-show">';
            echo '<input type="' . $value[0] . '" name="' . $value[2] . '" id="' . $value[2] . '" class="input"/> ';
            if ($value[0] == 'password') echo '<i class="fas fa-eye show"></i>';
            if ($value[0] == 'password') echo '</div>';
            echo '<span class="input-message-error" data-span="' . $value[2] . '"></span>';
            echo '</div>';
        }

        echo '<span id="error" class="error-message"></span>';

        echo $this->submit();
    }
}

$form = new Formulaire();

$form->addValues('name', 'Nom', 'text');
$form->addValues('phone', 'Téléphone', 'tel');
$form->addValues('postal', 'Code Postal', 'text');
$form->addValues('email', 'Adresse Mail', 'email');
$form->addValues('password', 'Mot de passe', 'password');
