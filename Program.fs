open Chiron

type Feature =
    | ElectricWindows
    | PowerSteering
    | AutomaticWipers
    | CruiseControl
    | Autopilot

    static member ToJson(feature: Feature) =
        match feature with
        | ElectricWindows -> ToJsonDefaults.ToJson "electric_windows"
        | _ -> ToJsonDefaults.ToJson "something_else"

type Transmission =
    | Automatic
    | CVT
    | Manual

    static member ToJson(transmission: Transmission) =
        match transmission with
        | Automatic -> ToJsonDefaults.ToJson "auto"
        | CVT -> ToJsonDefaults.ToJson "contvar"
        | Manual -> ToJsonDefaults.ToJson "manual"

type Car =
    { make: string
      model: string
      colour: string
      bhp: int
      features: Feature list
      transmission: Transmission }

    static member ToJson(car: Car) =
        json {
            do! Json.write "manufacturer" car.make
            do! Json.write "model" car.model
            do! Json.write "color" car.colour
            do! Json.write "power" car.bhp
            do! Json.write "options" car.features
            do! Json.write "transmission" car.transmission
        }

let car =
    { make = "Ford"
      model = "Focus"
      colour = "Red"
      bhp = 102
      features = [ AutomaticWipers; ElectricWindows ]
      transmission = Manual }

printfn "%s" ((Json.serialize >> Json.format) car)
