<?php

class Formulaire
{
    public function createLabel(string $for, string $texte)
    {
        return '<label for="' . $for . '" class="label">' . $texte . '</label>';
    }

    public function createInput(string $type, string $name)
    {
        return '<input type="' . $type . '" name="' . $name . '" id="' . $name . '" class="input"/>';
    }

    public function createStartDiv()
    {
        return '<div class="labelInput">';
    }

    public function createEndDiv()
    {
        return '</div>';
    }

    public function submit()
    {
        return '<button type="submit" class="btn btn-event" id="btn">Envoyer</button>';
    }
}

class Formulaire_2
{
    private $values = [];

    private $idForm;

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
            echo '<input type="' . $value[0] . '" name="' . $value[2] . '" id="' . $value[2] . '" class="input"/> ';
            echo '</div>';
        }

        echo '<span id="error" class="error-message"></span>';

        echo $this->submit();
    }
}

$form = new Formulaire_2();

$form->addValues('name', 'Nom', 'text');
$form->addValues('phone', 'Téléphone', 'tel');
$form->addValues('postal', 'Code Postal', 'text');
$form->addValues('email', 'Adresse Mail', 'email');
$form->addValues('password', 'Mot de passe', 'password');
