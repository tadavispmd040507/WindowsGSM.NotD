# WindowsGSM.NotD
🧩 Plugin for WindowsGSM to run a Night of the Dead Dedicated Server!!

## WindowsGSM Install

1. Download WindowsGSM from https://windowsgsm.com/
2. Create a Folder where you want the progame installed.
3. Extract the downloaded file.
4. Move the WindowsGSM.exe to the folder created in Step 2.
5. Run the WindowsGSM.exe

## Plugin Install

1. Download [latest](https://github.com/tadavispmd040507/WindowsGSM.NotD/releases/download/v1.0/WindowsGSM.NotD.zip) release.
2. You have 2 options...
    - Extract the file file downloaded and move the **ASKA.cs** folder to **WindowsGSM/plugins** then press the **Puzzle** icon in the bottom left corner and press the **[RELOAD PLUGINS]** or **Restart** WindowsGSM.
    - Press the **Puzzle** icon in the bottom left corner then press the **[IMPORT PLUGIN]** and select the downloaded zip file.

## Official Documentation

📋 N/A

## Steam Store Page

🎮 https://store.steampowered.com/app/1377380/Night_of_the_Dead/

## Dedicated Server SteamDB Page

🖥️ https://steamdb.info/app/1420710/info/

## Port Forwarding (REQUIRED)

- If you don't know how to do this then Google is your friend.
- 7777 UDP - Steam Game Port (Unless Port Was Changed)
- 27015 UDP - Steam Query Port (Unless Port Was Changed)

## Backup

- Recommended to use External Program or Script via Task Scheduler (WindowsGSM will backup the entire server minus the saves since they aren't located in the server install location)
- Recommended Files
    - WindowsGSM/servers/{Server ID}/serverfiles/ServerSettings.ini
    - WindowsGSM/servers/{Server ID}/serverfiles/Saved/SaveGames/{Save Name-Set in ServerSettings.ini}

## Parameters/Config Guide

[ServerSettings]\n
- ServerName=**{Is the Server Name Set In WindowsGSM}**
- Password=**{Not Rrquired}**
- MaxPlayers=**{Default is 16}**
```
[SystemSettings]
IngameAdminPassword=**{Required}**
DefaultMessageOfTheDay=**{Not Required}**
SaveName=**{Required}**
SaveIntervalHour=2 **{Options: 1 through 5 minutes(realtime)}**
```
[GameSettings]
Difficulty=Normal **{Options: Peaceful, Easy, Normal, Hard, Survival, Challenge, Legend, Custom}**

[GameSettings/General]
NoWave=0 **{Options: 0=disabled or 1=enabled}**
NoSpawnBuildingBlocker=0 **{Options: 0=disabled or 1=enabled / Activate Building Forbidden Area}**
NoZombieRespawn=0 **{Options: 0=disabled or 1=enabled / No Zombie Respawn}**
NaturalObjectRespawn=0 **{Options: 0=disabled or 1=enabled / Natural Objects Respawn}**
SyntheticObjectRespawn=0 **{Options: 0=disabled or 1=enabled / Synthetic Object Respawn}**
NoGeneratorTrouble=0 **{Options: 0=disabled or 1=enabled / No Generator Breakdown}**
NoDeathResearchDrop=0 **{Options: 0=disabled or 1=enabled / No Research Lost Upon Dying}**
DropItemsOnExit=0 **{Options: 0=disabled or 1=enabled / Drop Items on Exit}**
NoTeamKill=1 **{Options: 0=disabled or 1=enabled / No Teamkill}**
UsePlayerBuildingCorrode=0 **{Options: 0=disabled or 1=enabled / Building Decay After 5 Days of Inactivity}**
MaxWaveSpawnCount=200 **{Options: 50, 100, 200, 400, 800, 2000 / Limit Wave Zombie Amount}**

- ALL OPTIONS BELOW THIS WILL ONLY WORK WITH **CUSTOM** DIFFICULTY SELECTED
[GameSettings/Basic]
NormalZombieHealth=17 **{Options: 0 though 100 / Light Zombie HP}**
SpecialZombieHealth=17 **{Options: 0 though 100 / Heavy Zombie HP}**
GiantZombieHealth=17 **{Options: 0 though 100 / Giant Zombie HP}**
BossZombieHealth=17 **{Options: 0 though 100 / Unique Zombie HP}**
ZombieDamage=25 **{Options: 0 though 100 / Zombie Damage}**
ZombieMovementSpeed=37 **{Options: 0 though 100 / Zombie Movement Speed}**
WorldZombieSpawn=25 **{Options: 0 though 100 / World Zombie Spawn Amount}**
WaveZombieHealth=25 **{Options: 0 though 100 / Wave Zombie HP}**
WaveNormalZombieAmount=44 **{Options: 0 though 100 / Light Zombie Amount}**
WaveSpecialZombieAmount=18 **{Options: 0 though 100 / Heavy Zombie Amount}**
WaveGiantZombieAmount=21 **{Options: 0 though 100 / Giant Zombie Amount}**
AnimalHealth=17 **{Options: 0 though 100 / Animal HP}**
AnimalDamage=18 **{Options: 0 though 100 / Animal Attack Damage}**
WorldNormalZombieRespawnTime=120 **{Options: 30, 60, 120, 180, 240 / Light Zombie Respawn Time}**
WorldSpecialZombieRespawnTime=600 **{Options: 120, 300, 600, 900, 1200 / Heavy Zombie Respawn Time}**
WorldGiantZombieRespawnTime=600 **{Options: 120, 300, 600, 900, 1200 / Giant Zombie Respawn Time}**

[GameSettings/Advanced]
NoExperienceLoss=0 **{Options: 0=disabled or 1=enabled / No EXP Lost Upon Dying}**
NoDeathItemDrop=1 **{Options: 0=disabled or 1=enabled / No Items Drop Upon Dying}**
NoDeathEquipmentItemDrop=1 **{Options: 0=disabled or 1=enabled / No Equipment Drop Upon Dying}**
ResearchDataConsumption=50 **{Options: 0 though 100 / Research Data Consumption}**
FishSpeed=66 **{Options: 0 though 100 / Fish Speed}**
FishingGaugeDecrease=40 **{Options: 0 though 100 / Fish Power}**
SuperiorOrHigherEquipmentGainMultiplier=40 **{Options: 0 though 100 / High-Grade Equipment Drop Rate}**
BuildingHit=90 **{Options: 0 though 100 / Building HP}**
TrapDamage=66 **{Options: 0 though 100 / Trap Attack Damage}**
ResourcesReturnedAfterBuildingDestroyed=30 **{Options: 0 though 100 / Materials Return Rate After Building Destruction}**
AmountOfExperienceGained=1 **{Options: 1, 2, 3, 4, 5 / Gain EXP Amount}**
ResourceAcquisition=1 **{Options: 1, 2, 3 / Item Obtained Amount}**
InitialFoodAmount=10 **{Options: 0, 1, 2, 5, 10, 12, 15 / Initial Food Amount}**
NaturalObjectRespawnTime=720 **{Options: 240, 360, 480, 600, 720, 840, 960 / Natural Objects Respawn Time}**
SyntheticObjectRespawnTime=720 **{Options: 240, 360, 480, 600, 720, 840, 960 / Synthetic Objects Respawn Time}**
FarmResourceOutput=1.25 **{Options: 1, 1.25, 1.5, 1.75, 2 / Farm Resource Production Amount}**
MachineResourceOutput=1.25 **{Options: 0.5, 1, 1.5, 2, 2.5 / Machine Resource Production Amount}**
AnimalTrapTime=1 **{Options: 0.5, 1, 1.5, 2, 2.5 / Animal Trap Time}**
FarmResourceProductionTime=1 **{Options: 0.5, 1, 1.5 / Farm Resource Production Time}**
MachineResourceProductionTime=1 **{Options: 0.5, 1, 1.5 / Machine Resource Production Time}**
ElectricGeneration=1 **{Options: 0.5, 1, 1.5, 2, 2.5 / Power Generated}**
ElectricConsumption=1 **{Options: 0.5, 1, 1.5 / Power Consumption}**
ElectricOvercurrentLimit=1 **{Options: 0.5, 1, 1.5, 2, 2.5 / Power Limit}**
ElectricStandbyPower=1 **{Options: 0.5, 1, 1.5 / Standby Power}**

[GameSettings/Detail]
OneDayTime=240 **{Options: 60, 120, 180, 240, 300, 360, 420 / Times per Day}**
UnlockAllBuilding=0 **{Options: 0=disabled or 1=enabled / Unlock All Buildings}**
Hardcore=0 **{Options: 0=disabled or 1=enabled / Hardcore}**

## Features

- After Server Install use the **Edit Config** button to edit the ports, the plugin will add them to the command line.
- The plugin adds the following args to the command line **(?Name={Server Name}?listen -log -Port={Server Port} -QueryPort={Server Query Port} -CRASHREPORTS)**
- Creates the following directory on install **LF/Saved/Config**
- Copies the **ServerSettings.ini** over to **LF/Saved/Config** on every start and restart

## Key Notes

This game is in **Early Access**, WindowsGSM and this plugin is not responsible for any lost data that could occure to your server.

## WindowsGSM Support
[WindowsGSM](https://windowsgsm.com/discord)

## Donations

[Paypal](https://paypal.me/GDavis6899)