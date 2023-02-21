INCLUDE globals.ink

Hello there, welcome to my shop. #speaker:Merchant #portrait:Merchant #layout: OnLeft

I really like what you have done with this place. I'm looking for some items for the costume party. #speaker:Player #portrait:Player #layout: OnRight
-> main

=== main === 

Sadly I don't have many items right now. Most costumes where already bought. It's going to be a great party this year. Do you still want to see my stock? #speaker:Merchant #portrait:Merchant #layout: OnLeft


    +[Yes, please]
        ~OpenShop = "true"
        -> Accept
    +[Not right now]
        ~OpenShop = "false"
        ->Deny
        
        
=== Accept ===
I would like to see what you have. #speaker:Player #portrait:Player #layout: OnRight
Perfect! You have never seen costumes like the ones i have to sell... #speaker:Merchant #portrait:Merchant #layout: OnLeft
 ~OpenShop = ""
->DONE


=== Deny ===

I think I'm going to look elsewere first. Thanks any way #speaker:Player #portrait:Player #layout: OnRight
I understand! Wish you luck finding what you are looking for. #speaker:Merchant #portrait:Merchant #layout: OnLeft
 ~OpenShop = ""
->DONE
