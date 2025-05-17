# labo-03-jumper-MilanRottiers

Inleiding
  In deze opdracht heb ik een machine learning agent ontwikkeld die leert om over obstakels te springen. Obstakels met een andere kleur negeert de agent en laat die met zichzelf colliden. Hiervoor maakt hij gebruik van een
  RayPerceptionSensor3D.

Opzetten
  Start een nieuw unity project.
  Installeer de MLagents package via: Window > Package Manager.
  Zet alle nodige objecten in de scene:
  •	De agent
  •	Een plane
  •	Een obstacle spawner (lege gameobject)
  •	Een muur achter de agent (deze wordt gebruikt om de obstacles waar de agent over springt te verwijderen)
  Maak een prefab voor de Obstacle en BonusObstacle gameobject. Dit zijn cubes met een kinematic Rigidbody en een box collider.
  De agent krijgt een niet-kinematic Rigidbody component. Hiervan worden de x en z as bij position gelockt alsook de x, y en z as van de rotatie.
  Decision requester en een behaviour parameters component. Deze zijn nodig om de agent te trainen en gebruik te maken van een getrainde .onnx “ai brain”. De instellingen van de behaviour parameters component zijn:
  •	0 continuous actions
  •	1 discrete branch
  •	Branch 0 size 2
  Ook krijgt de agent een RayPerceptionSensor3D component met 2 detectable tags: “Obstacle” en “BonusObstacle”. Deze staan op de obstacle en bonusObstacle prefabs. 
  De obstacle spawner krijgt een script dat elke 2 seconden ofwel een obstacle spawnt of een bonusObstacle.
  De obstacle en bonusobstacle krijgen een script dat ervoor zorgt dat de obstacle in 1 richting (richting de agent) blijft gaan.
  De muur achter de agent krijgt een script dat ervoor zorgt dat als de obstacle er tegen komt, de obstacle verwijderd wordt en de agent een +1 reward krijgt. Als de BonusObstacle hiertegen komt, krijgt de agent een -1 reward.
  Dit betekent dat de agent erover is gesprongen.
  De agent krijgt ook een script dat ervoor zorgt dat hij een +1 reward krijgt als hij collide met de bonusObstacle en een -1 reward als hij collide met de obstacle. Bij het colliden wordt ook de episode beeindigd. Als
  actionsOut.DiscreteActions[0] 1 is, zal de agent springen.

Trainen
  Open de anaconda navigator.
  start een environment.
  open een terminal in anaconda navigator
  navigeer naar het unity project.
  voer volgende command uit en start het project in unity om de training te starten:
    mlagents-learn config/CubeAgent.yaml --run-id=CubeAgent
  nu wordt de agent getraind.
  navigeer in een nieuwe terminal naar het unity project.
  voer volgende command uit en ga in een browser naar localhost:6006:
    tensorboard --logdir results
  hier worden de grafieken getoond van de training.
  copieer of verplaats na het voltooien van de training het .onnx bestand dat de training heeft aangemaakt naar de unity assets folder en sleep deze in BehaviourParameters.Models.
  nu wordt deze getrainde ai gebruikt om de taken uit te voeren.
