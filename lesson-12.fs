type TimeOfDay = { hours: int; minutes: int; f: string }

let transform (x: TimeOfDay) = 
    if x.f = "PM" then (x.hours + 12) * 60 + x.minutes
    else x.hours * 60 + x.minutes

let (.>.) x y = (transform x) > (transform y)
