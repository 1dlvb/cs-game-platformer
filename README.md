# cs-game-platformer

## Платформа:
Windows

## Язык:
Русский

## Технологии:
C#, Godot

## Жанр:
Платформер, Приключения

## Настроение:
Спокойное

## Сеттинг:
Темный лес

## Сюжет:
В мире магии и приключений существует древний лес, который стал местом обитания различных существ и монстров. Главный герой, молодой лесной эльф по имени Эларион, обладает способностью прыгать на голову монстров, что позволяет ему уничтожать их.

Однажды злой колдун Ксаргон захватывает лес и порабощает его обитателей, превращая их в армию монстров. Эларион, обладая уникальной способностью и решимостью, отправляется на спасение своего дома.

Чтобы освободить лес от темных сил, Эларион должен пройти через разнообразные локации, преодолевая препятствия, решая головоломки и сражаясь с монстрами. Его способность прыгать на голову противников становится ключевой в битвах, позволяя ему уничтожать врагов и продвигаться вперед.

По пути Эларион встречает различных союзников, которые помогают ему в его квесте, а также находит улучшения для своих навыков и оружия. В конечной схватке с Ксаргоном, используя все свои силы и мастерство, Эларион должен одолеть колдуна и вернуть мир и гармонию в древний лес, став настоящим защитником своего дома.
Играй за веселого Гуся: обходи препятствия, собирай валюту и покупай крутые шапочки, чтобы играть было еще веселее.

## Игровой мир
В мире магии и приключений существует загадочный и древний лес, известный как Лес Теней. Этот лес обладает магическими свойствами, сплетая в себе тайны и опасности. Древние деревья простираются к небу, создавая густую зеленую кромку, под которой скрыты различные существа и монстры.

## Геймлей
- Уникальная способность: Эларион может прыгать на голову монстров, чтобы их уничтожить. Это становится ключевым элементом в битвах, где игрок должен правильно рассчитывать прыжки, чтобы победить противников.

- Разнообразные локации: Игрок пройдет через разнообразные локации Леса Теней, каждая из которых предлагает уникальные препятствия, головоломки и секреты. От темных пещер до ветреных вершин, игра предлагает разнообразные и красочные места для исследования.

- Сражения с монстрами: Во время своего путешествия Эларион сталкивается с различными монстрами, которые подчинены воле злого колдуна Ксаргона. Игроку предстоит использовать свою уникальную способность и тактические навыки, чтобы преодолеть врагов и продвигаться дальше.

- Финальная схватка: Кульминацией приключения становится финальная схватка с злым колдуном Ксаргоном. Используя все свои силы, мастерство и улучшения, Эларион должен преодолеть сложные испытания и одолеть колдуна, чтобы вернуть мир и гармонию в Лес Теней и стать настоящим героем.

Геймплей в игре предлагает игроку захватывающее путешествие, где динамичные бои, интересные уровни и увлекательный сюжет сливаются в единое целое, создавая захватывающий игровой опыт.
Игрок имеет одну жизнь на уровень.
Игрок должен дойти до босса и победить его за наименьше время.
## Объекты
Модель: Игрок, проходящий сквозь темный лес. Монстры, босс - то, что должен преодалеть герой. Монстры двигаются по заданному маршруту, а босс следует за игроком. Препятствия - различный рельеф базовой карты (в формате паркур). Очки - время, за которое игрок прошел уровень.

## Интерфейс:
Отрисовка игры и переданных игроком действий (бег, прыжки). Меню (Войти в игру, выйти из игры).

## Контроллер:
Игрок взаимодействует с персонажем посредством кнопок клавиатуры, перемещая его во время прохождения уровня (WASD). Если игрок прыгает на голову мостра - монстр погибает. Если монстр задевает игрока - игрок погибает. Уровень заканчивается, когда игрок прошел от пункта A до пункта B, где A - старт, B - финиш. Игра заканчивается после победы над боссом. На экран выводится суммарное время прохождения игры.  
