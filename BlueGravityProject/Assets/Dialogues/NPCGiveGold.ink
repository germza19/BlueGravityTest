INCLUDE globals.ink

{NPC1_localGiveGold == "": -> main | -> AcceptGold}

{GiveGold == "": -> main | -> AcceptGold}
-> main
=== main === 
Hi! I hope you are excited about the town party as I am. #speaker:Gabriel #portrait:NPC #layout: OnLeft

It's my first time in town, and I never heard of the celebrations before. I'm so excited! #speaker:Player #portrait:Player #layout: OnRight
Do you have a costume? The merchant may have some left if you need one. Do you need gold? #speaker:Gabriel #portrait:NPC #layout: OnLeft

    +[Yes, please]
        ~GiveGold = "true"
        ~NPC1_localGiveGold = "true"
        -> AcceptGold
    +[Not right now]
        ~GiveGold = "false"
        ~NPC1_localGiveGold = "false"
        ->DenyGold
        
        
=== AcceptGold ===
Many thanks, I didn't come prepared for this. I'll pay you back as soon as I can. #speaker:Player #portrait:Player #layout: OnRight
Perfect! You have never seen costumes like the ones i have to sell... #speaker:Gabriel #portrait:NPC #layout: OnLeft
~GiveGold = ""
~NPC1_localGiveGold = "true"
->DONE


=== DenyGold ===

I think I can buy something with the gold i currently have. Thanks, and enjoy the party! #speaker:Player #portrait:Player #layout: OnRight
I understand. If theres anything you need come any time. Goog luck!. #speaker:Gabriel #portrait:NPC #layout: OnLeft
 ~GiveGold = ""
  ~NPC1_localGiveGold = ""
->DONE