# FlappydaVinci
My first Unity game! I decided to follow a YouTube tutorial to get started. The Flappy Bird spin-off I created is a Leonardo da Vinci–inspired 2D animation game. I spent two weeks developing a feature that requires players to recognize and know da Vinci’s works in order to progress through the game (picking obstacle). What I have learned:

## Logic 
It became evidently clear that creating an object almost always requires a seperate "object manager". The object manager is the linking node between your object and other objects. Linking objects directly creates problems like loops and logic errors. It reminds me a lot of network segmentation.
<img width="1182" height="619" alt="image" src="https://github.com/user-attachments/assets/7d859183-fd09-4c12-81ba-a388b4f24347" />

## Animation
Animation was a bit difficult untill I finally learned about transitions and why you have to use them to navigate between scenes. I created two flapping wings on the machine, these wings flap on the spacebar trigger.
<p align="center">
<img width="1124" height="553" alt="image" src="https://github.com/user-attachments/assets/99cd221b-ac18-4f07-a9bb-e797981a5848" />
<img width="1278" height="651" alt="image" src="https://github.com/user-attachments/assets/90063617-0ba0-437f-9c3e-1e88ff278b1f" />
</p>

## Uniqueness
Creating the Renaissance Picking obstacle (DoYouKnowDavinci) was not an easy task, mainly because of timing. The Pillars would overlap with the picking obstacle as their speeds increased over time. At first I tried using the Coroutines to pause the Pillar Spawning function, but I got stuck mixing that with the spawnrate of pillars. Then I tried timing the objects to spawn in different incraments, not easy as their spawn rate changes over time. So I finally decided to destroy (Destroy(gameObject);) the Pillars a couple seconds before and after the picking obstacle. This is not as efficient as halting the spawn function with Corotines because I am unnecessarily spawning and destroying a game object, which is using too much computational power. But It works and I will improve it next time.
<img width="655" height="397" alt="image" src="https://github.com/user-attachments/assets/0f2600db-c80f-475a-96db-89c9f825cda7" />

