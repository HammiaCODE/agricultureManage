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

#### CropSentry
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

# AgricultureManage – Work Plan

## Team Roles  
**Modeling (Blender)**  
- **Erick** – Robot models  
- **Cared** – Tomato plants  
- **Hannia** – Greenhouse and props  

**Unity Development**  
- **Patricio** – Scene setup, Harvester logic, UI, tomato states  
- **Santiago** – CropSentry logic, Manager agent, perception, integration  

---

## Week 3 – Modeling, Unity Setup, Agent Basics

### Blender Tasks (Erick, Cared, Hannia)  
- Model robots: Harvester, CropSentry, Manager  
- Model tomato plants: healthy and infected  
- Model greenhouse and planting rows  
- Add UV maps and basic textures  
- Export models as FBX for Unity  

**Deliverables:**  
- Blender files (.blend)  
- FBX files ready for Unity  

### Unity Scene Setup (Patricio, Santiago)  
- Import models into Unity  
- Build greenhouse layout  
- Add colliders and NavMesh  
- Create prefabs for robots, plants, and slots  
- Add basic camera movement  

**Deliverables:**  
- Prototype Unity scene  
- Prefabs ready for scripting  

### Agent Script Skeletons (Santiago, Patricio)  
- Create C# scripts for each agent  
- Add basic movement: MoveForward(), Turn()  
- Add perception triggers: SawPlant(), SawAgent(), etc.  

**Deliverables:**  
- Agents moving in test mode  
- Console shows perception logs  

---

## Week 4 – Agent Behaviors and Simulation Logic

### Harvester (Reactive – Patricio)  
- Move through planting rows  
- Detect and collect tomatoes  
- Go to deposit area  
- Drop off tomatoes  

**Goal:** Full harvest cycle working  

### CropSentry (Hybrid – Santiago)  
- Patrol greenhouse  
- Detect infected plants  
- Remove infected tomatoes  
- Avoid other agents  

**Goal:** Infected tomato removal working  

### General Manager (Deliberative – Santiago)  
- Use BDI logic (Belief, Desire, Intention)  
- Decide when to harvest  
- Track infection levels  
- Assign tasks to agents  

**Goal:** Manager makes smart decisions  

### Tomato State Machine (Patricio)  
- Define states: Healthy, Infected, Removed  
- Add random infection generator  
- Control harvest timing  

**Goal:** Tomato states change during simulation  

---

## Week 4–5 – Final Integration and Presentation

### Integration & Testing (Patricio, Santiago)  
- Fix movement and pathfinding bugs  
- Improve perception and performance  

**Goal:** Smooth simulation  

### UI & Metrics (Patricio)  
- Add HUD showing:  
  - Tomatoes collected  
  - Infected found and missed  
  - Manager decisions  
  - Current cycle  
- Add debug tools  

**Goal:** Clear and useful UI  

### Visual Polish (Erick, Hannia, Cared)  
- Improve lighting and materials  
- Clean up models  
- Make tomato states easy to see  

**Goal:** Professional look  

### Final Presentation (Whole Team)  
- Record demo video  
- Take screenshots  
- Make slides and documentation  

**Goal:** Final build and presentation ready  