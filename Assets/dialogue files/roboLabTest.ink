Hello there! #speaker:NPC1 #portait:npc_1_neutral
-> main

=== main ===
my name is Murder Suspect #npc_1_neutral

* [Generaal Kenobi]
no
    ->main
+[did you do it?]
    no I did not #portait:npc_1_emotion 
    -> main
+[Did someone else do it?]
    it was <color=\#FF0000> the guy with the  moustache </color>
    -> reply




=== last ===
Any more questions? #speaker:NPC1 #portait:npc_1_neutral

+[yes]
-> main
+[no]
good luck
-> END


=== reply ===
- <b>No</b> it wasn't #speaker:NPC2 #portait:npc_2_neutral

-> last
