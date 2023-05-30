# Dungeon Master

Dungeon Master - это игра на движке Unity, созданная в качестве проекта по предмету Технологии разработки программных продуктов в РТУ МИРЭА<br><br>
Авторы проекта:<br>
Слесаренко Егор https://github.com/Eg0r4ik77<br>
Мазанов Алексей https://github.com/soumirel<br>
Юсипов Евгений https://github.com/AstroKettle<br>

 Жанр: Tower Defense <br>
 Режим: Однопользовательская игра <br>
 Платформы: Windows, Linux <br>

## Общее
Цель игры - как можно дольше уничтожать волны врагов, возводя оборонительные сооружения, чтобы не дать пересечь конец поля.

## Гайд
При старте игры перед игроком располагается клеточное игровое поле размером 5x10. В левом верхнем углу отображается текущее количество момент. Также сверху располагается таймер, фиксирующий время, пройденное с начала игрового процесса. Это время и будет учитываться при формировании рекорд по продолжительности игры после поражения.

<p align="center"><img align="center" src="https://github.com/soumirel/dungeon-master-unity-game-public/assets/91089172/ce4d7486-ead9-4a17-b37b-842a159eb961" alt="drawing" style="width:600px; height:300px;"/></p>

При нажатии на свободную клетку появляется интерактивная панель, позволяющая выбрать постройку для установки за определенную сумму монет в нажатую клетку. Постройкой может являться башня или линза. Башня отвечает за выпуск снарядов во врагов. О роли линзы будет рассказано позже.
<p align="center"><img align="center" src="https://github.com/soumirel/dungeon-master-unity-game-public/assets/91089172/3a8a4000-0c3c-41fa-8821-e7685bf411fb" alt="drawing" style="width:600px; height:300px;"/></p>


Башни различаются скоростью выстрела и скоростью полета снаряда, а также наносимым по врагам уроном.
Каждая башня имеет одну из базовых стихий:
- Огонь
- Вода
- Земля
- Ветер


Построенная башня начнет пускать снаряды вдоль линии, по которой идут враги.
<p align="center"><img align="center" src="https://github.com/soumirel/dungeon-master-unity-game-public/assets/91089172/451dae64-3ed1-4e6a-97a7-b2b1c55424ea" alt="drawing" style="width:600px;"/></p>


Стихию выпущенного из башни снаряда можно преобразовать, выставив перед башней линзу с другой стихией.
<p align="center"><img align="center" src=https://github.com/soumirel/dungeon-master-unity-game-public/assets/91089172/98b9c89a-9860-49e2-8adf-cd874ec0f6c9" alt="drawing" style="width:600px;"/></p>

Снаряд, прошедший через линзу, имеющую другую стихию, может сменить свою стихию на одну из следующих:
- Лава
- Пар
- Жар
- Лед
- Дерево
- Пыль

Каждую постройку можно удалить, вернув при этом часть монет, ранее затраченных на постройку.

<p align="center"><img align="center" src="https://github.com/soumirel/dungeon-master-unity-game-public/assets/91089172/0448b231-4fee-475f-9ef9-f544f87b1415" alt="drawing" style="width:600px; height:300px;"/></p>


Комбинируйте стихии башен и линз, укрепляйте линии и уничтожайте врагов, ставьте новые рекорды!

<p align="center"><img align="center" src="https://github.com/soumirel/dungeon-master-unity-game-public/assets/91089172/434d1937-3719-45e4-a1fc-e959ef9e2e77" alt="drawing" style="width:600px; height:300px;"/></p>


## Использованные ассеты

### Sprites
- ***Free - Pixel Art Asset Pack - Top down RPG - 16x16 Dungeon Crawler Sprites***
https://anokolisa.itch.io/dungeon-crawler-pixel-art-asset-pack

- ***Admurin's Skill Icons A Free Skills***
https://admurin.itch.io/admurins-skill-icons-a

- ***Loreon Knight character***
https://sanctumpixel.itch.io/loreon-knight-character

- ***Viking Axe Pixel Art Character***
https://sanctumpixel.itch.io/viking-axe-pixel-art-character

- ***Imp & Axe Demon Pixel Art Character***
https://sanctumpixel.itch.io/imp-axe-demon-pixel-art-character

- ***Sword Skeleton Pixel Art Character***
https://sanctumpixel.itch.io/sword-skeleton-pixel-art-character

- ***Fire Spell Effect 01***
https://pimen.itch.io/fire-spell

- ***Water Spell Effect 02***
https://pimen.itch.io/water-spell-effect-02

- ***Wind Spell Effect 01***
https://pimen.itch.io/wind

- Earth Spell Effect 01
https://pimen.itch.io/earth-spell-effect-01

- ***Smoke Effect 01***
https://pimen.itch.io/smoke-vfx-1

- ***Ice Effect 01***
https://pimen.itch.io/ice-spell-effect-01

- ***Wood Spell Effect***
https://pimen.itch.io/wood-spell-effect

- ***Pixel Art GUI Elements***
https://mounirtohami.itch.io/pixel-art-gui-elements

- ***Trap pack***
https://foozlecc.itch.io/trap-pack

- ***Mini FX, Items & UI***
https://grafxkid.itch.io/mini-fx-items-ui

### Fonts
- ***Planes_ValMore***
https://medievalmore.itch.io/pixel-art-planes-pack

### Sounds
- Abstraction Ludum Dare 28 - Track 3, Abstraction Ludum Dare 28 - Track 7 http://abstractionmusic.bandcamp.com/
<br> 

## Использованные пакеты
### Text
- TextMeshPro
### 2D
- 2D Animation
- 2D Sprite
- 2D Tilemap Editor
