# AgricultureManage

## Team Composition
- Santiago Alonzo Aguilar A01639373
- Hannia Escamilla Pérez A01639113
- Patricio Flores Reynoso A01645013
- Erick Sinhué Sánchez Martínez A01640018
- Cared Nicolle Castaños Manjarrez A01742620

## Challenge Description
"According to the United Nations Food and Agriculture Organization (FAO), between 20% and 40% of global production is lost each year due to diseases, pests, and labor scarcity"
The challenge is to create a functioning 3D simulation of a greenhouse implementing a multi-agent system capable of doing actions like inspecting, harvesting and removing diseased plants.

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
