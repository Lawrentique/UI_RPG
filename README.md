# UI_RPG
Homework 3, EKA University

Extra tasks:

1. Attack/Shield mechanic, which has meaning (attack uses stamina, shield restores stamina)
2. Damage UI for a player and enemies
3. 3 Different Enemies
4. 3 Different weapons, which player can choose (each weapon is efficient against specific enemy)
5. 3 Different locations (each location scales health and damage of enemies)
6. Experience mechanic (after killing certain number of enemies player gets new level, healing some of his hp and becoming stronger(health, damage, stamina))
7. A lot of UI enhancements
8. Different audio effects for player attacks, shield protection, shield break and all enemies
9. Overall made it to feel like game and not a bunch of mechanics

OOP:

1. Inheritance - Player and all enemies inherit from Character class
2. Polymorphism - Each enemy overrides attack from Character class, because they have different logic
3. Encapsulation - Important fields are protected and may be used only if they inherit it from the higher class
4. Abstraction - Weapon uses abstract GetDamage function because they have different patterns of damaging enemies
5. I tried to make code as reusable and scalable as possible (it`s easy to add new enemies, weapons, locations), a lot of systems are shared, like damage, sounds, UI updates are implemented once and are used frequently
