Create Spawn & Target Locations

	- Create Empty GameObjects:
		- SpawnQuadratic 
		- SpawnCubic 
		- EndPoint 
		
	
	- Position them in your scene as needed.
	- Attach the EnemySpawner script to an empty GameObject (EnemySpawner) and assign:
		- SpawnQuadratic
		- SpawnCubic
		- EndPoint.
	
	- Make sure enemies are tagged as "Enemy".
	- Assign the UI elements (HPText, GameameOverUI) in PlayerHealth.


Enemy Movement via Lerp

	- Attach this script to an enemy prefab.
	- Assign PathPoints with either 3 points (quadratic) or 4 points (cubic).
	- Set UseCubicPath to true for cubic movement and false for quadratic.

Player HP System & UI

	- Attach this script to a UI Manager object.
	- Assign a Text object for HP display.
	- Assign a GameObject (Panel) for the Fail UI.
	
Kill Enemies Using Bullet Magnitude

	- Tag Enemies as "Enemy"
	- Projectile destroys enemy if within DetectionRadius.
	
Gold System

	- Attach to a UI manager object and assign a Text UI element.
	
Tower Upgrades

	- Attach this script to an Upgrade UI with buttons for each upgrade.

Homing Missiles

	- Create a Missile Prefab
		- Add a SpriteRenderer to display the missile.
		- Add a Collider2D (e.g., CircleCollider2D) and set it as Trigger.
		- Add a Rigidbody2D and set Body Type = Kinematic.
		
	- Attach the HomingMissile Script
		- Drag the script onto the missile prefab.
		
