INCLUDE globalVars.ink

{ pokemon_name == "": -> main | -> already_chose}

=== main ===
Which pokemon do you choose?
    + [Charmander]
        -> chosen("Charmander")
    + [Bulbasaur]
        -> chosen("Bulbasaur")
    + [Squirtle]
        -> chosen("Squirtle")
        
=== chosen(pokemon) ===
~pokemon_name = pokemon
You chose {pokemon}!
-> END

=== already_chose ===
You've already made your choice, it was {pokemon_name}
-> END 