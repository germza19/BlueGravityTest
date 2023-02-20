INCLUDE globals.ink

Hello there, welcome to my shop. #speaker:Merchant #portrait:Merchant #layout: OnLeft

I really like what you have done with this place. I'm looking for some items. #speaker:Player #portrait:Player #layout: OnRight
-> main

=== main === 

What items are you interested in? #speaker:Merchant #portrait:Merchant #layout: OnLeft


    +[Clothes]
        ~items = "Clothes"
        -> chosen
    +[Masks]
        ~items = "Masks"
        ->chosen
        
        
=== chosen ===
I would like to see what {items} you have. #speaker:Player #portrait:Player #layout: OnRight
Perfect! You have never seen {items} like the ones i have to sell... #speaker:Merchant #portrait:Merchant #layout: OnLeft

->END
