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
**Architecture:** Deliberative  
```js
Beliefs
	bool isHarvestTime, timeToFindInfected;
	double RatioOfStandingPlants;
	Vector3 start, end; // start and end of asiggned area
	int tomatoesColected, infectedDetected, infectedNotDetected, plantSpaces;
Desires
	> Traverse plantation lines
	> Search for infected tomatoes
	> Remove infected tomatoes and 
	> Avoid obstacles/agents
Intentions
	> CURRENT_PLAN: Call to colect(assignedArea)
```

#### Finder
**Architecture:** Hybrid  
##### **Reactive**
**General Goal:** Search for and remove infected tomatoes and their adjacent ones to reduce harvested infected tomatos ratio.  
**Environment:** Agricultural crop farms contain planting spaces and other agents  
**Perception:** SawAgent(), SawInfectedTomato(), IsOnRestArea(), TimeToRemoveInfected()  
**Actions:** MoveForward(), MoveBackward(), Turn(degrees), TraversePlanters(), RemoveTomatoes(), MoveTorwards(area)  
```js
Layer 0: Stand down
Layer 1: Go to rest area
	IF(!IsOnRestArea())
		MoveTorwards(rest area)
Layer 2: Traverse crops
	IF(TimeToRemoveInfected())
		TraversePlanters()
Layer 3: Remove infected
	IF(SawInfectedTomato())
		MoveBackward()
		RemoveTomatoes()
		MoveForward()
		RemoveTomatoes()
		MoveForward()
		RemoveTomatoes()
Layer 5: Avoid other agents
	IF (SawAgent())
		Turn(90)
		MoveFoward()
		Turn(-90)
```

##### **Deliberative**
```js
Beliefs
	int removed;
	Vector3 restArea, start, end; // start and end of asiggned area
Desires
	> Traverse plantation lines
	> Search for infected tomatoes
	> Remove infected tomatoes and 
	> Avoid obstacles/agents
Intentions
	> CURRENT_PLAN: TraversePlanterLines
	> CURRENT_PLAN: SearchForInfectedTomatoes
```

#### Harvester
**Architecture:** Reactive  
**General Goal:** Harvest and deposit tomatoesz.  
**Environment:** Agricultural crop farms contain planting spaces and other agents  
**Perception:** SawAgent(), SawTomato(), IsOnRestArea(), IsHarvestTime(), HasTomatoes(), IsOnDepositArea()  
**Actions:** Harvest(), MoveForward(), Turn(degrees), TraversePlanters(), DepositTomatoes(), MoveTorwards(area)  
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


