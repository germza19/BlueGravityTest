INCLUDE globals.ink

{NPC5_localGiveGold == "": -> main | -> AcceptGold}

{GiveGold == "": -> main | -> AcceptGold}
-> main
=== main === 
Hi! I hope you are excited about the town party as I am. #speaker:Ollie #portrait:NPC #layout: OnLeft

It's my first time in town, and I never heard of the celebrations before. I'm so excited! #speaker:Player #portrait:Player #layout: OnRight
Do you have a costume? The merchant may have some left if you need one. Do you need gold? #speaker:Ollie #portrait:NPC #layout: OnLeft

    +[Yes, please]
        ~GiveGold = "true"
        ~NPC5_localGiveGold = "true"
        -> AcceptGold
    +[Not right now]
    ~GiveGold = "false"
        ~NPC5_localGiveGold = "false"
        ->DenyGold
        
        
=== AcceptGold ===
Many thanks, I didn't come prepared for this. I'll pay you back as soon as I can. #speaker:Player #portrait:Player #layout: OnRight
Perfect! You have never seen costumes like the ones i have to sell... #speaker:Ollie #portrait:NPC #layout: OnLeft
~GiveGold = ""
~NPC5_localGiveGold = "true"
->DONE


=== DenyGold ===

I think I can buy something with the gold i currently have. Thanks, and enjoy the party! #speaker:Player #portrait:Player #layout: OnRight
I understand. If theres anything you need come any time. Goog luck!. #speaker:Ollie #portrait:NPC #layout: OnLeft
 ~GiveGold = ""
  ~NPC5_localGiveGold = ""
->DONE