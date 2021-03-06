﻿namespace KeepCommand.Tests
open System
open NUnit.Framework
open System

open KeepCommand.TomlParser

[<TestFixture>]
type Test() = 

    let example =  """
    [group1]
    key = true
    key2 = 1337
    title = "TOML Example"

    [  owner]
    name = "Tom Preston-Werner"
    organization = "GitHub"
    bio = "GitHub Cofounder & CEO\nLikes tater tots and beer."
    dob =  1979-05-27T07:32:00Z   # First class dates? Why not?

    [database  ]
    server= "192.168.1.1"
    ports       =  [ 8001,8001 , 8002]
    connection_max =5000
    enabled=true

    [servers]

      # You can indent as you please. Tabs or spaces. TOML don't care.
      [  servers  .alpha]
      ip = "10.0.0.1"
      dc = "eqdc10"

      [servers.  beta  ]
      ip = "10.0.0.2"
      dc = "eqdc10"

    [clients]
    data = [ ["gamma","delta"], [1, 2] ] # just an update to make sure parsers support it

    # Line breaks are OK when inside arrays
    hosts = [
      "alpha",
      "omega"
      ]
    """ 


    [<Test>]
    member x.TestCase() =
        for tomlValue in parse example do
          printfn "%A %A" tomlValue.Key tomlValue.Value
        Console.ReadLine() |> ignore

        Assert.IsTrue(true)

