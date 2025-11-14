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
**Architecture:** Hybrid  
**General Goal:**   
**Environment:** Agricultural crop farms contain planting spaces and other agents  
**Perception:** SawAgent(), SawTomato(), IsOnRestArea(), IsHarvestTime(), HasTomatoes(), IsOnDepositArea()  
**Actions:** WaterPlants(), Harvest(), MoveForward(), Turn(degrees), TraversePlanters(), DepositTomatoes(), MoveForwards()  

#### Harvester
**Architecture:** Reactive  
**General Goal:** Harvest and deposit tomatoesz.  
**Environment:** Agricultural crop farms contain planting spaces and other agents  
**Perception:** SawAgent(), SawTomato(), IsOnRestArea(), IsHarvestTime(), HasTomatoes(), IsOnDepositArea()  
**Actions:** WaterPlants(), Harvest(), MoveForward(), Turn(degrees), TraversePlanters(), DepositTomatoes(), MoveForwards()  
```js
Layer 0: Stand down
Layer 1: Go to rest area
	IF(!IsOnRestArea())
		MoveTorwards(rest area)
Layer 2: Go to deposit tomatoes
	IF(HasTomatoes() && !IsOnDepositArea())
		MoveTowards(deposit area)
	IF(HasTomatoes() && IsOnDepositArea())
		DepositTomatoes()
Layer 3: Go harvest
	IF(IsHarvestTime())
		TraversePlanters()
Layer 4: Collect tomatoes
	IF(SawTomatoe())
		Harvest()
Layer 5: Avoid other agents
	IF (SawAgent())
		Turn(90)
		MoveFoward()
		Turn(-90)
```

### Work Plan


