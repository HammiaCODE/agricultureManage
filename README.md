# AgricultureManage

## Team Composition
- Santiago Alonzo Aguilar A01639373
- Hannia Escamilla Pérez A01639113
- Patricio Flores Reynoso A01645013
- Erick Sinhué Sánchez Martínez A01640018
- Cared Nicolle Castaños Manjarrez A01742620

## Challenge Description


### Agents 

#### General Manager

#### Finder

#### Planter
**Architecture:** Reactive  
**General Goal:** Replant tomato plants when they are cut.  
**Environment:** Agricultural crop farms contain planting spaces and other agents  
**Perception:** SawAgent(), HasSeeds(), IsOnRestArea()  
**Actions:** ReplenishSeeds(), WaterPlants(), PlantSeeds(), MoveForward(), Turn(degrees)  
```js
Layer 0: Stand Down
  IF(IsOnRestArea())
    IF(
    ReplenishSeeds()
Layer 1: Go to rest area
  IF(!IsOnRestArea())
    MoveForward(rest area)
Layer 2:
Layer 3:
Layer 4: Avoid other agents
  IF (SawAgent())
		Turn(90)
		MoveFoward()
		Turn(-90)
```


### Work Plan
